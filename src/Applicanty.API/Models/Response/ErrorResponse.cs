using System;
using System.Text;

namespace Applicanty.API.Models.Response
{
    public class ErrorResponse
    {
        public string Message { get; set; }

        public ErrorResponse(Exception ex)
        {
            StringBuilder sb = new StringBuilder(ex.Message);

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;

                sb.AppendLine($"\t\t\t--->>> {ex.Message}");
            }

            Message = sb.ToString();
        }
        
        public ErrorResponse(string message)
        {
            Message = message;
        }
    }
}
