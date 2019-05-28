﻿Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.Odbc
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data

Public Class FormLapPenjualanV1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim cryRpt As New ReportDocument
        'cryRpt.Load("G:\Project\AplikasiKasir - Fail\AplikasiPenjualanV1\Aplikasi-Penjualan\LaporanPenjualan.rpt")
        'cryRpt.Datas()
        'CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()

        Call loadReport()
    End Sub

    Private Sub FormLapPenjualanV1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub loadReport()
        Call koneksi()
        Dim rpt As New ReportDocument
        Da = New OdbcDataAdapter("SELECT id_barang, nama_barang,harga_satuan, SUM(qty) AS qty, SUM(SubTotal) AS subtotal,SUM(diskon) AS diskon,SUM(netto) AS netto,SUM(total_pokok) AS total_pokok,penjualan.tanggal AS tanggal FROM detail_penjualan JOIN penjualan ON penjualan.id_penjualan = detail_penjualan.id_penjualan WHERE tanggal = '2019-05-27' GROUP BY id_barang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "DetailTransaksi")
        DataGridView1.DataSource = Ds.Tables(0)
        rpt.Load("G:\Project\AplikasiKasir - Fail\AplikasiPenjualanV1\Aplikasi-Penjualan\CrystalReport3.rpt")
        rpt.SetDataSource(Ds.Tables(0))
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()
    End Sub

End Class