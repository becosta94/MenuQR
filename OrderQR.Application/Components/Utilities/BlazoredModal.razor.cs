using OrderQR.Application.Entities.Modal;
using OrderQR.Application.Interfaces;
using OrderQR.Application.Services;
using Microsoft.AspNetCore.Components;

namespace OrderQR.Application.Components.Utilities
{
    public partial class BlazoredModal : IDisposable
    {
        const string _defaultStyle = "blazored-modal";
        const string _defaultPosition = "blazored-modal-center";
        private bool? _componentDisableBackgroundCancel;
        private bool? _componentHideHeader;
        private bool? _componentHideCloseButton;
        private string _componentPosition;
        private string _componentStyle;
        private bool _isVisible;
        private string _title;
        private RenderFragment _content;
        private ModalParameters _modalParameters;
        [Inject]
        public IModalServices ModalService { get; set; }
        [Parameter]
        public bool? HideHeader { get; set; }
        [Parameter]
        public bool? HideCloseButton { get; set; }
        [Parameter]
        public bool? DisableBackgroundCancel { get; set; }
        [Parameter]
        public string Position { get; set; }
        [Parameter]
        public string Style { get; set; }

        protected override void OnInitialized()
        {
            ((ModalServices)ModalService).OnShow += ShowModal;
            ((ModalServices)ModalService).CloseModal += CloseModal;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private async void ShowModal(string title, RenderFragment content, ModalParameters modalParameters, ModalOptions options)
        {
            _title = title;
            _content = content;
            _modalParameters = modalParameters;
            _isVisible = true;
            SetModalOptions(options);
            await InvokeAsync(StateHasChanged);
        }
        private async void CloseModal()
        {
            _title = "";
            _content = null;
            _componentStyle = "";
            _isVisible = false;
            await InvokeAsync(StateHasChanged);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((ModalServices)ModalService).OnShow -= ShowModal;
                ((ModalServices)ModalService).CloseModal -= CloseModal;
            }
        }

        private void HandleBackgrounClick()
        {
            if (_componentDisableBackgroundCancel.Value) return;
            ModalService.Cancel();
        }

        private void SetModalOptions(ModalOptions options)
        {
            _componentHideHeader = HideHeader;
            if (options.HideHeader.HasValue)
                _componentHideHeader = options.HideHeader.Value;

            _componentHideCloseButton = HideCloseButton;
            if (options.HideCloseButton.HasValue)
                _componentHideCloseButton = options.HideCloseButton.Value;

            _componentDisableBackgroundCancel = DisableBackgroundCancel;
            if (options.DisableBackgroundCancel.HasValue)
                _componentDisableBackgroundCancel= options.DisableBackgroundCancel.Value;

            _componentPosition = string.IsNullOrWhiteSpace(options.Position) ? Position : options.Position;
            if (string.IsNullOrWhiteSpace(_componentPosition))
                _componentPosition = _defaultPosition;

            _componentStyle = string.IsNullOrWhiteSpace(options.Style) ? Style : options.Style;
            if (string.IsNullOrWhiteSpace(_componentStyle))
                _componentStyle = _defaultStyle;
        }
        public void SetTitle(string title)
        {
            _title = title;
            StateHasChanged();
        }
    }
}
