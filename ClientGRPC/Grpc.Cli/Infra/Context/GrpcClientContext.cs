using Grpc.Net.Client;

namespace ClienteInfo.Infra.Context
{
    public class GrpcClientContext
    {
        public GrpcClientContext(string url)
        {
            GrpcChannel = GrpcChannel.ForAddress(url);
        }

        public GrpcChannel GrpcChannel { get; set;}
    }
}