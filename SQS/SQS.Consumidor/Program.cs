using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQS.Consumidor
{
    internal class Program
    {
        // Consumir o serviço de SQS, vamos precisar do SDK Install-Package AWSSDK.SQS -Version 3.5.1.14
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Criando o cliente            
            var client = new AmazonSQSClient(RegionEndpoint.SAEast1);

            // Pegar as mensagens da fila
            var request = new ReceiveMessageRequest { QueueUrl = "https://sqs.sa-east-1.amazonaws.com/437719538875/teste" };

            while (true)
            {

                var response = await client.ReceiveMessageAsync(request);

                foreach (var mensagem in response.Messages)
                {
                    Console.WriteLine(mensagem.Body);
                    await client.DeleteMessageAsync("https://sqs.sa-east-1.amazonaws.com/437719538875/teste", mensagem.ReceiptHandle);
                }
            }

        }
    }
}
