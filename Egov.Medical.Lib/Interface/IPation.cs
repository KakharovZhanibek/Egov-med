using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;

namespace Egov.Medical.Lib.Interface
{
    
    public interface IPation
    {
        int UserId { get; set; }
        string FullName { get; set; }
        DateTime DoB { get; set; }
        Gender Sex { get; set; }
        string IIN { get; set; }
        int Age();
    }
}
