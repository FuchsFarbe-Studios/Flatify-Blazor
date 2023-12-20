// EpochWorlds
// CssBuilder.cs
// FuchsFarbe Studios 2023
// Modified: 20-12-2023
// Copyright (c) 2011 - 2019 Ed Charbeneau
// License: MIT
// See https://github.com/EdCharbeneau

namespace Flatify.Utilities
{
    public struct CssBuilder
    {
        private String stringBuffer;

        /// <summary>
        ///     Creates a CssBuilder used to define conditional CSS classes used in a component. Call Build() to return the
        ///     completed CSS Classes as a string.
        /// </summary>
        /// <param name="value"> </param>
        public static CssBuilder Default(String value)
        {
            return new CssBuilder(value);
        }

        /// <summary>
        ///     Creates an Empty CssBuilder used to define conditional CSS classes used in a component. Call Build() to return the
        ///     completed CSS Classes as a string.
        /// </summary>
        public static CssBuilder Empty()
        {
            return new CssBuilder();
        }

        /// <summary>
        ///     Creates a CssBuilder used to define conditional CSS classes used in a component. Call Build() to return the
        ///     completed CSS Classes as a string.
        /// </summary>
        /// <param name="value"> </param>
        public CssBuilder(String value)
        {
            stringBuffer = value;
        }

        /// <summary>
        ///     Adds a raw string to the builder that will be concatenated with the next class or value added to the builder.
        /// </summary>
        /// <param name="value"> </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddValue(String value)
        {
            stringBuffer += value;
            return this;
        }

        /// <summary>
        ///     Adds a CSS Class to the builder with space separator.
        /// </summary>
        /// <param name="value"> CSS Class to add </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddClass(String value)
        {
            return AddValue(" " + value);
        }

        /// <summary>
        ///     Adds a conditional CSS Class to the builder with space separator.
        /// </summary>
        /// <param name="value">
        ///     CSS Class to conditionally add.
        /// </param>
        /// <param name="when">
        ///     Condition in which the CSS Class is added.
        /// </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddClass(String value, Boolean when = true)
        {
            return when
                       ? AddClass(value)
                       : this;
        }

        /// <summary>
        ///     Adds a conditional CSS Class to the builder with space separator.
        /// </summary>
        /// <param name="value">
        ///     CSS Class to conditionally add.
        /// </param>
        /// <param name="when">
        ///     Nullable condition in which the CSS Class is added.
        /// </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddClass(String value, Boolean? when = true)
        {
            return when == true
                       ? AddClass(value)
                       : this;
        }

        /// <summary>
        ///     Adds a conditional CSS Class to the builder with space separator.
        /// </summary>
        /// <param name="value">
        ///     CSS Class to conditionally add.
        /// </param>
        /// <param name="when">
        ///     Condition in which the CSS Class is added.
        /// </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddClass(String value, Func<Boolean> when = null)
        {
            return AddClass(value, when != null && when());
        }

        /// <summary>
        ///     Adds a conditional CSS Class to the builder with space separator.
        /// </summary>
        /// <param name="value">
        ///     Function that returns a CSS Class to conditionally add.
        /// </param>
        /// <param name="when">
        ///     Condition in which the CSS Class is added.
        /// </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddClass(Func<String> value, Boolean when = true)
        {
            return when
                       ? AddClass(value())
                       : this;
        }

        /// <summary>
        ///     Adds a conditional CSS Class to the builder with space separator.
        /// </summary>
        /// <param name="value">
        ///     Function that returns a CSS Class to conditionally add.
        /// </param>
        /// <param name="when">
        ///     Condition in which the CSS Class is added.
        /// </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddClass(Func<String> value, Func<Boolean> when = null)
        {
            return AddClass(value, when != null && when());
        }

        /// <summary>
        ///     Adds a conditional nested CssBuilder to the builder with space separator.
        /// </summary>
        /// <param name="builder">
        ///     CSS Class to conditionally add.
        /// </param>
        /// <param name="when">
        ///     Condition in which the CSS Class is added.
        /// </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddClass(CssBuilder builder, Boolean when = true)
        {
            return when
                       ? AddClass(builder.Build())
                       : this;
        }

        /// <summary>
        ///     Adds a conditional CSS Class to the builder with space separator.
        /// </summary>
        /// <param name="builder">
        ///     CSS Class to conditionally add.
        /// </param>
        /// <param name="when">
        ///     Condition in which the CSS Class is added.
        /// </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddClass(CssBuilder builder, Func<Boolean> when = null)
        {
            return AddClass(builder, when != null && when());
        }

        /// <summary>
        ///     Adds a conditional CSS Class when it exists in a dictionary to the builder with space separator. Null safe
        ///     operation.
        /// </summary>
        /// <param name="additionalAttributes">
        ///     Additional Attribute splat parameters
        /// </param>
        /// <returns> CssBuilder </returns>
        public CssBuilder AddClassFromAttributes(IReadOnlyDictionary<String, Object> additionalAttributes)
        {
            return additionalAttributes == null
                       ? this
                       : additionalAttributes.TryGetValue("class", out var c)
                           ? AddClass(c.ToString())
                           : this;
        }

        /// <summary>
        ///     Finalize the completed CSS Classes as a string.
        /// </summary>
        /// <returns> string </returns>
        public String Build()
        {
            // String buffer finalization code
            return stringBuffer != null
                       ? stringBuffer.Trim()
                       : string.Empty;
        }

        // ToString should only and always call Build to finalize the rendered string.
        public override String ToString()
        {
            return Build();
        }
    }
}