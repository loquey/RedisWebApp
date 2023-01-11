/// <summary>
/// Product category entity
/// </summary>
internal class ProductCategory : BaseEntity
{
    /// <summary>
    /// Category Identifier for the product 
    /// </summary>
    public ProductCategoryId ProductCategoryId { get; set; }

    /// <summary>
    /// Category name
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Brief decription of the category
    /// </summary>
    public string CategoryDescription { get; set; }
}

[StronglyTypedId]
internal partial struct ProductCategoryId { }