using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using System.ComponentModel;
using DevExpress.Persistent.BaseImpl.EF;

namespace HowToUseTreeListEditor.Module {
    [NavigationItem]
    public abstract class Category : BaseObject, ITreeNode {
        protected abstract ITreeNode GetParent();
        protected abstract IBindingList GetChildren();

        public virtual string Name { get; set; }
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
