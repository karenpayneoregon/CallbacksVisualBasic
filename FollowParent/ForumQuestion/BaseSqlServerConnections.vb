Imports System.Data.SqlClient

Public Class BaseSqlServerConnections
    Protected DatabaseServer As String = "KARENS-PC"
    Protected DefaultCatalog As String = "ForumExamples"
    Public ReadOnly Property ConnectionString As String
        Get
            Return $"Data Source={DatabaseServer};" &
                   $"Initial Catalog={DefaultCatalog};" &
                   "Integrated Security=True"
        End Get
    End Property
End Class
Public Class DataOperations
    Inherits BaseSqlServerConnections
    Public Function FindRecord(ByVal pValue As String) As Item
        Dim result As Item

        Using cn = New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd = New SqlCommand With {.Connection = cn}

                cmd.CommandText = "SELECT id,Comment " &
                                  "FROM dbo.tblFileMaster " &
                                  "WHERE chrFileID = @chrFileID"

                cmd.Parameters.AddWithValue("@chrFileID", pValue)
                cn.Open()
                Dim reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    result = New Item() With
                        {
                            .Id = reader.GetInt32(0),
                            .Comment = reader.GetString(1),
                            .chrFileID = pValue
                        }
                End If
            End Using
        End Using

        Return result

    End Function
End Class
Public Class Item
    Public Property Id() As Integer
    Public Property chrFileID() As String
    Public Property Comment() As String

    Public Overrides Function ToString() As String
        Return $"Id: {Id} Comment: {Comment}"
    End Function
End Class
