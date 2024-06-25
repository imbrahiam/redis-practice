using RedisConfig;
using StackExchange.Redis;

namespace Provider
{
    internal class Program
    {
        static readonly ConnectionMultiplexer _redis = Redis.GetInstance();

        static void Main(string[] args)
        {
            var subscriber = _redis.GetSubscriber();
            Console.WriteLine($"Redis on at {subscriber.Ping().Milliseconds} ms!\n");
            uint i = 1;
            
            while (true)
            {
                Console.Write($"Channel(notifications) - Publish: ");
                string msg = Console.ReadLine()!;
                long listeners = subscriber.Publish("notifications", msg);
                Console.WriteLine($"Message published to {listeners} subscriber(s)\n");
            }
        }
    }
}
