using Shared.Utils.HttpErrors;

namespace Shared.Utils.Helpers
{
    public static class ResponseHelper
    {
        public static void ReturnNotFound(string message)
        {
            throw new NotFoundException(message);
        }

        public static void ReturnBadRequest(string message)
        {
            throw new BadRequestException(message);
        }
    }
}
