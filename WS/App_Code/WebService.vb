Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.OracleClient
Imports System.Data
Imports System
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Security
Imports System.Net
Imports System.Security.Cryptography.X509Certificates


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
' <WebService(Namespace:="http://tempuri.org/")> _
<WebService(Namespace:="http://crop-wsn.ddns.net/webservice.asmx/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService

    Inherits System.Web.Services.WebService
    Dim IPAcesso As String = "192.168.23.32"
    'Dim IPAcesso As String = "193.137.232.45"

    <WebMethod()> _
    Public Function ValidaUser(user As String, pass As String) As Integer
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")
        Dim comando As OracleCommand
        Dim da As New OracleDataAdapter
        Try
            conexao.Open()
            Dim Sql As String = "select * from BDA_pfernandes.sectores"
            comando = New OracleCommand(Sql, conexao)
            Dim dr As OracleDataReader = comando.ExecuteReader
            If dr.Read() Then
                Return dr.Item(0)
            Else
                Return 0
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function


    <WebMethod()> _
    Public Function LerSectores(user As String, pass As String) As DataTable
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")
        Dim comando As OracleCommand
        Dim da As New OracleDataAdapter
        Dim ds As New DataSet
        Try
            conexao.Open()
            comando = New OracleCommand("select ID_SECTOR, NOME from BDA_pfernandes.sectores order by NOME desc", conexao)
            da.SelectCommand = comando
            da.Fill(ds)
            da.Dispose()
            comando.Dispose()
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function



    <WebMethod()> _
    Public Function LerSectoresMobile(user As String, pass As String) As List(Of Sectores)
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")
        Dim Lista = New List(Of Sectores)
        Dim comando As New OracleCommand
        'Dim da As New OracleDataAdapter
        Dim dr As OracleDataReader
        Try
            conexao.Open()
            comando.Connection = conexao
            comando.CommandText = "select ID_SECTOR, NOME from BDA_pfernandes.sectores"
            dr = comando.ExecuteReader
            Do While dr.Read
                Dim registo As New Sectores
                registo.id_Sector = dr.Item(0)
                registo.nome = dr.Item(1)
                Lista.Add(registo)
            Loop
            comando.Dispose()
            Return Lista
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function



    <WebMethod()> _
    Public Function LerTipoRegisto(user As String, pass As String) As DataTable
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")
        Dim comando As OracleCommand
        Dim da As New OracleDataAdapter
        Dim ds As New DataSet
        Try
            conexao.Open()
            comando = New OracleCommand("select ID_REGISTO, TIPO_DE_REGISTO from BDA_pfernandes.tipo_registo", conexao)
            da.SelectCommand = comando
            da.Fill(ds)
            da.Dispose()
            comando.Dispose()
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function



    <WebMethod()> _
    Public Function LerTipoRegistoMobile(user As String, pass As String) As List(Of TipoDeRegisto)
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")
        Dim Lista = New List(Of TipoDeRegisto)
        Dim comando As New OracleCommand
        Dim dr As OracleDataReader
        Try
            conexao.Open()
            comando.Connection = conexao
            comando.CommandText = "select ID_REGISTO, TIPO_DE_REGISTO from BDA_pfernandes.tipo_registo"
            dr = comando.ExecuteReader
            Do While dr.Read
                Dim registo As New TipoDeRegisto
                registo.id_Registo = dr.Item(0)
                registo.tipoRegisto = dr.Item(1)
                Lista.Add(registo)
            Loop
            comando.Dispose()
            Return Lista
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function

    <WebMethod()> _
    Public Function LerUtilizadores(user As String, pass As String) As DataTable
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")
        Dim comando As OracleCommand
        Dim da As New OracleDataAdapter
        Dim ds As New DataSet
        Try
            conexao.Open()
            comando = New OracleCommand("select USER_ID, USERNAME from BDA_pfernandes.utilizadores", conexao)
            da.SelectCommand = comando
            da.Fill(ds)
            da.Dispose()
            comando.Dispose()
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function


    <WebMethod()> _
    Public Function LerSect_Topog(user As String, pass As String) As DataTable
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")
        Dim comando As OracleCommand
        Dim da As New OracleDataAdapter
        Dim ds As New DataSet
        Try
            conexao.Open()
            comando = New OracleCommand("select sectores_id_sector, lev_topog_id_lv_topog, seq_poligonal, coord_x, coord_y from BDA_pfernandes.sector_lv_topog, BDA_pfernandes.lev_topog where tipo_de_ponto='LIMITE' and lev_topog_id_lv_topog=id_lv_topog", conexao)
            da.SelectCommand = comando
            da.Fill(ds)
            da.Dispose()
            comando.Dispose()
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function


    <WebMethod()> _
    Public Function LerRecolhaValoresMobile_1(user As String, pass As String, id_sector As Integer, id_tp_registo As Integer) As List(Of Registos)
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")

        Dim Lista = New List(Of Registos)()
        Dim comando As New OracleCommand
        Dim da As New OracleDataAdapter
        Dim dr As OracleDataReader
        Try

            conexao.Open()
            comando.Connection = conexao
            comando.CommandText = "select * from BDA_pfernandes.recolha_valores where SECTORES_ID_SECTOR = " & id_sector & " and TIPO_REGISTO_ID_REGISTO = " & id_tp_registo & " order by data_leitura desc"
            dr = comando.ExecuteReader
            Do While dr.Read
                Dim registo As New Registos
                registo.data_leitura = CDate(dr.Item(0)).ToShortDateString
                Lista.Add(registo)
            Loop
            comando.Dispose()
            Return Lista
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function

    <WebMethod()> _
    Public Function LerRecolhaValoresMobile_2(user As String, pass As String, id_sector As Integer, id_tp_registo As Integer, data As String) As List(Of Registos)
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")

        Dim Lista = New List(Of Registos)()
        Dim comando As New OracleCommand
        Dim da As New OracleDataAdapter
        Dim dr As OracleDataReader
        Try

            conexao.Open()
            comando.Connection = conexao
            comando.CommandText = "select * from BDA_pfernandes.recolha_valores, bda_pfernandes.utilizadores where recolha_valores.USER_ID=utilizadores.USER_ID and SECTORES_ID_SECTOR = " & id_sector & " and TIPO_REGISTO_ID_REGISTO = " & id_tp_registo & " and DATA_LEITURA = to_date('" & data & "','dd-mm-yyyy') order by DATA_LEITURA desc"
            dr = comando.ExecuteReader
            Do While dr.Read
                Dim registo As New Registos
                registo.data_leitura = CDate(dr.Item(0)).ToShortDateString
                registo.sector = dr.Item(1)
                registo.t_reg = dr.Item(2)
                registo.registo = dr.Item(3)
                registo.sensor_id = dr.Item(4)
                registo.user_id = dr.Item(5)
                registo.Username = dr.Item("USERNAME")
                Lista.Add(registo)
            Loop
            comando.Dispose()
            Return Lista
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function

    <WebMethod()> _
    Public Function LerRecolhaValoresMobile(user As String, pass As String) As List(Of Registos)
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")

        Dim Lista = New List(Of Registos)()
        Dim comando As New OracleCommand
        Dim da As New OracleDataAdapter
        Dim dr As OracleDataReader
        Try

            conexao.Open()
            comando.Connection = conexao
            comando.CommandText = "select * from BDA_pfernandes.recolha_valores rv, bda_pfernandes.utilizadores ut where rv.user_id= ut.user_id order by data_leitura desc"
            dr = comando.ExecuteReader
            Do While dr.Read
                Dim registo As New Registos
                registo.data_leitura = CDate(dr.Item(0)).ToShortDateString
                registo.sector = dr.Item(1)
                registo.t_reg = dr.Item(2)
                registo.registo = dr.Item(3)
                registo.sensor_id = dr.Item(4)
                registo.user_id = dr.Item(5)
                registo.Username = dr.Item("USERNAME")
                Lista.Add(registo)
            Loop
            comando.Dispose()
            Return Lista
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function


    <WebMethod()> _
    Function RegistarLeituraWSNMobile(user As String, pass As String, tp_registo As String, leitura As Single, sensor_id As Integer, comentario As String) As Integer
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")

        Dim Sql = "BDA_pfernandes.INT_REGISTO('" & tp_registo & "', " & leitura.ToString.Replace(",", ".") & ", " & sensor_id & ", 0, '" & comentario & "', NULL, NULL)"

        Try
            conexao.Open()
            Dim comando As New OracleCommand(Sql, conexao)
            comando.CommandType = CommandType.StoredProcedure
            Dim nregistos As Integer = comando.ExecuteNonQuery()
            Return nregistos

        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return 0
        Finally
            conexao.Close()
        End Try

    End Function

    <WebMethod()> _
    Function RegistarLeituraMobile(user As String, pass As String, data As String, id_Sector As Integer, tp_registo As String, leitura As Single, sensor_id As Integer, user_id As Integer) As Integer
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")

        Dim sql = "BDA_pfernandes.INT_REGISTO( to_date('" & data.Replace("-", ".").Replace("/", ".") & "','dd.mm.yyyy'), " & id_Sector & ", '" & tp_registo & "', " & leitura.ToString.Replace(",", ".") & ", " & sensor_id & ", " & user_id & ", NULL, NULL)"

        Try
            conexao.Open()
            Dim comando As New OracleCommand(sql, conexao)
            comando.CommandType = CommandType.StoredProcedure
            Dim nregistos As Integer = comando.ExecuteNonQuery
            Return nregistos

        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return 0
        Finally
            conexao.Close()
        End Try
    End Function


    <WebMethod()> _
    Function RegistarLeituraListaMobile(user As String, pass As String, lst As List(Of Registos)) As Integer
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")

        For i As Integer = 0 To lst.Count - 1
            If lst(i).paramSql = 1 Or lst(i).paramSql = 2 Then
                Try
                    Dim Sql As String = "BDA_pfernandes.INT_REGISTO( to_date('" & lst(i).data_leitura.Replace("-", ".").Replace("/", ".") & "','dd.mm.yyyy'), " & lst(i).sector & ", '" & lst(i).t_reg & "', " & lst(i).registo.ToString.Replace(",", ".") & ", " & lst(i).sensor_id & ", " & lst(i).user_id & ", NULL, NULL)"

                    conexao.Open()
                    Dim comando As New OracleCommand(Sql, conexao)
                    comando.CommandType = CommandType.StoredProcedure
                    Dim nregistos As Integer = comando.ExecuteNonQuery
                    Return nregistos

                Catch ex As Exception
                    MsgBox("Erro:" & ex.Message)
                    Return 0
                Finally
                    conexao.Close()
                End Try
            End If
        Next


        For i As Integer = 0 To lst.Count - 1
            If lst(i).paramSql = 3 Then
                Try
                    conexao.Open()
                    Dim sql = "DELETE from BDA_pfernandes.RECOLHA_VALORES where DATA_LEITURA = to_date('" & lst(i).data_leitura.Replace("-", ".").Replace("/", ".") & "','dd.mm.yyyy') and TIPO_REGISTO_ID_REGISTO = " & lst(i).t_reg & " and SECTORES_ID_SECTOR = " & lst(i).sector & " and ID_SENSOR = " & lst(i).sensor_id & ""
                    Dim comando = New OracleCommand(sql, conexao)
                    Dim nregistos As Integer = comando.ExecuteNonQuery
                    Return nregistos
                Catch ex As Exception
                    MsgBox("Erro:" & ex.Message)
                    Return 0
                Finally
                    conexao.Close()
                End Try
            End If
        Next
    End Function

    <WebMethod()> _
    Public Function ApagaRegisto(user As String, pass As String, data As String, tipo_registo As Integer, id_sector As Integer, id_sensor As Integer) As Integer
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")

        Try
            conexao.Open()
            Dim sql = "DELETE from BDA_pfernandes.RECOLHA_VALORES where DATA_LEITURA = to_date('" & data.Replace("-", ".").Replace("/", ".") & "','dd.mm.yyyy') and TIPO_REGISTO_ID_REGISTO = " & tipo_registo & " and SECTORES_ID_SECTOR = " & id_sector & " and ID_SENSOR = " & id_sensor & ""
            Dim comando = New OracleCommand(sql, conexao)
            Dim nregistos As Integer = comando.ExecuteNonQuery
            Return nregistos
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return 0
        Finally
            conexao.Close()
        End Try
    End Function


    <WebMethod()> _
    Public Function LerComentarios(user As String, pass As String) As DataTable
        Dim conexao As OracleConnection = New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" & IPAcesso & ")(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=test)));User Id=" & user & ";Password=" & pass & ";")
        Dim comando As OracleCommand
        Dim da As New OracleDataAdapter
        Dim ds As New DataSet
        Try
            conexao.Open()
            comando = New OracleCommand("select ID_COM, COMENTARIO from BDA_pfernandes.comentarios", conexao)
            da.SelectCommand = comando
            da.Fill(ds)
            da.Dispose()
            comando.Dispose()
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("Erro:" & ex.Message)
            Return Nothing
        Finally
            conexao.Close()
        End Try
    End Function


End Class

Public Class Registos
    Private pid As Integer
    Public Property id As Integer
        Get
            Return pid
        End Get
        Set(value As Integer)
            pid = value
        End Set
    End Property

    Private pdata_leitura As String
    Public Property data_leitura As String
        Get
            Return pdata_leitura
        End Get
        Set(data As String)
            pdata_leitura = data
        End Set
    End Property

    Private psector As Integer
    Public Property sector As Integer
        Get
            Return psector
        End Get
        Set(value As Integer)
            psector = value
        End Set
    End Property

    Private pt_reg As Integer
    Public Property t_reg As Integer
        Get
            Return pt_reg
        End Get
        Set(value As Integer)
            pt_reg = value
        End Set
    End Property

    Private pregisto As Single
    Public Property registo As Single
        Get
            Return pregisto
        End Get
        Set(value As Single)
            pregisto = value
        End Set
    End Property

    Public puser_id As Integer
    Public Property user_id As Integer
        Get
            Return puser_id
        End Get
        Set(value As Integer)
            puser_id = value
        End Set
    End Property

    Public psensor_id As Integer
    Public Property sensor_id As Integer
        Get
            Return psensor_id
        End Get
        Set(value As Integer)
            psensor_id = value
        End Set
    End Property

    Public pUsername As String
    Public Property Username As String
        Get
            Return pUsername
        End Get
        Set(value As String)
            pUsername = value
        End Set
    End Property

    Public pParamSql As Integer
    Public Property paramSql As Integer
        Get
            Return pParamSql
        End Get
        Set(value As Integer)
            pParamSql = value
        End Set
    End Property
End Class

Public Class Sectores
    Private pid As Integer
    Public Property id As Integer
        Get
            Return pid
        End Get
        Set(value As Integer)
            pid = value
        End Set
    End Property

    Private pid_Sector As Integer
    Public Property id_Sector As Integer
        Get
            Return pid_Sector
        End Get
        Set(value As Integer)
            pid_Sector = value
        End Set
    End Property

    Private pNome As String
    Public Property nome As String
        Get
            Return pNome
        End Get
        Set(value As String)
            pNome = value
        End Set
    End Property

End Class

Public Class TipoDeRegisto
    Private pid As Integer
    Public Property id As Integer
        Get
            Return pid
        End Get
        Set(value As Integer)
            pid = value
        End Set
    End Property

    Private pid_Registo As Integer
    Public Property id_Registo As Integer
        Get
            Return pid_Registo
        End Get
        Set(value As Integer)
            pid_Registo = value
        End Set
    End Property

    Private pTipoRegisto As String
    Public Property tipoRegisto As String
        Get
            Return pTipoRegisto
        End Get
        Set(value As String)
            pTipoRegisto = value
        End Set
    End Property

End Class