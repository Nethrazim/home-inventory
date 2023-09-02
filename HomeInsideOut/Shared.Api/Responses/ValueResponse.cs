namespace Shared.Api.Responses
{
    public class ValueResponse<T> : BaseResponse
        where T : struct
    {
        public T Value { get; set; }
    }
}
