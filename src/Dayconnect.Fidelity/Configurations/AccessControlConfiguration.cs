using Dayconnect.Fidelity.Domain.Interfaces.ExternalService;
using Dayconnect.Fidelity.ExternalService;

#nullable disable

namespace Dayconnect.Fidelity.Configurations;

public static class AccessControlConfiguration
{
    public static void IntegrateAcessControl(this IServiceCollection services, string endPoint)
    {
        services.AddHttpClient<IAccessControlSession, AccessControlSession>(client =>
        {
            client.BaseAddress = new Uri(endPoint);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("pt-BR"));
        });
    }
}