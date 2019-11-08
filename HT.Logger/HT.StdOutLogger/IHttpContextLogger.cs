using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StdOutLogger.Models;

namespace StdOutLogger
{
    public interface IHttpContextLogger
    {
        Task AddHttpRequest(HttpRequest httpRequest);
        void AddHttpResponse(HttpResponse httpResponse);
        HttpContextLog GetHttpContextLogModel();
    }
}
