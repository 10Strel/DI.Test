using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DI.Test.Web.Controllers
{
    internal static class ModelStateExtension
    {
        internal static void SetIntPositiveValidationError(this ModelStateDictionary modelState, string key, string? name = null)
        {
            if (modelState[key]?.Errors.Any() == null)
                modelState.AddModelError(key, $"Значение {name ?? key} должно быть натуральным числом больше нуля.");
        }

        internal static List<ResponseError> GetResponseError(this ModelStateDictionary modelState)
        {
            var responseErrors = new List<ResponseError>();
            var erroneousFields = modelState
                                    .Where(ms => ms.Value.Errors.Any())
                                    .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors.Select(error => new ResponseError(fieldKey, error.ErrorMessage));
                responseErrors.AddRange(fieldErrors);
            }

            return responseErrors;
        }
    }
}
