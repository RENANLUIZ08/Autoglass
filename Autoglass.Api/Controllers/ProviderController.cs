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
    public class ProviderController : ControllerBase<ProviderDto>
    {
        private readonly IProviderService _providerService;
        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Novo cadastro de Fornecedor", Description = "EndPoint de Cadastro de Fornecedor")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cadastro realizado com sucesso!")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, description: "Ocorreu um erro durante a transação, verifique as informações e tente novamente")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        public override IActionResult Create([FromBody] ProviderDto entity)
        {
            try
            {
                return Ok(_providerService.Create(entity));
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
        [SwaggerOperation(Summary = "Atualizar cadastro de Fornecedor", Description = "EndPoint de Atualização de Fornecedor")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cadastro atualizado com sucesso!")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, description: "Ocorreu um erro durante a transação, verifique as informações e tente novamente")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Não foram localizados dados com os as informacoes enviadas.")]
        public override IActionResult Update([FromBody] ProviderDto entity)
        {
            try
            {
                return Ok(_providerService.Update(entity));
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

        [HttpGet]
        [SwaggerOperation(Summary = "Obter cadastro de Fornecedor pelo Id", Description = "EndPoint de Obter fornecedor pelo identificador")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Dados obtidos com sucesso!")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, description: "Ocorreu um erro durante a transação, verifique as informações e tente novamente")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Não foram localizados dados com os as informacoes enviadas.")]

        public override IActionResult Get(int id)
        {
            try
            {
                return Ok(_providerService.GetById(id));
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
        [SwaggerOperation(Summary = "Obter lista de cadastro de Fornecedores", Description = "EndPoint de Obter os fornecedores cadastrados")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Dados obtidos com sucesso!")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, description: "Ocorreu um erro durante a transação, verifique as informações e tente novamente")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Não foram localizados dados com os as informacoes enviadas.")]

        public IActionResult GetAll()
        {
            try
            {
                return Ok(_providerService.GetAll());
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
