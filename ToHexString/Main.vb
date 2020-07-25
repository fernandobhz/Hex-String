Imports System.IO

Module Main

    Sub Main()
        InstallContexMenu.InstallAsContext()

        Dim Args As String() = Environment.GetCommandLineArgs

        If Args.Count <> 2 Then
            MsgBox("usage ToBinaryString inputfile.exe")
            End
        End If

        Dim InputPath As String = Args(1)

        If Not My.Computer.FileSystem.FileExists(InputPath) Then
            MsgBox("Input file doesn't exists", MsgBoxStyle.Critical)
            End
        End If

        Using inputStream As New FileStream(InputPath, FileMode.Open)
            Using outputStream As New FileStream(InputPath & ".hexstring", FileMode.Create)
                For i As Integer = 1 To inputStream.Length

                    Dim b As Integer = inputStream.ReadByte
                    Dim x2str As String = b.ToString("X2")
                    Dim x2buff As Byte() = System.Text.Encoding.ASCII.GetBytes(x2str)

                    outputStream.Write(x2buff, 0, x2buff.Length)

                    If i Mod 64 = 0 Then
                        outputStream.Write({13, 10}, 0, 2)
                    End If

                Next
            End Using
        End Using


    End Sub


End Module
