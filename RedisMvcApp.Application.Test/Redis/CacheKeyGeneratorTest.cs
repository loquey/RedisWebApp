using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace RedisMvcApp.Application.Test.Redis
{

    public class CacheKeyGeneratorTest
    {
        [Fact]
        public void GeneratePageKey()
        {
            var cacheKey = CacheKeyGenerator.GetPageKey("index_html");

            Assert.Equal("pagecache:index_html", cacheKey);
        }

        [Fact]
        public void GeneratePageKeyWithVariableId()
        {
            var cacheKey = CacheKeyGenerator.GetPageKey("index_html", "45");

            Assert.Equal("pagecache:index_html:45", cacheKey);
        }

        [Fact]
        public void GenerateRowKey()
        {
            var cacheKey = CacheKeyGenerator.GetRowKey("348");

            Assert.Equal("rowcache:348", cacheKey);
        }

        [Fact]
        public void GenerateRowKeyWithVariableId()
        {
            var cacheKey = CacheKeyGenerator.GetRowKey("348", "45");

            Assert.Equal("rowcache:348:45", cacheKey);
        }

        [Fact]
        public void GenerateDataKey()
        {
            var cacheKey = CacheKeyGenerator.GetDataKey("sessionid");

            Assert.Equal("datacache:sessionid", cacheKey);
        }

        [Fact]
        public void GenerateDataKeyWithVariableId()
        {
            var cacheKey = CacheKeyGenerator.GetDataKey("sessionid", "userid");

            Assert.Equal("datacache:sessionid:userid", cacheKey);
        }
    }
}
