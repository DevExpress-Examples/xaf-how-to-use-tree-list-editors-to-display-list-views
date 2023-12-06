Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

Namespace HowToUseTreeListEditor.Module

    <NavigationItem>
    Public MustInherit Class Category
        Inherits BaseObject
        Implements ITreeNode

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
End Namespace
