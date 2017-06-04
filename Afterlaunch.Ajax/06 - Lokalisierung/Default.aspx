<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_06___Lokalisierung_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Afterlaunch - Lokalisierung</title>
    <link rel="Stylesheet" href="../style/common.css" />
    <script type="text/javascript">      

    </script>
    <style type="text/css">
        #drpLanguages
        {
            width: 124px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" ScriptMode="Debug" EnableScriptGlobalization="true" runat="server">
        <Scripts>
            <asp:ScriptReference Path="Output.js" ResourceUICultures="de-DE" />
        </Scripts>
    </asp:ScriptManager>
    <div>
        <h2>eBooks zum Thema Ajax.</h2>
        <div id="content" style="width:600px;float:left"></div>
        <div style="float:right">
            <asp:DropDownList runat="server" AutoPostBack="true" ID="selectLanguage" OnSelectedIndexChanged="selectLanguage_SelectedIndexChanged">
            <asp:ListItem Text="English" Value="en"></asp:ListItem>
            <asp:ListItem Text="Deutsch" Value="de"></asp:ListItem>
        </asp:DropDownList>
        </div>      
      
    </div>
    </form>
</body>
</html>
