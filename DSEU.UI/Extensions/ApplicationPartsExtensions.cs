using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace DSEU.UI.Extensions
{
    public static class ApplicationPartsExtensions
    {
        public static IMvcBuilder AddApplicationParts(this IMvcBuilder builder, IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                builder.AddApplicationPart(assembly);
            }
            return builder;
        }
    }

   
}
