Imports iText.Kernel.Pdf
Imports iText.Layout.Element
Imports MySql.Data.MySqlClient
Imports System.IO
Imports iText.Layout

Public Class Cita
    Inherits System.Web.UI.Page
    Dim connectionString As String = "Server=127.0.0.1;Database=citamedica;User ID=root;Password=Joana0401*;"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowCitas()
    End Sub

    Private Sub ShowCitas()
        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "SELECT d.id as 'Doctor ID', d.firstname as 'Doctor nombre', d.lastname as 'Doctor apellido', s.id as 'Especialidad ID', s.speciality as 'Especialidad', p.id as 'Paciente ID', p.firstname as 'Paciente nombre', p.lastname as 'Paciente apellido', p.sintoma FROM doctor d INNER JOIN speciality s ON d.specialityId = s.id INNER JOIN pacient p ON d.id = p.doctorId"


                ' Crear el comando
                Using da As New MySqlDataAdapter(query, con)
                    Dim ds As New DataSet()

                    ' Llenar el conjunto de datos con los resultados de la consulta
                    da.Fill(ds)

                    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                        ' Enlazar el conjunto de datos al GridView
                        GridViewCitas.DataSource = ds
                        GridViewCitas.DataBind()
                    Else
                        ' No hay registros, puedes mostrar un mensaje o realizar alguna otra acción
                        MsgBox("No hay registros de citas en la tabla para mostrar. Agregue uno!")
                    End If
                End Using

            Catch ex As Exception
                Console.WriteLine("Error al ejecutar la consulta: " & ex.Message)
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al mostrar las citas, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        ShowCitas()
    End Sub

    Private Sub GeneratePDF()
        Using con As New MySqlConnection(connectionString)
            Try
                ' Abrir la conexión
                con.Open()

                ' Ejemplo de consulta
                Dim query As String = "SELECT d.id as 'Doctor ID', d.firstname as 'Doctor nombre', d.lastname as 'Doctor apellido', s.id as 'Especialidad ID', s.speciality as 'Especialidad', p.id as 'Paciente ID', p.firstname as 'Paciente nombre', p.lastname as 'Paciente apellido', p.sintoma FROM doctor d INNER JOIN speciality s ON d.specialityId = s.id INNER JOIN pacient p ON d.id = p.doctorId"

                ' Crear el comando
                Using da As New MySqlDataAdapter(query, con)
                    Dim ds As New DataSet()

                    ' Llenar el conjunto de datos con los resultados de la consulta
                    da.Fill(ds)

                    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                        ' Crear el documento PDF
                        Dim pdfFilePath As String = Server.MapPath("~/Citas.pdf")

                        Using writer As New PdfWriter(pdfFilePath)
                            Using pdf As New PdfDocument(writer)
                                Dim document As New Document(pdf)

                                ' Agregar encabezado al PDF
                                document.Add(New Paragraph("Registros de Citas"))

                                ' Iterar a través de los registros y agregarlos al PDF
                                For Each row As DataRow In ds.Tables(0).Rows
                                    document.Add(New Paragraph($"Doctor ID: {row("Doctor ID")}, Doctor Nombre: {row("Doctor nombre")}, Doctor Apellido: {row("Doctor apellido")}, Especialidad ID: {row("Especialidad ID")}, Especialidad: {row("Especialidad")}, Paciente ID: {row("Paciente ID")}, Paciente Nombre: {row("Paciente nombre")}, Paciente Apellido: {row("Paciente apellido")}, Síntoma: {row("sintoma")}"))
                                Next
                            End Using
                        End Using

                        ' Descargar el PDF generado
                        Response.ContentType = "application/pdf"
                        Response.AppendHeader("Content-Disposition", "attachment; filename=Citas.pdf")
                        Response.TransmitFile(pdfFilePath)
                        Response.End()
                    Else
                        ' No hay registros, puedes mostrar un mensaje o realizar alguna otra acción
                        MsgBox("No hay registros de citas en la tabla para generar el PDF. Agregue uno!")
                    End If
                End Using

            Catch ex As Exception
                Console.WriteLine("Error al ejecutar la consulta: " & ex.Message)
                ' Manejar excepciones aquí (por ejemplo, mostrar un mensaje de error)
                MsgBox("Hubo un error al generar el PDF de las citas, intenta nuevamente...")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GeneratePDF()
    End Sub
End Class