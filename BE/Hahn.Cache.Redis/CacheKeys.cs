using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Cache
{
    public class CacheKeys
    {
        private static string addToCacheKey;
        static CacheKeys()
        {

        }
        public static string GetAllAssetsKey()
        {
            return $"AllAssets";
        }

        public static string GetUserKey(string userid)
        {
            return $"HahnUsers{addToCacheKey}:User_{userid}";
        }

    }
}
