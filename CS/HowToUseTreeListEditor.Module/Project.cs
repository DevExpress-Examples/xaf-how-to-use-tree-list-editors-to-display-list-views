using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    public class Project : Category {
        private ProjectGroup projectGroup;
        protected override ITreeNode Parent {
            get {
                return projectGroup;
            }
        }
        protected override IBindingList Children {
            get {
                return ProjectAreas;
            }
        }
        public Project(Session session) : base(session) { }
        public Project(Session session, string name)
            : base(session) {
            this.Name = name;
        }
        [Association("ProjectGroup-Projects")]
        public ProjectGroup ProjectGroup {
            get {
                return projectGroup;
            }
            set {
                SetPropertyValue("ProjectGroup", ref projectGroup, value);
            }
        }
        [Association("Project-ProjectAreas"), Aggregated]
        public XPCollection<ProjectArea> ProjectAreas {
            get {
                return GetCollection<ProjectArea>("ProjectAreas");
            }
        }
    }


}
