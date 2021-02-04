using System.Reflection;
using System.Resources;

namespace DSEU.Domain.Resources
{
    public class TaskResourceManager
    {
        /// <summary>
        /// Имя сборки
        /// </summary>
        private const string ASSEBLY_NAME = "DSEU.Domain.Resources.TaskResources";

        public static string GetResource(string resourceName)
        {
            var resourceManager = new ResourceManager(ASSEBLY_NAME, Assembly.GetExecutingAssembly());
            var culture = DSEUInstallContext.MainCulture;
            return resourceManager.GetString(resourceName, culture);
        }
    }
}
