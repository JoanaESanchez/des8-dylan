Imports System.Drawing
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.IO
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports iText.Layout.Element
Public Class Especialidades
    Inherits System.Web.UI.Page
    Dim connectionString As String = "Server=127.0.0.1;Database=citamedica;User ID=root;Password=Joana0401*;"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowSpeciality()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim speciality As String = DropDownSpeciality.SelectedValue

        If String.IsNullOrEmpty(speciality) Then
            ' La variable está vacía o es nulla
            MsgBox("No pueden enviarse sin haber seleccionado una especialidad, seleccione una.")
            Return
        End If

        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "INSERT INTO speciality (speciality) VALUES (@speciality)"

                ' Crear el comando
                Using cmd As New MySqlCommand(query, con)
                    ' Configurar los parámetros (ajustar según tu estructura de tabla)
                    cmd.Parameters.AddWithValue("@speciality", speciality)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Especialidad agregada exitosamente")
                ShowSpeciality()
            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al agregar la especialidad, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim id As String = txtSpecialityId.Text

        If String.IsNullOrEmpty(id) Then
            ' La variable está vacía o es nulla
            MsgBox("No pueden enviarse si el id esta vacio")
            Return
        End If

        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "DELETE FROM speciality WHERE ID = (@id)"

                ' Crear el comando
                Using cmd As New MySqlCommand(query, con)
                    ' Configurar los parámetros (ajustar según tu estructura de tabla)
                    cmd.Parameters.AddWithValue("@id", id)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Especialidad eliminada exitosamente")
                ShowSpeciality()
            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al eliminar la especialidad, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        ShowSpeciality()
    End Sub

    Private Sub ShowSpeciality()
        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "SELECT s.id, s.speciality as 'Especialidad' FROM speciality s"

                ' Crear el comando
                Using da As New MySqlDataAdapter(query, con)
                    Dim ds As New DataSet()

                    ' Llenar el conjunto de datos con los resultados de la consulta
                    da.Fill(ds)

                    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                        ' Enlazar el conjunto de datos al GridView
                        GridViewSpeciality.DataSource = ds
                        GridViewSpeciality.DataBind()
                    Else
                        ' No hay registros, puedes mostrar un mensaje o realizar alguna otra acción
                        MsgBox("No hay registros de especialidades en la tabla para mostrar. Agregue uno")
                    End If
                End Using

            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al mostrar las especialidades, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim speciality As String = DropDownSpeciality.SelectedValue
        Dim id As String = txtSpecialityId.Text

        If String.IsNullOrEmpty(speciality) Or String.IsNullOrEmpty(id) Then
            ' La variable está vacía o es nulla
            MsgBox("No pueden enviarse campos vacíos, complete el formulario...")
            Return
        End If

        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "UPDATE speciality SET speciality = (@speciality) WHERE id = (@id)"

                ' Crear el comando
                Using cmd As New MySqlCommand(query, con)
                    ' Configurar los parámetros (ajustar según tu estructura de tabla)
                    cmd.Parameters.AddWithValue("@speciality", speciality)
                    cmd.Parameters.AddWithValue("@id", id)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Especialidad actualizada exitosamente")
                ShowSpeciality()
            Catch ex As Exception
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al actualizar la especialidad, intenta nuevamente...")
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
                Dim query As String = "SELECT s.id, s.speciality as 'Especialidad' FROM speciality s"

                ' Crear el comando
                Using da As New MySqlDataAdapter(query, con)
                    Dim ds As New DataSet()

                    ' Llenar el conjunto de datos con los resultados de la consulta
                    da.Fill(ds)

                    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                        ' Crear el documento PDF
                        Dim pdfFilePath As String = Server.MapPath("~/Especialidades.pdf")

                        Using writer As New PdfWriter(pdfFilePath)
                            Using pdf As New PdfDocument(writer)
                                Dim document As New Document(pdf)

                                ' Agregar encabezado al PDF
                                document.Add(New Paragraph("Registros de Especialidades"))

                                ' Iterar a través de los registros y agregarlos al PDF
                                For Each row As DataRow In ds.Tables(0).Rows
                                    document.Add(New Paragraph($"ID: {row("id")}, Especialidad: {row("Especialidad")}"))
                                Next
                            End Using
                        End Using

                        ' Descargar el PDF generado
                        Response.ContentType = "application/pdf"
                        Response.AppendHeader("Content-Disposition", "attachment; filename=Especialidades.pdf")
                        Response.TransmitFile(pdfFilePath)
                        Response.End()
                    Else
                        ' No hay registros, puedes mostrar un mensaje o realizar alguna otra acción
                        MsgBox("No hay registros de especialidades en la tabla para generar el PDF. Agregue uno")
                    End If
                End Using

            Catch ex As Exception
                Trace.Write(ex.ToString())

                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al generar el PDF de las especialidades, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GeneratePDF()
    End Sub
End Class