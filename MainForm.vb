﻿Imports System.Data.Odbc
Public Class MainForm

    Private Sub BunifuTileButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        If MsgBox("Apakah Anda yakin ingin keluar ?", vbYesNo + vbInformation) = vbYes Then
            Me.Dispose()
        End If
    End Sub

    Private Sub BunifuImageButton3_Click(sender As Object, e As EventArgs) Handles BunifuImageButton3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Sub nonAktif()
        btnLogin.Text = "Login"
        btnBarang.Enabled = False
        btnUser.Enabled = False
        btnDashboard.Enabled = False
        btnPenjualan.Enabled = False
        btnLaporan.Enabled = False
        btnSetup.Enabled = False
    End Sub


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Call nonAktif()
        'Call tampilBarang()
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        pnlDashboard.Show()
        pnlBarang.Hide()
    End Sub

    Private Sub btnBarang_Click(sender As Object, e As EventArgs) Handles btnBarang.Click
        switchPanel(FormBarang)
    End Sub

    Private Sub pnlBarang_Paint(sender As Object, e As PaintEventArgs) Handles pnlBarang.Paint
        FormBarang.Show()
    End Sub

    

    Sub switchPanel(ByVal panel As Form)
        Panel2.Controls.Clear()
        panel.TopLevel = False
        Panel2.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        switchPanel(FormUserlist)
    End Sub
End Class