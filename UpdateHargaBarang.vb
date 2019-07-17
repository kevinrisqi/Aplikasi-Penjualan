Imports System.Data.Odbc
Public Class UpdateHargaBarang

    Private Sub UpdateHargaBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
                Call insertData()
                Call updateData()
        End If
    End Sub

    Private Sub UpdateHargaBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
    End Sub

    Private Sub beliMax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles beli.KeyPress
        If beli.Text.Length >= 9 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub beli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles beli.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub jual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles jual.KeyPress
        If jual.Text.Length >= 10 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub jualMax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles jual.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub keterangan_KeyPress(sender As Object, e As KeyPressEventArgs)
        If keterangan.Text.Length >= 130 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub keteranganSubmit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles keterangan.KeyPress

    End Sub

    Sub switchPanel(ByVal panel As Form)
        MainForm.Panel2.Controls.Clear()
        panel.TopLevel = False
        MainForm.Panel2.Controls.Add(panel)
        panel.Show()
    End Sub

    Sub kondisiAwal()
        kodeBarang.Text = ""
        namaBarang.Text = ""
        beli.Text = ""
        jual.Text = ""
        id.Text = ""
    End Sub

    Sub insertData()
        If kodeBarang.Text = "" Or namaBarang.Text = "" Or beli.Text = "" Or jual.Text = "" Or keterangan.Text = "" Then
            MsgBox("Silahkan isi data dengan lengkap !", vbInformation)
        ElseIf Val(beli.Text) > Val(jual.Text) Then
            MsgBox("Harga beli harus lebih kecil dari harga jual !", vbInformation)
        Else
            Call koneksi()
            Dim inputData As String = "INSERT INTO update_harga (id_barang,harga_beli,harga_jual,keterangan,tanggal,jam) values ('" & kodeBarang.Text & "', '" & beli.Text & "', '" & jual.Text & "', '" & keterangan.Text & "', '" & tanggal.Text & "','" & jam.Text & "')"
            Cmd = New OdbcCommand(inputData, Conn)
            Cmd.ExecuteNonQuery()
            Cmd = New OdbcCommand("UPDATE barang set harga_beli='" & beli.Text & "' OR harga_jual = '" & jual.Text & "' WHERE id='" & id.Text & "'", Conn)
            Cmd.ExecuteNonQuery()
            Call kondisiAwal()
            Call FormBarang.kondisiAwal()
            switchPanel(UpdateHarga)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tanggal.Text = DateTime.Now.ToString("yyyy-MM-dd")
        jam.Text = DateTime.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click
            Call insertData()
            Call updateData()
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        switchPanel(UpdateHarga)
        Call kondisiAwal()
    End Sub
End Class