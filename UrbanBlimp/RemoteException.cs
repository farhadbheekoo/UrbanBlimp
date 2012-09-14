using System;
using System.Net;

namespace UrbanBlimp
{
    public class RemoteException:Exception
    {
        public RemoteException(string message, WebException innerException):base(message, innerException)
        {
            
        }
    }
}