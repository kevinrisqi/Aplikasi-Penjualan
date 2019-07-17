Imports System.Data.Odbc
Public Class UpdateHarga


    Sub tampilBarang()
        Call koneksi()
        Da = New OdbcDataAdapter("SELECT id,id_barang,nama_barang,harga_beli,harga_jual FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori", Conn)
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
            Dim searchData As String = "SELECT * FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori WHERE barang.id_barang  like '%" & search.text & "%'"
            Cmd = New OdbcCommand(searchData, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call koneksi()
                Dim query As String = "SELECT * FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori WHERE barang.id_barang like '%" & search.text & "%'"
                Da = New OdbcDataAdapter(query, Conn)
                Ds = New DataSet
                Da.Fill(Ds, "barang")
                BunifuCustomDataGrid1.DataSource = Ds.Tables("barang")
            End If
        Else
            Call koneksi()
            Dim searchData As String = "SELECT * FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori WHERE barang.nama_barang  like '%" & search.text & "%'"
            Cmd = New OdbcCommand(searchData, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call koneksi()
                Dim query As String = "SELECT * FROM barang JOIN kategori_barang ON barang.id_kategori = kategori_barang.id_kategori WHERE barang.nama_barang like '%" & search.text & "%'"
                Da = New OdbcDataAdapter(query, Conn)
                Ds = New DataSet
                Da.Fill(Ds, "barang")
                BunifuCustomDataGrid1.DataSource = Ds.Tables("barang")
            End If
        End If
    End Sub
End Class