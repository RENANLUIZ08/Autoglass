using Autoglass.Domain.DTO;
using Autoglass.Service.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace Autoglass.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase<ProductDto>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Novo cadastro de Produto", Description = "EndPoint de Cadastro de Produto")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cadastro realizado com sucesso!")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, description: "Ocorreu um erro durante a transação, verifique as informações e tente novamente")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]

        public override IActionResult Create([FromBody] ProductDto entity)
        {
            try
            {
                return Ok(_productService.Create(entity));
            }
            catch (OperationCanceledException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem($"Erro interno de cadastro, detalhes:{ex.Message}");
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Atualizar cadastro de Produto", Description = "EndPoint de Atualização de Produto")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cadastro atualizado com sucesso!")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, description: "Ocorreu um erro durante a transação, verifique as informações e tente novamente")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Não foram localizados dados com os as informacoes enviadas.")]

        public override IActionResult Update([FromBody] ProductDto entity)
        {
            try
            {
                return Ok(_productService.Update(entity));
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem($"Erro interno de atualização, detalhes:{ex.Message}");
            }
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Excluir cadastro de Produto", Description = "EndPoint de Exclusão de Produto")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cadastro atualizado com sucesso!")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, description: "Ocorreu um erro durante a transação, verifique as informações e tente novamente")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Não foram localizados dados com os as informacoes enviadas.")]

        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem($"Erro interno de exclusão, detalhes:{ex.Message}");
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter cadastro de Produto pelo Id", Description = "EndPoint de Obter produto pelo identificador")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Dados obtidos com sucesso!")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, description: "Ocorreu um erro durante a transação, verifique as informações e tente novamente")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Não foram localizados dados com os as informacoes enviadas.")]

        public override IActionResult Get(int id)
        {
            try
            {
                return Ok(_productService.GetById(id));
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem($"Erro interno ao selecionar por identificador, detalhes:{ex.Message}");
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter lista de cadastro de produtos", Description = "EndPoint de Obter os produtos cadastrados")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Dados obtidos com sucesso!")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, description: "Ocorreu um erro durante a transação, verifique as informações e tente novamente")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Não foram localizados dados com os as informacoes enviadas.")]

        public override IActionResult GetAll()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem($"Erro interno ao selecionar lista, detalhes:{ex.Message}");
            }
        }


    }
}
