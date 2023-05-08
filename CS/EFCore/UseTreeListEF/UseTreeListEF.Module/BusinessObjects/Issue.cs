using System;


using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl.EF;

namespace HowToUseTreeListEditor.Module {
    [DefaultClassOptions]
    public class Issue : BaseObject, ICategorizedItem {
        public virtual CategoryWithIssues Category { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Description { get; set; }
        ITreeNode ICategorizedItem.Category {
            get {
                return Category;
            }
            set {
                Category = (CategoryWithIssues)value;
            }
        }
    }


}
