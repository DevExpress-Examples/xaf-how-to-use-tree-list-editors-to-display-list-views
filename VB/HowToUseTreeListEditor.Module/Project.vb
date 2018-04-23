Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

Namespace HowToUseTreeListEditor.Module
    Public Class Project
        Inherits Category


        Private projectGroup_Renamed As ProjectGroup
        Protected Overrides ReadOnly Property Parent() As ITreeNode
            Get
                Return projectGroup_Renamed
            End Get
        End Property
        Protected Overrides ReadOnly Property Children() As IBindingList
            Get
                Return ProjectAreas
            End Get
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New(ByVal session As Session, ByVal name As String)
            MyBase.New(session)
            Me.Name = name
        End Sub
        <Association("ProjectGroup-Projects")> _
        Public Property ProjectGroup() As ProjectGroup
            Get
                Return projectGroup_Renamed
            End Get
            Set(ByVal value As ProjectGroup)
                SetPropertyValue("ProjectGroup", projectGroup_Renamed, value)
            End Set
        End Property
        <Association("Project-ProjectAreas"), Aggregated> _
        Public ReadOnly Property ProjectAreas() As XPCollection(Of ProjectArea)
            Get
                Return GetCollection(Of ProjectArea)("ProjectAreas")
            End Get
        End Property
    End Class


End Namespace
