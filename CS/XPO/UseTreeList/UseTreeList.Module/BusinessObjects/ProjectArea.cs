using DevExpress.Xpo;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectArea : Category {
        private Project project;
        protected override ITreeNode GetParent() {
            return project;
        }
        protected override IBindingList GetChildren() {
            return new BindingList<object>();
        }
        public ProjectArea(Session session) : base(session) { }
        public ProjectArea(Session session, string name)
            : base(session) {
            this.Name = name;
        }
        [Association("Project-ProjectAreas")]
        public Project Project {
            get {
                return project;
            }
            set {
                SetPropertyValue("Project", ref project, value);
            }
        }
    }
}
