using System;
using System.IO;
using System.Text;

namespace UrbanBlimp
{
	static class StreamExtensiosn
	{
		public static void WriteToStream(this Stream stream, Func<string> action)
		{
			var byteArray = Encoding.UTF8.GetBytes(action());
			stream.Write(byteArray, 0, byteArray.Length);
		}
	}
}