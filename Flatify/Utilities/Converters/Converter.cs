// EpochWorlds
// Converter.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Flatify.Utilities
{

    public class Converter<T, U>
    {
        public Func<T, U> SetFunc { get; set; }

        public Func<U, T> GetFunc { get; set; }

        /// <summary>
        ///     The culture info being used for decimal points, date and time format, etc.
        /// </summary>
        public CultureInfo Culture { get; set; } = Converters.DefaultCulture;

        public Action<String> OnError { get; set; }

        [MemberNotNullWhen(true, nameof(SetErrorMessage))]
        public Boolean SetError { get; set; }

        [MemberNotNullWhen(true, nameof(GetErrorMessage))]
        public Boolean GetError { get; set; }

        public String SetErrorMessage { get; set; }

        public String GetErrorMessage { get; set; }

        public U Set(T value)
        {
            SetError = false;
            SetErrorMessage = null;
            if (SetFunc == null)
                return default;

            try
            {
                return SetFunc(value);
            }
            catch (Exception e)
            {
                SetError = true;
                SetErrorMessage = $"Conversion from {typeof(T).Name} to {typeof(U).Name} failed: {e.Message}";
            }
            return default;
        }

        public T Get(U value)
        {
            GetError = false;
            GetErrorMessage = null;
            if (GetFunc == null)
                return default;

            try
            {
                return GetFunc(value);
            }
            catch (Exception e)
            {
                GetError = true;
                GetErrorMessage = $"Conversion from {typeof(U).Name} to {typeof(T).Name} failed: {e.Message}";
            }
            return default;
        }

        protected void UpdateSetError(String msg)
        {
            SetError = true;
            SetErrorMessage = msg;
            OnError?.Invoke(msg);
        }

        protected void UpdateGetError(String msg)
        {
            GetError = true;
            GetErrorMessage = msg;
            OnError?.Invoke(msg);
        }
    }

    /// <summary>
    ///     Converter from T to string Set converts to string Get converts from string
    /// </summary>
    public class Converter<T> : Converter<T, String>
    {
        /// <summary>
        ///     Custom Format to be applied on bidirectional way.
        /// </summary>
        public String? Format { get; set; } = null;
    }
}