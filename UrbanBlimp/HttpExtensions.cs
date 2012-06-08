using System;
using System.IO;
using System.Net;
using System.Text;

namespace UrbanBlimp
{
    static class HttpExtensions
    {
        public static void DoRequest(this WebRequest request, string postData, Action<bool> callback, Action<Exception> exceptionCallback)
        {
            DoRequest(request, postData, stream => true, callback, exceptionCallback);
        }

        public static void DoRequest<T>(this WebRequest request, string postData, Func<Stream, T> convertStream, Action<T> callback, Action<Exception> exceptionCallback)
        {
            //TODO: unit test to hit this try catch
            try
            {
                request.WriteToRequest(postData);
            }
            catch (Exception exception)
            {
                exceptionCallback(exception);
                return;
            }
            request.DoRequest(convertStream, callback, exceptionCallback);
        }

        static void WriteToRequest(this WebRequest request, string postData)
        {
            var byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(byteArray, 0, byteArray.Length);
            }
        }

        public static void DoRequest(this WebRequest webRequest, Action<bool> callback, Action<Exception> exceptionCallback)
        {
            webRequest.BeginGetResponse(ar => DoRequestCallback(ar, stream => true, callback, exceptionCallback), webRequest);
        }


        public static void DoRequest<T>(this WebRequest webRequest, Func<Stream, T> convertStream, Action<T> callback, Action<Exception> exceptionCallback)
        {
            webRequest.BeginGetResponse(ar => DoRequestCallback(ar, convertStream, callback, exceptionCallback), webRequest);
        }

        static void DoRequestCallback<T>(IAsyncResult asynResult, Func<Stream, T> convertStream, Action<T> callback, Action<Exception> exceptionCallback)
        {
            try
            {
                var request = (HttpWebRequest) asynResult.AsyncState;
                using (var endGetResponse = request.EndGetResponse(asynResult))
                using (var responseStream = endGetResponse.GetResponseStream())
                {
                    var result = convertStream(responseStream);
                    callback(result);
                }
            }
            catch (WebException webException)
            {
                if (webException.IsNotFound())
                {
                    //TODO: perhaps should be null??
                    callback(default(T));
                }
                exceptionCallback(webException);
            }
            catch (Exception exception)
            {
                exceptionCallback(exception);
            }
        }

        static bool IsNotFound(this WebException webException)
        {
            //TODO: unit test to hit this
            if (webException.Response == null)
            {
                return false;
            }
            var httpWebResponse = (HttpWebResponse)webException.Response;
            return httpWebResponse.StatusCode == HttpStatusCode.NotFound;
        }
    }
}