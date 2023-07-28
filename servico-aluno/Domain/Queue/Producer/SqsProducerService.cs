using Amazon.SQS.Model;
using Amazon.SQS;
using Amazon;

namespace servico_aluno.Domain.Queue.Producer
{
    public class SqsProducerService
    {

        private readonly AmazonSQSClient _sqsClient;
        private readonly string _queueUrl;
        private readonly IConfigurationRoot _configuration;

        public SqsProducerService()
        {
            _queueUrl = Environment.GetEnvironmentVariable("QueueUrlProducer");

            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("awsAccessKey")) || string.IsNullOrEmpty(Environment.GetEnvironmentVariable("awsSecretKey")) || string.IsNullOrEmpty(Environment.GetEnvironmentVariable("awsRegion")))
            {
                throw new Exception("Missing AWS environment variables");
            }

            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(Environment.GetEnvironmentVariable("awsAccessKey"), Environment.GetEnvironmentVariable("awsSecretKey"));
            var config = new AmazonSQSConfig { RegionEndpoint = RegionEndpoint.GetBySystemName(Environment.GetEnvironmentVariable("awsRegion")) };
            _sqsClient = new AmazonSQSClient(awsCredentials, config);
        }

        public async Task SendAsync(string message)
        {
            var sendRequest = new SendMessageRequest
            {
                QueueUrl = _queueUrl,
                MessageBody = message
            };

            await _sqsClient.SendMessageAsync(sendRequest);
        }

    }
}
