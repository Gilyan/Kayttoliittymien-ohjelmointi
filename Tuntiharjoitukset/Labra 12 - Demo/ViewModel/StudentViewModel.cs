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

            students.Add(new Student { FirstName = "Tanis", LastName = "Half-Elven" });
            students.Add(new Student { FirstName = "Raistlin", LastName = "Majere" });
            students.Add(new Student { FirstName = "Kitiara", LastName = "Uth Matar" });
            students.Add(new Student { FirstName = "Sturm", LastName = "Brightblade" });
            students.Add(new Student { FirstName = "Tasslehoff ", LastName = "Burrfoot" });

            Students = students;
        }
    }
}
