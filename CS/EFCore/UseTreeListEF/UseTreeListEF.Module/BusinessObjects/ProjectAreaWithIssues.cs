using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectAreaWithIssues : CategoryWithIssues {
        protected override ITreeNode Parent {
            get {
                return ProjectWithIssues;
            }
        }
        protected override IBindingList Children {
            get {
                return new BindingList<object>();
            }
        }
        public virtual ProjectWithIssues ProjectWithIssues { get; set; }
    }
}
