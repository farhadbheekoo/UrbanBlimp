using System.Net;

namespace UrbanBlimp
{
    public interface IRequestBuilder
    {
        WebRequest Build(string url);
    }
}