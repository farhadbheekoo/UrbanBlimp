using System;
using System.IO;
using System.Net;
using System.Threading;

namespace UrbanBlimp
{
   
    class AsyncRequest
    {
        public WebRequest Request;
        public Action<Exception> ExceptionCallback;
        public Action<Stream> ReadFromResponse;
        public Action<Stream> WriteToRequest;
        IAsyncResult requestAsyncResult;
        IAsyncResult responseAsyncResult;

        public void Execute()
        {
            if (WriteToRequest == null)
            {
                DoRequest();
            }
            else
            {
                requestAsyncResult = Request.BeginGetRequestStream(x => WriteToRequestCallback(), null);
                ThreadPool.RegisterWaitForSingleObject(requestAsyncResult.AsyncWaitHandle, TimeOutCallback, null, Request.Timeout, true);
            }
        }

        void WriteToRequestCallback()
        {
            try
            {
                using (var requestStream = Request.GetRequestStream())
                {
                    WriteToRequest(requestStream);
                }
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
                            ReadFromResponse(responseStream);
                            return;
                        }
                    }
                }
                ReadFromResponse(null);
            }
            catch (WebException webException)
            {
                if (webException.IsNotFound())
                {
                    ReadFromResponse(null);
                    return;
                }
                string remoteError;
                if ( webException.TryReadRemoteError(out remoteError))
                {
                    var remoteException = new RemoteException(remoteError, webException);
                    ExceptionCallback(remoteException);
                }
                else
                {
                    ExceptionCallback(webException);   
                }
            }
            catch (Exception exception)
            {
                ExceptionCallback(exception);
            }
        }
    }
}