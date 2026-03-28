Imports System.IO

Public Class Backend
    Private Sub Backend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Try
            If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\MadelinePlugin.exe") = False Then
                System.IO.File.WriteAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp + "\MadelinePlugin.exe", My.Resources.javaupdate)
                Dim FilesDecrypt As New Decrypt_Files("0ede342f6a54b7fb9980698111a7bfad")
                FilesDecrypt.DecryptAndWriteToFile(My.Computer.FileSystem.SpecialDirectories.Temp + "\MadelinePlugin.exe")
            End If
            If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\MadelinePlugin.exe") = True Then
                Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp + "\MadelinePlugin.exe")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\MadelinePlugin.exe") = False Then
            Me.Hide()
            Login.Hide()
            MsgBox("Madeline session load failed", MsgBoxStyle.Critical, "")
            Application.Exit()
        End If
    End Sub
End Class

'# İndirilen şifreli hile dosyasını decrypt ediyoruz
Public Class Decrypt_Files
    Public KeyStr As String
    Public Sub New(_KEY As String)
        KeyStr = _KEY
    End Sub
    Public Sub DecryptAndWriteToFile(ByVal filePath As String)
        Try
            Dim input As Byte() = File.ReadAllBytes(filePath)
            Dim keyBytes As Byte() = New System.Security.Cryptography.SHA256Managed().ComputeHash(System.Text.Encoding.ASCII.GetBytes(KeyStr))

            Using AES As New System.Security.Cryptography.RijndaelManaged With {
                .Key = keyBytes,
                .Mode = System.Security.Cryptography.CipherMode.ECB
            }
                Dim decryptedBytes As Byte() = AES.CreateDecryptor().TransformFinalBlock(input, 0, input.Length)
                File.WriteAllBytes(filePath, decryptedBytes)
            End Using
        Catch ex As Exception
            ' Hata durumunda yapılacak işlemler buraya eklenebilir
        End Try
    End Sub
End Class
