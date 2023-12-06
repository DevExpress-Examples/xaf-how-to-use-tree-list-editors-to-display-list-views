Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Data.Filtering

Namespace HowToUseTreeListEditor.Module

    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub

        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            For k As Integer = 0 To 3 - 1
                Dim projectGroupNameWI As String = "ProjectGroupWithIssue" & k
                Dim projectGroupName As String = "ProjectGroup" & k
                Dim projectGroupWithIssue As ProjectGroupWithIssues = CreateObject(Of ProjectGroupWithIssues)("Name", projectGroupNameWI)
                Dim projectGroup As ProjectGroup = CreateObject(Of ProjectGroup)("Name", projectGroupName)
                projectGroupWithIssue.NameProp = projectGroupNameWI
                projectGroup.NameProp = projectGroupName
                PopulateWithIssue(projectGroupWithIssue)
                For i As Integer = 0 To 3 - 1
                    Dim projectNameWI As String = "ProjectWithIssue" & k & " - " & i
                    Dim projectName As String = "Project" & k & " - " & i
                    Dim projectWithIssue As ProjectWithIssues = CreateObject(Of ProjectWithIssues)("Name", projectNameWI)
                    Dim project As Project = CreateObject(Of Project)("Name", projectName)
                    projectWithIssue.NameProp = projectNameWI
                    project.NameProp = projectName
                    PopulateWithIssue(projectWithIssue)
                    For j As Integer = 0 To 3 - 1
                        Dim projectAreaNameWI As String = "ProjectAreaWithIssue" & k & " - " & i & " - " & j
                        Dim projectAreaName As String = "ProjectArea" & k & " - " & i & " - " & j
                        Dim projectAreaWI As ProjectAreaWithIssues = CreateObject(Of ProjectAreaWithIssues)("Name", projectAreaNameWI)
                        Dim projectArea As ProjectArea = CreateObject(Of ProjectArea)("Name", projectAreaName)
                        projectAreaWI.NameProp = projectAreaNameWI
                        projectArea.NameProp = projectAreaName
                        PopulateWithIssue(projectAreaWI)
                        projectWithIssue.ProjectAreasWithIssues.Add(projectAreaWI)
                        project.ProjectAreas.Add(projectArea)
                    Next

                    projectGroupWithIssue.ProjectsWithIssues.Add(projectWithIssue)
                    projectGroup.Projects.Add(project)
                Next
            Next

            ObjectSpace.CommitChanges()
            MyBase.UpdateDatabaseAfterUpdateSchema()
        End Sub

        Private Sub PopulateWithIssue(ByVal category As CategoryWithIssues)
            For l As Integer = 0 To 3 - 1
                Dim issueName As String = category.NameProp & " -" & "Issue" & l
                Dim issue As Issue = CreateObject(Of Issue)("Subject", issueName)
                issue.Subject = issueName
                category.Issues.Add(issue)
            Next
        End Sub

        Private Function CreateObject(Of T)(ByVal propertyName As String, ByVal value As String) As T
            Dim theObject As T = ObjectSpace.FindObject(Of T)(New OperandProperty(propertyName) Is value)
            If theObject Is Nothing Then theObject = ObjectSpace.CreateObject(Of T)()
            Return theObject
        End Function
    End Class
End Namespace
