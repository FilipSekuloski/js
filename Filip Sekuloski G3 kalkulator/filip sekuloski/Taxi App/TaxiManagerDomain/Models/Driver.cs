using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManagerDomain.Enums;

namespace TaxiManagerDomain.Models
{
    public class Driver:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public Shift Shift { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpieryDate  { get; set; }
        public Car _car;//tuka praime istanca od Car
        //
        public Car Car//tuka doagjame do objektite vo klasata Car
        {
            get => _car;
            set// mora prvo da imame instanca na driver, pa da iskoristime seterot
            {
                if(value != null && _car ==null)
                {
                    value.DriversAssigned.Add(this); //this e instanca na potencijalniot objekt shto rabotime, this se odnesuva na driverot///so value pristapuvame do kasata car
                }
                else if(value == null && _car !=null)//this se odnesuva na driverot, na instancata so koja rabotime
                {
                    _car.DriversAssigned.Remove(this);
                }
                _car = value;
            }
        }
        public Driver()
        {
        }
        public Driver(string firstName,string lastName,Shift shift, 
                        string license, DateTime expieryDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            License = license;
            LicenseExpieryDate = expieryDate;
        }
        public override string Print()
        {
            var model = Car == null ? "/" : Car.Model;//ako na istancata od Driver nema kola, model e /, ako ima e string na istancata od kola, kje go dobieme modelot;
            //sega istoto so if else
            //string model1 = "";
            //if (Car == null)
            //{
            //    model1 = "/";
            //}
            //else
            //{
            //    model1=Car.Model;
            //}
            return $"{FullName} driving in the {Shift} shift with a {model}";
        }
    }
}
