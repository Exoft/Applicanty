using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Applicanty.Core.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<IdentityError> IdentityErrors { get; set; }

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

        public ErrorResponse(IEnumerable<IdentityError> errors)
        {
            IdentityErrors = errors;
        }
    }
}
