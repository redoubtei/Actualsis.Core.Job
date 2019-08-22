using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actualsis.Infrastructure.JobCamp.Common
{
    public class ConfigurationHelper<T> where T : class, new()
    {
        //索引器必须以this关键字定义，其实这个this就是类实例化之后的对象
        public T this[string index]
        {
            get
            {
                return ConfigurationManager.GetAppSettings<T>(index);
            }
        }
    }
    public static class ConfigurationManager
    {
        public static T GetAppSettings<T>(string key) where T : class, new()
        {
            var baseDir = AppContext.BaseDirectory;
            var indexBin = baseDir.IndexOf("bin");
            // log.Write(baseDir);
            var subToSrc = "";

            if (indexBin > 0)
                subToSrc = baseDir.Substring(0, indexBin);
            else
                subToSrc = baseDir;

            var currentClassDir = subToSrc;

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(currentClassDir)
                .Add(new JsonConfigurationSource { Path = "appsettings.json", Optional = false, ReloadOnChange = true })
                .Build();

            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;

            return appconfig;
        }
    }
}
