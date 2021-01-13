using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace App.Configurations
{
    public static class GlobalizationConfig
    {
        public static IApplicationBuilder UseGlobalizationConfig(this IApplicationBuilder app)
        {
            var defaultCurture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCurture),
                SupportedCultures = new List<CultureInfo> { defaultCurture },
                SupportedUICultures = new List<CultureInfo> { defaultCurture }
            };
            app.UseRequestLocalization(localizationOptions);

            return app;
        }
    }
}