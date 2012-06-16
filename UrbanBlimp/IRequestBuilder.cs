using System.Net;

namespace UrbanBlimp
{
    public interface IRequestBuilder
    {
        HttpWebRequest Build(string url);
    }
}