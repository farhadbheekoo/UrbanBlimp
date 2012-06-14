using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace UrbanBlimp
{
    class AsyncRequest : AsyncRequest<object>
    {
    }

    class AsyncRequest<T>
    {
        public WebRequest Request;
        public string PostData;
        public Action<Exception> ExceptionCallback;
        public T Response;
        public Func<Stream, T> ConvertStream;
        public Action<T> Callback;
        IAsyncResult requestAsyncResult;
        IAsyncResult responseAsyncResult;
        byte[] byteArray;

        public void Execute()
        {
            if (PostData == null)
            {
                DoRequest();
            }
            else
            {
                byteArray = Encoding.UTF8.GetBytes(PostData);
                Request.ContentType = "application/json";
                Request.ContentLength = byteArray.Length;
                requestAsyncResult = Request.BeginGetRequestStream(x => WriteToRequest(), null);
                ThreadPool.RegisterWaitForSingleObject(requestAsyncResult.AsyncWaitHandle, TimeOutCallback, null, Request.Timeout, true);
            }
        }

        void WriteToRequest()
        {
            try
            {
                using (var requestStream = Request.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }
                byteArray = null;
                DoRequest();
            }
            catch (Exception exception)
            {
                ExceptionCallback(exception);
            }
        }

        void DoRequest()
        {
            responseAsyncResult = Request.BeginGetResponse(x => DoRequestCallback(), null);
            ThreadPool.RegisterWaitForSingleObject(responseAsyncResult.AsyncWaitHandle, TimeOutCallback, null, Request.Timeout, true);
        }

        void TimeOutCallback(object state, bool timedOut)
        {
            if (timedOut)
            {
                Request.Abort();
            }
        }


        void DoRequestCallback()
        {
            try
            {
                using (var endGetResponse = Request.EndGetResponse(responseAsyncResult))
                {
                    if (ConvertStream != null)
                    {
                        using (var responseStream = endGetResponse.GetResponseStream())
                        {
                            Response = ConvertStream(responseStream);
                        }
                    }
                }
                Callback(Response);
            }
            catch (WebException webException)
            {
                if (webException.IsNotFound())
                {
                    Callback(Response);
                    return;
                }
                ExceptionCallback(webException);
            }
            catch (Exception exception)
            {
                ExceptionCallback(exception);
            }
        }
    }
}