Public Class GraphData
    Private _ID As Integer
    Private _Amount As Double
    Private _SIP_Value As Double
    Private _Index_Value As Double

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property

    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal Value As Double)
            _Amount = Value
        End Set
    End Property

    Public Property Ret_Value() As Double
        Get
            Return _SIP_Value
        End Get
        Set(ByVal Value As Double)
            _SIP_Value = Value
        End Set
    End Property

    Public Property Index_Value() As Double
        Get
            Return _Index_Value
        End Get
        Set(ByVal Value As Double)
            _Index_Value = Value
        End Set
    End Property
End Class


Public Class GraphData4Spt

    Private _ID As Integer

    Private _Investment_In_Index As Double
    Private _Cumulative_Amount As Double


    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property

    Public Property Cumulative_Amount() As Double
        Get
            Return _Cumulative_Amount
        End Get
        Set(ByVal Value As Double)
            _Cumulative_Amount = Value
        End Set
    End Property

    Public Property Investment_In_Index() As Double
        Get
            Return _Investment_In_Index
        End Get
        Set(ByVal Value As Double)
            _Investment_In_Index = Value
        End Set
    End Property
End Class