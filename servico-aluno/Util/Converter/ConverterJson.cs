using System.Text.Json;

namespace servico_aluno.Util.Converter
{
    public static class ConverterJson
    {
        public static string ConverterJsonByKey(string json, string key)
        {
            using var document = JsonDocument.Parse(json);
            if (document.RootElement.TryGetProperty(key, out var tokenElement))
            {
                return tokenElement.GetString();
            }
            else
            {
                throw new InvalidOperationException("O campo 'token' não foi encontrado na resposta da API.");
            }
        }
    }
}
