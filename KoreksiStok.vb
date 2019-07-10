Imports System.Data.Odbc
Public Class KoreksiStok

    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        Dim i As Integer
        Dim kodeStok As String
        i = BunifuCustomDataGrid1.CurrentRow.Index

        kodeStok = BunifuCustomDataGrid1.Item(0, i).Value
        'search.text = BunifuCustomDataGrid1.Item(0, i).Value
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

    Sub searchData()
        Call koneksi()
        Dim searchData As String = "SELECT id,tanggal,jam,keterangan,admin FROM koreksi_stok where id like '%" & search.text & "%' GROUP BY id ORDER BY tanggal DESC"
        Cmd = New OdbcCommand(searchData, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Call koneksi()
            Dim query As String = "SELECT id,tanggal,jam,keterangan,admin FROM koreksi_stok where id like '%" & search.text & "%' GROUP BY id ORDER BY tanggal DESC"
            Da = New OdbcDataAdapter(query, Conn)
            Ds = New DataSet
            Da.Fill(Ds)
            BunifuCustomDataGrid1.DataSource = Ds.Tables(0)
        End If
    End Sub


    Private Sub search_OnTextChange(sender As Object, e As EventArgs) Handles search.OnTextChange
        Call searchData()
    End Sub


End Class