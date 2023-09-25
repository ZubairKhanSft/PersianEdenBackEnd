using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Entities
{
    public class FuneralPictures
    {
        public int Id { get; set; }
        public int DeceasedId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
