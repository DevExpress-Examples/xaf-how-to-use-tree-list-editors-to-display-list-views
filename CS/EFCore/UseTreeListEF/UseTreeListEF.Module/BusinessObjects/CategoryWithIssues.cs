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

namespace HowToUseTreeListEditor.Module {
    [NavigationItem]
    public abstract class CategoryWithIssues : BaseObject, ITreeNode {

        public virtual IList<Issue> Issues { get; set; } = new ObservableCollection<Issue>();

        private List<Issue> allIssues;
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
    public class ProjectGroupWithIssues : CategoryWithIssues {
        protected override ITreeNode Parent {
            get {
                return null;
            }
        }
        BindingList<ProjectWithIssues> children;
        protected override IBindingList Children {
            get {
                if (children == null) {
                    children = new BindingList<ProjectWithIssues>(ProjectsWithIssues);
                }
                return children;
            }
        }

        public ProjectGroupWithIssues(string name) {

            this.Name = name;
        }

        public virtual IList<ProjectWithIssues> ProjectsWithIssues { get; set; } = new ObservableCollection<ProjectWithIssues>();
    }

    public class ProjectWithIssues : CategoryWithIssues {
        private ProjectGroupWithIssues projectGroupWithIssues;
        protected override ITreeNode Parent {
            get {
                return projectGroupWithIssues;
            }
        }
        BindingList<ProjectAreaWithIssues> children;
        protected override IBindingList Children {
            get {
                if (children == null) {
                    children = new BindingList<ProjectAreaWithIssues>(ProjectAreasWithIssues);
                }
                return children;
            }
        }

        public ProjectWithIssues(string name) {
            this.Name = name;
        }

        public virtual ProjectGroupWithIssues ProjectGroupWithIssues { get; set; }

        public IList<ProjectAreaWithIssues> ProjectAreasWithIssues { get; set; } = new ObservableCollection<ProjectAreaWithIssues>();
    }

    public class ProjectAreaWithIssues : CategoryWithIssues {
        private ProjectWithIssues projectWithIssues;
        protected override ITreeNode Parent {
            get {
                return projectWithIssues;
            }
        }
        protected override IBindingList Children {
            get {
                return new BindingList<object>();
            }
        }

        public ProjectAreaWithIssues(string name) {
            this.Name = name;
        }

        public virtual ProjectWithIssues ProjectWithIssues { get; set; }
    }
}
