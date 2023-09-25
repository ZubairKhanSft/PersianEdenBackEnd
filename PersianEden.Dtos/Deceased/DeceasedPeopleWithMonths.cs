using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Dtos.Deceased
{
    public class DeceasedPeopleWithMonths
    {
        public string Month { get; set; }
        public List<DeceasedPeopleDetailDto> DeceasedPeople { get; set; }
    }

    
}
