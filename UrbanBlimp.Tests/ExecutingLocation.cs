using System;
using System.IO;
using System.Reflection;

public static class ExecutingLocation
{
    public static string Location;

    static ExecutingLocation()
    {
        
        var platform = Environment.OSVersion.Platform;
        var executingAssembly = Assembly.GetExecutingAssembly();
        string matchText;
        if (platform == PlatformID.MacOSX || platform == PlatformID.Unix)
        {
            matchText = @"file://";
        }
        else
        {
            matchText = @"file:///";
        }
        var replace = executingAssembly.CodeBase.Replace(matchText, String.Empty);
        Location= Path.GetDirectoryName(replace);
    }
}