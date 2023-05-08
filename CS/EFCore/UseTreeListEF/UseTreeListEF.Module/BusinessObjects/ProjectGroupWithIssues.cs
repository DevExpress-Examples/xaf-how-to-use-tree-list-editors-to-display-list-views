using DevExpress.Persistent.Base.General;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectGroupWithIssues : CategoryWithIssues {
        protected override ITreeNode Parent {
            get {
                return null;
            }
        }
        BindingList<ProjectWithIssues> children;
        protected override IBindingList Children {
            get {
                if (children == null) {
                    children = new BindingList<ProjectWithIssues>(ProjectsWithIssues);
                }
                return children;
            }
        }
        public virtual IList<ProjectWithIssues> ProjectsWithIssues { get; set; } = new ObservableCollection<ProjectWithIssues>();
    }
}
