using COE.Common.DAL;
using COE.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Survey.BLL.Repositories
{
    public partial class SpecializationsRepository
    {
        public virtual List<Specialization> GetListByUser(Guid userID)
        {
            return this.DbSet.Where(s =>
                s.UserSpecialization.Any(us => us.UserDisplayID == userID)). 
                OrderBy(s => s.Name).ToList();
        }
    }
}
