using System;

namespace UrbanBlimp.Tag
{
    public class ModifyTagService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string tag, Tokens tokens, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + tag);
            request.Method = "POST";
            var postData = TokenSerializer.Serialize(tokens);
            request.DoRequest(postData, b => callback(), exceptionCallback);
        }
    }
}