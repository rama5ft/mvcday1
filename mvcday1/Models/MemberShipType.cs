using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcday1.Models
{
    public class MemberShipType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public short Duration { get; set; }
        public double SignUpFee { get; set; }
        public short Discount { get; set; }
    }
}