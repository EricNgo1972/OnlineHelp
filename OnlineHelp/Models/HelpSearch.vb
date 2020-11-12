﻿Imports Microsoft.Azure.Search
Imports pbs.Helper
Imports pbs.Helper.Interfaces

Public Class HelpSearch
    Implements IRunable

    Private ReadOnly Property Notes As String Implements IRunable.Notes
        Get
            Return <syntax>pbs.BO.Azure.HelpSearch?searchfor=something.
                Search help with Azure search engine.
                   </syntax>.Value.RemoveDoubleSpaces
        End Get
    End Property

    Private Sub Run(args As pbsCmdArgs) Implements IRunable.Run
        Dim topic = args.GetDefaultParameter

    End Sub

    Shared Function SearchForTopic(Topic As String, ByRef NextLink As Models.SearchContinuationToken) As List(Of HelpTopicInfo)


        Dim docs = SearchDocs(Topic, NextLink)

        'Dim htmls = SearchHtml(Topic)

        'For Each itm In htmls
        '    docs.Add(itm)
        'Next

        Return (From doc In docs Order By doc.SearchScore Descending, doc.UpdatedTime Descending).ToList

    End Function

    Private Shared Function SearchDocs(Topic As String, ByRef NextLink As Models.SearchContinuationToken) As List(Of HelpTopicInfo)

        Dim sic = New SearchIndexClient(SearchCloudKey.GetKey, "azureblob-index", New SearchCredentials(SearchCloudKey.GetValue))

        Dim docs = New List(Of HelpTopicInfo)

        If Not String.IsNullOrEmpty(Topic) Then

            Dim params As New Models.SearchParameters()
            params.Top = 1000
            params.SearchMode = Models.SearchMode.All

            Dim results = sic.Documents.Search(Topic, params)
            NextLink = results.ContinuationToken

            For Each ret In results.Results

                If ret.Score > 0.1 Then
                    Dim doc = HelpTopicInfo.BuildHelpTopicInfo(ret.Document)
                    doc.SearchScore = ret.Score

                    docs.Add(doc)
                End If


            Next
        End If

        Return docs
    End Function

    'Private Shared Function SearchHtml(Topic As String) As List(Of HelpTopicInfo)

    '    Dim sic = New SearchIndexClient(SearchCloudKey.GetKey, "azureblob-phoebus-help-index", New SearchCredentials(SearchCloudKey.GetValue))

    '    Dim docs = New List(Of HelpTopicInfo)

    '    If Not String.IsNullOrEmpty(Topic) Then
    '        Dim results = sic.Documents.Search(Topic)
    '        For Each ret In results.Results

    '            Dim doc = HelpTopicInfo.BuildHelpTopicInfo(ret.Document)

    '            docs.Add(doc)
    '        Next
    '    End If

    '    Return docs
    'End Function


    Private Class SearchCloudKey
        Public Shared Function GetKey() As String
            'Return "phoebushelp"
            Return "spc"
        End Function

        Public Shared Function GetValue() As String
            Return "7AF7D336E494DD509C5C21BA57979F03"
        End Function
    End Class
End Class