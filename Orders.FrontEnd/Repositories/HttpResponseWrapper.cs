using System.Net;

namespace Orders.FrontEnd.Repositories

{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var statuscode = HttpResponseMessage.StatusCode;
            if (statuscode == HttpStatusCode.NotFound)
            {
                return "recurso no encontrado.";
            }
            if (statuscode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            if (statuscode == HttpStatusCode.Unauthorized)
            {
                return "Tienes que estar logueado para ejecutar esta operacion";
            }
            if (statuscode == HttpStatusCode.Forbidden)
            {
                return "No tienes permiso para hacer esta operacion";
            }

            return "Ha ocurrido un error inexperado";
        }
    }
}