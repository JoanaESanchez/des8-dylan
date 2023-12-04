Imports MySql.Data.MySqlClient
Imports System.IO
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports iText.Layout.Element

Public Class Paciente
    Inherits System.Web.UI.Page
    Dim connectionString As String = "Server=127.0.0.1;Database=citamedica;User ID=root;Password=Joana0401*;"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowPacient()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim firstName As String = txtPacientFirstname.Text
        Dim lastName As String = txtPacientLastname.Text
        Dim sintoma As String = txtSintoma.Text
        Dim doctorId As String = txtDoctorId.Text

        If String.IsNullOrEmpty(firstName) Or String.IsNullOrEmpty(lastName) Or String.IsNullOrEmpty(sintoma) Or String.IsNullOrEmpty(doctorId) Then
            ' La variable está vacía o es nulla
            MsgBox("No pueden enviarse campos vacíos, complete el formulario...")
            Return
        End If

        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "INSERT INTO pacient (firstname, lastname, sintoma, doctorId) VALUES (@firstname, @lastname, @sintoma, @doctorId)"

                ' Crear el comando
                Using cmd As New MySqlCommand(query, con)
                    ' Configurar los parámetros (ajustar según tu estructura de tabla)
                    cmd.Parameters.AddWithValue("@firstname", firstName)
                    cmd.Parameters.AddWithValue("@lastname", lastName)
                    cmd.Parameters.AddWithValue("@sintoma", sintoma)
                    cmd.Parameters.AddWithValue("@doctorId", doctorId)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Paciente agregado exitosamente")
                ShowPacient()
            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al agregar un paciente, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Private Sub ShowPacient()
        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "SELECT p.id, p.firstname as 'Nombre', p.lastname as 'Apellido', p.sintoma, p.doctorId as 'Doctor ID' FROM pacient p"

                ' Crear el comando
                Using da As New MySqlDataAdapter(query, con)
                    Dim ds As New DataSet()

                    ' Llenar el conjunto de datos con los resultados de la consulta
                    da.Fill(ds)

                    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                        ' Enlazar el conjunto de datos al GridView
                        GridViewPacient.DataSource = ds
                        GridViewPacient.DataBind()
                    Else
                        ' No hay registros, puedes mostrar un mensaje o realizar alguna otra acción
                        MsgBox("No hay registros de pacientes en la tabla para mostrar. Agregue uno!")
                    End If
                End Using

            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al mostrar los pacientes, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim id As String = txtPacientId.Text

        If String.IsNullOrEmpty(id) Then
            ' La variable está vacía o es nulla
            MsgBox("No puede enviarse si el id esta vacío")
            Return
        End If

        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "DELETE FROM pacient WHERE ID = (@id)"

                ' Crear el comando
                Using cmd As New MySqlCommand(query, con)
                    ' Configurar los parámetros (ajustar según tu estructura de tabla)
                    cmd.Parameters.AddWithValue("@id", id)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("paciente eliminado exitosamente")
                ShowPacient()
            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al eliminar el paciente, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        ShowPacient()
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim doctorId As String = txtDoctorId.Text
        Dim firstName As String = txtPacientFirstname.Text
        Dim lastName As String = txtPacientLastname.Text
        Dim sintoma As String = txtSintoma.Text
        Dim id As String = txtPacientId.Text

        If String.IsNullOrEmpty(firstName) Or String.IsNullOrEmpty(lastName) Or String.IsNullOrEmpty(sintoma) Or String.IsNullOrEmpty(id) Or String.IsNullOrEmpty(doctorId) Then
            ' La variable está vacía o es nulla
            MsgBox("No pueden enviarse campos vacíos, complete el formulario...")
            Return
        End If

        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "UPDATE pacient SET firstname = (@firstname), lastname = (@lastname), sintoma = (@sintoma), doctorId = (@doctorId) WHERE id = (@id)"

                ' Crear el comando
                Using cmd As New MySqlCommand(query, con)
                    ' Configurar los parámetros (ajustar según tu estructura de tabla)
                    cmd.Parameters.AddWithValue("@sintoma", sintoma)
                    cmd.Parameters.AddWithValue("@firstname", firstName)
                    cmd.Parameters.AddWithValue("@lastname", lastName)
                    cmd.Parameters.AddWithValue("@doctorId", doctorId)
                    cmd.Parameters.AddWithValue("@id", id)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Paciente actualizado exitosamente")
                ShowPacient()
            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al actualizar el paciente, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub


    Private Sub GeneratePDF()
        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "SELECT p.id, p.firstname as 'Nombre', p.lastname as 'Apellido', p.sintoma, p.doctorId as 'Doctor ID' FROM pacient p"

                ' Crear el comando
                Using da As New MySqlDataAdapter(query, con)
                    Dim ds As New DataSet()

                    ' Llenar el conjunto de datos con los resultados de la consulta
                    da.Fill(ds)

                    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                        ' Crear el documento PDF
                        Dim pdfFilePath As String = Server.MapPath("~/Pacientes.pdf")

                        Using writer As New PdfWriter(pdfFilePath)
                            Using pdf As New PdfDocument(writer)
                                Dim document As New Document(pdf)

                                ' Agregar encabezado al PDF
                                document.Add(New Paragraph("Registros de Pacientes"))

                                ' Iterar a través de los registros y agregarlos al PDF
                                For Each row As DataRow In ds.Tables(0).Rows
                                    document.Add(New Paragraph($"ID: {row("id")}, Nombre: {row("Nombre")}, Apellido: {row("Apellido")}, Síntoma: {row("sintoma")}, Doctor ID: {row("Doctor ID")}"))
                                Next
                            End Using
                        End Using

                        ' Descargar el PDF generado
                        Response.ContentType = "application/pdf"
                        Response.AppendHeader("Content-Disposition", "attachment; filename=Pacientes.pdf")
                        Response.TransmitFile(pdfFilePath)
                        Response.End()
                    Else
                        ' No hay registros, puedes mostrar un mensaje o realizar alguna otra acción
                        MsgBox("No hay registros de pacientes en la tabla para generar el PDF. Agregue uno!")
                    End If
                End Using

            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al generar el PDF de los pacientes, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GeneratePDF()
    End Sub
End Class