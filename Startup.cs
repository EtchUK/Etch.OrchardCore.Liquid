using Etch.OrchardCore.Liquid.Filters;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Liquid;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Liquid
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddLiquidFilter<OrdinalDateFilter>("ordinal_date");
        }
    }
}
