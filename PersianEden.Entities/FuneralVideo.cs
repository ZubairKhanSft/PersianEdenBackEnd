using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Entities
{
    public class FuneralVideo
    {
        public int Id { get; set; }
        public int DeceasedId { get; set; }
        public string VideoPath { get; set; }
        public DateTime CreatedOn { get; set; }
        
    }
}
