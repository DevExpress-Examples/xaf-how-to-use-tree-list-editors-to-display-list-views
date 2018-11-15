<!-- default file list -->
*Files to look at*:

* [Category.cs](./CS/HowToUseTreeListEditor.Module/Category.cs) (VB: [Category.vb](./VB/HowToUseTreeListEditor.Module/Category.vb))
* [CategoryWithIssues.cs](./CS/HowToUseTreeListEditor.Module/CategoryWithIssues.cs) (VB: [CategoryWithIssues.vb](./VB/HowToUseTreeListEditor.Module/CategoryWithIssues.vb))
* [Issue.cs](./CS/HowToUseTreeListEditor.Module/Issue.cs) (VB: [Issue.vb](./VB/HowToUseTreeListEditor.Module/Issue.vb))
* [Project.cs](./CS/HowToUseTreeListEditor.Module/Project.cs) (VB: [ProjectArea.vb](./VB/HowToUseTreeListEditor.Module/ProjectArea.vb))
* [ProjectArea.cs](./CS/HowToUseTreeListEditor.Module/ProjectArea.cs) (VB: [ProjectArea.vb](./VB/HowToUseTreeListEditor.Module/ProjectArea.vb))
* [ProjectGroup.cs](./CS/HowToUseTreeListEditor.Module/ProjectGroup.cs) (VB: [ProjectGroup.vb](./VB/HowToUseTreeListEditor.Module/ProjectGroup.vb))
* [Updater.cs](./CS/HowToUseTreeListEditor.Module/Updater.cs) (VB: [Updater.vb](./VB/HowToUseTreeListEditor.Module/Updater.vb))
<!-- default file list end -->
# How to Use Tree List Editors to Display List Views


<p>This example demonstrates how to use the TreeListEditor and CategorizedListEditor, which are supplied with the TreeListEditorsWindowsFormsModule. The following techniques are used:</p><p>1) A List View that represents objects of the type that implements the ITreeNode interface is automatically presented by the TreeListEditor.<br />
See the Category class and its descendants: ProjectGroup, Project and ProjectArea.<br />
For details, refer to the "TreeList Editors Module Overview" and "Implement the ITreeNode Interface"  topics in the Concepts | Extra Modules | TreeList Editors Module section of the XAF documentation.</p><p>2) A List View that represents objects of the type that implements the ICategorizedItem interface is automatically presented by the CategorizedListEditor.<br />
See the Issue class that is related to the CategoryWithIssues class by the Many-to-One relationship.<br />
For details, refer to the "TreeList Editors Module Overview" and "Implement the ICategorizedItem Interface"  topics in the Concepts | Extra Modules | TreeList Editors Module section of the XAF documentation.</p><p>3) A List View that represents objects of the HCategory type, which is supplied with the Business Class Library, is automatically presented by the TreeListEditor.<br />
The HCategory class is added to the application's business model via the Module Designer of the common module project.<br />
For details, refer to the <a href="http://documentation.devexpress.com/#Xaf/CustomDocument2836"><u>TreeList Editors Module Overview</u></a> and <a href="http://documentation.devexpress.com/#Xaf/CustomDocument2839"><u>Use the Built-in HCategory Class</u></a> topics in the XAF documentation.</p><p><strong>I</strong><strong>mportant Notes:</strong><br />
Take special note of the <a href="https://www.devexpress.com/Support/Center/p/B181657">Layout - The "Error creating window handle" error may occur when changing the MasterDeailMode option under certain circumstances</a></p>

<br/>


