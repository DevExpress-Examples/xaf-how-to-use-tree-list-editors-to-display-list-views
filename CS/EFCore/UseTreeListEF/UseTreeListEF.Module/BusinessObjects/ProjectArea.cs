using System;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectArea : Category {
        private Project project;
        protected override ITreeNode Parent {
            get {
                return project;
            }
        }
        protected override IBindingList Children {
            get {
                return new BindingList<object>();
            }
        }
        public ProjectArea(string name) {
            this.Name = name;
        }
        public virtual Project Project { get; set; }
    }
}
