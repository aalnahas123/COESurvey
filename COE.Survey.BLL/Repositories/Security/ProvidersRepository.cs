using COE.Common.Model;
using System.Collections.Generic;
using System.Linq;


namespace COE.Survey.BLL.Repositories
{
    public partial class ProvidersRepository
    {
        public List<Provider> GetProvidersWithColleges(List<int> CurrentUserColleges)
        {
            var providersQuery = this.DbSet.Select(x => new { x.ID, x.Name, x.NameAr, CollegeList = x.College.Select(c => new { c.ID, c.Name, c.NameAr }) }).Where(pr => pr.CollegeList.Count() > 0 && pr.CollegeList.Any(cl => CurrentUserColleges.Contains(cl.ID)));
            return providersQuery.AsEnumerable().Select(P => new Provider { ID = P.ID, Name = P.Name, NameAr = string.IsNullOrEmpty(P.NameAr) ? "noname" : P.NameAr, CollegeList = P.CollegeList.Where(w => CurrentUserColleges.Contains(w.ID)).Select(c => new College { ID = c.ID, Name = c.Name, NameAr = c.NameAr }).ToList() }).ToList();
        }

    }
}
