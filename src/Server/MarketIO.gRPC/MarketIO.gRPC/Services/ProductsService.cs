using Grpc.Core;
using MarketIO.gRPC.Protos;
using System.Threading.Tasks;

namespace MarketIO.gRPC.Services
{
    public class ProductsService : Products.ProductsBase
    {
        public ProductsService()
        {
          
        }


        public override Task<ProductsPacket> GetProducts(ProductRequest request1, ServerCallContext context)
        {
            var packet = new ProductsPacket();
            packet.Products.Add(new ProductResponse { Id = 1, Image = "degfht", Name = "Soab" });
            packet.Products.Add(new ProductResponse { Id = 2, Image = "dfdg", Name = "Chips" });
            packet.Products.Add(new ProductResponse { Id = 3, Image = "dfsfh", Name = "Tea" });
            return  Task.FromResult(packet);
        }
    }
}
