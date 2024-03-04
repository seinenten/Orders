namespace Orders.FrontEnd.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseMessage> GetAsync<T>(string url);

        Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model);

        Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model)
    }
}
