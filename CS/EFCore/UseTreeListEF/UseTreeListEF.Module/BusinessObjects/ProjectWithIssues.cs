using DevExpress.Persistent.Base.General;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectWithIssues : CategoryWithIssues {
        protected override ITreeNode GetParent() {
            return ProjectGroupWithIssues;
        }
        BindingList<ProjectAreaWithIssues> children;
        protected override IBindingList GetChildren() {
            if (children == null) {
                children = new BindingList<ProjectAreaWithIssues>(ProjectAreasWithIssues);
            }
            return children;
        }
        public virtual ProjectGroupWithIssues ProjectGroupWithIssues { get; set; }
        public virtual IList<ProjectAreaWithIssues> ProjectAreasWithIssues { get; set; } = new ObservableCollection<ProjectAreaWithIssues>();
    }
}