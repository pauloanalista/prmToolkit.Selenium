# prmToolkit.Selenium
Pacote nuget responsável por integarir com sites através dos drives do Selenium

### Installation

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia a dll
```sh
Install-Package prmToolkit.Selenium 
```
### Exemplo de como usar
No exemplo abaixo temos um cenário usando o driver do Chrome.

```sh
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Threading;

namespace Console.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define qual browse queremos rodar e em que local está o drive do mesmo, também é possível definir se irá rodar todo processo em background.
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"C:\_Paulo\POCs\Selenium\driver");
            //Carrega uma página
            webDriver.LoadPage(TimeSpan.FromSeconds(10), @"https://www.google.com");
            //Seta informações na caixa de texto
            webDriver.SetText(By.Name("q"), "ilovecode.com.br");
            //Realiza um submit
            webDriver.Submit(By.Name("btnK"));
            //Fecha a janela após terminar execução
            webDriver.Close();

        }
    }
}
```
