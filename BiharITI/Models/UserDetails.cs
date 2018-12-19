using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiharITI.Models
{
    public class UserDetails
    {
        public int UserID { get; set; }
        public string DisplayName { get; set; }
        public decimal Lesson1Score { get; set; }
        public decimal Lesson2Score { get; set; }

    }
}