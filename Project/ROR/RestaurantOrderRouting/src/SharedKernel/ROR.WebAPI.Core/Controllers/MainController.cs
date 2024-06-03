using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ROR.Core.Communication;
using System.Collections.Generic;
using System.Linq;

namespace ROR.WebAPI.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new { 
                    Success = true,
                    Data = result,    
                });
            }

            return BadRequest(new { 
                Success = false,
                Errors = Erros.ToArray()
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddProcessingError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddProcessingError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult response)
        {
            IsResponseWithErrors(response);

            return CustomResponse();
        }

        protected bool IsResponseWithErrors(ResponseResult response)
        {
            if (response == null || !response.Errors.Messages.Any()) return false;

            foreach (var message in response.Errors.Messages)
            {
                AddProcessingError(message);
            }

            return true;
        }

        protected bool ValidOperation()
        {
            return !Erros.Any();
        }

        protected void AddProcessingError(string erro)
        {
            Erros.Add(erro);
        }

        protected void ClearProcessingErrors()
        {
            Erros.Clear();
        }
    }
}
