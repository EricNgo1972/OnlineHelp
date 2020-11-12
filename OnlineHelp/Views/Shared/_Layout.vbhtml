<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Phoebus online Help</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div class="navbar navbar-expand-lg navbar-light bg-light">
        <img src="~/Content/Images/Logo/AppIcon.png" width="48" height="48">
        @Html.ActionLink("Phoebus Online Help", "Index", "Home", Nothing, New With {.class = "navbar-brand"})
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation" style="">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarColor01">
            <ul class="navbar-nav mr-auto">
                @*<li class="nav-item">
                    <a class="nav-link" href="#">Topics</a>
                </li>*@

                <li class="nav-item">
                    @Html.ActionLink("About", "About", "Home", Nothing, New With {.class = "nav-link"})

                </li>
            </ul>

        </div>

    </div>

     

    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Cty Cổ phần Công nghệ San Phú</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
