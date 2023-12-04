Imports MySql.Data.MySqlClient
Imports System.IO
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports iText.Layout.Element
Public Class Doctor
    Inherits System.Web.UI.Page
    Dim connectionString As String = "Server=127.0.0.1;Database=citamedica;User ID=root;Password=Joana0401*;"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowDoctor()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim firstName As String = txtDoctorFirstname.Text
        Dim lastName As String = txtDoctorLastname.Text
        Dim specialityId As String = txtSpecialityId.Text

        If String.IsNullOrEmpty(firstName) Or String.IsNullOrEmpty(lastName) Or String.IsNullOrEmpty(specialityId) Then
            ' La variable está vacía o es nulla
            MsgBox("No pueden enviarse campos vacíos, complete el formulario...")
            Return
        End If

        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "INSERT INTO doctor (firstname, lastname, specialityId) VALUES (@firstname, @lastname, @specialityId)"

                ' Crear el comando
                Using cmd As New MySqlCommand(query, con)
                    ' Configurar los parámetros (ajustar según tu estructura de tabla)
                    cmd.Parameters.AddWithValue("@firstname", firstName)
                    cmd.Parameters.AddWithValue("@lastname", lastName)
                    cmd.Parameters.AddWithValue("@specialityId", specialityId)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Doctor agregado exitosamente")
                ShowDoctor()
            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al agregar un doctor, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim id As String = txtDoctorId.Text

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
                Dim query As String = "DELETE FROM doctor WHERE ID = (@id)"

                ' Crear el comando
                Using cmd As New MySqlCommand(query, con)
                    ' Configurar los parámetros (ajustar según tu estructura de tabla)
                    cmd.Parameters.AddWithValue("@id", id)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("doctor eliminado exitosamente")
                ShowDoctor()
            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al eliminar el doctor, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Private Sub ShowDoctor()
        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "SELECT d.id, d.firstname as 'Nombre', d.lastname as 'Apellido', d.specialityId as 'Especialidad ID' FROM doctor d"

                ' Crear el comando
                Using da As New MySqlDataAdapter(query, con)
                    Dim ds As New DataSet()

                    ' Llenar el conjunto de datos con los resultados de la consulta
                    da.Fill(ds)

                    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                        ' Enlazar el conjunto de datos al GridView
                        GridViewDoctor.DataSource = ds
                        GridViewDoctor.DataBind()
                    Else
                        ' No hay registros, puedes mostrar un mensaje o realizar alguna otra acción
                        MsgBox("No hay registros de doctores en la tabla para mostrar. Agregue uno!")
                    End If
                End Using

            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al mostrar los doctores, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim firstName As String = txtDoctorFirstname.Text
        Dim lastName As String = txtDoctorLastname.Text
        Dim specialityId As String = txtSpecialityId.Text
        Dim id As String = txtDoctorId.Text

        If String.IsNullOrEmpty(firstName) Or String.IsNullOrEmpty(lastName) Or String.IsNullOrEmpty(specialityId) Or String.IsNullOrEmpty(id) Then
            ' La variable está vacía o es nulla
            MsgBox("No pueden enviarse campos vacíos, complete el formulario...")
            Return
        End If

        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "UPDATE doctor SET firstname = (@firstname), lastname = (@lastname), specialityId = (@specialityId) WHERE id = (@id)"

                ' Crear el comando
                Using cmd As New MySqlCommand(query, con)
                    ' Configurar los parámetros (ajustar según tu estructura de tabla)
                    cmd.Parameters.AddWithValue("@specialityId", specialityId)
                    cmd.Parameters.AddWithValue("@firstname", firstName)
                    cmd.Parameters.AddWithValue("@lastname", lastName)
                    cmd.Parameters.AddWithValue("@id", id)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Doctor actualizado exitosamente")
                ShowDoctor()
            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al actualizar el doctor, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        ShowDoctor()
    End Sub

    Private Sub GeneratePDF()
        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "SELECT d.id, d.firstname as 'Nombre', d.lastname as 'Apellido', d.specialityId as 'Especialidad ID' FROM doctor d"

                ' Crear el comando
                Using da As New MySqlDataAdapter(query, con)
                    Dim ds As New DataSet()

                    ' Llenar el conjunto de datos con los resultados de la consulta
                    da.Fill(ds)

                    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                        ' Crear el documento PDF
                        Dim pdfFilePath As String = Server.MapPath("~/Doctores.pdf")

                        Using writer As New PdfWriter(pdfFilePath)
                            Using pdf As New PdfDocument(writer)
                                Dim document As New Document(pdf)

                                ' Agregar encabezado al PDF
                                document.Add(New Paragraph("Registros de Doctores"))

                                ' Iterar a través de los registros y agregarlos al PDF
                                For Each row As DataRow In ds.Tables(0).Rows
                                    document.Add(New Paragraph($"ID: {row("id")}, Nombre: {row("Nombre")}, Apellido: {row("Apellido")}, Especialidad ID: {row("Especialidad ID")}"))
                                Next
                            End Using
                        End Using

                        ' Descargar el PDF generado
                        Response.ContentType = "application/pdf"
                        Response.AppendHeader("Content-Disposition", "attachment; filename=Doctores.pdf")
                        Response.TransmitFile(pdfFilePath)
                        Response.End()
                    Else
                        ' No hay registros, puedes mostrar un mensaje o realizar alguna otra acción
                        MsgBox("No hay registros de doctores en la tabla para generar el PDF. Agregue uno!")
                    End If
                End Using

            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al generar el PDF de los doctores, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GeneratePDF()
    End Sub
End Class