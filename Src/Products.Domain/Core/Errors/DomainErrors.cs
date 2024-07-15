using Products.Domain.Core.BaseType;

namespace Products.Domain.Core.Errors;

public static class DomainErrors
{
    public static class Product
    {
        public static Error NullOrEmpty => new Error("Product.NotNull", "The Product can not be Null or Empty");

        public static Error NotFound => new Error("Product.NotFound", "Product with the spicified Id does not exsit.");

        public static Error AlreadyExsit => new Error("Product.AlreadyExsit", "Product with the spicified Id AlreadyExsit.");
    }

    public static class Name
    {
        public static Error NullOrEmpty => new Error("Name.NullOrEmpty", "The Name of product can not be Null or Empty.");

        public static Error LongerThanAllowed => new Error("Name.LongerThanAllowed", "The Name is longer than allowed.");

        public static Error ShorterThanAllowed => new Error("Name.ShorterThanAllowed ", "The Name is shorter than allowed.");

        public static Error InValidFormate => new Error("Name.InValidFormate", "The Name of product can onle containes carachters and can't containse numbers .");
    }

    public static class Description
    {
        public static Error NullOrEmpty => new Error("Description.NullOrEmpty", "The Description of product can not be Null or Empty.");

        public static Error LongerThanAllowed => new Error("Description.LongerThanAllowed", "The Description is longer than allowed.");

        public static Error ShorterThanAllowed => new Error("Description.VeryShort", "The Description is shorter than allowed.");
    }

    public static class Price
    {
        public static Error InValidPrice => new Error("Price.InValidPrice", "The Price of product can not be zero or negative.");
    }

    public static class Stock
    {
        public static Error InValidCount => new Error("Stock.InValidCount", "The Stock of product can not be negative.");
    }
}
