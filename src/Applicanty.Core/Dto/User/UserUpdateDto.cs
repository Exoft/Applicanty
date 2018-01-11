using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Core.Dto
{
    public class UserUpdateDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
