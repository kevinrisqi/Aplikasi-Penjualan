Imports System.Data.Odbc
Public Class KoreksiStok

    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        Dim i As Integer
        i = BunifuCustomDataGrid1.CurrentRow.Index

        kodeStok.Text = BunifuCustomDataGrid1.Item(1, i).Value
        'MsgBox(BunifuCustomDataGrid1.Item(0, i).Value, vbInformation)
    End Sub

    Private Sub KoreksiStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampilData()
    End Sub

    Sub tampilData()
        Call koneksi()
        Da = New OdbcDataAdapter("SELECT id,tanggal,jam,keterangan FROM koreksi_stok group by id", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "kr")
        BunifuCustomDataGrid1.DataSource = Ds.Tables("kr")
        BunifuCustomDataGrid1.ReadOnly = True
        BunifuCustomDataGrid1.Enabled = True
    End Sub
End Class