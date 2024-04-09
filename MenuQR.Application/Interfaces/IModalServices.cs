using MenuQR.Application.Entities.Modal;
using Microsoft.AspNetCore.Components;

namespace MenuQR.Application.Interfaces
{
    public interface IModalServices
    {
        event Action<ModalResult> OnClose;
        event Action<string, RenderFragment, ModalParameters, ModalOptions> OnShow;
        void Show<T>(string title, ModalParameters modalParameters) where T : ComponentBase;
        void Show<T>(string title, ModalParameters modalParameters = null, ModalOptions options = null) where T : ComponentBase;
        void Show(Type contentComponent, string title, ModalParameters modalParameters, ModalOptions options);
        void Close(ModalResult modalResult);
        void Cancel();
    }
}
