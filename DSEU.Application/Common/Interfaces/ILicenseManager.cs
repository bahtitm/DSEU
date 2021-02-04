using System.Collections.Generic;
using System.Threading.Tasks;
using DSEU.Domain;

namespace DSEU.Application.Common.Interfaces
{
    public interface ILicenseManager
    {
        public int UsersCount { get; }
        IReadOnlyCollection<License> GetLicenses();
        Task LoadLicense();
        bool IsTrial();
    }
}
