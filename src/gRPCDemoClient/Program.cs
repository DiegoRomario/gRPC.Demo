using Grpc.Net.Client;
using gRPCDemoHost;
using System;
using System.Threading.Tasks;

namespace gRPCDemoClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new gRPCDemoHost.Greeter.GreeterClient(channel);
            Console.WriteLine("Which Stock would you like to subscribe to follow the quote?");
            string stock = Console.ReadLine();
            Console.WriteLine("Please select the mode: [A]utomatic or [M]anual");
            string mode = Console.ReadLine();
            while (true)
            {
                var response = client.SayHello(new gRPCDemoHost.HelloRequest() { Name = stock });
                Console.WriteLine(response.Message);
                await channel.ShutdownAsync();
                if (mode == "M")
                {
                    Console.WriteLine("Press any key to see the current quote...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Loading...");
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }
    }
}
