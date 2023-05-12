using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManagerDomain.Enums;

namespace TaxiManagerDomain.Models
{
    public class Car:BaseEntity
    {
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpieryDate { get; set; }
        public List<Driver> DriversAssigned { get; set; }

        public Car() { }
        //public Car(string model, string licensePlate, DateTime expieryDate);
        public override string Print()
        {
            int assignedPercent = DriversAssigned.Count == 0 ? 0 : 100 / +DriversAssigned.Count + 1;//dali listata driversAssigned e 0, ako e nula vrakja nula, ako ne e nula vrakja procent;
            return $"{Model} with License Plate {LicensePlate} and utilize {LicensePlateExpieryDate} ";
        }
        public ExpieryStatus IsLicenseExpired()
        {
            if (DateTime.Today >= LicensePlateExpieryDate)
            {
                return ExpieryStatus.Expired;
            } 
            else if(DateTime.Today.AddMonths(3) >= LicensePlateExpieryDate)
            {
                return ExpieryStatus.Warning;
            }
            else
            {
                return ExpieryStatus.Valid;
            }

        }
    }
}
