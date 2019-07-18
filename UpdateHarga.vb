Imports System.Data.Odbc
Public Class UpdateHarga


    Sub tampilBarang()
        Call koneksi()
        Da = New OdbcDataAdapter("SELECT id,id_barang,nama_barang,harga_beli,harga_jual FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori ORDER BY id_barang ASC", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "barang")
        BunifuCustomDataGrid1.DataSource = Ds.Tables("barang")
        BunifuCustomDataGrid1.ReadOnly = True
    End Sub

    Private Sub UpdateHarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampilBarang()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub search_OnTextChange(sender As Object, e As EventArgs) Handles search.OnTextChange
        If RadioButton1.Checked Then
            Call koneksi()
            Dim searchData As String = "SELECT id,id_barang,nama_barang,harga_beli,harga_jual FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori WHERE barang.id_barang  like '%" & search.text & "%' ORDER BY id_barang ASC"
            Cmd = New OdbcCommand(searchData, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call koneksi()
                Dim query As String = "SELECT id,id_barang,nama_barang,harga_beli,harga_jual FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori WHERE barang.id_barang like '%" & search.text & "%' ORDER BY id_barang ASC"
                Da = New OdbcDataAdapter(query, Conn)
                Ds = New DataSet
                Da.Fill(Ds, "barang")
                BunifuCustomDataGrid1.DataSource = Ds.Tables("barang")
            End If
        ElseIf RadioButton2.Checked Then
            Call koneksi()
            Dim searchData As String = "SELECT id,id_barang,nama_barang,harga_beli,harga_jual FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori WHERE barang.nama_barang  like '%" & search.text & "%' ORDER BY id_barang ASC"
            Cmd = New OdbcCommand(searchData, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call koneksi()
                Dim query As String = "SELECT id,id_barang,nama_barang,harga_beli,harga_jual FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori WHERE barang.nama_barang like '%" & search.text & "%' ORDER BY id_barang ASC"
                Da = New OdbcDataAdapter(query, Conn)
                Ds = New DataSet
                Da.Fill(Ds, "barang")
                BunifuCustomDataGrid1.DataSource = Ds.Tables("barang")
            End If
        ElseIf search.text = "" Then
            Call tampilBarang()
        Else
        End If
    End Sub

    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        Dim i As Integer

        i = BunifuCustomDataGrid1.CurrentRow.Index

        'searchItem.Text = BunifuCustomDataGrid1.Item(0, i).Value
        Call koneksi()
        Da = New OdbcDataAdapter("SELECT tanggal,jam,keterangan,harga_beli,harga_jual FROM update_harga WHERE id_barang='" & BunifuCustomDataGrid1.Item(1, i).Value & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "bc2")
        BunifuCustomDataGrid2.DataSource = Ds.Tables("bc2")
        BunifuCustomDataGrid2.ReadOnly = True
        BunifuCustomDataGrid2.Enabled = True
    End Sub

    Private Sub BunifuCustomDataGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellContentClick

    End Sub

    Private Sub BunifuCustomDataGrid1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellDoubleClick
        Dim i As Integer
        i = BunifuCustomDataGrid1.CurrentRow.Index

        'UpdateHargaBarang.id.Text = BunifuCustomDataGrid1.Item(0, i).Value
        UpdateHargaBarang.id.Text = BunifuCustomDataGrid1.Item(0, i).Value
        UpdateHargaBarang.kodeBarang.Text = BunifuCustomDataGrid1.Item(1, i).Value
        UpdateHargaBarang.namaBarang.Text = BunifuCustomDataGrid1.Item(2, i).Value
        UpdateHargaBarang.beli.Text = BunifuCustomDataGrid1.Item(3, i).Value
        UpdateHargaBarang.jual.Text = BunifuCustomDataGrid1.Item(4, i).Value
        MainForm.switchPanel(UpdateHargaBarang)
    End Sub

    Private Sub BunifuTextbox1_OnTextChange(sender As Object, e As EventArgs) Handles BunifuTextbox1.OnTextChange
        If RadioButton4.Checked Then
            Call koneksi()
            Dim searchData As String = "SELECT tanggal,jam,keterangan,harga_beli,harga_jual FROM update_harga WHERE tanggal like '%" & BunifuTextbox1.text & "%'"
            Cmd = New OdbcCommand(searchData, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call koneksi()
                Dim query As String = "SELECT tanggal,jam,keterangan,harga_beli,harga_jual FROM update_harga WHERE tanggal like '%" & BunifuTextbox1.text & "%'"
                Da = New OdbcDataAdapter(query, Conn)
                Ds = New DataSet
                Da.Fill(Ds, "update_harga")
                BunifuCustomDataGrid2.DataSource = Ds.Tables("update_harga")
            End If
        ElseIf RadioButton3.Checked Then
            Call koneksi()
            Dim searchData As String = "SELECT tanggal,jam,keterangan,harga_beli,harga_jual FROM update_harga WHERE keterangan like '%" & BunifuTextbox1.text & "%'"
            Cmd = New OdbcCommand(searchData, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call koneksi()
                Dim query As String = "SELECT tanggal,jam,keterangan,harga_beli,harga_jual FROM update_harga WHERE keterangan like '%" & BunifuTextbox1.text & "%'"
                Da = New OdbcDataAdapter(query, Conn)
                Ds = New DataSet
                Da.Fill(Ds, "update_harga")
                BunifuCustomDataGrid2.DataSource = Ds.Tables("update_harga")
            End If
        Else
        End If
    End Sub
End Class