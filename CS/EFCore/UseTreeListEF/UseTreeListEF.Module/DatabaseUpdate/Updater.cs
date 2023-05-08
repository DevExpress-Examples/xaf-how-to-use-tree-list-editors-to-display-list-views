using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.EF;
using DevExpress.Persistent.BaseImpl.EF;
using HowToUseTreeListEditor.Module;

namespace UseTreeListEF.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
    public override void UpdateDatabaseAfterUpdateSchema() {
        for (int k = 0; k < 3; k++) {
            string projectGroupNameWI = "ProjectGroupWithIssue" + k;
            string projectGroupName = "ProjectGroup" + k;

            ProjectGroupWithIssues projectGroupWithIssue = CreateObject<ProjectGroupWithIssues>("Name", projectGroupNameWI);
            ProjectGroup projectGroup = CreateObject<ProjectGroup>("Name", projectGroupName);

            projectGroupWithIssue.Name = projectGroupNameWI;
            projectGroup.Name = projectGroupName;

            PopulateWithIssue(projectGroupWithIssue);

            for (int i = 0; i < 3; i++) {
                string projectNameWI = "ProjectWithIssue" + k + " - " + i;
                string projectName = "Project" + k + " - " + i;

                ProjectWithIssues projectWithIssue = CreateObject<ProjectWithIssues>("Name", projectNameWI);
                Project project = CreateObject<Project>("Name", projectName);

                projectWithIssue.Name = projectNameWI;
                project.Name = projectName;

                PopulateWithIssue(projectWithIssue);

                for (int j = 0; j < 3; j++) {
                    string projectAreaNameWI = "ProjectAreaWithIssue" + k + " - " + i + " - " + j;
                    string projectAreaName = "ProjectArea" + k + " - " + i + " - " + j;

                    ProjectAreaWithIssues projectAreaWI = CreateObject<ProjectAreaWithIssues>("Name", projectAreaNameWI);
                    ProjectArea projectArea = CreateObject<ProjectArea>("Name", projectAreaName);

                    projectAreaWI.Name = projectAreaNameWI;
                    projectArea.Name = projectAreaName;

                    PopulateWithIssue(projectAreaWI);

                    projectWithIssue.ProjectAreasWithIssues.Add(projectAreaWI);
                    project.ProjectAreas.Add(projectArea);
                }
                projectGroupWithIssue.ProjectsWithIssues.Add(projectWithIssue);
                projectGroup.Projects.Add(project);
            }
        }
        ObjectSpace.CommitChanges();

        base.UpdateDatabaseAfterUpdateSchema();
    }

    void PopulateWithIssue(CategoryWithIssues category) {
        for (int l = 0; l < 3; l++) {
            string issueName = category.Name + " -" + "Issue" + l;
            Issue issue = CreateObject<Issue>("Subject", issueName);
            issue.Subject = issueName;
            category.Issues.Add(issue);
        }
    }

    T CreateObject<T>(string propertyName, string value) {

        T theObject = ObjectSpace.FindObject<T>(new OperandProperty(propertyName) == value);
        if (theObject == null)
            theObject = ObjectSpace.CreateObject<T>();

        return theObject;

    }

}
