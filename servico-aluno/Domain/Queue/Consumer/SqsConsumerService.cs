using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using servico_aluno.Domain.Entities;
using servico_aluno.Domain.Queue.Producer;
using servico_aluno.Infrastructure.Services;
using System.Diagnostics;

namespace servico_aluno.Domain.Queue.Consumer
{
    public class SqsConsumerService
    {
        private readonly AmazonSQSClient _sqsClient;
        private readonly IConfigurationRoot _configuration;
        private readonly string _queueUrl;
        private readonly StudentAverageService _studentAverageService;
        private readonly SqsProducerService _producerService;

        public SqsConsumerService()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            if (string.IsNullOrEmpty(_configuration["awsAccessKey"]) || string.IsNullOrEmpty(_configuration["awsSecretKey"]) || string.IsNullOrEmpty(_configuration["awsRegion"]))
            {
                throw new Exception("Missing AWS environment variables");
            }

            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(_configuration["awsAccessKey"], _configuration["awsSecretKey"]);
            var config = new AmazonSQSConfig { RegionEndpoint = RegionEndpoint.GetBySystemName(_configuration["awsRegion"]) };
            _sqsClient = new AmazonSQSClient(awsCredentials, config);
            _producerService = new SqsProducerService();
            //_avaliacaoService = new AvaliacaoService(_producerService);
        }

        public async Task StartListeningAsync()
        {
            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = _configuration["QueueUrlConsomer"],
                MaxNumberOfMessages = 10,
                WaitTimeSeconds = 20,
                VisibilityTimeout = 60
            };

            while (true)
            {
                var receiveMessageResponse = await _sqsClient.ReceiveMessageAsync(receiveMessageRequest);
                Debug.WriteLine("Buscando mensagens na fila...");

                if (receiveMessageResponse.Messages.Count == 0)
                {

                    continue;
                }

                foreach (var message in receiveMessageResponse.Messages)
                {
                    await _studentAverageService.ProcessarMensagemAsync(message.Body);
                    Debug.WriteLine($"Mensagem recebida: {message.Body}");



                    await DeleteMessageAsync(message);
                }
            }
        }

        private async Task DeleteMessageAsync(Message message)
        {
            var deleteMessageRequest = new DeleteMessageRequest
            {
                QueueUrl = _configuration["QueueUrlConsomer"],
                ReceiptHandle = message.ReceiptHandle
            };

            await _sqsClient.DeleteMessageAsync(deleteMessageRequest);
        }


    }
}
