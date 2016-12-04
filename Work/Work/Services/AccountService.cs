using System;
using System.Collections.Generic;
using System.Linq;
using Work.DataAccess;
using System.Web;

namespace Work.Services
{
    public class AccountService
    {
        public bool Login(string login, string password)
        {
            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
                return user != null;
            }
        }
    }
}