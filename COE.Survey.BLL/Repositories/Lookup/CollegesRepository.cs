using COE.Common.DAL;
using COE.Common.Model;
using COE.Common.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace COE.Survey.BLL.Repositories
{
    public partial class CollegesRepository
    {
        public virtual List<LookupViewModel> GetListByUserId(string loginName)
        {
            using (var context = new COEEntities())
            {
                var query = (from college in context.College
                             join userCollege in context.UserCollege on college.ID equals userCollege.CollegeID
                             join user in context.UserDisplay on userCollege.UserDisplayID equals user.ID
                             where (user.LoginName == loginName)
                             orderby college.Name
                             select new LookupViewModel
                             {
                                 Value = college.ID,
                                 Text = (string.IsNullOrEmpty(college.Name)) ? college.NameAr : college.Name
                             });

                return query.ToList();
            }
        }
        public virtual List<College> GetListByUser(string loginName)
        {
            return this.DbSet.Where(c =>
                c.UserCollege.Any(uc => uc.UserDisplay.LoginName == loginName)).
                OrderBy(c => c.Name).
                ToList();
        }

        public List<College> GetCollegesWithSpecializationsByUserID(Guid userID, List<int> currentUserColleges)
        {
            var providersQuery = this.DbSet.Select(c => new
            {
                c.ID,
                c.Name,
                c.NameAr,
                c.UserCollege,
                SpecializationList = c.CollegeSpecialization.Select(cs => new
                {
                    cs.SpecializationID,
                    cs.Specialization.Name,
                    cs.Specialization.NameAr
                })
            }).Where(pr =>
                pr.SpecializationList.Count() > 0 &&
                //pr.SpecializationList.Any(sp => currentUserSpecializations.Contains(sp.SpecializationID)) &&
                pr.UserCollege.Any(uc => uc.UserDisplayID == userID) &&
                currentUserColleges.Contains(pr.ID));

            return providersQuery.AsEnumerable().Select(c => new College
            {
                ID = c.ID,
                Name = c.Name,
                NameAr = string.IsNullOrEmpty(c.NameAr) ? "noname" : c.NameAr,
                SpecializationsList = c.SpecializationList.Select(s =>
                     new Specialization
                     {
                         ID = s.SpecializationID,
                         Name = s.Name,
                         NameAr = s.NameAr
                     }).ToList()
            }).ToList();
        }
    }
}
