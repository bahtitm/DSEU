using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using DSEU.Devexpress.Devexpress.ModelBinders;

namespace DSEU.Devexpress.Devexpress.Options
{
    [ModelBinder(BinderType = typeof(DataSourceLoadOptionsBinder))]
    public class DataSourceLoadOptions : DataSourceLoadOptionsBase
    {
    }
}
