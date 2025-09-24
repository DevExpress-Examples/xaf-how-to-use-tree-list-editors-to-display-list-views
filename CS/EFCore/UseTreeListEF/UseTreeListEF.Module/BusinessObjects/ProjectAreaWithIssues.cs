using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectAreaWithIssues : CategoryWithIssues {
        protected override ITreeNode GetParent() {
            return ProjectWithIssues;
        }
        protected override IBindingList GetChildren() {
            return new BindingList<object>();
        }
        public virtual ProjectWithIssues ProjectWithIssues { get; set; }
    }
}
