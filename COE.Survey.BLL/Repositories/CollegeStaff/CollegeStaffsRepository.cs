using COE.Common.Model;
using COE.Common.Model.Enums;
using System;
using System.Linq;

namespace COE.Survey.BLL.Repositories
{
    public partial class CollegeStaffsRepository
    {
        /// <summary>
        /// Add new College Staff
        /// </summary>
        /// <param name="CollegeStaff"></param>
        /// <returns></returns>
        public virtual int Save(CollegeStaff module)
        {
            try
            {
                //check Name Dublication
                bool isDublicated = CheckDuplication(module);
                if (!isDublicated)
                {
                    var unitOfWork = new COEUoW();
                    unitOfWork.CollegeStaff.Add(module);
                    unitOfWork.Save();
                    return (int)Common.Model.Enums.Enum.SaveStaus.Saved;
                }
                else
                {
                    return (int)Common.Model.Enums.Enum.SaveStaus.AlreadyExist;
                }
            }
            catch (Exception ex)
            {
                return (int)Common.Model.Enums.Enum.SaveStaus.ItemError;
                throw ex;
            }
        }

 

        /// <summary>
        /// Delete an course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public virtual bool Delete(int id)
        //{
        //    if (id <= 0)
        //        throw new ArgumentNullException("ID");

        //    try
        //    {
        //        using (var unit = new COEUoW())
        //        {
        //            //delete all term courses ,before deleting the course
        //            var termCourses = this.GetCourseOpenTermsById(id);
        //            foreach (var termCourse in termCourses)
        //            {
        //                unit.TermCourse.DeleteById(termCourse.ID);
        //            }
        //            if (termCourses != null && termCourses.Count > 0)
        //                unit.Save();

        //            //delete the course
        //            bool deleted = unit.Course.DeleteById(id);
        //            unit.Save();
        //            return deleted;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// check if this course already existed , before creating new course
        /// the same college and the same course code
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns>true:if course is duplicated , false: otherwise  </returns>
        public virtual bool CheckDuplication(CollegeStaff staff)
        {
            bool isDuplicated = false;
            var unitOfWork = new COEUoW();
            var result = unitOfWork.CollegeStaff.GetByQuery(x => x.Email.ToLower()== staff.Email.Trim().ToLower()).ToList();
            if (result.Count > 0)
            {
                isDuplicated = true;
            }
            return isDuplicated;
        }

    }
}
