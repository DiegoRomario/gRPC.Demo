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
            var response = client.SayHello(new gRPCDemoHost.HelloRequest() { Name = "Demo Client!" });
            Console.WriteLine(response.Message);
            await channel.ShutdownAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
