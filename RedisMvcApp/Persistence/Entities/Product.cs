
using RedisMvcApp.Persistence.Entities;

/// <summary>
/// Product entity
/// </summary>
public sealed class Product : BaseEntity
{
    /// <summary>
    /// Name of the product
    /// </summary>
    public string? ProductName { get; set; }

    /// <summary>
    /// Store-keeping unit number
    /// </summary>
    public Guid SKU { get; set; }

    /// <summary>
    /// Product Identifier
    /// </summary>
    public ProductId ProductId { get; set; }

    public Product(string productName)
    {
        if (string.IsNullOrEmpty(productName))
            throw new ArgumentNullException("Invalid or empty product name. Please supply a valid product name");
        ProductName = ProductName;
    }
}

[StronglyTypedId()]
public partial struct ProductId { }