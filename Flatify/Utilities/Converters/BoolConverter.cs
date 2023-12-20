// EpochWorlds
// BoolConverter.cs
// FuchsFarbe Studios 2023
// matsu
// Modified: 20-12-2023
namespace Flatify.Utilities
{
    public class BoolConverter<T> : Converter<T, Boolean?>
    {
        public BoolConverter()
        {
            SetFunc = OnSet;
            GetFunc = OnGet;
        }

        private T OnGet(Boolean? value)
        {
            try
            {
                var type = typeof(T);
                if (type == typeof(Boolean))
                {
                    Object result = value == true;
                    return (T)result;
                }

                if (type == typeof(Boolean?))
                {
                    Object result = value;
                    return (T)result;
                }

                if (type == typeof(String))
                {
                    Object result = value switch
                    {
                        true => "on",
                        false => "off",
                        _ => null
                    };
                    return (T)result;
                }

                if (type == typeof(Int32))
                {
                    Object result = value == true
                                        ? 1
                                        : 0;
                    return (T)result;
                }

                if (type == typeof(Int32?))
                {
                    Object? result = value switch
                    {
                        true => 1,
                        false => 0,
                        _ => null
                    };
                    return (T)result;
                }

                UpdateGetError($"Conversion to type {typeof(T)} not implemented");
                return default;
            }
            catch (Exception exception)
            {
                UpdateGetError($"Conversion error: {exception.Message}");
                return default;
            }
        }

        private Boolean? OnSet(T arg)
        {
            // This catches all nullable values which are null. No further null checks are needed below.!
            if (arg is null)
                return null;

            try
            {
                switch (arg)
                {
                    case Boolean boolValue:
                        return boolValue;
                    case Int32 intValue:
                        return intValue > 0;
                    case String stringValue when string.IsNullOrWhiteSpace(stringValue):
                        return null;
                    case String stringValue when bool.TryParse(stringValue, out var flag):
                        return flag;
                    case String stringValue when stringValue.ToLowerInvariant() == "on":
                        return true;
                    case String stringValue when stringValue.ToLowerInvariant() == "off":
                        return false;
                    case String:
                        return null;
                    default:
                        UpdateSetError($"Unable to convert to bool? from type {typeof(T).Name}");
                        return null;
                }
            }
            catch (FormatException exception)
            {
                UpdateSetError($"Conversion error: {exception.Message}");
                return null;
            }
        }
    }
}