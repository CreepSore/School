using BSWPFLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvgCalc
{
    class SubjectCollection : BS2NotifyPropertyBase
    {

        #region Members
        protected List<SubjectBase> subjects;
        #endregion

        #region Properties
        protected SubjectBase curSubject { get; set; }
        public SubjectBase CurSubject { get { return curSubject; } set { curSubject = value; OnPropertyChanged();  } }

        public ICommand NextSubjectCmd { get; protected set; }
        public ICommand PrevSubjectCmd { get; protected set; }
        #endregion

        public SubjectCollection()
        {
            subjects = new List<SubjectBase>()
            {
                new LDUSubjectViewModel()
                {
                    Name = "INF",
                    Grade = "1",
                    IsExempted = false
                },
                new LDUSubjectViewModel()
                {
                    Name = "APHM",
                    Grade = "1",
                    IsExempted = false
                },

                new LEUSubjectViewModel()
                {
                    Name = "AWL",
                    Grade = "1",
                    IsExempted = false
                },
                new EmptySubnetViewModel()
                {
                    Name = "DUK",
                    Grade = "1",
                    IsExempted = false
                },
            };

            CurSubject = subjects.FirstOrDefault();

            NextSubjectCmd = new BS2Command(OnNextSubject);
            PrevSubjectCmd = new BS2Command(OnPrevSubject);
        }

        public void OnNextSubject(object sender)
        {
            int currentIndex = this.subjects.IndexOf(this.CurSubject);
            if (currentIndex < subjects.Count - 1)
            {
                this.CurSubject = subjects[currentIndex + 1];
            }
        }

        public void OnPrevSubject(object sender)
        {
            int currentIndex = this.subjects.IndexOf(this.CurSubject);
            if (currentIndex > 0)
            {
                this.CurSubject = subjects[currentIndex - 1];
            }
        }
    }
}
