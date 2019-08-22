namespace Actualsis.Infrastructure.Redis
{
    public class RedisConfig
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Password { get; set; }
        public string DefaultKey { get; set; }
        public int DbIndex { get; set; }
        public string ConnectionString { get; set; }
        public string InstanceName { get; set; }
    }
}
