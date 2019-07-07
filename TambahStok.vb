Imports System.Data.Odbc
Public Class TambahStok

    Public namaBarang As String
    Public jam As String

    Private Sub TambahStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadTambahStok()
        Call kodeOtomatis()
    End Sub

    Sub loadTambahStok()
        petugas.Text = MainForm.btnLogin.Text
        newstock.Text = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tanggal.Text = DateTime.Now.ToString("yyyy-MM-dd")
        jam = DateTime.Now.ToString("hh:mm:ss")
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

    Sub inputBarang()
        Cmd = New OdbcCommand("SELECT * FROM barang WHERE id_barang='" & kodebarang.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            MsgBox("Kode Barang tidak tersedia !", vbInformation)
        Else
            namaBarang = Rd.Item("nama_barang")
            oldstock.Text = Rd.Item("stok")
        End If
    End Sub

    Sub tambahStok()
        If Val(newstock.Text) + Val(oldstock.Text) < 0 Then
            MsgBox("Stok tidak boleh kurang dari 0 !", vbInformation)
        Else
            BunifuCustomDataGrid2.Rows.Add(New String() {namaBarang, oldstock.Text, Val(newstock.Text) + Val(oldstock.Text)})
        End If
    End Sub

    Sub simpanStok()
        If BunifuCustomDataGrid2.Rows.Count = 0 Then
            MsgBox("Data masih kosong, silahkan isi data terlebih dahulu !", vbInformation)
        Else
            'Cmd = New OdbcCommand("INSERT INTO koreksi_stok (id) VALUES ('"& IDTrans.Text &"')")
            For baris As Integer = 0 To BunifuCustomDataGrid2.Rows.Count - 1
                Cmd = New OdbcCommand("INSERT INTO koreksi_stok (id,tanggal,jam,admin,keterangan,nama_barang,stok_lama,stok_sekarang) VALUES ('" & IDTrans.Text & "','" & tanggal.Text & "','" & jam & "','" & petugas.Text & "','" & keterangan.Text & "','" & BunifuCustomDataGrid2.Rows(baris).Cells(0).Value & "','" & BunifuCustomDataGrid2.Rows(baris).Cells(1).Value & "','" & BunifuCustomDataGrid2.Rows(baris).Cells(2).Value & "')", Conn)
                Cmd.ExecuteNonQuery()
            Next
        End If
    End Sub


    Private Sub newstock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles newstock.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = "-") Then e.Handled = True
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        KoreksiBarang.Show()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Call tambahStok()
    End Sub

    Private Sub kodebarang_KeyDown(sender As Object, e As KeyEventArgs) Handles kodebarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call inputBarang()
        End If
    End Sub

    Private Sub kodebarang_TextChanged(sender As Object, e As EventArgs) Handles kodebarang.TextChanged

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        If BunifuCustomDataGrid2.SelectedRows.Count > 0 Then
            'MsgBox("Data tersedia", vbInformation)
            BunifuCustomDataGrid2.Rows.Remove(BunifuCustomDataGrid2.SelectedRows(0))
        Else
            MsgBox("Silahkan pilih satu baris data yang akan dihapus !", vbInformation)
        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Call simpanStok()
    End Sub
End Class