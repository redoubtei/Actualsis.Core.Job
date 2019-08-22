using Actualsis.Base.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actualsis.Infrastructure.JobCamp.Common.downconfig
{
    public class DownloadHelper
    {
        private static DownloadConfig _DownloadConfig;
        public static DownloadConfig downloadConfig
        {
            get
            {
                if (_DownloadConfig == null)
                {
                    _DownloadConfig = ConfigurationManager.GetAppSettings<DownloadConfig>("DownloadConfig");
                }
                return _DownloadConfig;
            }
        }
    }
}
