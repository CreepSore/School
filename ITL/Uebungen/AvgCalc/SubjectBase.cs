using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AvgCalc
{
    public abstract class SubjectBase
    {

        public string Name { get; set; }

        public int Grade { get {
                int grde;
                if(!int.TryParse(grade, out grde))
                    return 0;
                if (this.SubjectGroup != null && this.SubjectGroup.Id == 40 && grde > 1)
                    grde--;
                return grde;
            } set { grade = value.ToString(); } }
        public string grade { get; set; }
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
