using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class SubProgramSearchViewModel : BaseSearchViewModel
    {
        public SubProgramSearchViewModel()
        {
        }
        public int ID { get; set; }

        public string SubProgramName { get; set; }

        public string ProgramSpecializationName { get; set; }

        public int? ProgramSpecializationID { get; set; }

        public StaticPagedList<SubProgram> Items { get; set; }
    }
}
