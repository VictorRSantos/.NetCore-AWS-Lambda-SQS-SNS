using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQS.Fornecedor
{
    internal class Program
    {
        // Vai enviar mensagem para fila
        static async Task Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            // Forncedor vai enviar mensagem
            var client = new AmazonSQSClient(RegionEndpoint.SAEast1);
            var request = new SendMessageRequest
            { 
                QueueUrl = "https://sqs.sa-east-1.amazonaws.com/437719538875/teste",
                MessageBody = "teste 123"
            };

            await client.SendMessageAsync(request);

        }
    }
}
