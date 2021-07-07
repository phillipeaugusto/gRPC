using ClienteInfo.Infra;
using ClienteInfo.Infra.Context;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteInfo.Extensions
{
    public static class GrpcExtensions
    {
        public static void GrpcClientInitialization(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ConnectionGrpc:Url"];
            var grpcChanel = new GrpcClientContext(url);
            services.AddSingleton(grpcChanel);
        }

    }
}