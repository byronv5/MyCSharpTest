<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncipherTest.aspx.cs" Inherits="WebTest.EncipherTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txt_before" TextMode="MultiLine" runat="server" Height="60px" Width="430px"></asp:TextBox><asp:Button ID="btn_md5" runat="server" Text="MD5标准加密" OnClick="Btn_Md5_Click" /><asp:TextBox ID="txt_after" runat="server" Width="234px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
