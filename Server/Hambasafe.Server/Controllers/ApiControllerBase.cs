using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Hambasafe.Server.Models;
//using Hambasafe.Server.Services.Configuration;
//using Hambasafe.Server.Services.TableStorage;
using log4net;

namespace Hambasafe.Server.Controllers
{
    public class ApiControllerBase : ApiController
    {
        //private readonly IConfigurationService _configuration;
      //  private readonly ITableStorageService _tableStorage;
        //public ApiControllerBase(IConfigurationService configuration, ITableStorageService tableStorage)
        //{

        //    _configuration = configuration;
        //    _tableStorage = tableStorage;
        //}

        //protected string ConnectionString()
        //{
        //    string connectionString = _configuration.GetStorageConnectionString();
        //    return connectionString;
        //}

        //protected void WriteErrorReport(Exception error)
        //{
        //    ErrorReport errorReport = new ErrorReport(error);
        //    string connectionString = ConnectionString();

        //    if (HttpContext.Current != null)
        //    {
        //        HttpRequest currentRequest = HttpContext.Current.Request;
        //        errorReport.UserHostAddress = currentRequest.UserHostAddress;
        //        errorReport.Url = currentRequest.Url.ToString();
        //        errorReport.UserAgentString = currentRequest.UserAgent;
        //    }

        //    errorReport.PartitionKey = error.GetType().Name;
        //    errorReport.RowKey = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
        //    _tableStorage.Save(connectionString, "ApiError", errorReport);
        //}

        protected void HandleError(Exception error)
        {
        //    WriteErrorReport(error);
        //    Log.Error(error.Message, error);
        //    throw new HttpResponseException(new HttpResponseMessage()
        //    {
        //        StatusCode = HttpStatusCode.InternalServerError,
        //        Content = new StringContent(error.Message)
        //    });
        }
        protected ILog Log
        {
            get
            {
                return LogManager.GetLogger(GetType());
            }
        }
    }
}