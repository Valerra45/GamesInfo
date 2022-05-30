using GamesInfo.Core.Exceptions;
using System.Net;

namespace GamesInfo.WebHost.Helpers
{
    public static class ExceptionsHelper
    {
        public static Dictionary<Type, HttpStatusCode> ExceptionsHttpStatusCodes
            => new()
            {
                [typeof(ValidationException)] = HttpStatusCode.UnprocessableEntity,
                [typeof(EntityNotFoundException)] = HttpStatusCode.NotFound
            };
    }
}
