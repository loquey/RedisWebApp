namespace RedisMvcApp.Models.Products;


/// <summary>
/// Product category entity
/// </summary>
public class ProductCategoryModel
{
    /// <summary>
    /// Category Identifier for the product 
    /// </summary>
    public Guid ProductCategoryId { get; set; }

    /// <summary>
    /// Category name
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Brief decription of the category
    /// </summary>
    public string CategoryDescription { get; set; }
}