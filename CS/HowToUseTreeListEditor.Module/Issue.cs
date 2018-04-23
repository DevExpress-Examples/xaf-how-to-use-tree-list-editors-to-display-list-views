using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;

namespace HowToUseTreeListEditor.Module {
    [DefaultClassOptions]
    public class Issue : BaseObject, ICategorizedItem {
        private CategoryWithIssues categoryWithIssues;
        private string subject;
        private string description;
        public Issue(Session session) : base(session) { }
        public Issue(Session session, string subject)
            : base(session) {
            this.subject = subject;
        }
        [Association("CategoryWithIssues-Issues")]
        public CategoryWithIssues Category {
            get {
                return categoryWithIssues;
            }
            set {
                SetPropertyValue("Category", ref categoryWithIssues, value);
            }
        }
        public string Subject {
            get {
                return subject;
            }
            set {
                SetPropertyValue("Subject", ref subject, value);
            }
        }
        public string Description {
            get {
                return description;
            }
            set {
                SetPropertyValue("Description", ref description, value);
            }
        }
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
