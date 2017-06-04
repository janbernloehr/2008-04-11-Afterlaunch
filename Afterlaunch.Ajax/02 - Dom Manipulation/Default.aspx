<%@ Page Language="VB" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Afterlaunch - Ajax Dom</title>
  <link rel="Stylesheet" href="../style/common.css" />

  <script type="text/javascript">
    // controls
    var item1;
    var item2;
    var item3;
    var item4;
    var item5;
    var popup;
    
    function pageLoad() {
        // controls initialisieren
        item1 = $get("item1");
        item2 = $get("item2");
        item3 = $get("item3");
        item4 = $get("item4");
        item5 = $get("item5");
        popup = $get("popup");
        
        // event handler initilisieren
        
        $addHandler(item1, "mouseover", OnMouseEvent);
        $addHandler(item1, "mousemove", OnMouseEvent);
        $addHandler(item1, "mouseout", OnMouseEvent);
        
        $addHandlers(item2, { mouseover : OnMouseEvent,
                              mousemove : OnMouseEvent,
                              mouseout  : OnMouseEvent });
        $addHandlers(item3, { mouseover : OnMouseEvent,
                              mousemove : OnMouseEvent,
                              mouseout  : OnMouseEvent });
        $addHandlers(item4, { mouseover : OnMouseEvent,
                              mousemove : OnMouseEvent,
                              mouseout  : OnMouseEvent });
        $addHandlers(item5, { mouseover : OnMouseEvent,
                              mousemove : OnMouseEvent,
                              mouseout  : OnMouseEvent });
                              
        /*
        Mehrere event handler auf einmal freigeben
        
        $removeHandlers(item1, { mouseover : OnMouseEvent,
                              mousemove : OnMouseEvent,
                              mouseout  : OnMouseEvent });
        */
        
        
        /*
        Alle event handler entfernen
        
        $clearHandlers(item1);
        */
    }
    
    function pageUnload() {
      // event handler freigeben
      
      $clearHandlers(item1);
      $clearHandlers(item2);
      $clearHandlers(item3);
      $clearHandlers(item4);
      $clearHandlers(item5);
    }
    
    // ein handler für alle
    function OnMouseEvent(e) {
        // e enthält event arguments
        
        // e.type   : Event Typ
        // e.target : Auslöser (sender)
        
        switch (e.type) {
            case "mouseover" :
                // ausgewähltes buch finden
                var book = getBookFromElement(e.target);
                
                // popup html generieren
                popup.innerHTML = String.format("<img src='{0}' />",
                                                book.ThumbnailUrl);
                
                // popup position aktualisieren
                var popupX = e.clientX + 12;
                var popupY = e.clientY - 8;
        
                // popup positionieren
                Sys.UI.DomElement.setLocation(popup, popupX, popupY);
               
                // popup anzeigen
                Sys.UI.DomElement.setVisible(popup, true);
                
                // link highlight
                Sys.UI.DomElement.addCssClass(e.target, "highlight");
                
                break;
                
            case "mousemove" :
                // popup position aktualisieren
                var popupX = e.clientX + 12;
                var popupY = e.clientY - 8;
        
                Sys.UI.DomElement.setLocation(popup, popupX, popupY);
                
                break;
                
            case "mouseout" :
                // popup verstecken
                Sys.UI.DomElement.setVisible(popup, false);
                
                // link highlight entfernen
                Sys.UI.DomElement.removeCssClass(e.target, "highlight");
                
                break;
        }
    }
    
    function getBookFromElement(element) {
        // dummy daten holen
        var books = getBooks();
                
        // ausgewähltes item bestimmen
        switch (element) {
            case item1:
                return books[0];
                break;
            case item2:
                return books[1];
                break;
            case item3:
                return books[2];
                break;
            case item4:
                return books[3];
                break;
            case item5:
                return books[4];
                break;
            default:
                return;
        }
    }
    
    function getBooks() {
        return [ { Title : "What's Ajax?",
                   BookUrl : "../ebooks/WhatsAjax.pdf",
                   ImageUrl : "../images/book.png",
                   ThumbnailUrl : "../ebooks/WhatsAjax.png" }, 
                 { Title : "Ajax DomElement",
                   BookUrl : "../ebooks/DomElement.pdf",
                   ImageUrl : "../images/book.png",
                   ThumbnailUrl : "../ebooks/DomElement.png" }, 
                 { Title : "Ajax Client Life-Cycle",
                   BookUrl : "../ebooks/ClientLifeCycle.pdf",
                   ImageUrl : "../images/book.png",
                   ThumbnailUrl : "../ebooks/ClientLifeCycle.png" }, 
                 { Title : "Ajax Array Extension",
                   BookUrl : "../ebooks/ArrayExtension.pdf",
                   ImageUrl : "../images/book.png",
                   ThumbnailUrl : "../ebooks/ArrayExtension.png" }, 
                 { Title : "Ajax String & Object Extension",
                   BookUrl : "../ebooks/StringAndObjectExtension.pdf",
                   ImageUrl : "../images/book.png",
                   ThumbnailUrl : "../ebooks/StringAndObjectExtension.png" }
               ]
    }
    
  </script>

</head>
<body>
  <form id="form1" runat="server">
  <asp:ScriptManager runat="server" ID="scriptManager" />
  <h2>
    eBooks zum Thema Ajax.</h2>
  <ul class="book-list">
    <li>
      <img src="../images/book.png" />
      <a id="item1" href="../ebooks/WhatsAjax.pdf" target="_blank">What&#39;s Ajax?</a>
    </li>
    <li>
      <img src="../images/book.png" />
      <a id="item2" href="../ebooks/DomElement.pdf" target="_blank">Ajax DomElement</a>
    </li>
    <li>
      <img src="../images/book.png" />
      <a id="item3" href="../ebooks/ClientLifeCycle.pdf" target="_blank">Ajax Client Life-Cycle</a>
    </li>
    <li>
      <img src="../images/book.png" />
      <a id="item4" href="../ebooks/ArrayExtension.pdf" target="_blank">Ajax Array Extension</a>
    </li>
    <li>
      <img src="../images/book.png" />
      <a id="item5" href="../ebooks/StringAndObjectExtension.pdf" target="_blank">Ajax String
        & Object Extension</a> </li>
  </ul>
  <!-- info popup -->
  <div id="popup">
  </div>
  </form>
</body>
</html>
