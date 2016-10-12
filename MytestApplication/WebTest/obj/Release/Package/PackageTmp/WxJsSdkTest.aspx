<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WxJsSdkTest.aspx.cs" Inherits="WebTest.WxJsSdkTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>微信JS-SDK</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />

    <script src="http://apps.bdimg.com/libs/jquery/2.1.4/jquery.min.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="Scripts/WxConfig.js"></script>
    <script>
        $(function () {
            $.ajax({
                type: "post",
                dataType: "json",
                url: "ajax/GetWxJsApiConfig.ashx",
                data: { "Pagepath": "WebTest/WxJsSdkTest.aspx" },
                success: function (data) {
                    wxconfig(data);
                }
            });
        });

        function shareTimeLine() {
            wx.onMenuShareTimeline({
                title: 'helloworld', // 分享标题
                link: 'www.fuck.com', // 分享链接
                imgUrl: '', // 分享图标
                success: function () {
                    // 用户确认分享后执行的回调函数
                },
                cancel: function () {
                    // 用户取消分享后执行的回调函数
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="#" onclick="shareTimeLine()">分享到朋友圈</a>
        </div>
    </form>
</body>
</html>
