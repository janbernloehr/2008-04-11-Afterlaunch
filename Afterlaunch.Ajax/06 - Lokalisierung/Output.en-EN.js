Sys.Application.add_load(SetText);
function SetText()
{
    alert(Sys.CultureInfo.CurrentCulture.name);
    $get('content').innerHTML = GlobalOutput.Text;
}
GlobalOutput={
"Text":"The culture value that is used by the client script is based on the default culture setting provided by the user's browser settings. Alternatively, it can be set to a specific culture value by using server settings or server code in your application.A culture value provides information about a specific culture (locale). The culture value is a combination of two letters for a language and two letters for a country or region. Examples include es-MX (Spanish Mexico), es-CO (Spanish Columbia), and fr-CA (French Canada)."
};
