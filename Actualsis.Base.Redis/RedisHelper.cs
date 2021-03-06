﻿
using Actualsis.Base.Common;

namespace Actualsis.Base.Redis

{
    public class RedisHelper
    {
        private static RedisConfig _RedisConfig;
        public static RedisConfig RedisConfig
        {
            get
            {
                if (_RedisConfig == null)
                {
                    _RedisConfig = ConfigurationManager.GetAppSettings<RedisConfig>("RedisConfig");
                }
                return _RedisConfig;
            }
        }
    }
}
