
/// <summary>
/// Cache key ID generators for redis cache
/// </summary>
public static class CacheKeyGenerator
{
    /// <summary>
    /// generate unique string for the data cache type
    /// </summary>
    /// <param name="key">Unique key</param>
    /// <param name="ids">optional Id's to be passed</param>
    /// <returns></returns>
    public static object GetDataKey(string key, params string[] ids)
         => _KeyGenerator("datacache", key, ids);


    /// <summary>
    /// Generate unique string for the page cache type
    /// </summary>
    /// <param name="key">Unique key </param>
    /// <param name="ids">Optional Ids</param>
    /// <returns></returns>
    public static string GetPageKey(string key, params string[] ids)
         => _KeyGenerator("pagecache", key, ids);

    /// <summary>
    /// Generate unique string for the row cache type
    /// </summary>
    /// <param name="key">Key id</param>
    /// <param name="ids">optional Ids</param>
    /// <returns></returns>
    public static object GetRowKey(string key, params string[] ids)
        => _KeyGenerator("rowcache", key, ids);

    private static string _KeyGenerator(string sectionkey, string key, params string[] ids)
        => ids.Any() ?
        string.Join(":", sectionkey, key, string.Join(":", ids)) :
        string.Join(":", sectionkey, key);
}