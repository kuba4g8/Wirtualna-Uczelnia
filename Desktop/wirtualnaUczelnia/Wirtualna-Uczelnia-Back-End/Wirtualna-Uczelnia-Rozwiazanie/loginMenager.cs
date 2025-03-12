using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualna_Uczelnia
{
    public class loginMenager
    {
        private sqlMenager sqlMenager;


        public loginMenager()
        {
            sqlMenager = new sqlMenager();
        }

        //loggedUser? -> oznacza ze obiekt moze byc null!
        public LoggedUser? tryLogin(string email, string haslo)
        {
            List<LoggedUser> usersList = new List<LoggedUser>(); //lista wszystkich uzytkownikow z bazy danych

            usersList = sqlMenager.loadDataToList<LoggedUser>("SELECT * FROM `logowanie`");

            foreach (var user in usersList)
            {
                if (user.email == email && user.haslo == haslo)
                {
                    return user; //zalogowano
                }
            }
            
            return null;
        }
    }
    //obiekt przetrzymujace dane do logowania
    public class LoggedUser
    {
        public int loginID { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public bool isTeacher { get; set; }
        public bool isAdmin { get; set; }
    }
}
