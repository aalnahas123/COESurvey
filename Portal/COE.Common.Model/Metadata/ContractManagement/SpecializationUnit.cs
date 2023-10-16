using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    //public partial class SpecializationUnit : System.IEquatable<SpecializationUnit>
    //{
    //    public bool Equals(SpecializationUnit other)
    //    {
    //        if (other == null)
    //            return false;

    //        return this.UnitID == other.UnitID && this.Code == other.Code;
    //    }

    //    public override bool Equals(object obj) => Equals(obj as SpecializationUnit);

    //}

    public partial class SpecializationUnit : System.IEquatable<SpecializationUnit>
    {
        public bool Equals(SpecializationUnit other)
        {
            if (other == null)
                return false;

            return this.UnitID == other.UnitID; //&& this.Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as SpecializationUnit);

    }
}
