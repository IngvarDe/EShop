using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Linq;

namespace EShop.Common.Extensions
{
    public static class ModelStateExtensions
    {
        public static IDictionary Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var errors = modelState
                    .ToDictionary(kvp => kvp.Key, kvp => kvp
                    .Value.Errors
                    .Select(e => e.ErrorMessage)
                    .ToArray())
                    .Where(m => m.Value.Count() > 0);

                return errors.ToDictionary(x => x.Key, y => y.Value);
            }

            return null;
        }
    }
}
