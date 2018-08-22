using Egov.Medical.Lib.Model;
using GeneratorName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egov.Medical.model;


namespace Egov.Medical
{
    public enum TypeMenu { type1, type2 }
    class Program
    {
        static void Main(string[] args)
        {
            ServiseProgram.PrintMenu();

            switch (ServiseProgram.GetPunctMenu())
            {
                case 1:
                    {
                        ServiseProgram.Autorization();
                    }
                    break;
                case 2:
                    {
                        if (ServiseUser.Registration(ServiseProgram.GetUserInfoForRegist()))
                        {
                            Console.Clear();
                            Console.WriteLine("register ok");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("register error");
                        }
                    }
                    break;
            }
        }
    }
}
