using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Framework.Data;
using Commons.Framework.Globalization;
using COE.Common.Model;
using COE.Common.DAL;
using COE.Common.Model.ViewModels;

namespace COE.Survey.BLL.Repositories
{
    public partial class ModuleCategoryRepository
    {
        public virtual List<LookupViewModel> GetList()
        {

            using (var context = new COEEntities())
            {
                var moduleCategory = context.ModuleCategory.ToList().Where(x => x.IsActive = true).Select(x => new LookupViewModel
                {
                    Value = x.ID,
                    Text = x.Name
                });

                return moduleCategory.ToList();
            }

        }

    }
}
