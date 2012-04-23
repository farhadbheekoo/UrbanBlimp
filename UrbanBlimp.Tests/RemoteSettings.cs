using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

public static class RemoteSettings
{
    public static NetworkCredential ApplicationMasterCredential;
    public static NetworkCredential ApplicationCredential;
    public static string AppleDeviceId;
    public static string AndroidPushId;

    static RemoteSettings()
    {
        var filePath = Path.GetFullPath(Path.Combine(ExecutingLocation.Location, @"..\..\..\UrbanAirshipRemoteSettings.txt"));
        if (!File.Exists(filePath))
        {
            throw new Exception("Could not find config file " + filePath);
        }
        var lines = File.ReadAllLines(filePath);
        var applicationKey = GetValue(lines, "ApplicationKey");
        AppleDeviceId = GetValue(lines, "AppleDeviceId");
        AndroidPushId = GetValue(lines, "AndroidPushId");
        ApplicationMasterCredential = new NetworkCredential
                                          {
                                              UserName = applicationKey,
                                              Password = GetValue(lines, "ApplicationMasterSecret")
                                          };
        ApplicationCredential = new NetworkCredential
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