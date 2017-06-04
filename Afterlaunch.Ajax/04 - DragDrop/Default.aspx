<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Afterlaunch - Client-Page-LifeCycle</title>
  <link rel="Stylesheet" href="../style/common.css" />

  <script type="text/javascript">
  
  // controls
  var item1;
  var item2;
  var item3;
  var item4;
  var item5;
  var download;
  var dropZone;
  var form1;
  var statusInfo;
  //var progressBar;
  
  // status data
  var statusText = "";
  var bookIds = new Array();
  
  function pageLoad() {
    var bounds = Sys.UI.DomElement.getBounds($get("form1"));
    
    item1 = $get("item1");
    item2 = $get("item2");
    item3 = $get("item3");
    item4 = $get("item4");
    item5 = $get("item5");
    dropZone = $get("item-container-2");
    
    download = new Sys.Preview.UI.Button($get("download"));
    statusInfo = new Sys.Preview.UI.Label($get("statusInfo"));
    //progressBar = new Sys.Preview.UI.Image($get("bar"));
    
    download.initialize();
    download.add_click(downloadClick);
    
    //progressBar.initialize();
        
    Sys.UI.DomElement.setLocation(item1, bounds.x + 32, bounds.y + 150);
    Sys.UI.DomElement.setLocation(item2, bounds.x + 32, bounds.y + 200);
    Sys.UI.DomElement.setLocation(item3, bounds.x + 32, bounds.y + 250);
    Sys.UI.DomElement.setLocation(item4, bounds.x + 32, bounds.y + 300);
    Sys.UI.DomElement.setLocation(item5, bounds.x + 32, bounds.y + 350);
    
    var source1 = new Custom.UI.BookDragSourceBehavior
        (item1, 1);
    var source2 = new Custom.UI.BookDragSourceBehavior
        (item2, 2);
    var source3 = new Custom.UI.BookDragSourceBehavior
        (item3, 3);
    var source4 = new Custom.UI.BookDragSourceBehavior
        (item4, 4);
    var source5 = new Custom.UI.BookDragSourceBehavior
        (item5, 5);

    source1.initialize();
    source2.initialize();
    source3.initialize();
    source4.initialize();
    source5.initialize();    
    
    var target = new Custom.UI.BookDropTargetBehavior(dropZone);
    
    target.initialize();    
  }
    
  function pageUnload() {
  
  }
  
  function downloadClick() {
    var sb = new Sys.StringBuilder();
    
    sb.appendLine("Ausgewählte eBooks:");
    
    function enumerator(element, index, array) {
      sb.appendLine(String.format(" eBook {0}", element));
    }
    
    Array.forEach(bookIds, enumerator);
    
    alert(sb.toString());
  }
    
  function getElementByBookId(bookId) {
      switch(bookId) {
        case 1:
          return item1;
          break;
        case 2:
          return item2;
          break;
        case 3:
          return item3;
          break;
        case 4:
          return item4;
          break;
        case 5:
          return item5;
          break;
      }
    }
    
  </script>

</head>
<body>
  <form id="form1" runat="server">
  <asp:ScriptManager runat="server" ID="scriptManager">
    <Scripts>
      <asp:ScriptReference Assembly="Microsoft.Web.Preview" Name="PreviewScript.js" />
      <asp:ScriptReference Assembly="Microsoft.Web.Preview" Name="PreviewDragDrop.js" />
      <asp:ScriptReference Assembly="Microsoft.Web.Preview" Name="PreviewGlitz.js" />
      <asp:ScriptReference Path="../scriptLibrary/DragSourceBehavior.js" />
    </Scripts>
  </asp:ScriptManager>

  <script type="text/javascript">
  
    Custom.UI.BookDropTargetBehavior.prototype.drop = function(dragMode, dataType, data)
    {
      this.get_element().style.backgroundColor = '#fff';
        
      statusText += String.format("eBook {0} gedropped<br />", data);
      statusInfo.set_text(statusText);
      
      Array.add(bookIds, data);
      
      var element = getElementByBookId(data);
      
      Sys.UI.DomElement.setVisible(element, false);
      
//      var numb = new Sys.Preview.UI.Effects.LengthAnimation();
//      numb.set_target(progressBar);
//      numb.set_duration(3);
//      numb.set_startValue(0);
//      numb.set_endValue(100);
//      numb.set_property("width");
//      numb.set_fps(20);
//      numb.play();
    }
  </script>

  <h2>
    Ajax Drag and Drop</h2>
  <div id="item-container-1" style="float: left; border: dashed 2px #aaa; height: 300px;
    width: 340px;">
    <div id="item1" style="height: 100px;">
      <img id="link1" src="../images/book.png" />
      <a href="../ebooks/WhatsAjax.pdf" target="_blank">What's Ajax?</a></div>
    <div id="item2" style="height: 100px;">
      <img id="link2" src="../images/book.png" />
      <a href="../ebooks/DomElement.pdf" target="_blank">Ajax DomElement</a>
    </div>
    <div id="item3">
      <img id="link3" src="../images/book.png" />
      <a href="../ebooks/ClientLifeCycle.pdf" target="_blank">Ajax Client Life-Cycle</a>
    </div>
    <div id="item4">
      <img id="link4" src="../images/book.png" />
      <a href="../ebooks/ArrayExtension.pdf" target="_blank">Ajax Array Extension</a>
    </div>
    <div id="item5">
      <img id="link5" src="../images/book.png" />
      <a href="../ebooks/StringAndObjectExtension.pdf" target="_blank">Ajax String & Object
        Extension</a>
    </div>
  </div>
  <div style="float: left; width: 40px;">
  </div>
  <div id="item-container-2" style="float: left; border: dashed 2px #aaa; height: 300px;
    width: 340px;">
    Warenkorb
    <div id="statusInfo">
    </div>
  </div>
  <div style="clear: both;">
  </div>
  <%--<div>
    <img id="bar" src="../images/book.png" />
  </div>--%>
  <div>
    <input type="button" id="download" value="Download" />
  </div>
  </form>
</body>
</html>
