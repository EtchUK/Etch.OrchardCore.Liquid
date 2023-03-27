using Fluid;
using Fluid.Values;
using OrchardCore.Liquid;
using System;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Liquid.Filters
{
    public class OrdinalDayFilter : ILiquidFilter
    {
        public ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, LiquidTemplateContext context)
        {
            if (input.IsNil())
            {
                return new ValueTask<FluidValue>(new StringValue("Invalid Date passed to ordinal filter"));
            }

            var date = (DateTime)input.ToObjectValue();

            return new ValueTask<FluidValue>(new StringValue(date.ToString($"d{CalculateDateSuffix(date)}")));
        }

        private string CalculateDateSuffix(DateTime date)
        {
            if (date.Day == 1 || date.Day == 21 || date.Day == 31)
            {
                return "\\s\\t";
            }
            else if (date.Day == 2 || date.Day == 22)
            {
                return "\\n\\d";
            }
            else if (date.Day == 3 || date.Day == 23)
            {
                return "\\r\\d";
            }
            else
            {
                return "\\t\\h";
            }
        }
    }
}