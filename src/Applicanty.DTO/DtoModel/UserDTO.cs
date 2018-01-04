using Applicanty.Core.Model;
using AutoMapper;

namespace Applicanty.DTO.DtoModel
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
