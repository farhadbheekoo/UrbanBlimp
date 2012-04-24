UrbanBlimp
==========

A dot net library to talk to Urban Airship http://urbanairship.com/

# Download

Download from here https://github.com/SimonCropp/UrbanBlimp/downloads

## .net4 or Mono

If you are running full .net (Mono or MS) on Windows, Mac or Linux then your want to use

`BackEnd\UrbanBlimp.dll`

## MonoTouch

If you are using MonoTouch (http://xamarin.com/monotouch) on IOS (http://www.apple.com/ios/) then you want to use 

`FrontEnd\IOS\UrbanBlimp.dll`

## Mono for Android

If you are using Mono for Android (http://xamarin.com/monoforandroid) on Android (http://www.android.com/) then you want to use 

`FrontEnd\Android\UrbanBlimp.dll`

# Sample Code

## IRequestBuilder

Define a way of build an IRequestBuilder. This will be re-used on all samples

    using UrbanBlimp;
    public static class CustomRequestBuilder
    {
        public static IRequestBuilder GetRequestBuilder()
        {
            return new RequestBuilder
                       {
                           NetworkCredential = new NetworkCredential
                                                   {
                                                       //TODO: use your Urban Airship settings here
                                                       UserName = "AirshipApplicationKey",
                                                       Password = "AirshipSecret"
                                                   }
                       };
        }
    }
    
## Apple IOS Samples 

### AddRegistrationService 

        var service = new AddRegistrationService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        var registration = new Registration
                               {
                                   Tags = new List<string> {"MyTag"},
                                   Alias = "MyAlias",
                                   Badge = 10
                               };
        service.Execute("AppleDeviceId", registration);
        
### FeedbackService

        var feedbackService = new FeedbackService
                                  {
                                      RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                                  };
        var feedback = feedbackService.Execute(10.Days().Ago());
        foreach (var deviceFeedback in feedback)
        {
            Debug.WriteLine(deviceFeedback.Alias);
            Debug.WriteLine(deviceFeedback.DeviceToken);
            Debug.WriteLine(deviceFeedback.IsActive);
            Debug.WriteLine(deviceFeedback.MakedInactiveOn);
        }
        
### GetRegistrationService

        var service = new GetRegistrationService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        var registration = service.Execute("ApplePushId");
        Debug.WriteLine(registration.Badge);
        Debug.WriteLine(registration.Alias);
        Debug.WriteLine(registration.QuietTime);
        Debug.WriteLine(registration.TimeZone);
        Debug.WriteLine(string.Join(" ", registration.Tags));
        
### PushService

        var service = new PushService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
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
                                                     Badge = "2",
                                                     Sound = "Sound1"
                                                 }
                               };
        service.Execute(notification);
        
## Android       

### Using statement

    using UrbanBlimp.Android;
        
### AddRegistrationService

        var service = new AddRegistrationService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        var registration = new NewRegistration
                               {
                                   Tags = new List<string> {"MyTag"},
                                   Alias = "MyAlias"
                               };
        service.Execute("AndroidPushId", registration);
        
### GetRegistrationService
        
        var service = new GetRegistrationService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        var registration = service.Execute("AndroidPushId");
        Debug.WriteLine(registration.Active);
        Debug.WriteLine(registration.Alias);
        Debug.WriteLine(registration.Created);
        Debug.WriteLine(string.Join(" ", registration.Tags));
        
### PushService
        
        var service = new PushService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
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
        service.Execute(notification);
        
        
        
        
        
        
        