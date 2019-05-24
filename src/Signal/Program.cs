using System;
using System.Threading.Tasks;
using InflexSwaggerClient.Services;

namespace Signal {
    class Program {
        static async Task Main(string[] args) {

            var client = new HubService(new ServiceOptions {
                BaseUrl = "http://10.211.55.4:5000"
            });

            var response = await client.InitConnection();
            Console.WriteLine("Response - {0} {1}", response.Success, response.Message);

            client.FireNewInputStatus += (id, status) => {
                Console.WriteLine("Input - {0} {1}", id, status);
            };

            client.FireNewOutputStatus += (id, status) => {
                Console.WriteLine("Output - {0} {1}", id, status);
            };


            Console.WriteLine("Waiting for signal ...");
            Console.ReadLine();
        }
    }
}
