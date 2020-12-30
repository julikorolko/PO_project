﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektPO
{public enum Status { adult,child}
    class Client_booked : AClient
    {
        
        
        Status status;
        public Status Status { get => status; set => status = value; }
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
    }
}