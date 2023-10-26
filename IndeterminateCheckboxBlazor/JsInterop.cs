using Microsoft.JSInterop;

namespace IndeterminateCheckboxBlazor;

internal class JsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;
    
    public JsInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/IndeterminateCheckboxBlazor/checkbox.js").AsTask());
    }

    public async ValueTask SetValueAsync(string id, bool? value)
    {
        IJSObjectReference module = await moduleTask.Value;
        await module.InvokeVoidAsync("setValue", id, value);
    }

    public async ValueTask InitializeAsync(string id)
    {
        IJSObjectReference module = await moduleTask.Value;
        await module.InvokeVoidAsync("initialize", id);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            IJSObjectReference module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}