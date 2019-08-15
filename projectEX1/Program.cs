using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clarifai.API;
using Clarifai.DTOs.Inputs;
namespace projectEX1
{
    class Program
    {
        static void Main(string[] args)
        {
            // With `CLARIFAI_API_KEY` defined as an environment variable
            var client = new ClarifaiClient("9b91bce106fd4d25946434b28687f915");

            // When passed in as a string
           // var client = new ClarifaiClient("YOUR_CLARIFAI_API_KEY");

            // When using async/await
            //var res = await client.PublicModels.GeneralModel
            //    .Predict(new ClarifaiURLImage("https://samples.clarifai.com/metro-north.jpg"))
            //    .ExecuteAsync();

            // When synchronous
            var res = client.PublicModels.GeneralModel
                .Predict(new ClarifaiURLImage("https://cdn1.vectorstock.com/i/1000x1000/32/45/cartoon-sun-with-sunglasses-vector-21573245.jpg"))
                .ExecuteAsync()
                .Result;

            // Print the concepts
            foreach (var concept in res.Get().Data)
            {
                Console.WriteLine($"{concept.Name}: {concept.Value}");
            }
        }
    }
}
