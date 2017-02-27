<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Vitaminder.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    
    <title>Vitaminder</title>

    <!-- Bootstrap core CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
        }
    </style>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="frmMain" runat="server">

        <div id="amazon-root"></div>
        <script type="text/javascript">
            window.onAmazonLoginReady = function() {
                amazon.Login.setClientId('amzn1.application-oa2-client.d1c6352332154272b75adfa65a6031f5');
                var options = new Object();
                var scope = ('dash:replenish');
                var scope_data = new Object();
                scope_data['dash:replenish'] = {"device_model":"e2baabee-39a8-4634-8be9-8b104d5db906","serial":"123456","is_test_device":true};
                options['scope_data'] = scope_data;
                options['scope'] = scope;
                options['response_type'] = 'code';
                amazon.Login.authorize(options, "https://vitaminder.azurewebsites.net/HandleLogin.aspx");
            };
            (function(d) {
                var a = d.createElement('script'); a.type = 'text/javascript';
                a.async = true; a.id = 'amazon-login-sdk';
                a.src = 'https://api-cdn.amazon.com/sdk/login1.js';
                d.getElementById('amazon-root').appendChild(a);
            })(document);
        </script>

        <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="https://vitaminder.azurewebsites.net">Vitaminder</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">

                    <ul class="nav navbar-nav">
                        <li class="active"><a href="https://www.hackster.io/ishotjr/vitaminder-a-vitamin-reminder-tracker-replenishment-system-e5a6d7">Hackster.io Project</a></li>
                        <li><a href="https://github.com/ishotjr/Vitaminder">Source Code</a></li>
                        <li><a href="https://vitaminder.azurewebsites.net">Start Over</a></li>
                    </ul>

                </div><!--/.navbar-collapse -->
            </div>
        </nav>

        <div class="container">

            <h1>Welcome to Vitaminder!</h1>
            <div class="alert alert-warning" role="alert">Please ensure pop-ups are allowed in order to proceed.</div>
            <h2>Please use the following pop-up to select your reorder preference.</h2>
            <div class="alert alert-info" role="alert">You will be automatically redirected after making your selection...</div>

            <hr>

            <footer>
                <p>&copy; 2016 <a href="http://ishotjr.com">ishotjr.com</a></p>
            </footer>
        </div> <!-- /container -->

        <!-- Bootstrap core JavaScript
        ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script src="/Scripts/jquery-1.9.1.min.js"></script>
        <script src="/Scripts/bootstrap.min.js"></script>

    </form>
</body>
</html>