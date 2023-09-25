using PersianEden.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public Constants.RecordStatus Status { get; set; }
    }
}
