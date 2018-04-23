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
    Public MustInherit Class Category
        Inherits BaseObject
        Implements ITreeNode


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
End Namespace
