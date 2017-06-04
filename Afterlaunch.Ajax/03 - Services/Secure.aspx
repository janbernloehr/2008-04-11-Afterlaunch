<%@ Page Language="VB" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Afterlaunch - Ajax Authorization</title>
  <link rel="Stylesheet" href="../style/common.css" />

  <script type="text/javascript">
    
    // controls
    var logout;
    var buy1;
    var buy2;
    var buy3;
    var buy4;
    var buy5;
    var balance;
    var lastTransaction;
    var statusInfo;
    
    function pageLoad() {
      // controls initialisieren
      logout = $get("logout");
      buy1 = $get("buy1");
      buy2 = $get("buy2");
      buy3 = $get("buy3");
      buy4 = $get("buy4");
      buy5 = $get("buy5");
      balance = $get("balance");
      lastTransaction = $get("lastTransaction");
      statusInfo = $get("statusInfo");
      
      // event handler initialisieren
      $addHandler(logout, "click", logoutClick);
      
      $addHandler(buy1, "click", buyClick);
      $addHandler(buy2, "click", buyClick);
      $addHandler(buy3, "click", buyClick);
      $addHandler(buy4, "click", buyClick);
      $addHandler(buy5, "click", buyClick);
      
      // profile laden
      loadProfile();
    }
    
    function loadProfile() {
      Sys.Services.ProfileService.load(null,              // alle properties
                                       profileCompleted); // callback
    }
    
    function profileCompleted() {
      var profileService = Sys.Services.ProfileService;

      balance.innerHTML = profileService.properties.balance;
      lastTransaction.innerHTML = profileService.properties.lastTransaction;
      
      statusInfo.innerHTML = "Profil geladen.";
    }
   
    // handler für buyN.click
    function buyClick(e) {
      var bookId = 1;
    
      eBooksService.BuyBook(bookId, serviceSuccess);
      
      var profileService = Sys.Services.ProfileService;
      profileService.properties.lastTransaction = new Date();
      profileService.properties.balance = 7000;
      
      profileService.save(null, profileSaved);
    }
    
    function serviceSuccess() {
      loadProfile();
    }
    
    function profileSaved() {
      statusInfo.innerHTML = "Profil gespeichert.";
    }
    
    // handler für logout.click
    function logoutClick(e) {
      Sys.Services.AuthenticationService.logout(
                                          "default.aspx"); // redirect
    }
    
  </script>

</head>
<body>
  <form id="form1" runat="server">
  <asp:ScriptManager runat="server" ID="scriptManager">
    <Services>
      <asp:ServiceReference Path="~/services/eBooksService.asmx" />
    </Services>
  </asp:ScriptManager>
  <h2>
    Willkommen auf Ihrer persönlichen Seite.</h2>
  <div>
    Status <span id="statusInfo"></span>
  </div>
  <div>
    Kontostand: <span id="balance"></span>.<br />
    Letzer Einkauf: <span id="lastTransaction"></span>.
  </div>
  <ul class="book-list">
    <li>
      <img alt="" src="../images/book.png" />
      <a id="item1" href="../ebooks/WhatsAjax.pdf" target="_blank">What's Ajax?</a>
      <input type="button" id="buy1" value="Kaufen" />
    </li>
    <li>
      <img alt="" src="../images/book.png" />
      <a id="item2" href="../ebooks/DomElement.pdf" target="_blank">Ajax DomElement</a>
      <input type="button" id="buy2" value="Kaufen" />
    </li>
    <li>
      <img alt="" src="../images/book.png" />
      <a id="item3" href="../ebooks/ClientLifeCycle.pdf" target="_blank">Ajax Client Life-Cycle</a>
      <input type="button" id="buy3" value="Kaufen" />
    </li>
    <li>
      <img alt="" src="../images/book.png" />
      <a id="item4" href="../ebooks/ArrayExtension.pdf" target="_blank">Ajax Array Extension</a>
      <input type="button" id="buy4" value="Kaufen" />
    </li>
    <li>
      <img alt="" src="../images/book.png" />
      <a id="item5" href="../ebooks/StringAndObjectExtension.pdf" target="_blank">Ajax String
        & Object Extension</a>
      <input type="button" id="buy5" value="Kaufen" />
    </li>
  </ul>
  <div>
    <input type="button" id="logout" value="Abmelden" />
  </div>
  </form>
</body>
</html>
