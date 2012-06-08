using System;
using System.Threading;

public class AsyncTestHelper<T>
{
    public ManualResetEvent allDone = new ManualResetEvent(false);

    public Action<Exception> HandleException;
    public Action<T> Callback;
    public T Response;
    Exception exception;

    public AsyncTestHelper()
    {
        HandleException = exception =>
            {
                this.exception = exception;
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
        if (exception != null)
        {
            throw exception;
        }
    }
}

public class AsyncTestHelper
{
    public ManualResetEvent allDone = new ManualResetEvent(false);

    public Action<Exception> HandleException;
    public Action Callback;
    Exception exception;

    public AsyncTestHelper()
    {
        HandleException = exception =>
        {
            allDone.Set();
            this.exception = exception;
        };
        Callback = () => allDone.Set();
    }

    public void Wait()
    {
        allDone.WaitOne();
        if (exception != null)
        {
            throw exception;
        }
    }
}