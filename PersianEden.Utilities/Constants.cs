using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Utilities
{
   public class Constants
    {
        public const string DateFormat = "MM/dd/yyyy";

        public const int DefaultPageSize = 10;

        public enum RecordStatus { Created, Active, Inactive, Deleted ,Presence,Absence}


        public enum PostType { }


        public struct UserType
        {
            public const string Admin = "Administrator";
            public const string Employee = "Employee";
        }

     
        public const string SessionKeyName = "CompanyTenantId";
        public string SessionInfo_Name { get; private set; }

    }
}
