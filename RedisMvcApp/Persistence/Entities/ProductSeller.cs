
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RedisMvcApp.Persistence.Entities;

/// <summary>
/// Product seller entity
/// </summary>
public class ProductSeller : BaseEntity 
{
    /// <summary>
    /// Unique Id for product seller
    /// </summary>
    public ProductSellerId ProductSellerId { get; set; }

    /// <summary>
    /// Foreign key product Id
    /// </summary>
    public ProductIdType ProductId { get; set; }

    /// <summary>
    /// Product navigation property
    /// </summary>
    public Product Product { get; set; }

    public Quantity ProductQuantity { get; set; }
}

[StronglyTypedId(backingType: StronglyTypedIdBackingType.Guid, converters: StronglyTypedIdConverter.EfCoreValueConverter | StronglyTypedIdConverter.SystemTextJson)]
public partial struct ProductSellerId { }


/// <summary>
/// Product quantity type
/// </summary>
public struct Quantity
{
    /// <summary>
    /// Quantity is in stock
    /// </summary>
    public bool InStock => _Quantity > 0;

    /// <summary>
    /// Quantity is out of stock
    /// </summary>
    public bool OutOfStock => !InStock;

    /// <summary>
    /// Quantity is lower than minimum stock required
    /// </summary>
    /// <param name="minimumStock">Minimum number of stock required</param>
    /// <returns></returns>
    public bool LowOnStock(int minimumStock) => _Quantity < minimumStock;

    public Quantity(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), $"Invalid quantity {quantity}, Specify a quantity greater than zero");

        _Quantity = quantity;
    }

    /// <summary>
    /// Increase quantity by a value
    /// </summary>
    /// <param name="rhs">Quantity to be increased </param>
    /// <param name="lhs">Inrease quantity by</param>
    /// <returns></returns>
    public static Quantity operator +(Quantity rhs, int lhs)
    {
        rhs._Quantity += lhs;
        return rhs;
    }

    /// <summary>
    /// Decrease quantity by a value
    /// </summary>
    /// <param name="rhs">Quantity to be increased </param>
    /// <param name="lhs">Inrease quantity by</param>
    /// <returns></returns>
    public static Quantity operator -(Quantity rhs, int lhs) =>
        lhs > rhs 
            ? throw new InvalidOperationException("Value is higher that available quantity")
            : rhs + (-lhs);


    public static implicit operator int(Quantity rhs) => rhs._Quantity;

    /// <summary>
    /// Quantity Store
    /// </summary>
    private int _Quantity;

    public class EfCoreValueConverter : ValueConverter<Quantity, int>
    {
        public EfCoreValueConverter() : this(null) { }
        public EfCoreValueConverter(ConverterMappingHints mappingHints = null)
            : base(
                id => id,
                value =>  new Quantity(value),
                mappingHints
            )
        { }
    }
}
