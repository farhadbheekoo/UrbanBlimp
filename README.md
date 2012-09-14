UrbanBlimp
==========

A dot net library to talk to Urban Airship http://urbanairship.com/

# License 

MIT License
http://www.opensource.org/licenses/mit-license.php

# Download

Download from here https://github.com/SimonCropp/UrbanBlimp/downloads

## .net4 or Mono

If you are running full .net (Mono or MS) on Windows, Mac or Linux then your want to use

`BackEnd\UrbanBlimp.dll`

For users of nuget here is the package (http://nuget.org/packages/urbanblimp)

## MonoTouch

If you are using MonoTouch (http://xamarin.com/monotouch) on IOS (http://www.apple.com/ios/) then you want to use 

`FrontEnd\IOS\UrbanBlimp.dll`

## Mono for Android

If you are using Mono for Android (http://xamarin.com/monoforandroid) on Android (http://www.android.com/) then you want to use 

`FrontEnd\Android\UrbanBlimp.dll`

# Sample Code

## IRequestBuilder

Define a way of build an IRequestBuilder. The IRequestBuilder implementation differs slightly between the "back end" and "front end" APIs. The reason for this is to make the difference between using the ApplicationMasterSecret and the ApplicationSecret explicit. 

### IOS Sample RequestBuilder

	using System.Net;
	using MonoTouch.CoreFoundation;
	using UrbanBlimp;

    public class IOSRequestBuilder : RequestBuilder
    {
        //Singleton for convenience. If use an IOC or prefer instance based this is not required
        public static IOSRequestBuilder Instance;

        static IOSRequestBuilder()
        {
            Instance = new IOSRequestBuilder();
        }


        public IOSRequestBuilder()
        {
            //NOTE: DO NOT USE YOUR MASTER CREDENTIALS HERE
            BuildApplicationCredentials = () => new NetworkCredential("ApplicationName", "ApplicationSecret");
            ConfigureRequest = request =>
                {
                    request.Proxy = CFNetwork.GetDefaultProxy();
                    //only a suggested timeout
                    request.Timeout = 30000;
                };
        }
    }

### Android Sample RequestBuilder

TODO
    
### Server Sample RequestBuilder

    using System.Net;
    using UrbanBlimp;

    public class ServerRequestBuilder : RequestBuilder
    {
        //Singleton for convenience. If use an IOC or prefer instance based this is not required
        public static ServerRequestBuilder Instance;

        static ServerRequestBuilder()
        {
            Instance = new ServerRequestBuilder();
        }


        public ServerRequestBuilder()
        {
            //NOTE: Be careful about managing your master secret. Consider reading it from an encrypted setting on the server
            BuildApplicationMasterCredentials = () => new NetworkCredential("ApplicationName", "ApplicationMasterSecret");
            ConfigureRequest = request =>
            {
                //TODO: configure proxy if necessary
                //request.Proxy = XXX

                //only a suggested timeout
                request.Timeout = 30000;
            };
        }

    }
    
## Exception Callback

All service calls take a callback of Action{Exception} as the final parameter. This will be called if a Exception occurs during communication with UrbanAirship. For my samples I am just stubbing out the callback using 

    public class ExceptionHandler
    {
        public static void Handle(Exception obj)
        {
            //Handle exceptions here 
        }
    }
    
## Apple IOS Samples 

### Using statement

    using UrbanBlimp.Apple;

### AddRegistrationService 

    public void Simple()
    {
        var service = new AddRegistrationService
                            {
                                RequestBuilder = ServerRequestBuilder.Instance
                            };
        var registration = new Registration
                                {
                                    Tags = new List<string> {"MyTag"},
                                    Alias = "MyAlias",
                                    Badge = 10
                                };
        service.Execute("AppleDeviceId", registration, () => Debug.WriteLine("Success"), ExceptionHandler.Handle);
    }
        
### FeedbackService

    public void Simple()
    {
        var feedbackService = new FeedbackService
                                    {
                                        RequestBuilder = ServerRequestBuilder.Instance
                                    };
        feedbackService.Execute(10.Days().Ago(), Callback, ExceptionHandler.Handle);
    }

    void Callback(List<DeviceFeedback> feedback)
    {
        foreach (var deviceFeedback in feedback)
        {
            Debug.WriteLine(deviceFeedback.Alias);
            Debug.WriteLine(deviceFeedback.DeviceToken);
            Debug.WriteLine(deviceFeedback.IsActive);
            Debug.WriteLine(deviceFeedback.MakedInactiveOn);
        }
    }
        
### GetRegistrationService

    public void Tags()
    {
        var service = new GetRegistrationService
                            {
                                RequestBuilder = ServerRequestBuilder.Instance
                            };
            service.Execute("ApplePushId",Callback,ExceptionHandler.Handle);
    }

    void Callback(Registration registration)
    {
        Debug.WriteLine(registration.Badge);
        Debug.WriteLine(registration.Alias);
        Debug.WriteLine(registration.QuietTime);
        Debug.WriteLine(registration.TimeZone);
        Debug.WriteLine(string.Join(" ", registration.Tags));
    }
        
### PushService

    public void Simple()
    {
        var service = new PushService
                            {
                                RequestBuilder = ServerRequestBuilder.Instance
                            };
        var notification = new PushNotification
                                {
                                    Tags = new List<string> {"MyTag"},
                                    ExcludeTokens = new List<string> {"TokenToExclude"},
                                    DeviceTokens = new List<string> {"AppleDeviceId"},
                                    Aliases = new List<string> {"MyAlias"},
                                    Payload = new PushPayload
                                                    {
                                                        Alert = "Alert 2",
                                                        Badge = Badge.Increment(),
                                                        Sound = "Sound1"
                                                    }
                                };
        service.Execute(notification,() => Debug.WriteLine("Success"),ExceptionHandler.Handle);
    }

        
## Android       

### Using statement

    using UrbanBlimp.Android;
        
### AddRegistrationService

    public void Simple()
    {
        var service = new AddRegistrationService
                            {
                                RequestBuilder = ServerRequestBuilder.Instance
                            };
        var registration = new NewRegistration
                                {
                                    Tags = new List<string> {"MyTag"},
                                    Alias = "MyAlias"
                                };
        service.Execute("AndroidPushId", registration,() => Debug.WriteLine("Success"),ExceptionHandler.Handle);
    }
        
### GetRegistrationService
        
    public void Simple()
    {
        var service = new AddRegistrationService
                            {
                                RequestBuilder = ServerRequestBuilder.Instance
                            };
        var registration = new NewRegistration
                                {
                                    Tags = new List<string> {"MyTag"},
                                    Alias = "MyAlias"
                                };
        service.Execute("AndroidPushId", registration,() => Debug.WriteLine("Success"),ExceptionHandler.Handle);
    }
    
### PushService
        
    public void Simple()
    {
        var service = new PushService
                            {
                                RequestBuilder = ServerRequestBuilder.Instance
                            };
        var notification = new PushNotification
                                {
                                    Tags = new List<string> {"MyTag"},
                                    PushIds = new List<string> {"AndroidPushId"},
                                    Payload = new PushPayload
                                                    {
                                                        Alert = "Alert 2"
                                                    }
                                };
        service.Execute(notification,() => Debug.WriteLine("Success"),ExceptionHandler.Handle);
    }        
         