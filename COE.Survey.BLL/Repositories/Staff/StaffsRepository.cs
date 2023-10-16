using COE.Common.Localization;
using COE.Common.Model;
using COE.Common.Model.Enums;
using Commons.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace COE.Survey.BLL.Repositories
{
    public partial class CollegeStaffsRepository
    {
        //public virtual ReturnResult Search(CollegeStaff model, List<int> CurrentUserColleges)
        //{
        //    var result = new ReturnResult();

        //    if (CurrentUserColleges.Count > 0)
        //    {
        //        var staffUsers = this.GetByQuery(w => CurrentUserColleges.Contains(w.College.ID));

        //        if (!string.IsNullOrEmpty(model.Name))
        //        {
        //            staffUsers = staffUsers.Where(x => x.Name.ToLower().Contains(model.Name));
        //        }
        //        if (!string.IsNullOrEmpty(model.Email))
        //        {
        //            staffUsers = staffUsers.Where(x => x.Email.ToLower().Contains(model.Email.ToLower()));
        //        }
        //        if (model.College > 0)
        //        {
        //            staffUsers = staffUsers.Where(x => x.CollegeID == model.College);
        //        }
        //        if (model.UserType > 0)
        //        {
        //            staffUsers = staffUsers.Where(x => x.TypeID == model.UserType);
        //        }
        //        if (model.VisaType > 0)
        //        {
        //            staffUsers = staffUsers.Where(x => x.VisaTypeID == model.VisaType);
        //        }
        //        if (model.Specialization > 0)
        //        {
        //            staffUsers = staffUsers.Where(x => x.SpesializationID == model.Specialization);
        //        }

        //        var UsersList = staffUsers
        //            .GetPaged(x => x.ID, true, model.PageNumber, BLL.AppSettings.DefaultPagerPageSize);
        //        result = UsersList;
        //    }
        //    return result;
        //}
        public virtual ReturnResult Insert(CollegeStaff model)
        {
            var result = new ReturnResult();

            if (this.DbSet.Any(r => r.Name.ToLower().Trim() == model.Name.ToLower().Trim())) result.ModelState.AddModelError("Name", SharedResources.NameAddedBefore);
            if (!result.ModelState.IsValid) return result;

            this.Add(model);
            return result;
        }

        public virtual ReturnResult Edit(CollegeStaff model)
        {
            var result = new ReturnResult();

            if (this.DbSet.Any(r => r.Name.ToLower().Trim() == model.Name.ToLower().Trim() && r.ID != model.ID)) result.ModelState.AddModelError("Name", SharedResources.NameAddedBefore);
            if (!result.ModelState.IsValid) return result;

            this.Update(model.ID, model);
            return result;
        }

    }
}
