// EpochWorlds
// FlatFormComponent.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 23-12-2023
namespace Flatify
{
    public abstract class FlatFormComponent<T> : FlatComponentBase, IFormComponent, IDisposable
    {
        private bool _error;
        private bool _hasErrors;
        private bool _required;
        private bool _touched;
        private object _validation;
        private List<string> _validationErrors;

        /// <inheritdoc />
        public void Dispose()
        {
            // TODO release managed resources here
        }

        /// <inheritdoc />
        public bool Required { get => _required; set => _required = value; }

        /// <inheritdoc />
        public bool Error { get => _error; set => _error = value; }

        /// <inheritdoc />
        public bool HasErrors => _hasErrors;

        /// <summary>
        ///     This manages the state of having been "touched" by the user. A form control always starts out untouched but becomes
        ///     touched when the user performed input or the blur event was raised. The touched state is only relevant for inputs
        ///     that have no value (i.e. empty text fields). Being untouched will suppress RequiredError
        /// </summary>
        public bool Touched { get; protected set; }

        /// <inheritdoc />
        public object Validation { get => _validation; set => _validation = value; }

        /// <inheritdoc />
        public List<string> ValidationErrors { get => _validationErrors; set => _validationErrors = value; }

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