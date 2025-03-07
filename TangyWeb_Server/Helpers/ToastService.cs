using Microsoft.JSInterop;

namespace TangyWeb_Server.Helpers;

public sealed class ToastService(IJSRuntime jsRuntime)
{
    public async Task ShowToast(string message, ToastType type = ToastType.Info)
    {
        await jsRuntime.InvokeVoidAsync("showToast", message, type.ToString().ToLower());
    }

    public async Task ShowSuccessToast(string message)
    {
        await ShowToast(message, ToastType.Success);
    }

    public async Task ShowErrorToast(string message)
    {
        await ShowToast(message, ToastType.Error);
    }

    public async Task ShowInfoToast(string message)
    {
        await ShowToast(message, ToastType.Info);
    }

    public async Task ShowWarningToast(string message)
    {
        await ShowToast(message, ToastType.Warning);
    }
}