using Microsoft.JSInterop;

namespace IndeterminateCheckboxBlazor;

public static class JsCallback
{
    private static readonly Dictionary<string, Action> _callbacks = new();

    internal static void RegisterCallback(string id, Action callback) => _callbacks[id] = callback;

    internal static void UnregisterCallback(string id) => _callbacks.Remove(id);

    [JSInvokable("CheckboxChangeRequestAsync")]
    public static Task CheckboxChangeRequestAsync(string id)
    {
        if (_callbacks.TryGetValue(id, out Action? a))
        {
            a();
        }

        return Task.CompletedTask;
    }

}