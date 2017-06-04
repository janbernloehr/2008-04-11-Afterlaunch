<%@ Page Language="VB" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Afterlaunch - Ajax Authorization</title>
  <link rel="Stylesheet" href="../style/common.css" />

  <script type="text/javascript">

  // controls
  var username;
  var password;
  var persistentCookie;
  var login;
  var statusInfo;

  function pageLoad() {
    // controls initialisieren
    username = $get("username");
    password = $get("password");
    persistentCookie = $get("persistentCookie");
    login = $get("login");
    statusInfo = $get("statusInfo");
    
    // event handler initialisieren
    $addHandler(login, "click", loginClick);
  }

  // handler für login.click
  function loginClick(e) {
    var isPersistent = (persistentCookie.value == "on");
    
    Sys.Services.AuthenticationService.login(
                              username.value,     // Username
                              password.value,     // Password
                              isPersistent,       // Cookie?
                              null,
                              "default.aspx",     // Redirect Url
                              loginCompleted);    // Callback

    // login button deaktivieren
    login.disabled = true;
  }

  function loginCompleted(validCredentials) {
    // Aufruf des AuthenticationService war erfolgreich.

    if (validCredentials) {
      // Benutzerdaten gültig.
      
      statusInfo.innerHTML = 
        "Login erfolgreich.";
    } else {
      // Benutzerdaten ungültig.
      
      statusInfo.innerHTML = 
        "Login fehlgeschlagen. Ungültige Benutzerdaten.";
      login.disabled = false;
    }
  }
  </script>

</head>
<body>
  <form id="form1" runat="server">
  <asp:ScriptManager runat="server" ID="scriptManager">
  </asp:ScriptManager>
  <h2>
    Melden Sie Sich an, um Zugriff auf den geschützten Bereich zu bekommen.</h2>
  <label for="username">
    Benutzername:</label>
  <input type="text" id="username" style="width: 10em;" />
  <br />
  <label for="password">
    Passwort:</label>
  <input type="password" id="password" style="width: 10em;" />
  <br />
  <input type="checkbox" id="persistentCookie"
         style="width: 1em;" />
  Angemeldet bleiben?
  <br />
  <!-- buttons -->
  <input type="button" id="login" value="Anmelden" /><br />
  <a href="Default.aspx">Zur Startseite</a><br />
  <!-- info popup -->
  <div id="statusInfo">
  </div>
  </form>
</body>
</html>
