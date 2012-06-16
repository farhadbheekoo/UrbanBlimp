using System;
using System.Threading;

public class AsyncTestHelper<T>
{
    public ManualResetEvent allDone = new ManualResetEvent(false);

    public Action<Exception> HandleException;
    public Action<T> Callback;
    public T Response;
    public Exception Exception;

    public AsyncTestHelper()
    {
        HandleException = exception =>
            {
                Exception = exception;
                allDone.Set();
            };
        Callback = value =>
            {
                Response = value;
                allDone.Set();
            };
    }

    public void Wait()
    {
        allDone.WaitOne();
    }
}

public class AsyncTestHelper : AsyncTestHelper<object>
{
}