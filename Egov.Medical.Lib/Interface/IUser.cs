using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egov.Medical.Lib.Interface
{
    interface IUser
    {
        
        string login { get; set; }
        string password { get; set; }
        int role { get; set; }
        DateTime CreatDate { get; set; }
        string WhoCreate { get; set; }
        bool IsBlock { get; set; }
        void BlockUser(bool status);
    }
}
