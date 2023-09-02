namespace Shared.Api.Responses
{
    public class EntityResponse<T> : BaseResponse
        where T : class
    {
        public T Entity { get; set; }
    }
}
