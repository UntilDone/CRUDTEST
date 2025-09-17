﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD.Model.Models;
using CRUD.BL.Services;
using CRUD.Model.Entities;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;

namespace CRUD.ApiService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetProducts()
        {
            var products = await productService.GetProducts();
            return Ok(new BaseResponseModel { Success = true, Data = products });
        }
        [HttpPost]
        public async Task<ActionResult<ProductModel>> CreateProduct(ProductModel productModel)
        {
            await productService.CreateProduct(productModel);
            return Ok(new BaseResponseModel { Success = true });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetProduct(int id)
        {
            var productModel = await productService.GetProduct(id);
            if (productModel == null)
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not Found" });

            }
            return Ok(new BaseResponseModel { Success = true, Data = productModel });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponseModel>> UpdateProduct(int id, ProductModel productModel)
        {
            if (id != productModel.ID || !await productService.ProductModelExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Bad request" });
            }
            await productService.UpdateProduct(productModel);
            return Ok(new BaseResponseModel { Success = true });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!await productService.ProductModelExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not Found" });
            }
            await productService.DeleteProduct(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
