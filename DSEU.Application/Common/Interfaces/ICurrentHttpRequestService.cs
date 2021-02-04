namespace DSEU.Application.Common.Interfaces
{
    public interface ICurrentHttpRequestService
    {
        string HostName { get;  }
        string UserAgent { get;  }
    }
}
