/* **************************************
Tuntidemo, MVVM -harjoittelua.
22.2. lisätty myös MySQL-tietokannan käyttöönottoharjoitus.

Luotu 20.2.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using Labra_12___Demo.Model;
using MySql.Data.MySqlClient;
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

        //metodi StudentViewModeliin, jolla haetaan oppilastiedot MySql-palvemilta
        public void LoadStudentsFromMysql()
        {
            try
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connStr = GetMysqlConnectionString();
                string sql = "SELECT firstname, lastname, asioid FROM student";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Labra_12___Demo.Model.Student s = new Model.Student();
                            s.FirstName = reader.GetString(0);
                            s.LastName = reader.GetString(1);
                            s.AsioID = reader.GetString(2);
                            students.Add(s);
                        }
                        Students = students;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private string GetMysqlConnectionString()
        {
            string pw = "";
            // Haetaan salasana App.Config -tiedostosta:
            pw = Labra_12___Demo.Properties.Settings.Default.salasana;
            return string.Format("Data source=mysql.labranet.jamk.fi;Initial Catalog=K8517;user=K8517;password={0}", pw);
        }
    }
}
