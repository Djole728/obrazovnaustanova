using System.Linq;

namespace ObrazovneUstanove.UI.Custom.Extensions
{
    public static class ModelStateExtensions
    {
        public static string UserFriendlyErrors(this System.Web.Mvc.ModelStateDictionary dictionary)
        {
            var errors = dictionary
                .Where(o => o.Value.Errors.Any())
                .Select(o => o.Value.Errors.Select(o1 => o1.ErrorMessage))
                .SelectMany(o => o);

            return string.Join("<br />", errors);
        }
    }
}
