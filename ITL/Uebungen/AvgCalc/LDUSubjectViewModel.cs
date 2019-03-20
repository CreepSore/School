using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvgCalc
{
    class LDUSubjectViewModel : SubjectBase
    {
        public int GradeForAveraging
        {
            get
            {
                return SubjectGroup.Name == "V" ? (Grade > 1 ? Grade - 1 : Grade) : Grade;
            }
        }
        public LDUSubjectViewModel()
        {
            subjectGroups = new List<SubjectGroupModel>()
            {
                new SubjectGroupModel {Id = 30, Name = "N"},
                new SubjectGroupModel {Id = 40, Name = "V"}
            };

            SubjectGroup = subjectGroups.FirstOrDefault();
        }

    }
}
