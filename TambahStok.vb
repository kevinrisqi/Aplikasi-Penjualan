Imports System.Data.Odbc
Public Class TambahStok


    Private Sub TambahStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadTambahStok()
        Call kodeOtomatis()
    End Sub

    Sub loadTambahStok()
        petugas.Text = MainForm.btnLogin.Text
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tanggal.Text = DateTime.Now.ToString("yyyy-MM-dd")
    End Sub

    Sub kodeOtomatis()
        Call koneksi()
        Cmd = New OdbcCommand("select * from koreksi_stok where id in (select max(id) from koreksi_stok)", Conn)
        Dim urutan As String
        Dim hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            urutan = "STK" + "001"
        Else
            hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            urutan = "STK" + Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        IDTrans.Text = urutan
    End Sub

    Private Sub newstock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles newstock.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class