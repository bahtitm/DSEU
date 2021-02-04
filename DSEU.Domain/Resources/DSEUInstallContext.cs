using System.Globalization;

namespace DSEU.Domain.Resources
{
    public static class DSEUInstallContext
    {
        private static CultureInfo defaultCulture = new CultureInfo("tk");
        private static CultureInfo mainCulture;

        public static CultureInfo MainCulture
        {
            get => mainCulture ?? defaultCulture;
            set
            {
                if (mainCulture != null)
                    throw new System.Exception("Culture already assigned");

                mainCulture = value;
            }
        }
    }
}
