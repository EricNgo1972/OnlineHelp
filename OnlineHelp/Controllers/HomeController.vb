Imports Microsoft.Azure.Search

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    'Function Index() As ActionResult
    '    Return View()
    'End Function

    Function Index(SearchFor As String)

        Dim NextLink As Models.SearchContinuationToken = Nothing
        Dim searchResults = HelpSearch.SearchForTopic(SearchFor, NextLink)

        ViewBag.SearchFor = SearchFor
        ViewBag.NextLink = NextLink

        Return View(searchResults)

    End Function

    Function About() As ActionResult
        ViewData("Message") = "Online Help documentation"

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "SPC Technology"

        Return View()
    End Function
End Class
