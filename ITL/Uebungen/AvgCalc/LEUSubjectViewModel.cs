using System.Collections.Generic;
using System.Linq;

namespace AvgCalc
{
    public class LEUSubjectViewModel : SubjectBase
    {

        public LEUSubjectViewModel()
        {
            subjectGroups = new List<SubjectGroupModel>()
            {
                new SubjectGroupModel {Id = 10, Name = "1"},
                new SubjectGroupModel {Id = 20, Name = "2"},
            };

            SubjectGroup = subjectGroups.FirstOrDefault();
        }

    }
}
