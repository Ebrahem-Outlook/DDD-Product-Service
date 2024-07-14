using Product.Domain.Core.BaseType;

namespace Product.Domain.Products;

public sealed class Product : AggregateRoot
{
    private Product() : base() { }

    public Product(string name, string description, decimal price, string sKU, string barCode, decimal weight, string manufacturer, string brand, DateTime createdDate, DateTime modifiedDate, List<string> categories, int stockQuantity, int minumumStockQuantity, bool isActive, double rating, List<ProductReview> reviews)
    {
        Name = name;
        Description = description;
        Price = price;
        SKU = sKU;
        BarCode = barCode;
        Weight = weight;
        Manufacturer = manufacturer;
        Brand = brand;
        CreatedDate = createdDate;
        ModifiedDate = modifiedDate;
        Categories = categories;
        StockQuantity = stockQuantity;
        MinumumStockQuantity = minumumStockQuantity;
        IsActive = isActive;
        Rating = rating;
        Reviews = reviews;
    }



    /// <summary>
    /// 
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public decimal Price { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string SKU { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string BarCode { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public decimal Weight { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Manufacturer { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Brand { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime CreatedDate { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime ModifiedDate { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> Categories { get; private set; } = new();

    /// <summary>
    /// 
    /// </summary>
    public int StockQuantity { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int MinumumStockQuantity { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public double Rating { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public List<ProductReview> Reviews { get; private set; } = new();
}

/// <summary>
/// 
/// </summary>
public class ProductReview
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string ReviewerName { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Content { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public double Rating { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime CreatedDate { get; private set; }
}
