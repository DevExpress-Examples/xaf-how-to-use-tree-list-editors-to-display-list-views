using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    [NavigationItem]
    public abstract class CategoryWithIssues : BaseObject, ITreeNode {
        [Association("CategoryWithIssues-Issues")]
        public XPCollection<Issue> Issues {
            get {
                return GetCollection<Issue>("Issues");
            }
        }
        private XPCollection<Issue> allIssues;
        public XPCollection<Issue> AllIssues {
            get {
                if(allIssues == null) {
                    allIssues = new XPCollection<Issue>(Session, false);
                    CollectIssuesRecursive(this, allIssues);
                    allIssues.BindingBehavior = CollectionBindingBehavior.AllowNone;
                }
                return allIssues;
            }
        }
        private void CollectIssuesRecursive(CategoryWithIssues issueCategory, XPCollection<Issue> target) {
            target.AddRange(issueCategory.Issues);
            foreach(CategoryWithIssues childCategory in issueCategory.Children) {
                CollectIssuesRecursive(childCategory, target);
            }
        }
        private string name;
        protected abstract ITreeNode Parent {
            get;
        }
        protected abstract IBindingList Children {
            get;
        }
        public CategoryWithIssues(Session session) : base(session) { }
        public string Name {
            get {
                return name;
            }
            set {
                SetPropertyValue("Name", ref name, value);
            }
        }
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
        protected override IBindingList Children {
            get {
                return ProjectsWithIssues;
            }
        }
        public ProjectGroupWithIssues(Session session) : base(session) { }
        public ProjectGroupWithIssues(Session session, string name)
            : base(session) {
            this.Name = name;
        }
        [Association("ProjectGroupWithIssues-ProjectsWithIssues"), Aggregated]
        public XPCollection<ProjectWithIssues> ProjectsWithIssues {
            get {
                return GetCollection<ProjectWithIssues>("ProjectsWithIssues");
            }
        }
    }

    public class ProjectWithIssues : CategoryWithIssues {
        private ProjectGroupWithIssues projectGroupWithIssues;
        protected override ITreeNode Parent {
            get {
                return projectGroupWithIssues;
            }
        }
        protected override IBindingList Children {
            get {
                return ProjectAreasWithIssues;
            }
        }
        public ProjectWithIssues(Session session) : base(session) { }
        public ProjectWithIssues(Session session, string name)
            : base(session) {
            this.Name = name;
        }
        [Association("ProjectGroupWithIssues-ProjectsWithIssues")]
        public ProjectGroupWithIssues ProjectGroupWithIssues {
            get {
                return projectGroupWithIssues;
            }
            set {
                SetPropertyValue("ProjectGroupWithIssues", ref projectGroupWithIssues, value);
            }
        }
        [Association("ProjectWithIssues-ProjectAreasWithIssues"), Aggregated]
        public XPCollection<ProjectAreaWithIssues> ProjectAreasWithIssues {
            get {
                return GetCollection<ProjectAreaWithIssues>("ProjectAreasWithIssues");
            }
        }
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
        public ProjectAreaWithIssues(Session session) : base(session) { }
        public ProjectAreaWithIssues(Session session, string name)
            : base(session) {
            this.Name = name;
        }
        [Association("ProjectWithIssues-ProjectAreasWithIssues")]
        public ProjectWithIssues ProjectWithIssues {
            get {
                return projectWithIssues;
            }
            set {
                SetPropertyValue("ProjectWithIssues", ref projectWithIssues, value);
            }
        }
    }
}
