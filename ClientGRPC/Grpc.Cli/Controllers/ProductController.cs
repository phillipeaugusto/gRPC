using System;
using System.Threading.Tasks;
using ClienteInfo.Dto;
using ClienteInfo.Infra.Context;
using DomainInfo.ConvertPASF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService;

namespace ClienteInfo.Controllers
{
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public async Task<ActionResult> Add(
            [FromServices] GrpcClientContext grpcClientContext,
            [FromBody] ProductDto productDto
        )
        {
            try
            {
                var client = new ProductsService.ProductsServiceClient(grpcClientContext.GrpcChannel);
                var objConvertGeneric = new ConvertGeneric<ProductAddRequest, ProductDto>(productDto);
                var reply = await client.AddAsync(objConvertGeneric.Convert());
                return Ok(reply);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult> FindById(
            [FromServices] GrpcClientContext grpcClientContext,
            [FromQuery] Guid id
        )
        {
            try
            {
                var client = new ProductsService.ProductsServiceClient(grpcClientContext.GrpcChannel);
                var reply = await client.FindByIdAsync(new ProductIdRequest {Id = id.ToString()});
                return Ok(reply);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("")]
        [HttpPut]
        public async Task<ActionResult> Update(
            [FromServices] GrpcClientContext grpcClientContext,
            [FromBody] ProductDto productDto
        )
        {
            try
            {
                var client = new ProductsService.ProductsServiceClient(grpcClientContext.GrpcChannel);
                var objConvertGeneric = new ConvertGeneric<ProductRequest, ProductDto>(productDto);
                var reply = await client.UpdateAsync(objConvertGeneric.Convert());
                return Ok(reply);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("AllProducts")]
        [HttpGet]
        public async Task<ActionResult> FindAll(
            [FromServices] GrpcClientContext grpcClientContext
        )
        {
            try
            {
                var client = new ProductsService.ProductsServiceClient(grpcClientContext.GrpcChannel);
                var reply = await client.FindAllAsync(new ProductService.Empty());
                return Ok(reply);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [Route("")]
        [HttpDelete]
        public async Task<ActionResult> Remove(
            [FromServices] GrpcClientContext grpcClientContext,
            [FromQuery] Guid id
        )
        {
            try
            {
                var client = new ProductsService.ProductsServiceClient(grpcClientContext.GrpcChannel);
                var reply = await client.RemoveAsync(new ProductIdRequest {Id = id.ToString()});
                return Ok(reply);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}