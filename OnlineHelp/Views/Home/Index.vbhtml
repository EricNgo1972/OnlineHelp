@Code
    Dim topic As String = ViewBag.SearchFor


    'If ViewBag.NextLink IsNot Nothing Then
    '    nextLink = CallByName(ViewBag.NextLink, "NextLink", CallType.Get) 'pbs.Helper.DataMapper.GetPropertyValue(ViewBag.NextLink, "NextLink", String.Empty)
    'End If

    Dim results = TryCast(ViewData.Model, List(Of HelpTopicInfo))

End Code

@Using Html.BeginForm("Index", "Home", FormMethod.Post)
    @<div name="SearchCriteria" Class="container" style="padding: 20px 5px 4px 4px;">
    <div Class="row">
        <div Class="col-sm-2">@Html.Label("Search for:", New With {.class = "form-check-label"})</div>
        <div Class="col-sm-8">@Html.TextBox("SearchFor", topic, New With {.class = "form-control", .style = "max-width: 100%;"})</div>
        <div Class="col-sm-2"><input type="submit" , value="Search" class="btn btn-primary"></div>
    </div>
    <div Class="row">
        <div Class="col-sm-12">

            @If results IsNot Nothing Then
                @Html.Label(String.Format("Found {0:0} documents", results.Count), New With {.class = "alert alert-dismissible alert-light", .style = "max-width: 100%;"})
            End If
        </div>
        </div>
    </div>  
End Using

        <div Name = "SearchResults" Class="container">
    @If results IsNot Nothing Then

        For Each doc In results
                        @<div class="container">

                            <div Class="row">
                                <div class="col-sm-9">
                                    <div class="alert alert-dismissible alert-warning" Score: @doc.SearchScore>
                                        <b><a href="@doc.Link" target="_blank">@doc.Name</a></b>
                                        Size:  @String.Format("{0:#,###}", doc.Size). Updated: @doc.UpdatedTime by @doc.Author
                                    </div>
                                </div>
                                <div Class="col-sm-3">
                                    <div class="alert alert-dismissible alert-warning">Score: @doc.SearchScore</div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12"> @doc.Content. <a href="@doc.Link" target="_blank"> Link...</a> </div>
                            </div>

                        </div>
        Next

    End If
    </div>
