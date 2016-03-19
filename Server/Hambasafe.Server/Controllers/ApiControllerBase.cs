using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Hambasafe.Server.Attributes;
using Hambasafe.Server.Models;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using log4net;

namespace Hambasafe.Server.Controllers
{
    [GeneralExceptionFilter]
    public class ApiControllerBase : ApiController
    {
        private readonly IConfigurationService _configuration;
        private readonly ITableStorageService _tableStorage;

        public ApiControllerBase(IConfigurationService configuration, ITableStorageService tableStorage)
        {
            _configuration = configuration;
            _tableStorage = tableStorage;
        }

        protected HttpResponseMessage HandleError(Exception error)
        {
            // Until we can figure out how to push to the azure storage, errors are not going to be logged
            // WriteErrorReport(error);
            Log.Error(error.Message, error);

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error.Message);
        }

        private string ConnectionString()
        {
            string connectionString = _configuration.GetStorageConnectionString();
            return connectionString;
        }

        private void WriteErrorReport(Exception error)
        {
            ErrorReport errorReport = new ErrorReport(error);
            string connectionString = ConnectionString();

            if (HttpContext.Current != null)
            {
                HttpRequest currentRequest = HttpContext.Current.Request;
                errorReport.UserHostAddress = currentRequest.UserHostAddress;
                errorReport.Url = currentRequest.Url.ToString();
                errorReport.UserAgentString = currentRequest.UserAgent;
            }

            errorReport.PartitionKey = error.GetType().Name;
            errorReport.RowKey = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
            _tableStorage.Save(connectionString, "ApiError", errorReport);
        }

        private ILog Log
        {
            get
            {
                return LogManager.GetLogger(GetType());
            }
        }
    }
}