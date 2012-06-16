using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace UrbanBlimp
{
   
    class AsyncRequest
    {
        public WebRequest Request;
        public string PostData;
        public Action<Exception> ExceptionCallback;
        public Action<Stream> Callback;
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
                    if (Request.Method == "get" || Request.Method == "post")
                    {
                        using (var responseStream = endGetResponse.GetResponseStream())
                        {
                            Callback(responseStream);
                        }
                    }
                }
                Callback(null);
            }
            catch (WebException webException)
            {
                if (webException.IsNotFound())
                {
                    Callback(null);
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