using System.IO;
using System.Text;

public static class StreamHelper
{
    
    public static MemoryStream GetStream(this string s)
    {
        var replace = s.Replace("'", @"""");
        return new MemoryStream(Encoding.Default.GetBytes(replace));
    }
}