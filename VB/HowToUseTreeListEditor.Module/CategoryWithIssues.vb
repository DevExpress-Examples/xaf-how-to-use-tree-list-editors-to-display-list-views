Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

Namespace HowToUseTreeListEditor.Module

    <NavigationItem>
    Public MustInherit Class CategoryWithIssues
        Inherits BaseObject
        Implements ITreeNode

        <Association("CategoryWithIssues-Issues")>
        Public ReadOnly Property Issues As XPCollection(Of Issue)
            Get
                Return GetCollection(Of Issue)("Issues")
            End Get
        End Property

        Private allIssuesField As XPCollection(Of Issue)

        Public ReadOnly Property AllIssues As XPCollection(Of Issue)
            Get
                If allIssuesField Is Nothing Then
                    allIssuesField = New XPCollection(Of Issue)(Session, False)
                    CollectIssuesRecursive(Me, allIssuesField)
                    allIssuesField.BindingBehavior = CollectionBindingBehavior.AllowNone
                End If

                Return allIssuesField
            End Get
        End Property

        Private Sub CollectIssuesRecursive(ByVal issueCategory As CategoryWithIssues, ByVal target As XPCollection(Of Issue))
            target.AddRange(issueCategory.Issues)
            For Each childCategory As CategoryWithIssues In issueCategory.ChildrenProp
                CollectIssuesRecursive(childCategory, target)
            Next
        End Sub

        Private nameField As String

        Protected MustOverride ReadOnly Property ParentProp As ITreeNode

        Protected MustOverride ReadOnly Property ChildrenProp As IBindingList

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Property NameProp As String
            Get
                Return nameField
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Name", nameField, value)
            End Set
        End Property

#Region "ITreeNode"
        Private ReadOnly Property Children As IBindingList Implements ITreeNode.Children
            Get
                Return ChildrenProp
            End Get
        End Property

        Private ReadOnly Property Name As String Implements ITreeNode.Name
            Get
                Return NameProp
            End Get
        End Property

        Private ReadOnly Property Parent As ITreeNode Implements ITreeNode.Parent
            Get
                Return ParentProp
            End Get
        End Property
#End Region
    End Class

    Public Class ProjectGroupWithIssues
        Inherits CategoryWithIssues

        Protected Overrides ReadOnly Property ParentProp As ITreeNode
            Get
                Return Nothing
            End Get
        End Property

        Protected Overrides ReadOnly Property ChildrenProp As IBindingList
            Get
                Return ProjectsWithIssues
            End Get
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Sub New(ByVal session As Session, ByVal name As String)
            MyBase.New(session)
            NameProp = name
        End Sub

        <Association("ProjectGroupWithIssues-ProjectsWithIssues"), Aggregated>
        Public ReadOnly Property ProjectsWithIssues As XPCollection(Of ProjectWithIssues)
            Get
                Return GetCollection(Of ProjectWithIssues)("ProjectsWithIssues")
            End Get
        End Property
    End Class

    Public Class ProjectWithIssues
        Inherits CategoryWithIssues

        Private projectGroupWithIssuesField As ProjectGroupWithIssues

        Protected Overrides ReadOnly Property ParentProp As ITreeNode
            Get
                Return projectGroupWithIssuesField
            End Get
        End Property

        Protected Overrides ReadOnly Property ChildrenProp As IBindingList
            Get
                Return ProjectAreasWithIssues
            End Get
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Sub New(ByVal session As Session, ByVal name As String)
            MyBase.New(session)
            NameProp = name
        End Sub

        <Association("ProjectGroupWithIssues-ProjectsWithIssues")>
        Public Property ProjectGroupWithIssues As ProjectGroupWithIssues
            Get
                Return projectGroupWithIssuesField
            End Get

            Set(ByVal value As ProjectGroupWithIssues)
                SetPropertyValue("ProjectGroupWithIssues", projectGroupWithIssuesField, value)
            End Set
        End Property

        <Association("ProjectWithIssues-ProjectAreasWithIssues"), Aggregated>
        Public ReadOnly Property ProjectAreasWithIssues As XPCollection(Of ProjectAreaWithIssues)
            Get
                Return GetCollection(Of ProjectAreaWithIssues)("ProjectAreasWithIssues")
            End Get
        End Property
    End Class

    Public Class ProjectAreaWithIssues
        Inherits CategoryWithIssues

        Private projectWithIssuesField As ProjectWithIssues

        Protected Overrides ReadOnly Property ParentProp As ITreeNode
            Get
                Return projectWithIssuesField
            End Get
        End Property

        Protected Overrides ReadOnly Property ChildrenProp As IBindingList
            Get
                Return New BindingList(Of Object)()
            End Get
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Sub New(ByVal session As Session, ByVal name As String)
            MyBase.New(session)
            NameProp = name
        End Sub

        <Association("ProjectWithIssues-ProjectAreasWithIssues")>
        Public Property ProjectWithIssues As ProjectWithIssues
            Get
                Return projectWithIssuesField
            End Get

            Set(ByVal value As ProjectWithIssues)
                SetPropertyValue("ProjectWithIssues", projectWithIssuesField, value)
            End Set
        End Property
    End Class
End Namespace
