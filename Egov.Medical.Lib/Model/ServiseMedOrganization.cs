using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Egov.Medical.Lib.Model
{
    public class ServiseMedOrganization
    {
        public static List<MedOrganization> GetMedOrganizations()
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db"))
            {
                List<MedOrganization> ogs= db.GetCollection<MedOrganization>("MedOrganization").FindAll().ToList();
                for (int i = 0; i < ogs.Count; i++)
                {
                    ogs[i].Patients= db.GetCollection<Pation>("Patient")
                        .FindAll()
                        .Where(f => f.MedOrganizationId== ogs[i].MedOrganizationId)
                        .ToList();
                }
                return ogs;
            }
        }

        public static bool AddMedOrg(MedOrganization org)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db"))
                {
                    var collection = db.GetCollection<MedOrganization>("MedOrganization");
                    collection.Insert(org);
                }
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }

}
