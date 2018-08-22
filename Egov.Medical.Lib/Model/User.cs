using Egov.Medical.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;

namespace Egov.Medical.Lib.Model
{
    public class User : IUser, IPation
    {
        public DateTime CreatDate { get; set; }

        public DateTime DoB { get; set; }

        public string FullName { get; set; }

        public string IIN { get; set; }

        public bool IsBlock { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public int role { get; set; }

        public Gender Sex { get; set; }

        public int UserId { get; set; }

        public string WhoCreate { get; set; }

        public int Age()
        {
            return (DateTime.Now.Year - DoB.Year);
        }

        public void BlockUser(bool status)
        {
            //not realise
        }
    }
}
