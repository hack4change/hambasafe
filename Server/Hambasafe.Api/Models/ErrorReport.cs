//using System;
//using Microsoft.WindowsAzure.Storage.Table;

//namespace Hambasafe.Server.Models
//{
//    public class ErrorReport : TableEntity
//    {
//        public ErrorReport()
//        {
//        }

//        public ErrorReport(Exception error)
//        {
//            StackTrace = error.ToString();
//            Message = error.Message;
//            Source = error.Source;
//        }

//        public string Source { get; set; }
//        public string Message { get; set; }
//        public string StackTrace { get; set; }
//        public string UserHostAddress { get; set; }
//        public string Url { get; set; }
//        public string UserAgentString { get; set; }
//    }
//}