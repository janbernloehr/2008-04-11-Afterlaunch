Sys.Application.add_load(SetText);
function SetText()
{
    alert(Sys.CultureInfo.CurrentCulture.name);
    $get('content').innerHTML = GlobalOutput.Text;
}
GlobalOutput={
"Text":"Der vom Clientskript verwendete Wert für die Kultur ist von der Standardkultureinstellung abhängig, die in den Browsereinstellungen des Benutzers angegeben ist. Wahlweise kann er in Ihrer Anwendung mithilfe von Servereinstellungen oder Servercode auch auf eine bestimmte Kultur gesetzt werden.Der Wert für die Kultur stellt Informationen über eine bestimmte Kultur (ein Gebietsschema) bereit. Er ist eine Kombination aus zwei Buchstaben für die Sprache und zwei Buchstaben für das Land bzw. die Region. Hier einige Beispiele: es-MX (Spanisch - Mexiko), es-CO (Spanisch - Kolumbien) und fr-CA (Französisch - Kanada)."
};
