using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvgCalc
{
    public abstract class SubjectBase
    {

        public string Name { get; set; }
        public string Grade { get; set; }
        public bool IsExempted { get; set; }

        public bool HasGroups {
            get {
                return this.SubjectGroups.Count > 0 ? true : false;
            }
        }

        public SubjectGroupModel SubjectGroup { get; set; }

        protected List<SubjectGroupModel> subjectGroups;
        public List<SubjectGroupModel> SubjectGroups
        {
            get { return subjectGroups; }
        }
        
    }
}
