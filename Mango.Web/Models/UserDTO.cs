using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
    public class UserDTO
    {
        public string Id { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
