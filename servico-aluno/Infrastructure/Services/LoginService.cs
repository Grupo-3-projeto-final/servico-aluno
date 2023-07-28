using System.Text.Json;
using System.Text;
using servico_aluno.Util.Converter;

namespace servico_aluno.Infrastructure.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfigurationRoot _configuration;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public async Task<string> login()
        {
            try
            {
                dynamic loginRequest = new
                {
                    Email = "teste1@",
                    Password = "teste1"
                };

                HttpClient a = new HttpClient();

                var jsonContent = JsonSerializer.Serialize(loginRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var url = $"{_configuration["URLIdentityServer"]}/login";
                var response = await a.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = ConverterJson.ConverterJsonByKey(responseContent, "token");
                return result;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("Não foi possivel logar no serviço de login", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Aconteceu algum erro ao resgatar token", ex);
            }
        }

    }
}
