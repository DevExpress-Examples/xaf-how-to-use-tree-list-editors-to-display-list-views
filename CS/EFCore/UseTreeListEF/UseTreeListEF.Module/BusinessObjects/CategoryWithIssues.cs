using System;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations.Schema;

namespace HowToUseTreeListEditor.Module {
    [NavigationItem]
    public abstract class CategoryWithIssues : BaseObject, ITreeNode {

        public virtual IList<Issue> Issues { get; set; } = new ObservableCollection<Issue>();

    
        private List<Issue> allIssues;
        [NotMapped]
        public IList<Issue> AllIssues {
            get {
                if (allIssues == null) {
                    allIssues = new List<Issue>();
                    CollectIssuesRecursive(this, allIssues);
                }
                return allIssues;
            }
        }
        private void CollectIssuesRecursive(CategoryWithIssues issueCategory, List<Issue> target) {
            target.AddRange(issueCategory.Issues);
            foreach (CategoryWithIssues childCategory in issueCategory.Children) {
                CollectIssuesRecursive(childCategory, target);
            }
        }
        protected abstract ITreeNode Parent {
            get;
        }
        protected abstract IBindingList Children {
            get;
        }

        public virtual string Name { get; set; }
        #region ITreeNode
        IBindingList ITreeNode.Children {
            get {
                return Children;
            }
        }
        string ITreeNode.Name {
            get {
                return Name;
            }
        }
        ITreeNode ITreeNode.Parent {
            get {
                return Parent;
            }
        }
        #endregion
    }
}
