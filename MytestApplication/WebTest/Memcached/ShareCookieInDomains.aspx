<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareCookieInDomains.aspx.cs" Inherits="WebTest.ShareCookieInDomains" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>share1</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="Button1" Text="设置cookie" OnClick="btn_setcookie_click" />
            <asp:Button runat="server" ID="Button2" Text="获取cookie" OnClick="btn_getcookie_click" />
            <asp:Button runat="server" ID="Button6" Text="删除cookie" OnClick="btn_removecookie_click" />
        </div>
        <div>
            <asp:Button runat="server" ID="Button3" Text="设置memcache" OnClick="btn_setcache_click" />
            <asp:Button runat="server" ID="Button4" Text="获取memcache" OnClick="btn_getcache_click" />
            <asp:Button runat="server" ID="Button5" Text="删除memcache" OnClick="btn_removecache_click" />
        </div>
    </form>
</body>
</html>
