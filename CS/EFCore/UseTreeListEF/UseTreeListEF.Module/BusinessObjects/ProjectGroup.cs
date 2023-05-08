using System;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HowToUseTreeListEditor.Module {
    public class ProjectGroup : Category {
        protected override ITreeNode Parent {
            get {
                return null;
            }
        }
        BindingList<Project> children;
        protected override IBindingList Children {
            get {
                if (children == null) {
                    children = new BindingList<Project>(Projects);
                }
                return children;
            }
        }

 
        public virtual IList<Project> Projects { get; set; }= new ObservableCollection<Project>();
    }
}
