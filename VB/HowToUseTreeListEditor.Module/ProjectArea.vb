Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

Namespace HowToUseTreeListEditor.Module

    Public Class ProjectArea
        Inherits Category

        Private projectField As Project

        Protected Overrides ReadOnly Property ParentProp As ITreeNode
            Get
                Return projectField
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

        <Association("Project-ProjectAreas")>
        Public Property Project As Project
            Get
                Return projectField
            End Get

            Set(ByVal value As Project)
                SetPropertyValue("Project", projectField, value)
            End Set
        End Property
    End Class
End Namespace
