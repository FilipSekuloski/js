using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManagerDomain.Enums;

namespace TaxiManagerDomain.Models
{
    public class User:BaseEntity
    {
        private string _username;
        public string Username
        {
            get=> _username;
            set => _username = value.ToLower();
        }
        public string Password { get; set; }
        public Role Role { get; set; }
        public override string Print()
        {
            return $"4214124";
            }
    }
}
