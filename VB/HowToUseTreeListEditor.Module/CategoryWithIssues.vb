Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

Namespace HowToUseTreeListEditor.Module
    <NavigationItem> _
    Public MustInherit Class CategoryWithIssues
        Inherits BaseObject
        Implements ITreeNode

        <Association("CategoryWithIssues-Issues")> _
        Public ReadOnly Property Issues() As XPCollection(Of Issue)
            Get
                Return GetCollection(Of Issue)("Issues")
            End Get
        End Property

        Private allIssues_Renamed As XPCollection(Of Issue)
        Public ReadOnly Property AllIssues() As XPCollection(Of Issue)
            Get
                If allIssues_Renamed Is Nothing Then
                    allIssues_Renamed = New XPCollection(Of Issue)(Session, False)
                    CollectIssuesRecursive(Me, allIssues_Renamed)
                    allIssues_Renamed.BindingBehavior = CollectionBindingBehavior.AllowNone
                End If
                Return allIssues_Renamed
            End Get
        End Property
        Private Sub CollectIssuesRecursive(ByVal issueCategory As CategoryWithIssues, ByVal target As XPCollection(Of Issue))
            target.AddRange(issueCategory.Issues)
            For Each childCategory As CategoryWithIssues In issueCategory.Children
                CollectIssuesRecursive(childCategory, target)
            Next childCategory
        End Sub

        Private name_Renamed As String
        Protected MustOverride ReadOnly Property Parent() As ITreeNode
        Protected MustOverride ReadOnly Property Children() As IBindingList
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Name", name_Renamed, value)
            End Set
        End Property
        #Region "ITreeNode"
        Private ReadOnly Property ITreeNode_Children() As IBindingList Implements ITreeNode.Children
            Get
                Return Children
            End Get
        End Property
        Private ReadOnly Property ITreeNode_Name() As String Implements ITreeNode.Name
            Get
                Return Name
            End Get
        End Property
        Private ReadOnly Property ITreeNode_Parent() As ITreeNode Implements ITreeNode.Parent
            Get
                Return Parent
            End Get
        End Property
        #End Region
    End Class
    Public Class ProjectGroupWithIssues
        Inherits CategoryWithIssues

        Protected Overrides ReadOnly Property Parent() As ITreeNode
            Get
                Return Nothing
            End Get
        End Property
        Protected Overrides ReadOnly Property Children() As IBindingList
            Get
                Return ProjectsWithIssues
            End Get
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            MyBase.New(session)
            Me.Name = name
        End Sub
        <Association("ProjectGroupWithIssues-ProjectsWithIssues"), Aggregated> _
        Public ReadOnly Property ProjectsWithIssues() As XPCollection(Of ProjectWithIssues)
            Get
                Return GetCollection(Of ProjectWithIssues)("ProjectsWithIssues")
            End Get
        End Property
    End Class

    Public Class ProjectWithIssues
        Inherits CategoryWithIssues


        Private projectGroupWithIssues_Renamed As ProjectGroupWithIssues
        Protected Overrides ReadOnly Property Parent() As ITreeNode
            Get
                Return projectGroupWithIssues_Renamed
            End Get
        End Property
        Protected Overrides ReadOnly Property Children() As IBindingList
            Get
                Return ProjectAreasWithIssues
            End Get
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            MyBase.New(session)
            Me.Name = name
        End Sub
        <Association("ProjectGroupWithIssues-ProjectsWithIssues")> _
        Public Property ProjectGroupWithIssues() As ProjectGroupWithIssues
            Get
                Return projectGroupWithIssues_Renamed
            End Get
            Set(ByVal value As ProjectGroupWithIssues)
                SetPropertyValue("ProjectGroupWithIssues", projectGroupWithIssues_Renamed, value)
            End Set
        End Property
        <Association("ProjectWithIssues-ProjectAreasWithIssues"), Aggregated> _
        Public ReadOnly Property ProjectAreasWithIssues() As XPCollection(Of ProjectAreaWithIssues)
            Get
                Return GetCollection(Of ProjectAreaWithIssues)("ProjectAreasWithIssues")
            End Get
        End Property
    End Class

    Public Class ProjectAreaWithIssues
        Inherits CategoryWithIssues


        Private projectWithIssues_Renamed As ProjectWithIssues
        Protected Overrides ReadOnly Property Parent() As ITreeNode
            Get
                Return projectWithIssues_Renamed
            End Get
        End Property
        Protected Overrides ReadOnly Property Children() As IBindingList
            Get
                Return New BindingList(Of Object)()
            End Get
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            MyBase.New(session)
            Me.Name = name
        End Sub
        <Association("ProjectWithIssues-ProjectAreasWithIssues")> _
        Public Property ProjectWithIssues() As ProjectWithIssues
            Get
                Return projectWithIssues_Renamed
            End Get
            Set(ByVal value As ProjectWithIssues)
                SetPropertyValue("ProjectWithIssues", projectWithIssues_Renamed, value)
            End Set
        End Property
    End Class
End Namespace
