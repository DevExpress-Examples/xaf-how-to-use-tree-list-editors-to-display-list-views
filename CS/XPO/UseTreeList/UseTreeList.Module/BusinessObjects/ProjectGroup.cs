using DevExpress.Xpo;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectGroup : Category {
        protected override ITreeNode GetParent() {
            return null;
        }
        protected override IBindingList GetChildren() {
            return Projects;
        }
        public ProjectGroup(Session session) : base(session) { }
        public ProjectGroup(Session session, string name)
            : base(session) {
            this.Name = name;
        }
        [Association("ProjectGroup-Projects"), Aggregated]
        public XPCollection<Project> Projects {
            get {
                return GetCollection<Project>("Projects");
            }
        }
    }
}
