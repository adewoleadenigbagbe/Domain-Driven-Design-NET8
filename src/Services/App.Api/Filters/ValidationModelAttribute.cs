using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace App.Api.Filters
{
    public class ValidateModel : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ValidationResultModel(context.ModelState));
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

    }

    public class ValidationResultModel : IValidationResult
    {
        public ValidationResultModel()
        {
            ErrorMessage = "Validation Failed";
            Status = HttpStatusCode.BadRequest;
        }

        public ValidationResultModel(ModelStateDictionary modelState) : this()
        {
            Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.GroupBy(g => g.ErrorMessage).Select(x => new ValidationError(key, x.First().ErrorMessage)))
                .ToList();
        }

        public HttpStatusCode Status { get ; set; }

        public string ErrorMessage { get; set ; }

        public IEnumerable<IValidationError> Errors { get; set ; }

    }

    public interface IValidationResult
    {
        [JsonIgnore]
        HttpStatusCode Status { get; set; }

        [JsonIgnore]
        string ErrorMessage { get; set; }

        IEnumerable<IValidationError> Errors { get; set; }      
    }

    public class ValidationError : IValidationError
    {
        public string PropertyName { get; set; }

        public string Message { get; set; }

        public ValidationError(string field, string message)
        {
            PropertyName = field != string.Empty ? field : null;
            Message = message;
        }
    }

    public interface IValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        string PropertyName { get; set; }

        string Message { get; set; }
    }
}
