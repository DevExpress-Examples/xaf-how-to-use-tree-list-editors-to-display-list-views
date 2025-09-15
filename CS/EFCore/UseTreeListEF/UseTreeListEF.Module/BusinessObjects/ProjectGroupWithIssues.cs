using DevExpress.Persistent.Base.General;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectGroupWithIssues : CategoryWithIssues {
        protected override ITreeNode GetParent() {
            return null;
        }
        BindingList<ProjectWithIssues> children;
        protected override IBindingList GetChildren() {
            if (children == null) {
                children = new BindingList<ProjectWithIssues>(ProjectsWithIssues);
            }
            return children;
        }
        public virtual IList<ProjectWithIssues> ProjectsWithIssues { get; set; } = new ObservableCollection<ProjectWithIssues>();
    }
}
