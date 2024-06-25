using StackExchange.Redis;

namespace RedisConfig
{
    public static class Redis
    {
        static readonly string HOST_NAME = Environment.GetEnvironmentVariable("REDIS_HOST_NAME", EnvironmentVariableTarget.Machine)!;
        static readonly string PORT_NUMBER = Environment.GetEnvironmentVariable("REDIS_PORT_NUMBER", EnvironmentVariableTarget.Machine)!;
        static readonly string PASSWORD = Environment.GetEnvironmentVariable("REDIS_PASSWORD", EnvironmentVariableTarget.Machine)!;
        static readonly ConnectionMultiplexer _instance = GetMultiplexer();
        
        public static ConnectionMultiplexer GetInstance()
        {
            return _instance;
        }

        private static ConnectionMultiplexer GetMultiplexer()
        {
            string config = $"{HOST_NAME}:{PORT_NUMBER},password={PASSWORD}";
            var options = ConfigurationOptions.Parse(config);
            var conn = ConnectionMultiplexer.Connect(options);

            return conn;
        }
    }
}
