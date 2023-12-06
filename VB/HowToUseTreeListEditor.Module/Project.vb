Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

Namespace HowToUseTreeListEditor.Module

    Public Class Project
        Inherits Category

        Private projectGroupField As ProjectGroup

        Protected Overrides ReadOnly Property ParentProp As ITreeNode
            Get
                Return projectGroupField
            End Get
        End Property

        Protected Overrides ReadOnly Property ChildrenProp As IBindingList
            Get
                Return ProjectAreas
            End Get
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Sub New(ByVal session As Session, ByVal name As String)
            MyBase.New(session)
            NameProp = name
        End Sub

        <Association("ProjectGroup-Projects")>
        Public Property ProjectGroup As ProjectGroup
            Get
                Return projectGroupField
            End Get

            Set(ByVal value As ProjectGroup)
                SetPropertyValue("ProjectGroup", projectGroupField, value)
            End Set
        End Property

        <Association("Project-ProjectAreas"), Aggregated>
        Public ReadOnly Property ProjectAreas As XPCollection(Of ProjectArea)
            Get
                Return GetCollection(Of ProjectArea)("ProjectAreas")
            End Get
        End Property
    End Class
End Namespace
