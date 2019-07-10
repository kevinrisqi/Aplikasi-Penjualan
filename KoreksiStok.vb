Imports System.Data.Odbc
Public Class KoreksiStok

    Dim kodeStok As String

    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        Dim i As Integer

        i = BunifuCustomDataGrid1.CurrentRow.Index

        kodeStok = BunifuCustomDataGrid1.Item(0, i).Value
        'searchItem.Text = BunifuCustomDataGrid1.Item(0, i).Value
        Call koneksi()
        Da = New OdbcDataAdapter("SELECT nama_barang,stok_lama,stok_sekarang FROM koreksi_stok WHERE id='" & kodeStok & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "kr2")
        BunifuCustomDataGrid2.DataSource = Ds.Tables("kr2")
        BunifuCustomDataGrid2.ReadOnly = True
        BunifuCustomDataGrid2.Enabled = True
    End Sub

    Private Sub KoreksiStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampilData()
    End Sub

    Sub tampilData()
        Call koneksi()
        Da = New OdbcDataAdapter("SELECT id,tanggal,jam,keterangan,admin FROM koreksi_stok GROUP BY id ORDER BY tanggal DESC", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "kr")
        BunifuCustomDataGrid1.DataSource = Ds.Tables("kr")
        BunifuCustomDataGrid1.ReadOnly = True
        BunifuCustomDataGrid1.Enabled = True
    End Sub

    Sub searchDataByID()
        Call koneksi()
        Dim searchData As String = "SELECT id,tanggal,jam,keterangan,admin FROM koreksi_stok WHERE id like '%" & searchItem.text & "%' GROUP BY id ORDER BY tanggal DESC"
        Cmd = New OdbcCommand(searchData, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Call koneksi()
            Dim query As String = "SELECT id,tanggal,jam,keterangan,admin FROM koreksi_stok WHERE id like '%" & searchItem.text & "%'  GROUP BY id ORDER BY tanggal DESC"
            Da = New OdbcDataAdapter(query, Conn)
            Ds = New DataSet
            Da.Fill(Ds)
            BunifuCustomDataGrid1.DataSource = Ds.Tables(0)
        End If
    End Sub

    Sub searchDataByTanggal()
        Call koneksi()
        Dim searchData As String = "SELECT id,tanggal,jam,keterangan,admin FROM koreksi_stok WHERE tanggal like '%" & searchItem.text & "%' GROUP BY id ORDER BY tanggal DESC"
        Cmd = New OdbcCommand(searchData, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Call koneksi()
            Dim query As String = "SELECT id,tanggal,jam,keterangan,admin FROM koreksi_stok WHERE tanggal like '%" & searchItem.text & "%'  GROUP BY id ORDER BY tanggal DESC"
            Da = New OdbcDataAdapter(query, Conn)
            Ds = New DataSet
            Da.Fill(Ds)
            BunifuCustomDataGrid1.DataSource = Ds.Tables(0)
        End If
    End Sub

    Sub searchDataByKeterangan()
        Call koneksi()
        Dim searchData As String = "SELECT id,tanggal,jam,keterangan,admin FROM koreksi_stok WHERE keterangan like '%" & searchItem.text & "%' GROUP BY id ORDER BY tanggal DESC"
        Cmd = New OdbcCommand(searchData, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Call koneksi()
            Dim query As String = "SELECT id,tanggal,jam,keterangan,admin FROM koreksi_stok WHERE keterangan like '%" & searchItem.text & "%'  GROUP BY id ORDER BY tanggal DESC"
            Da = New OdbcDataAdapter(query, Conn)
            Ds = New DataSet
            Da.Fill(Ds)
            BunifuCustomDataGrid1.DataSource = Ds.Tables(0)
        End If
    End Sub

    Private Sub search_OnTextChange(sender As Object, e As EventArgs) Handles searchItem.OnTextChange
        If R_ID.Checked = True Then
            Call searchDataByID()
        ElseIf R_Tanggal.Checked = True Then
            Call searchDataByTanggal()
        Else
            Call searchDataByKeterangan()
        End If
    End Sub

    Sub hapusData()
        If kodeStok = "" Then
            MsgBox("Pilih data yang akan dihapus !", vbInformation)
        ElseIf MsgBox("Apakah Anda ingin menghapusnya ?", vbInformation + vbYesNo) = vbYes Then
            Call koneksi()
            Dim deleteData As String = "DELETE FROM koreksi_stok WHERE id = '" & kodeStok & "'"
            Cmd = New OdbcCommand(deleteData, Conn)
            Cmd.ExecuteNonQuery()
            'MsgBox("Data berhasil dihapus")
            Call tampilData()
        Else
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Call hapusData()
    End Sub
End Class