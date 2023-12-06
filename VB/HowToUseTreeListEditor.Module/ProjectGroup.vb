Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

Namespace HowToUseTreeListEditor.Module

    Public Class ProjectGroup
        Inherits Category

        Protected Overrides ReadOnly Property ParentProp As ITreeNode
            Get
                Return Nothing
            End Get
        End Property

        Protected Overrides ReadOnly Property ChildrenProp As IBindingList
            Get
                Return Projects
            End Get
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Sub New(ByVal session As Session, ByVal name As String)
            MyBase.New(session)
            NameProp = name
        End Sub

        <Association("ProjectGroup-Projects"), Aggregated>
        Public ReadOnly Property Projects As XPCollection(Of Project)
            Get
                Return GetCollection(Of Project)("Projects")
            End Get
        End Property
    End Class
End Namespace
