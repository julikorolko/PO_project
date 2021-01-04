using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektPO
{
    public abstract class AClient
    {
        string firstname;
        string surname;

        public string Firstname { get => firstname; set => firstname = value; }
        public string Surname { get => surname; set => surname = value; }
    }
}
