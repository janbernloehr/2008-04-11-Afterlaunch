<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientSideDatabinding.aspx.cs"
    Inherits="_07___ClientWebservice_ClientSideDatabinding" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Afterlaunch - Clientseitiges Databinding mit Javascript</title>
    <link rel="Stylesheet" href="../style/common.css" />
    <script type="text/javascript">            
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/services/eBooksDataService.asmx" />
        </Services>
        <Scripts>
            <asp:ScriptReference Assembly="Microsoft.Web.Preview" Name="PreviewScript.js" />
        </Scripts>
    </asp:ScriptManager>
    <div>
        <div>
            Afterlaunch - Clientseitiges Databinding mit Javascript <span id="loadingStatus">
                <img id="loadingGif" alt="Loading" src="../images/ajax-loader.gif" /></span>
        </div>
        <div id="item-container-1" style="float: left; border: dashed 2px #aaa; width: 700px;
            height: auto; margin: 10px; padding: 10px">
        <div id="Book titles to be listed here">
        </div>
        <div id="Books"></div>
        <div style="display:none;">
          <div id="LayoutTemplate">
            <div id="ItemTemplateParent">
              <div id="ItemTemplate">
                  <div style="height: 60px;"><img style="float:left" src="../images/book.png" />
                    <a href="#" target="_blank"><span id="BookTitle"></span></a>
                 </div>                  
              </div>
            </div>
          </div>
          <div id="emptyTemplate">
                        empty...
          </div>
        </div>    

        <script type="text/xml-script">
          <page xmlns="http://schemas.microsoft.com/xml-script/2005">
            <components>
            <dataSource id="BooksDataSource" serviceURL="../services/eBooksDataService.asmx" />
            
              <button id="btnGetBooks" >
                <click>
                    <invokeMethodAction target="BooksDataSource" method="load" />
                </click>
              </button>
              
              <listView id="Books" itemTemplateParentElementId="ItemTemplateParent">
              <bindings>
                  <binding dataContext="BooksDataSource" dataPath="data" property="data" />
                </bindings>
                <layoutTemplate>
                  <template layoutElement="LayoutTemplate" />
                </layoutTemplate>
                <itemTemplate>
                  <template layoutElement="ItemTemplate">
                    <label id="BookTitle">
                      <bindings>
                        <binding dataPath="Title" property="text" />
                      </bindings>
                    </label>                    
                  </template>
                </itemTemplate>
                <emptyTemplate>
                  <template layoutElement="emptyTemplate" />
                </emptyTemplate>
              </listView>              
            </components>
          </page>
        </script>
            
        </div>
        <div>        
            <input type="button" id="btnGetBooks" value="Abrufen" />
            <input type="button" id="btnAbort" value="Abbrechen" />
        </div>
    </div>
    
    </form>
</body>
</html>
