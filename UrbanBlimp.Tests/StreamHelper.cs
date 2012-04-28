using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class StreamHelper
{
    
    public static MemoryStream GetStream(this string s)
    {
        var replace = s.Replace("'", @"""");
        return new MemoryStream(Encoding.Default.GetBytes(replace));
    }

    public static T ToObject<T>(this string s, Func<MemoryStream,T > action)
    {
   
        using (var stream = s.GetStream())
        {
            return action(stream);
        }
    }
    public static List<T> ToObject<T>(this string s, Func<MemoryStream,IEnumerable<  T> > action)
    {
        using (var stream = s.GetStream())
        {
            return action(stream).ToList();
        }
    }
}