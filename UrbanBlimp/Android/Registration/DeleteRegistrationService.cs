using System;
using System.Net;

namespace UrbanBlimp.Android
{
    public class DeleteRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string pushId, Action<bool> callback, Action<WebException> exceptionCallback)
        {
            //TODO: validate args
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "Delete";
            request.DoRequest(callback, exceptionCallback);
        }
    }
}