using Etch.OrchardCore.Liquid.Filters;
using Fluid;
using Fluid.Values;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrchardCore.Liquid;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Liquid
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddLiquidFilter<OrdinalDateFilter>("ordinal_date");

            services.Configure<TemplateOptions>(o =>
            {
                o.Scope.SetValue("Environment", new ObjectValue(new LiquidEnvironmentAccessor()));
                o.MemberAccessStrategy.Register<LiquidEnvironmentAccessor, FluidValue>((obj, name, context) =>
                {
                    var liquidTemplateContext = (LiquidTemplateContext)context;
                    var hostEnvironment = liquidTemplateContext.Services.GetRequiredService<IHostEnvironment>();

                    FluidValue result = name switch
                    {
                        nameof(hostEnvironment.ApplicationName) => new StringValue(hostEnvironment.ApplicationName),
                        nameof(hostEnvironment.EnvironmentName) => new StringValue(hostEnvironment.EnvironmentName),
                        "IsDevelopment" => BooleanValue.Create(hostEnvironment.IsDevelopment()),
                        "IsStaging" => BooleanValue.Create(hostEnvironment.IsStaging()),
                        "IsProduction" => BooleanValue.Create(hostEnvironment.IsProduction()),
                        _ => NilValue.Instance
                    };

                    return result;
                });
            });
        }
    }
}
