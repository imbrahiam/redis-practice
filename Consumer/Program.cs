using RedisConfig;
using StackExchange.Redis;

namespace Consumer
{
    internal class Program
    {
        static readonly ConnectionMultiplexer _redis = Redis.GetInstance();
        static void Main(string[] args)
        {
            var subscriber = _redis.GetSubscriber();

            Console.WriteLine($"Subscriber listening on 'Notifications' channel...\n");
            uint i = 1;

            subscriber.Subscribe("notifications", (channel, message) => {
                Console.WriteLine((string)message!);
            });

            while (true);
        }
    }
}
