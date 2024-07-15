namespace Products.Domain.Core.Guards;

public static class Ensure
{
    public static void NotEmpty(string value, string message, string argumentName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(message, argumentName);
        }
    }

    public static void NotEmpty(Guid value, string message, string argumentName)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentNullException(message, argumentName);
        }
    }


    public static void NotEmpty(DateTime dateTime, string message, string argumentName)
    {
        if (dateTime == default)
        {
            throw new ArgumentNullException(message, argumentName);
        }
    }

    public static void NotEmpty<TValue>(TValue value, string message, string argumentName)
        where TValue : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(message, argumentName);
        }
    }
}
