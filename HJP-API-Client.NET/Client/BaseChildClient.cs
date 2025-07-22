using Hjp.Api.Client.Internal;

namespace Hjp.Api.Client
{
    internal abstract class BaseChildClient
    {
        protected readonly ApiClientInternal apiClientInternal = default!;

        protected string signature = null!;
        internal string Signature
        {
            get { return this.signature; }
            set { this.signature = value; }
        }

        internal event Func<CancellationToken, Task>? OnBeforeMethodAsync;

        internal BaseChildClient(ApiClientInternal apiClientInternal, string signature)
        {
            this.apiClientInternal = apiClientInternal;
            this.signature = signature;
        }

        protected async Task InvokeOnBeforeMethodAsync(CancellationToken cancellationToken)
        {
            if (this.OnBeforeMethodAsync != null)
            {
                foreach (Func<CancellationToken, Task> handler in this.OnBeforeMethodAsync.GetInvocationList())
                {
                    await handler.Invoke(cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}