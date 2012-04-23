using System;
using System.Diagnostics;
using NUnit.Framework;
using UrbanBlimp;

public class DateTimeExtensionsTests
{
    [Test]
    public void Foo()
    {
        var iso8601 = DateTime.Now.ToIso8601();
        Debug.WriteLine(iso8601);
    }
}