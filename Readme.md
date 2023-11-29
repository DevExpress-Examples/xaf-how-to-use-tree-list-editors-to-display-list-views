<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1125)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->



# How to Use Tree List Editors to Display List Views

This example describes how to use tree list control to show hierarchical data in XAF WinForms.
![image](https://github.com/DevExpress-Examples/XAF_how-to-use-tree-list-editors-to-display-list-views-e1125/assets/14300209/b08d7d3e-c32d-4b73-bd2f-f537f6770871)

## Implementation Details

This example demonstrates how to use the TreeListEditor and CategorizedListEditor, which are supplied with the [TreeListEditorsWindowsFormsModule](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule). We used the following techniques here: 
1) A List View that represents objects of the type that implements the [ITreeNode](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.General.ITreeNode) interface is automatically presented by the [TreeListEditor](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditor).
See the [Category](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Category.cs) class and its descendants: [ProjectGroup](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/ProjectGroup.cs), [Project](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Project.cs) and [ProjectArea](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/ProjectArea.cs).
For details, refer to the [TreeList Editors Module](https://docs.devexpress.com/eXpressAppFramework/112836/application-shell-and-base-infrastructure/tree-list-editors/tree-list-editors-module-overview) and [Display a Tree List using the ITreeNode interface](https://docs.devexpress.com/eXpressAppFramework/112837/application-shell-and-base-infrastructure/tree-list-editors/display-a-tree-list-using-the-tree-node-interface) help topics.

2) A List View that represents objects of the type that implements the [ICategorizedItem](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.General.ICategorizedItem) interface is automatically presented by the [CategorizedListEditor class](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.TreeListEditors.Win.CategorizedListEditor).
See the [Issue](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Issue.cs) class that is related to the [CategoryWithIssues](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/CategoryWithIssues.cs)  class by the One-to-Many relationship.
For details, refer to the [Categorized List](https://docs.devexpress.com/eXpressAppFramework/112838/application-shell-and-base-infrastructure/tree-list-editors/categorized-list) help topic.

3) A List View that represents objects of the HCategory type, which is supplied with the Business Class Library, is automatically presented by the TreeListEditor.
The HCategory class is added to the application's business model using this API: [Ways to Add a Business class](https://docs.devexpress.com/eXpressAppFramework/112847/business-model-design-orm/ways-to-add-a-business-class).
For details, refer to the [Display a Tree List using the HCategory class](https://docs.devexpress.com/eXpressAppFramework/112839/application-shell-and-base-infrastructure/tree-list-editors/display-a-tree-list-using-the-category-class) help topic.

Important Notes:
Take special note of the <a href="https://www.devexpress.com/Support/Center/p/B181657">Layout - The "Error creating window handle" error may occur when changing the MasterDeailMode option under certain circumstances</a>



## Files to Review

- [Category.cs](CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Category.cs)
- [Issue.cs](CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Issue.cs)

