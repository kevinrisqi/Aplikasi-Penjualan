Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.Odbc
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data
Public Class ListBarang

    Private Sub ListBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call listBarang()
    End Sub

    Sub listBarang()
        Call koneksi()
        Dim strPath As String
        strPath = Application.StartupPath
        strPath = strPath.Substring(0, strPath.LastIndexOf("\"))
        strPath = strPath.Substring(0, strPath.LastIndexOf("\"))
        strPath = strPath + "\"
        Dim rpt As New ReportDocument
        Da = New OdbcDataAdapter("CALL GetAllBarang()", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "barang")
        rpt.Load(strPath + "\Zenai Software\Point Of Sale\Reports\DaftarBarang.rpt") 'setup
        'rpt.Load(strPath + "Reports\DaftarBarang.rpt") 'trial
        rpt.SetDataSource(Ds.Tables(0))
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        MainForm.switchPanel(FormBarang)
    End Sub
End Class