using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors;
public class MethodInterception : MethodInterceptionBaseAttribute
{
    //İşlemden önce
    protected virtual void OnBefore(IInvocation invocation) { }

    //İşlemden sonra
    protected virtual void OnAfter(IInvocation invocation) { }

    //Exception durumunda
    protected virtual void OnException(IInvocation invocation, System.Exception e) { }

    //Success durumunda
    protected virtual void OnSuccess(IInvocation invocation) { }

    public override void Intercept(IInvocation invocation)
    {
        var isSuccess = true;
        OnBefore(invocation);
        try
        {
            invocation.Proceed(); //invocation çalıştır.
        }
        catch (Exception e)
        {
            isSuccess = false;
            OnException(invocation, e);
            throw;
        }
        finally
        {
            if (isSuccess)
            {
                OnSuccess(invocation);
            }
        }
        OnAfter(invocation);
    }
}