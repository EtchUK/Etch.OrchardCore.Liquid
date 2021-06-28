using Fluid;
using Fluid.Values;
using OrchardCore.Liquid;
using System;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Liquid.Filters
{
    public class OrdinalDateFilter : ILiquidFilter
    {
        public ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, TemplateContext ctx)
        {
            if (input.IsNil())
            {
                return new ValueTask<FluidValue>(new StringValue("Invalid Date passed to ordinal filter"));
            }

            var date = (DateTime)input.ToObjectValue();

            var dayString = string.Empty;

            if (date.Day == 1 || date.Day == 21 || date.Day == 31)
            {
                dayString = "\\s\\t";
            }
            else if (date.Day == 2 || date.Day == 22)
            {
                dayString = "\\n\\d";
            }
            else if (date.Day == 3 || date.Day == 23)
            {
                dayString = "\\r\\d";
            }
            else
            {
                dayString = "\\t\\h";
            }

            return new ValueTask<FluidValue>(new StringValue(date.ToString($"MMMM d{dayString} yyyy")));
        }
    }
}