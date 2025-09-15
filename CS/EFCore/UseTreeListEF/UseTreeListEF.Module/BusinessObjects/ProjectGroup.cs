using DevExpress.Persistent.Base.General;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectGroup : Category {
        protected override ITreeNode GetParent() {
            return null;
        }
        BindingList<Project> children;
        protected override IBindingList GetChildren() {
            if (children == null) {
                children = new BindingList<Project>(Projects);
            }
            return children;
        }
        public virtual IList<Project> Projects { get; set; } = new ObservableCollection<Project>();
    }
}
