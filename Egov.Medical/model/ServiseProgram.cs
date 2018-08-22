using Egov.Medical.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;
namespace Egov.Medical.model
{
    public class ServiseProgram
    {
        private static User user;

        public ServiseProgram() { }
        public ServiseProgram(User u) { user = u; }

        public static void PrintMenu(TypeMenu typeMenu = TypeMenu.type1)
        {
            switch (typeMenu)
            {
                case TypeMenu.type1:
                    {
                        Console.WriteLine("1.Войти\n2.Регистрация");
                    }
                    break;
                case TypeMenu.type2:
                    {
                        Console.WriteLine("1. Список организаций");
                        Console.WriteLine("2. Добавить организацию");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("3. Список пациентов");
                        Console.WriteLine("4. Добавить пациента");
                    }
                    break;
                default:
                    break;
            }
        }

        public static int GetPunctMenu()
        {
            return Int32.Parse(Console.ReadLine());
        }

        public static User GetUserInfoForRegist()
        {
            User user = new User();
            Console.Write("{0, -40} ", "Введите ФИО:");
            user.FullName = Console.ReadLine();
            Console.Write("{0, -40} ", "Введите ИИН:");
            user.IIN = Console.ReadLine();
            Console.Write("{0, -40} ", "Введите дату рождения:");
            user.DoB = DateTime.Parse(Console.ReadLine());
            Console.Write("{0, -40} ", "Введите пол(0 - Ж, 1 - М):");
            user.Sex = (Gender)Int32.Parse(Console.ReadLine());

            Console.WriteLine("--------------------------------");
            Console.Write("{0, -40} ", "Выберете логин:");
            user.login = Console.ReadLine();
            Console.Write("{0, -40} ", "Выберете пароль:");
            user.password = Console.ReadLine();
            Console.WriteLine("--------------------------------");

            user.CreatDate = DateTime.Now;
            user.IsBlock = false;

            return user;
        }
        public static void Autorization()
        {
            int count = 3;

            do
            {
                Console.Write("введите логин: ");
                user = new User();

                user.login = Console.ReadLine();
                Console.Write("введите Пароль: ");
                user.password = Console.ReadLine();

                if (ServiseUser.UserIsExist(user.login))
                {
                    StatusOFAutorization status = ServiseUser.LoginOn(user.login, user.password, out user);

                    if (status == StatusOFAutorization.status02)
                    {
                        count--;
                        Console.WriteLine("у вас осталось {0} попыток", count);
                    }
                    else if (status == StatusOFAutorization.status01)
                    {

                        do
                        {
                            Console.Clear();
                            SetConsoleColor(string.Format("добро пожаловать, {0}", user.FullName), ConsoleColor.Green);
                            PrintMenu(TypeMenu.type2);
                            switch (GetPunctMenu())
                            {
                                case 1:
                                    {
                                        PrintMedOrg();
                                    }
                                    break;
                                case 2:
                                    {
                                        AddMedOrg();
                                    }
                                    break;

                                case 3:
                                    {
                                        PrintPatients();
                                    }
                                    break;
                                case 4:
                                    {
                                        AddPatient();
                                    }
                                    break;
                            }
                        } while (Console.ReadLine() != "back");

                        break;
                    }
                    else
                    {
                        SetConsoleColor("ошибка авторизации", ConsoleColor.Red);
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    SetConsoleColor("такого пользователя не существует", ConsoleColor.Red);
                }
            } while (count > 0);

            if (count == 0)
            {
                ServiseUser.BlockUser(user.login);
                Console.Clear();
                SetConsoleColor("вы заблокированы", ConsoleColor.Red);
            }
        }

        public static void PrintMedOrg()
        {
            foreach (MedOrganization item in ServiseMedOrganization.GetMedOrganizations())
            {
                Console.WriteLine("{0}. {1} ({2})", item.MedOrganizationId, item.NameOfOrganization, item.TelephoneNumber);
            }
        }
        public static void AddMedOrg()
        {
            MedOrganization newMedOrg = new MedOrganization();
            Console.Write("введите название мед организации: ");
            newMedOrg.NameOfOrganization = Console.ReadLine();
            Console.Write("введите адрес мед организации: ");
            newMedOrg.Address = Console.ReadLine();
            Console.Write("введите телефон мед организации: ");
            newMedOrg.TelephoneNumber = Console.ReadLine();
            if (ServiseMedOrganization.AddMedOrg(newMedOrg))
            {
                SetConsoleColor(string.Format("организация {0} добавлена", newMedOrg.NameOfOrganization), ConsoleColor.Green);
            }
            else SetConsoleColor("при добавлении возникла ошибка", ConsoleColor.Red);
        }

        public static void PrintPatients()
        {
            foreach (Pation item in ServisePatient.GetPatients())
            {
                Console.WriteLine("{0} ({1}) \t {2}", item.FullName, item.Sex, item.IIN);
            }
        }

        public static void AddPatient()
        {
            Pation newPatient = new Pation();
            Console.Write("введите ФИО: ");
            newPatient.FullName = Console.ReadLine();
            Console.Write("введите пол: ");
            newPatient.Sex = (Gender)Int32.Parse(Console.ReadLine());
            Console.Write("введите дату рождения: ");
            newPatient.DoB = DateTime.Parse(Console.ReadLine());
            Console.Write("введите ИИН: ");
            newPatient.IIN = Console.ReadLine();
            if (ServisePatient.AddPatient(newPatient))
            {
                SetConsoleColor(string.Format("пациент {0} добавлен", newPatient.FullName), ConsoleColor.Green);
            }
            else SetConsoleColor("при добавлении возникла ошибка", ConsoleColor.Red);
        }


        private static void SetConsoleColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
