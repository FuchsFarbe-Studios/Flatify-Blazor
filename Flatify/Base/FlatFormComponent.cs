// EpochWorlds
// FlatFormComponent.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 23-12-2023
namespace Flatify
{
    public abstract class FlatFormComponent<T> : FlatComponentBase, IFormComponent, IDisposable
    {
        private Boolean _error;
        private Boolean _hasErrors;
        private Boolean _required;
        private Boolean _touched;
        private Object _validation;
        private List<String> _validationErrors;

        /// <inheritdoc />
        public void Dispose()
        {
            // TODO release managed resources here
        }

        /// <inheritdoc />
        public Boolean Required { get => _required; set => _required = value; }

        /// <inheritdoc />
        public Boolean Error { get => _error; set => _error = value; }

        /// <inheritdoc />
        public Boolean HasErrors => _hasErrors;

        /// <summary>
        ///     This manages the state of having been "touched" by the user. A form control always starts out untouched but becomes
        ///     touched when the user performed input or the blur event was raised. The touched state is only relevant for inputs
        ///     that have no value (i.e. empty text fields). Being untouched will suppress RequiredError
        /// </summary>
        public Boolean Touched { get; protected set; }

        /// <inheritdoc />
        public Object Validation { get => _validation; set => _validation = value; }

        /// <inheritdoc />
        public List<String> ValidationErrors { get => _validationErrors; set => _validationErrors = value; }

        /// <inheritdoc />
        public Task Validate()
        {
            return null;
        }
        /// <inheritdoc />
        public Task ResetAsync()
        {
            return null;
        }
        /// <inheritdoc />
        public void ResetValidation()
        {
        }
        /// <inheritdoc />
        public void FormStateHasChanged()
        {
        }
    }
}