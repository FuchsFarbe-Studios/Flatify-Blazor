// EpochWorlds
// IFormComponent.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
namespace Flatify
{
    /// <summary>
    ///     A contract for a form input component that can be validated.
    /// </summary>
    public interface IFormComponent
    {
        /// <summary>
        ///     Determines if the field is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        ///     Set if the field encountered an error.
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        ///     Set if the form component fails multiple validations.
        /// </summary>
        public bool HasErrors { get; }

        /// <summary>
        ///     Determines if the field has been modified.
        /// </summary>
        public bool Touched { get; }

        /// <summary> Validation object. </summary>
        public object Validation { get; set; }

        /// <summary>
        ///     List of validation errors.
        /// </summary>
        public List<string> ValidationErrors { get; set; }

        /// <summary> Validates a field. </summary>
        /// <returns>
        ///     <see cref="Task" />
        /// </returns>
        public Task Validate();

        /// <summary> Resets a field. </summary>
        /// <returns>
        ///     <see cref="Task" />
        /// </returns>
        public Task ResetAsync();

        /// <summary>
        ///     Resets the field validations.
        /// </summary>
        public void ResetValidation();

        /// <summary>
        ///     Fired when the field has been changed.
        /// </summary>
        public void FormStateHasChanged();
    }
}