namespace RedisMvcApp.Persistence.Entities;

/// <summary>
/// Base entity, contain common properties for all entities
/// </summary>
public abstract class BaseEntity
{

    /// <summary>
    /// Date the entity was created
    /// </summary>
    public DateTimeOffset DateAdded { get; set; }

    /// <summary>
    /// Date the entity was last modifed
    /// </summary>
    public DateTimeOffset? LastModifed { get; set; }
}