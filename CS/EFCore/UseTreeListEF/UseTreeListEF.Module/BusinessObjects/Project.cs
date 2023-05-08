using System;


using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HowToUseTreeListEditor.Module {
    public class Project : Category {
        private ProjectGroup projectGroup;
        protected override ITreeNode Parent {
            get {
                return projectGroup;
            }
        }
        BindingList<ProjectArea> children;
        protected override IBindingList Children {
            get {
                if (children == null) {
                    children = new BindingList<ProjectArea>(ProjectAreas);
                }
                return children;
            }
        }
        public Project(string name) {
            this.Name = name;
        }

        public virtual ProjectGroup ProjectGroup { get; set; }
        public virtual IList<ProjectArea> ProjectAreas { get; set; } = new ObservableCollection<ProjectArea>();

    }


}
