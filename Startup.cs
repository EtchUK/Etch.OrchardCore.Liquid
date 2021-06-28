using System;
using Etch.OrchardCore.Liquid.Filters;
using Fluid;
using Fluid.Values;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.DisplayManagement.Descriptors;
using OrchardCore.DisplayManagement.Liquid.Filters;
using OrchardCore.Indexing;
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
