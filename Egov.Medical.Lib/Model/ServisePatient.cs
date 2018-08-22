using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Egov.Medical.Lib.Model
{
    public class ServisePatient
    {
        public static List<Pation> GetPatients()
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db"))
            {
                return db.GetCollection<Pation>("Patient").FindAll().ToList();
            }
        }
        public static bool AddPatient(Pation patient)
        {
            try
            {
                using (var db = new LiteDatabase(@"EgovMedDB.db"))
                {
                    var collection = db.GetCollection<Pation>("Patient");
                    collection.Insert(patient);
                }
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public static void AddMedOrgToPatient(int userId, int medOrganizationId)
        {
            using (var db = new LiteDatabase(@"EgovMedDB.db"))
            {
                var collection = db.GetCollection<Pation>("Patient");
                Pation p = collection.FindOne(f => f.PationId == userId);
                p.MedOrganizationId = medOrganizationId;
                collection.Update(p);
            }
        }
    }
}
