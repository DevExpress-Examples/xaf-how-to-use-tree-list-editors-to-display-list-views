Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base.General

Namespace HowToUseTreeListEditor.Module

    <DefaultClassOptions>
    Public Class Issue
        Inherits BaseObject
        Implements ICategorizedItem

        Private categoryWithIssues As CategoryWithIssues

        Private subjectField As String

        Private descriptionField As String

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Sub New(ByVal session As Session, ByVal subject As String)
            MyBase.New(session)
            subjectField = subject
        End Sub

        <Association("CategoryWithIssues-Issues")>
        Public Property CategoryProp As CategoryWithIssues
            Get
                Return categoryWithIssues
            End Get

            Set(ByVal value As CategoryWithIssues)
                SetPropertyValue("Category", categoryWithIssues, value)
            End Set
        End Property

        Public Property Subject As String
            Get
                Return subjectField
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Subject", subjectField, value)
            End Set
        End Property

        Public Property Description As String
            Get
                Return descriptionField
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Description", descriptionField, value)
            End Set
        End Property

        Private Property Category As ITreeNode Implements ICategorizedItem.Category
            Get
                Return CategoryProp
            End Get

            Set(ByVal value As ITreeNode)
                CategoryProp = CType(value, CategoryWithIssues)
            End Set
        End Property
    End Class
End Namespace
