using System;
using System.Threading.Tasks;
using DomainInfo.ConvertPASF;
using DomainInfo.Entity;
using Grpc.Core;
using ProductService;
using ServerInfo.Repository.Contracts;

namespace ServerInfo.Services
{
    public class ProductService: ProductsService.ProductsServiceBase
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task<ProductReply> Add(ProductAddRequest request, ServerCallContext context)
        {
            var objConvertGenericConvert = new ConvertGeneric<Product, ProductAddRequest>(request);
            var product = objConvertGenericConvert.Convert();
            
            var productExists = await _productRepository.ExistsByDescription(product.Description);

            if (productExists)
                return null;
            
            await _productRepository.Create(product);
            var convert = new ConvertGeneric<ProductReply, Product>(product);
            return convert.Convert();
        }
        
        public override async Task<ProductReply> Update(ProductRequest request, ServerCallContext context)
        {
            var objConvertGenericConvert = new ConvertGeneric<Product, ProductRequest>(request);
            var product = objConvertGenericConvert.Convert();
            var productExists = await _productRepository.Exists(product);

            if (!productExists)
                return null;
            
            await _productRepository.Update(product);
            var convert = new ConvertGeneric<ProductReply, Product>(product);
            return convert.Convert();
        }

        public override async Task<ProductReply> FindById(ProductIdRequest request, ServerCallContext context)
        {
            var guid = Guid.Parse(request.Id);
            var product = await _productRepository.FindById(guid);

            if (product == null) 
                return null;
            
            var convert = new ConvertGeneric<ProductReply, Product>(product);
            return convert.Convert();
        }

        public override async Task<ProductReplyArray> FindAll(Empty request, ServerCallContext context)
        {
            var listProduct = await _productRepository.FindAll();

            if (listProduct == null)
                return null;

            var list = new ProductReplyArray();
            
            foreach (var item in listProduct)
            {
                var convert = new ConvertGeneric<ProductReply, Product>(item);
                list.ProductReply.Add(convert.Convert());
            }
            
            return list;
        }
        
        public override async Task<Info> Remove(ProductIdRequest request, ServerCallContext context)
        {
            var guid = Guid.Parse(request.Id);
            var product = await _productRepository.FindById(guid);
            
            if (product == null)
                return null;

            await _productRepository.Remove(product);
            return new Info {Message = "Product successfully removed"};
        }
    }
}