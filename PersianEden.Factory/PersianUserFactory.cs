
using PersianEden.Entities;
using PersianEden.Models;
using PersianEden.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Factory
{
    public class PersianUserFactory
    {
        public static PersianEdenUser Create(UserAddModel model, string header)
        {
            var data = new PersianEdenUser
            {
                UserId = model.UserId,
                CompanyId = Int32.Parse(header),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Email = model.Email,
                Status = Constants.RecordStatus.Active,
                CreatedBy = "0",
                CreatedOn = DateTime.Now
            };
            return data;
        }
    }
}
