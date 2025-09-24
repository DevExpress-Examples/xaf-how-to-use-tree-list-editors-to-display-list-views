using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;

namespace HowToUseTreeListEditor.Module {
    [NavigationItem]
    public abstract class Category : BaseObject, ITreeNode {
        private string name;
        protected abstract ITreeNode GetParent();
        protected abstract IBindingList GetChildren();
        public Category(Session session) : base(session) { }
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
                return GetChildren();
            }
        }
        string ITreeNode.Name {
            get {
                return Name;
            }
        }
        ITreeNode ITreeNode.Parent {
            get {
                return GetParent();
            }
        }
        #endregion
    }
}
