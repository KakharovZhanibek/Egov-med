using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egov.Medical.Lib.Model
{
    public enum StatusOFAutorization { status01, status02, status03 }
    public class ServiseUser
    {
        public static bool Registration(User user)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db"))
                {
                    LiteCollection<User> users = db.GetCollection<User>("User");
                    users.Insert(user);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }
        }
        public static bool UserIsExist(string login)
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db"))
            {
                LiteCollection<User> users = db.GetCollection<User>("User");
                User user = users.FindOne(u => u.login == login);
                if (user != null)
                    return true;
                else return false;
            }
        }
        public static StatusOFAutorization LoginOn(string login, string password,
            out User newUser)
        {
            newUser = null;

            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db"))
                {
                    LiteCollection<User> users = db.GetCollection<User>("User");
                    newUser = users.FindOne(f => f.login == login && f.password == password);
                    if (newUser != null)
                        return StatusOFAutorization.status01;
                    else
                        return StatusOFAutorization.status02;
                }
            }
            catch (Exception ex) { return StatusOFAutorization.status03; }
        }
        public static void GetAllUser()
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db"))
            {
                LiteCollection<User> users = db.GetCollection<User>("User");
                foreach (var item in users.FindAll())
                {
                    Console.WriteLine("ФИО: {0}\t{1}", item.FullName, item.CreatDate);

                }
            }
        }
        //public static LogIn(string login, string password)
        public static void BlockUser(int userId)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db"))
                {
                    LiteCollection<User> users = db.GetCollection<User>("User");

                    User user = users.FindOne(f => f.UserId == userId);
                    user.IsBlock = true;

                    users.Update(user);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void BlockUser(string login)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db"))
                {
                    LiteCollection<User> users = db.GetCollection<User>("User");

                    User user = users.FindOne(f => f.login == login);
                    user.IsBlock = true;

                    users.Update(user);
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
