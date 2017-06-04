<%@ Page Language="VB" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Afterlaunch - Authorization</title>
  <link rel="Stylesheet" href="../style/common.css" />

  <script type="text/javascript">
  // controls
  var loginStatus;
  var login;
  var logout;
    
  function pageLoad() {
    // controls initialisieren
    loginStatus = $get("loginStatus");
    login = $get("login");
    logout = $get("logout");
    

    // event handler initialisieren
    $addHandler(login, "click", OnLoginClick);
    $addHandler(logout, "click", OnLogoutClick);

    // ui aktualisieren
    updateUI();
  }
  
  function updateUI() {
    var isLoggedIn = 
      Sys.Services.AuthenticationService.get_isLoggedIn();
        
    // buttons aktivieren / deaktivieren
    login.disabled = isLoggedIn;
    logout.disabled = !isLoggedIn;

    if (isLoggedIn) {
      // angemeldet
      loginStatus.innerHTML = 
        "<a href='Secure.aspx'>Hier</a> gehts zu den eBooks.";
    } else {
      // nicht angemeldet
      loginStatus.innerHTML = 
        "Bitte melden Sie Sich an, um unseren Service zu nutzen.";
    }
  }

  function OnLoginClick(e) {
    // zur login seite gehen
    document.location = "signin.aspx";
  }

  function OnLogoutClick(e) {
    // abmelden
    Sys.Services.AuthenticationService.logout();
  }
    
  </script>

</head>
<body>
  <form id="form1" runat="server">
  <asp:ScriptManager runat="server" ID="scriptManager" />
  <div>
    <div>
      Willkommen bei Ajax.eBooks!<br />
      <span id="loginStatus"></span>
    </div>
    <br />
    <div>
      <input type="button" id="login" value="Anmelden" />
      <input type="button" id="logout" value="Abmelden" />
    </div>
  </div>
  </form>
</body>
</html>
