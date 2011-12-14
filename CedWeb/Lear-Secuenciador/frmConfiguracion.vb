Public Class frmConfiguracion

    Dim LectArchINI As LecturaArchivoINI
    Dim PathArchINI As String

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmConfiguracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Header10TextBox.Text, Header11TextBox.Text, Header12TextBox.Text
        'Header20TextBox.Text, Header21TextBox.Text, Header22TextBox.Text

        PathArchINI = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()) + "Secuenciador.INI"

        ArchivoDatos1TextBox.Text = LectArchINI.IniGet(PathArchINI, "MAIN", "Arch1")
        ArchivoDatos2TextBox.Text = LectArchINI.IniGet(PathArchINI, "MAIN", "Arch2")
    End Sub

End Class