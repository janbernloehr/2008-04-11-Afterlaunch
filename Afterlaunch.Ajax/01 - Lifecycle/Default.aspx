<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Afterlaunch - Client-Page-LifeCycle</title>
  <link rel="Stylesheet" href="../style/common.css" />

  <script type="text/javascript">
    
  function pageInit() {
    alert("Seite wird geladen.");
    
    // Komponenten erstellen
  }
    
  function pageLoad() {
    alert("Seite ist geladen.");
    
    // Event Handler registrieren
  }
    
  function pageUnload() {
    alert("Seite wird entladen.");
    
    // Event Handler & Komponenten freigeben
  }
    
  </script>

</head>
<body>
  <form id="form1" runat="server">
  <asp:ScriptManager runat="server" ID="scriptManager" />

  <script type="text/javascript">
    Sys.Application.add_init(pageInit);
  </script>

  <h2>
    Client-Page-LifeCycle</h2>
  <div>
    Sys.Application<br />
    1. init<br />
    2. load<br />
    3. unload<br />
  </div>
  </form>
</body>
</html>
