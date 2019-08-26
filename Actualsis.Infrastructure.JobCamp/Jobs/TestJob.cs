using Actualsis.Base.Common;
using Actualsis.Base.Redis;
using Actualsis.Core.Repository;

using Quartz;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Actualsis.Infrastructure.JobCamp.Jobs
{
    /// <summary>
    /// 
    /// </summary>
    [DisallowConcurrentExecution]
    public class TestJob : IJob
    {
        private static readonly IDatabase _redis = new RedisService(connectionString: RedisHelper.RedisConfig.ConnectionString,
                                                                    instanceName: RedisHelper.RedisConfig.InstanceName,
                                                                    defaultDB: RedisHelper.RedisConfig.DbIndex
                                                                   ).GetDatabase();

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var jobKey = context.JobDetail.Key;//获取job信息
                var triggerKey = context.Trigger.Key;//获取trigger信息

                DapperHelper dapperHelper = new DapperHelper(ConfigHelper.connectionStrings.Connection);
                // 获取本地文件路径
                string path = ConfigHelper.downloadConfig.Path_folder;

                Console.WriteLine($"=== jobKey: {jobKey} triggerKey:{triggerKey} === ");
                Console.WriteLine($"=== path: {path} === ");

                //RedisService redisService = new RedisService();

                //IDatabase redis2 = new RedisService(connectionString: RedisHelper.RedisConfig.ConnectionString,
                //                                                               instanceName: RedisHelper.RedisConfig.InstanceName,
                //                                                                defaultDB: RedisHelper.RedisConfig.DbIndex
                //                                                              ).GetDatabase();

                //var  tet= redis2.HashGetAll("XhsVideos:data:videos");
                //var hash = _redis.HashGetAll("XhsVideos:data:videos");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"=======出现错误: {ex.Message}========");
            }
            await Task.CompletedTask;

        }
    }
}
