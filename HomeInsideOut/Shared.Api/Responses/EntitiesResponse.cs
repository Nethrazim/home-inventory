namespace Shared.Api.Responses
{
    public class EntitiesResponse<T> : BaseResponse
    {
        public List<T> Entities { get; set; }
    }
}
