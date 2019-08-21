using System;
using System.Collections.Generic;
using System.Text;

namespace Actualsis.Infrastructure.JobCamp.Common
{
   public class ConfigHelper
    {
        private static ConnectionStrings _ConnectionStrings;
        public static ConnectionStrings connectionStrings
        {
            get
            {
                if (_ConnectionStrings == null)
                {
                    _ConnectionStrings = ConfigurationManager.GetAppSettings<ConnectionStrings>("ConnectionStrings");
                }
                return _ConnectionStrings;
            }
        }
    }
}
