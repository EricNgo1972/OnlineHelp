Imports SPC.Helper.Extension

Public Class HelpTopicInfo

    Property SearchScore As Decimal

    Property Author As String

    Property UpdatedTime As String

    Property Size As Decimal

    Property Name As String = String.Empty

    Private _content As String = String.Empty
    Property Content As String
        Get
            Return _content
        End Get
        Set(value As String)
            value = Str.Nz(value, String.Empty)
            _content = value.Replace("\n", Environment.NewLine)
            _content = _content.Replace("\t", vbTab)
            _content = _content.Shorten(500)
        End Set
    End Property

    Const _helpRoot = "http://phoebusfiles.blob.core.windows.net/help"
    Private _link As String = String.Empty

    Property Link As String
        Get
            Return _link.RegExpReplace("docx$", "html")
            'Return String.Format("{0}/{1}.html", _helpRoot, Name.ShortFileName)
        End Get
        Set(value As String)
            _link = Str.Nz(value, String.Empty)
        End Set
    End Property


    Shared Function BuildHelpTopicInfo(search As Microsoft.Azure.Search.Models.Document) As HelpTopicInfo

        Dim atopic = New HelpTopicInfo
        Try

            atopic.Author = Str.DNz(search("metadata_author"), String.Empty)
            'atopic.UpdatedTime = DNz(search("metadata_storage_last_modified"), String.Empty)
            atopic.Name = Str.DNz(search("metadata_storage_name"), String.Empty)

            atopic.Content = Str.DNz(search("content"), String.Empty)

            atopic.Size = Str.DNz(search("metadata_storage_size"), String.Empty)

            Dim theParth = Str.DNz(search("metadata_storage_path"), String.Empty)

            Dim base64 = HttpServerUtility.UrlTokenDecode(theParth) 'Convert.FromBase64String(theParth)

            Dim theURL = HttpUtility.UrlDecode(base64, Encoding.ASCII)

            atopic._link = theURL '.RegExpReplace(".{1}$", String.Empty)

        Catch ex As Exception
            atopic.Content = ex.Message
        End Try

        Return atopic

    End Function

End Class
