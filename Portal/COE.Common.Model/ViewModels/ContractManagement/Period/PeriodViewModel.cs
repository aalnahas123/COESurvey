using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.ContractManagement.Period
{
    public class PeriodViewModel
    {
        public PeriodViewModel()
        {
            AcademicYearTermPeriod = new AcademicYearTermPeriod();
            QualificationPeriod = new QualificationPeriod();
        }
        public AcademicYearTermPeriod AcademicYearTermPeriod { get; set; }
        public QualificationPeriod QualificationPeriod { get; set; }
    }
}
