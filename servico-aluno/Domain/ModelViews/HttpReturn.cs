using System.Net;

namespace servico_aluno.Domain.ModelViews
{
    public class HttpReturn
    {

        public HttpReturn(string message, HttpStatusCode statusCode)
        {
            _message = message;
            _httpStatusCode = statusCode;
        }

        public string _message { get; private set; }
        public HttpStatusCode _httpStatusCode { get; private set; }
    }
}
