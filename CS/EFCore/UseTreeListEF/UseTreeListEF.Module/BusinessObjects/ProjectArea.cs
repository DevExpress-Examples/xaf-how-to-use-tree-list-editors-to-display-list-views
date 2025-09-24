using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectArea : Category {
        protected override ITreeNode GetParent() {
            return Project;
        }
        protected override IBindingList GetChildren() {
            return new BindingList<object>();
        }
        public virtual Project Project { get; set; }
    }
}
