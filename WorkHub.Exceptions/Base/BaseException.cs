using System.Net;

namespace WorkHub.Exceptions.Base;
public abstract class BaseException(string message) : SystemException(message)
{
    public abstract HttpStatusCode GetStatusCode();
}