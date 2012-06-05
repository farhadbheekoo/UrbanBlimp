using System;
using System.Net;

namespace UrbanBlimp.Android
{
    public class AddRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string pushId, NewRegistration registration, Action callback, Action<WebException> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "PUT";
            var postData = NewRegistrationSerializer.Serialize(registration);
            request.DoRequest(postData, b => callback(), exceptionCallback);
        }

        public void Execute(string pushId, Action callback, Action<WebException> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "PUT";
            request.DoRequest(b => callback(), exceptionCallback);
        }
    }
}