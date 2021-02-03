using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4
{
    public class LambdaFunction : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {/*
            builder
           .UseContentRoot(Directory.GetCurrentDirectory())
           .UseStartup()
           .UseApiGateway();*/
        }
    }
}
