using System;

namespace Applicanty.Core.Dto
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsArchived { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
