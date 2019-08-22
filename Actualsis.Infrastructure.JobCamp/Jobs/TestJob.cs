using Actualsis.Base.Common;
using Actualsis.Core.Repository;
using Actualsis.Infrastructure.JobCamp.Common;
using Quartz;
using System;
using System.Threading.Tasks;

namespace Actualsis.Infrastructure.JobCamp.Jobs
{
    [DisallowConcurrentExecution]
    public class TestJob : IJob
    {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=======出现错误: {ex.Message}========");
            }
            await Task.CompletedTask;

        }
    }
}
