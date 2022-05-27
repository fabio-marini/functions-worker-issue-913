using ClassLibrary1;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FunctionApp1
{
    public class Function2
    {
        private readonly ILogger _logger;
        private readonly MyDependency dep;

        public Function2(ILoggerFactory loggerFactory, MyDependency dep)
        {
            _logger = loggerFactory.CreateLogger<Function2>();

            this.dep = dep;
        }

        [Function("Function2")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation($"C# HTTP trigger function processed a request");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
