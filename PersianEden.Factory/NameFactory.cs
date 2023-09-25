using PersianEden.Entities;
using PersianEden.Models;
using System;

namespace PersianEden.Factory
{
    public class NameFactory
    {
        public static Name Create(NameModel model)
        {
            var data = new Name
            {
                FullName = model.Name
            };
        return data;
        }
    }
}
