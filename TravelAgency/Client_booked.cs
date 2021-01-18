using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgency
{
    public enum Status { Adult, Child }
    public class Client_booked : AClient, ICloneable
    {
        Status status;
        public Status Status { get => status; set => status = value; }
        public Client_booked()
        {

        }
        public Client_booked(string firstname, string surname, Status status)
        {
            this.Firstname = firstname;
            this.Surname = surname;
            this.Status = status;
        }
        public override string ToString()
        {
            return Firstname + " " + Surname + "\n"
                + "Status: " + Status;
        }

        
            public object Clone()
            {
                Client_booked clone = new Client_booked(this.Firstname, this.Surname, this.status);

                return clone;

            }
        
    }
}
