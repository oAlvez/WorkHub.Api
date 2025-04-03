using System.Net;
using WorkHub.Exceptions.Base;

namespace WorkHub.Exceptions;
public class RequestException(string message) : BaseException(message)
{
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}