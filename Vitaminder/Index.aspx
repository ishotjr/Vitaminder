<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Vitaminder.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vitaminder</title>
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

        <h1>Welcome to Vitaminder</h1>

        <p><em>Please ensure pop-ups are allowed in order to proceed.</em></p>

        <p>Please use the following pop-up to select your reorder preference.</p>

    </form>
</body>
</html>