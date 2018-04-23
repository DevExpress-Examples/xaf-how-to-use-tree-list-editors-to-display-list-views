Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.Base.General

Namespace HowToUseTreeListEditor.Module
    <DefaultClassOptions> _
    Public Class Issue
        Inherits BaseObject
        Implements ICategorizedItem

        Private categoryWithIssues As CategoryWithIssues

        Private subject_Renamed As String

        Private description_Renamed As String
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal subject As String)
            MyBase.New(session)
            Me.subject_Renamed = subject
        End Sub
        <Association("CategoryWithIssues-Issues")> _
        Public Property Category() As CategoryWithIssues
            Get
                Return categoryWithIssues
            End Get
            Set(ByVal value As CategoryWithIssues)
                SetPropertyValue("Category", categoryWithIssues, value)
            End Set
        End Property
        Public Property Subject() As String
            Get
                Return subject_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Subject", subject_Renamed, value)
            End Set
        End Property
        Public Property Description() As String
            Get
                Return description_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Description", description_Renamed, value)
            End Set
        End Property
        Private Property ICategorizedItem_Category() As ITreeNode Implements ICategorizedItem.Category
            Get
                Return Category
            End Get
            Set(ByVal value As ITreeNode)
                Category = DirectCast(value, CategoryWithIssues)
            End Set
        End Property
    End Class


End Namespace
