using Ticket360.Shared.Multitenancy;

namespace Ticket360.Infrastructure.OpenApi;

public class TenantIdHeaderAttribute : SwaggerHeaderAttribute
{
    public TenantIdHeaderAttribute()
        : base(
            MultitenancyConstants.TenantIdName,
            "Input your tenant Id to access this API",
            string.Empty,
            true)
    {
    }
}
