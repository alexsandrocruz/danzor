Danzor
======
Gerador de DANFe para projetos MVC

Danzor vai lhe auxiliar seu projeto ASP.NET MVC a gerar [DANFes](http://www.nfe.fazenda.gov.br/portal/perguntasFrequentes.aspx?tipoConteudo=Zn7vuWPGHL8=) de forma simples

###Instalação

> PM> Install-Package Danzor

###Utilização
No seu controller crie uma instância de DanzorPrintViewr passando o path onde está o XML da NFe

```
public ActionResult Danfe()
{
    string path = HttpContext.Server.MapPath("~/Content/NFe28090708060730000190550020000001762000007303procNFe.xml");
    DanzorPrintViewer model = new DanzorPrintViewer(path);
    
    return View("~/Views/Danfe/Danfe.cshtml", model);
}
```


###Exemplo On-line
Veja o funcionamento [aqui](http://danzor.azurewebsites.net/)

###Como colaborar
Abra uma Issue faça um fork do projeto. Quando concluir a alteração, abra um pull request!


