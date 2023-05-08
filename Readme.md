<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128594891/22.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1125)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [BusinessObjects](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/)
<!-- default file list end -->
# How to Use Tree List Editors to Display List Views


<p>This example demonstrates how to use the TreeListEditor and CategorizedListEditor, which are supplied with the [TreeListEditorsWindowsFormsModule](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule). The following techniques are used:</p><p>1) A List View that represents objects of the type that implements the [ITreeNode](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.General.ITreeNode) interface is automatically presented by the [TreeListEditor](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditor).<br />
See the [Category](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Category.cs) class and its descendants: [ProjectGroup](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/ProjectGroup.cs), [Project](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Project.cs) and [ProjectArea](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/ProjectArea.cs).<br />
For details, refer to the [TreeList Editors Module](https://docs.devexpress.com/eXpressAppFramework/112836/application-shell-and-base-infrastructure/tree-list-editors/tree-list-editors-module-overview) and [Display a Tree List using the ITreeNode interface](https://docs.devexpress.com/eXpressAppFramework/112837/application-shell-and-base-infrastructure/tree-list-editors/display-a-tree-list-using-the-tree-node-interface) help topics.</p><p>2) A List View that represents objects of the type that implements the [ICategorizedItem](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.General.ICategorizedItem) interface is automatically presented by the [CategorizedListEditor class](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.TreeListEditors.Win.CategorizedListEditor).<br />
See the [Issue](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Issue.cs) class that is related to the [CategoryWithIssues](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/CategoryWithIssues.cs)  class by the One-to-Many relationship.<br />
For details, refer to the [Categorized List](https://docs.devexpress.com/eXpressAppFramework/112838/application-shell-and-base-infrastructure/tree-list-editors/categorized-list) help topic.</p><p>3) A List View that represents objects of the HCategory type, which is supplied with the Business Class Library, is automatically presented by the TreeListEditor.<br />
The HCategory class is added to the application's business model using this API: [Ways to Add a Business class](https://docs.devexpress.com/eXpressAppFramework/112847/business-model-design-orm/ways-to-add-a-business-class).<br />
For details, refer to the [Display a Tree List using the HCategory class](https://docs.devexpress.com/eXpressAppFramework/112839/application-shell-and-base-infrastructure/tree-list-editors/display-a-tree-list-using-the-category-class) help topic.</p><p><strong>I</strong><strong>mportant Notes:</strong><br />
Take special note of the <a href="https://www.devexpress.com/Support/Center/p/B181657">Layout - The "Error creating window handle" error may occur when changing the MasterDeailMode option under certain circumstances</a></p>

<br/>


