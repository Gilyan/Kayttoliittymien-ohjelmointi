/* **************************************
Tuntidemo, MVVM -harjoittelua.

Luotu 20.2.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labra_12___Demo.Model
{
    public class Student
    {
        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string FullName
        {
            get
            {
                return firstname + " " + lastname;
            }
        }
    }
}
