using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class BatchSearchViewModel : BaseSearchViewModel
    {
        public BatchSearchViewModel()
        {
        }
        public int ID { get; set; }

        //[Display(Name = "Batch_BatchName", ResourceType = typeof(MetaData))]
        public string BatchName { get; set; }

        //[Display(Name = "Batch_BatchCode", ResourceType = typeof(MetaData))]
        public string BatchCode { get; set; }

        //[Display(Name = "SubProgram_ID", ResourceType = typeof(MetaData))]
        public int? SubProgramID { get; set; }

        //[Display(Name = "CollegeSpecialization_ID", ResourceType = typeof(MetaData))]
        public int? CollegeSpecializationID { get; set; }

        public StaticPagedList<Batch> Items { get; set; }
       
    }
}
