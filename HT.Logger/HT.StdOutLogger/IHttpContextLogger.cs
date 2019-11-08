using System.Threading.Tasks;
using HT.StdOutLogger.Models;
using Microsoft.AspNetCore.Http;

namespace HT.StdOutLogger
{
    public interface IHttpContextLogger
    {
        Task AddHttpRequest(HttpRequest httpRequest);
        void AddHttpResponse(HttpResponse httpResponse);
        HttpContextLog GetHttpContextLogModel();
    }
}
