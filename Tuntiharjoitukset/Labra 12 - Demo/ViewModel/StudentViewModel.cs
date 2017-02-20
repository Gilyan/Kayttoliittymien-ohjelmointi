/* **************************************
Tuntidemo, MVVM -harjoittelua.

Luotu 20.2.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using Labra_12___Demo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Labra_12___Demo.ViewModel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }
        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            // Lisätään esimerkin vuoksi muutama opiskelija, oikeassa sovelluksessa haettaisiin esiin tietokannasta

            students.Add(new Student { FirstName = "Tanis", LastName = "Half-Elven", AsioID = "A1234" });
            students.Add(new Student { FirstName = "Raistlin", LastName = "Majere", AsioID = "A1238" });
            students.Add(new Student { FirstName = "Kitiara", LastName = "Uth Matar", AsioID = "A1134" });
            students.Add(new Student { FirstName = "Sturm", LastName = "Brightblade", AsioID = "A1230" });
            students.Add(new Student { FirstName = "Tasslehoff ", LastName = "Burrfoot", AsioID = "A2234" });

            Students = students;
        }
    }
}
