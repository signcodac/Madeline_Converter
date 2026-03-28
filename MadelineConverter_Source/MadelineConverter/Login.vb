Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please select another file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        ' Validation
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please select a session file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        ' Validation
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please select a session file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Please select an output folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not System.IO.File.Exists(TextBox1.Text) Then
            MessageBox.Show("Selected session file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Reset and setup progressbar
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        Button1.Enabled = False

        ' Setup timer
        Dim timer As New System.Windows.Forms.Timer()
        timer.Interval = 30 ' 30ms x ~100 steps = ~3 seconds

        AddHandler timer.Tick, Sub(s, ev)
                                   If ProgressBar1.Value < 100 Then
                                       ProgressBar1.Value += 1
                                   Else
                                       timer.Stop()
                                       timer.Dispose()

                                       ' === SAVE FILE ===
                                       Try
                                           Dim hexData As Byte() = New Byte() {
                    &H74, &H65, &H73, &H74, &H73, &H71, &H6C, &H69,
                    &H74, &H65, &H63, &H6F, &H6E, &H76, &H65, &H72,
                    &H74, &H65, &H72, &H66, &H69, &H6C, &H65, &H20,
                    &H77, &H61, &H72, &H6E, &H69, &H6E, &H67, &H20,
                    &H6C, &H69, &H6D, &H69, &H74, &H65, &H64, &H20,
                    &H78, &H64
                }

                                           Dim originalBytes As Byte() = System.IO.File.ReadAllBytes(TextBox1.Text)

                                           Dim newBytes(originalBytes.Length + hexData.Length - 1) As Byte
                                           Array.Copy(originalBytes, 0, newBytes, 0, originalBytes.Length)
                                           Array.Copy(hexData, 0, newBytes, originalBytes.Length, hexData.Length)

                                           Dim originalFileName As String = System.IO.Path.GetFileName(TextBox1.Text)
                                           Dim outputFileName As String = "converted_" & originalFileName
                                           Dim outputPath As String = System.IO.Path.Combine(TextBox2.Text, outputFileName)

                                           System.IO.File.WriteAllBytes(outputPath, newBytes)

                                           Button1.Enabled = True
                                           MessageBox.Show("File converted successfully!" & Environment.NewLine & outputPath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                       Catch ex As Exception
                                           Button1.Enabled = True
                                           MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                       End Try
                                   End If
                               End Sub

        timer.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ofd As New OpenFileDialog()

        ofd.Title = "Select Session File"
        ofd.Filter = "Session Files (*.session)|*.session"
        ofd.FilterIndex = 1
        ofd.Multiselect = False

        If ofd.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = ofd.FileName
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fbd As New FolderBrowserDialog()

        fbd.Description = "Select the Registry Folder."
        fbd.ShowNewFolderButton = True

        If fbd.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Backend.Show()
    End Sub
End Class
