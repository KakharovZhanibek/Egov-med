using Egov.Medical.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;

namespace Egov.Medical.Lib.Model
{
    public class Pation : IPation
    {
        public int PationId { get; set; }
        public DateTime DoB { get; set; }

        public string FullName { get; set; }

        public string IIN { get; set; }

        public Gender Sex { get; set; }

        public int UserId { get; set; }

        public int Age()
        {
            return (DateTime.Now.Year - DoB.Year);
        }

        public int MedOrganizationId { get; set; } = 0;
        public MedOrganization MedOrganization { get; set; }
    }
}
