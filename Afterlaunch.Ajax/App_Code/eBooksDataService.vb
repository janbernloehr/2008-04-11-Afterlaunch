Imports System.Linq
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.ComponentModel
Imports Microsoft.Web.Preview.Services

<WebService(Namespace:="http://www.afterlaunch.de/services/Ajax_eBooks/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ScriptService(), GenerateScriptType(GetType(eBook))> _
Public Class eBooksDataService
    Inherits DataService

    <WebMethod(), ScriptMethod(), DataObjectMethod(DataObjectMethodType.Select)> _
  Public Function GetAllBooks() As eBook()
        Return New eBooksService().GetAllBooks()
    End Function
End Class
