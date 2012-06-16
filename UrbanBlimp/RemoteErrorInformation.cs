using System;
using System.IO;
using System.Net;

namespace UrbanBlimp
{
    public static class RemoteErrorInformation
    {
        public static bool TryReadRemoteError(this Exception exception, out string error)
        {
            var webException = exception as WebException;
            if (webException  == null)
            {
                error = null;
                return false;
            }

            var webResponse = webException.Response;
            if (webResponse == null)
            {
                error = null;
                return false;
            }

            using (var responseStream = webResponse.GetResponseStream())
            {
                if (responseStream == null)
                {
                    error = null;
                    return false;
                }
                using (var streamReader = new StreamReader(responseStream))
                {
                    error = streamReader.ReadToEnd();
                    return true;
                }
            }
        }
    }
}