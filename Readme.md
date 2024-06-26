<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128594891/22.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1125)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# XAF WinForms - How to Use Tree List Editors to Display List Views

This example describes how to use a tree list control to show hierarchical data in XAF WinForms applications. For this purpose, the example uses the `TreeListEditor` and `CategorizedListEditor` supplied with the [TreeListEditorsWindowsFormsModule](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule). 

<kbd>![image](https://github.com/DevExpress-Examples/XAF_how-to-use-tree-list-editors-to-display-list-views-e1125/assets/14300209/b08d7d3e-c32d-4b73-bd2f-f537f6770871)</kbd>

## Implementation Details

The example uses the following techniques:

1. A List View that defines objects of a type that implements the [ITreeNode](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.General.ITreeNode) interface. This view is displayed by the [TreeListEditor](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditor).
 
    _Files to review_:
  
    * The [Category](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Category.cs) class.
    * The `Category` class' descendants: [ProjectGroup](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/ProjectGroup.cs), [Project](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Project.cs), and [ProjectArea](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/ProjectArea.cs)
    
    For details, refer to the following help topics: [TreeList Editors Module](https://docs.devexpress.com/eXpressAppFramework/112836/application-shell-and-base-infrastructure/tree-list-editors/tree-list-editors-module-overview) and [Display a Tree List using the ITreeNode interface](https://docs.devexpress.com/eXpressAppFramework/112837/application-shell-and-base-infrastructure/tree-list-editors/display-a-tree-list-using-the-tree-node-interface).
  
2. A List View that defines objects of a type that implements the [ICategorizedItem](https://docs.devexpress.com/eXpressAppFramework/DevExpress.Persistent.Base.General.ICategorizedItem) interface. This view is displayed by the [CategorizedListEditor](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.TreeListEditors.Win.CategorizedListEditor).

    _Files to review_:

    * The [Issue](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Issue.cs) class
    * The [CategoryWithIssues](./CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/CategoryWithIssues.cs) class that is related to the previous class by a one-to-many relationship.

    For details, refer to the following topic: [Categorized List](https://docs.devexpress.com/eXpressAppFramework/112838/application-shell-and-base-infrastructure/tree-list-editors/categorized-list).

3. A List View that defines objects of the `HCategory` type, supplied with the Business Class Library. This view is displayed by the `TreeListEditor`. The `HCategory` class is added to the application's business model using the following API: [Ways to Add a Business class](https://docs.devexpress.com/eXpressAppFramework/112847/business-model-design-orm/ways-to-add-a-business-class).

    For details, refer to the following topic: [Display a Tree List using the HCategory class](https://docs.devexpress.com/eXpressAppFramework/112839/application-shell-and-base-infrastructure/tree-list-editors/display-a-tree-list-using-the-category-class).

## Important Notes

Pay attention to the following KB article: [Layout - There are circumstances that cause the "Error creating window handle" error to occur when you alter the MasterDeailMode option](https://supportcenter.devexpress.com/ticket/details/b181657/layout-troubleshooting-the-error-creating-window-handle-or-infinite-recursion-detected).

## Files to Review

- [Category.cs](CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Category.cs)
- [Issue.cs](CS/EFCore/UseTreeListEF/UseTreeListEF.Module/BusinessObjects/Issue.cs)

## More Example

* [XAF Blazor - How to Implement a TreeList Editor to Display Hierarchical Data](https://github.com/DevExpress-Examples/xaf-treelist-editor-blazor)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-use-tree-list-editors-to-display-list-views&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-use-tree-list-editors-to-display-list-views&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
