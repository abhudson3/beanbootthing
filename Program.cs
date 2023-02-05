using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

WebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.llbean.com/llb/shop/31178?page=mens-llbean-boots-6in&bc=474-629-506794&feat=506794-GN2&csp=f&pos=9");
System.Threading.Thread.Sleep(5000);
driver.FindElement(By.XPath("/html/body/aside/div/div[1]/button")).Click();
System.Threading.Thread.Sleep(5000);
driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[6]/div[2]/div/div[2]/button")).Click();
System.Threading.Thread.Sleep(5000);
driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[5]/div/div/div[2]/section[1]/article[3]/div/div[2]/div/form/div[2]/div[1]/div[1]/div/fieldset/ul/li[3]/label")).Click();
System.Threading.Thread.Sleep(5000);
bool inStock = false;
while(inStock == false){
    driver.Navigate().Refresh();
    System.Threading.Thread.Sleep(5000);
    driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[5]/div/div/div[2]/section[1]/article[3]/div/div[2]/div/form/div[2]/div[1]/div[1]/div/fieldset/ul/li[3]/label")).Click();
    System.Threading.Thread.Sleep(5000);

    try{
        driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div[5]/div/div/div[2]/section[1]/article[3]/div/div[2]/div/form/div[4]/div[3]"));
    }
    catch{
    MailMessage mail = new MailMessage();
    
    mail.From = new MailAddress("regiprotest2@gmail.com");
    mail.To.Add("abhudson3@crimson.ua.edu");
    mail.Subject = "Boots";
    mail.Body = "Boots available";
    
    SmtpClient SmtpServer = new SmtpClient();
    SmtpServer.Host = "smtp.gmail.com";
    SmtpServer.Port = 587;
    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
    SmtpServer.Credentials = new NetworkCredential("regiprotest2@gmail.com", "stsjpserbidjwwby");
    SmtpServer.Timeout = 20000;
    SmtpServer.EnableSsl = true;

    SmtpServer.Send(mail);
    inStock = true;
    }
}
driver.Close();