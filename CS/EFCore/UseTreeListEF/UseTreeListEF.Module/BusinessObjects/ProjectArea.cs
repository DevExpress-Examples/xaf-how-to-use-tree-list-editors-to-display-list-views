using System;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectArea : Category {
        protected override ITreeNode Parent {
            get {
                return Project;
            }
        }
        protected override IBindingList Children {
            get {
                return new BindingList<object>();
            }
        }
      
        public virtual Project Project { get; set; }
    }
}
