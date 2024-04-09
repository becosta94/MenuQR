using MenuQR.Application.Entities.Modal;
using MenuQR.Application.Interfaces;
using Microsoft.AspNetCore.Components;


namespace MenuQR.Application.Services
{
    public class ModalServices : IModalServices
    {
        public event Action<ModalResult> OnClose;
        internal event Action CloseModal;
        public event Action<string, RenderFragment, ModalParameters, ModalOptions> OnShow;
        private Type _modalType;

        public void Cancel()
        {
            CloseModal?.Invoke();
            OnClose?.Invoke(ModalResult.Cancel(_modalType));
        }

        public void Close(ModalResult modalResult)
        {
            modalResult.ModalType = _modalType;
            CloseModal?.Invoke();
            OnClose?.Invoke(modalResult);
        }

        public void Show<T>(string title, ModalParameters modalParameters) where T : ComponentBase
        {
            Show<T>(title, modalParameters, new ModalOptions());
        }

        public void Show<T>(string title, ModalParameters modalParameters = null, ModalOptions options = null) where T : ComponentBase
        {
            Show(typeof(T), title, modalParameters, options);
        }

        public void Show(Type contentComponent, string title, ModalParameters modalParameters, ModalOptions options)
        {
            if(!typeof(ComponentBase).IsAssignableFrom(contentComponent))
            {
                throw new ArgumentException("Must be a Blazor Component");
            }
            var content = new RenderFragment(x => { x.OpenComponent(1, contentComponent); x.CloseComponent(); });
            _modalType = contentComponent;
            OnShow?.Invoke(title, content, modalParameters, options);
        }
    }
}
