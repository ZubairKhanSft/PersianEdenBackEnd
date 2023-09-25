using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Models
{
    public class UserAddModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
