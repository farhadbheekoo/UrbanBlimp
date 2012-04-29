using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

public static class RemoteSettings
{
    public static NetworkCredential ApplicationMasterCredential
    {
        get
        {
            Init();
            return applicationMasterCredential;
        }
    }

    public static NetworkCredential ApplicationCredential
    {
        get
        {
            Init();
            return applicationCredential;
        }
    }
    public static string AppleDeviceId
    {
        get
        {
            Init();
            return appleDeviceId;
        }
    }
    public static string AndroidPushId
    {
        get
        {
            Init();
            return appleDeviceId;
        }
    }
    static NetworkCredential applicationMasterCredential;
    static string appleDeviceId;
    static string androidPushId;
    static NetworkCredential applicationCredential;
    static bool isInit;

    static void Init()
    {
        if (isInit)
        {
            return;
        }
        isInit = true;
        var filePath = Path.GetFullPath(Path.Combine(ExecutingLocation.Location, @"..\..\..\UrbanAirshipRemoteSettings.txt"));
        if (!File.Exists(filePath))
        {
            throw new Exception("Could not find config file " + filePath);
        }
        var lines = File.ReadAllLines(filePath);
        var applicationKey = GetValue(lines, "ApplicationKey");
        appleDeviceId = GetValue(lines, "AppleDeviceId");
        androidPushId = GetValue(lines, "AndroidPushId");
        applicationMasterCredential = new NetworkCredential
                                          {
                                              UserName = applicationKey,
                                              Password = GetValue(lines, "ApplicationMasterSecret")
                                          };
        applicationCredential = new NetworkCredential
                                    {
                                        UserName = applicationKey,
                                        Password = GetValue(lines, "ApplicationSecret")
                                    };
    }


    static string GetValue(IEnumerable<string> lines, string key)
    {
        var first = lines.First(x => x.StartsWith(key));

        if (first == null)
        {
            throw new Exception("Could not find " + key);
        }
        return first.Replace(key + " ", "");
    }
}