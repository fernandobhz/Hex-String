Imports System.IO

Module Main

    Sub Main()
        InstallContexMenu.InstallAsOpen(".hexstring")

        Dim Args As String() = Environment.GetCommandLineArgs

        If Args.Count <> 2 Then
            MsgBox("usage FromBinaryString inputfile.exe.hexstring")
            End
        End If

        Dim InputPath As String = Args(1)

        If Not InputPath.EndsWith(".hexstring") Then
            MsgBox("File must be .hexstring extension")
            End
        End If

        If Not My.Computer.FileSystem.FileExists(InputPath) Then
            MsgBox("Input file doesn't exists", MsgBoxStyle.Critical)
            End
        End If


        Using inputStream As New FileStream(InputPath, FileMode.Open)
            Using outputStream As New FileStream(InputPath.Replace(".hexstring", ""), FileMode.Create)
                Using SR As New StreamReader(inputStream)
                    Do While SR.Peek > 0

                        Dim Line As String = SR.ReadLine()

                        For i As Integer = 0 To Line.Length - 1 Step 2

                            Dim x2str As String = Line.Substring(i, 2)
                            Dim b As Byte = Convert.ToByte(x2str, 16)

                            outputStream.WriteByte(b)

                        Next

                    Loop
                End Using
            End Using
        End Using

    End Sub


End Module
