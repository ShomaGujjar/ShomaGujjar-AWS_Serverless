using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Books
{
    public class Function
    {
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest apigProxyEvent, ILambdaContext context)
        {
            var id = apigProxyEvent.PathParameters;
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "message", "hello world" }
            };

            switch (apigProxyEvent.HttpMethod)
            {
                case "POST":
                    break;
                case "GET":
                    body = new Dictionary<string, string>
                    {
                        {"message","Hello GET()" }
                    };
                    break;
                case "PUT":
                    break;
                case "DELETE":
                    break;
                default:
                    body = new Dictionary<string, string>
                    {
                        {"message",$"Unsupported HTTP method{apigProxyEvent.HttpMethod}" }
                    };
                    break;
            }
            return new APIGatewayProxyResponse
            {
                Body = JsonConvert.SerializeObject(body),
                StatusCode = 200,
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };

        }
    }
}
