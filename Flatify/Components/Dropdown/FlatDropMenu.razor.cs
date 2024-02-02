using Flatify.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Flatify.Components
{
    public partial class FlatDropMenu
    {
        private bool _isMouseOver = false;
        private bool _isOpen;
        protected string Classname => new CssBuilder("mud-menu")
                                      .AddClass(Class)
                                      .Build();
        protected string ActivatorClassname => new CssBuilder("mud-menu-activator")
                                               .AddClass("mud-disabled", Disabled)
                                               .Build();

        /// <summary>
        ///     Place a MudButton, a MudIconButton or any other component capable of acting as an activator. This will override the
        ///     standard button and all parameters which concern it.
        /// </summary>
        [Parameter] public RenderFragment ActivatorContent { get; set; }

        /// <summary>
        ///     Specify the activation event when ActivatorContent is set
        /// </summary>
        [Parameter] public MouseEvent ActivationEvent { get; set; } = MouseEvent.LeftClick;

        /// <summary>
        ///     Fired when the menu IsOpen property changes.
        /// </summary>
        [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }

        /// <summary>
        ///     Gets a value indicating whether the menu is currently open or not.
        /// </summary>
        public bool IsOpen => _isOpen;

        /// <summary>
        ///     If true, menu will be disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        ///     If true, instead of positioning the menu at the left upper corner, position at the exact cursor location. This
        ///     makes sense for larger activators
        /// </summary>
        public bool PositionAtCursor { get; set; }

        /// <summary>
        ///     The menu items to be displayed in the menu.
        /// </summary>
        [Parameter] public RenderFragment MenuItems { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        /// <summary> Closes the menu. </summary>
        public void CloseMenu()
        {
            _isOpen = false;
            _isMouseOver = false;
            StateHasChanged();
            IsOpenChanged.InvokeAsync(_isOpen);
        }

        /// <summary> Opens the menu. </summary>
        /// <param name="args">
        ///     The arguments of the calling mouse event. If <see cref="PositionAtCursor" /> is true, the menu will be positioned
        ///     using the coordinates in this parameter.
        /// </param>
        public void OpenMenu(EventArgs args)
        {
            if (Disabled)
                return;

            _isOpen = true;
            StateHasChanged();
            IsOpenChanged.InvokeAsync(_isOpen);
        }

        public void ToggleMenu(MouseEventArgs args)
        {
            if (Disabled)
                return;
            if (ActivationEvent == MouseEvent.LeftClick && args.Button != 0 && !_isOpen)
                return;
            if (ActivationEvent == MouseEvent.RightClick && args.Button != 2 && !_isOpen)
                return;

            if (_isOpen)
                CloseMenu();
            else
                OpenMenu(args);
        }

        public void ToggleMenuTouch(TouchEventArgs args)
        {
            if (Disabled)
            {
                return;
            }

            if (_isOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu(args);
            }
        }

        /// <summary>
        ///     Implementation of IActivatable.Activate, toggles the menu.
        /// </summary>
        /// <param name="activator"> </param>
        /// <param name="args"> </param>
        public void Activate(object activator, MouseEventArgs args)
        {
            ToggleMenu(args);
        }

        public void MouseEnter(MouseEventArgs args)
        {
            _isMouseOver = true;

            if (ActivationEvent == MouseEvent.MouseOver)
            {
                OpenMenu(args);
            }
        }

        public async void MouseLeave()
        {
            _isMouseOver = false;

            await Task.Delay(100);

            if (ActivationEvent == MouseEvent.MouseOver && _isMouseOver == false)
            {
                CloseMenu();
            }
        }
    }
}