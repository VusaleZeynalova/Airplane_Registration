using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PasportNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
