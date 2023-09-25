using PersianEden.Dtos.Deceased;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Dtos.HebrewMonths
{
    public class HebrewMonthsDto
    {
        public int Id { get; set; }
        public string HebrewMonthsName { get; set; }
        public List<DeceasedPeopleDetailDto> DeceasedPeople { get; set; }

    }
}
