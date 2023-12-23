// EpochWorlds
// IForm.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
namespace Flatify
{
    /// <summary>
    ///     Interface for creating form components.
    /// </summary>
    public interface IForm
    {
        /// <summary>
        ///     Set if the form is valid.
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        ///     A list of the form errors.
        /// </summary>
        public string[] Errors { get; }

        /// <summary> The form's model. </summary>
        public object Model { get; set; }

        /// <summary>
        ///     Triggers a field change event for a form component.
        /// </summary>
        /// <param name="formControl">
        ///     The form control that changed.
        /// </param>
        /// <param name="newValue">
        ///     New value of the field.
        /// </param>
        public void FieldChanged(IFormComponent formControl, object newValue);

        /// <summary>
        ///     Adds a form component to the form.
        /// </summary>
        /// <param name="formControl"> Control to add. </param>
        internal void Add(IFormComponent formControl);

        /// <summary>
        ///     Removes a form component from the form.
        /// </summary>
        /// <param name="formControl"> Control to remove. </param>
        internal void Remove(IFormComponent formControl);

        /// <summary>
        ///     Updates a form component.
        /// </summary>
        /// <param name="formControl"> Control to update. </param>
        internal void Update(IFormComponent formControl);
    }
}