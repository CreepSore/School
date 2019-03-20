using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvgCalc
{
    class LDUSubjectViewModel : SubjectBase
    {

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
