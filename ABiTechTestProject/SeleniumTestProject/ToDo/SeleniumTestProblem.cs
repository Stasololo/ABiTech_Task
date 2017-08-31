using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

namespace SeleniumTestProject.Problem
{
    [TestClass]
    public class SeleniumTestProblem
    {
        private ChromeDriver chromeDriver;

        public SeleniumTestProblem()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestMethod]
        public void CreateProblem()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));

            chromeDriver.Navigate().GoToUrl("http://localhost:62666");

            //поиск таблицы списка Problem
            var table = chromeDriver.FindElement(By.TagName("table"));
            var tBody = table.FindElement(By.TagName("tbody")); //tbody таблицы
            var trCount = tBody.FindElements(By.TagName("tr")).Count; //колличество строк таблицы до создания нового Problem

            //поиск кнопки модального окна создания Problem
            var buttons = chromeDriver.FindElements(By.TagName("button"));
            var createButt = buttons[0];
            createButt.Click();

            //поиск модального окна создания Problem
            var myModalCreate = chromeDriver.FindElement(By.Id("myModalCreate"));
            //поиск строк ввода Problem 
            var inputs = myModalCreate.FindElements(By.TagName("input"));

            var inputName = inputs[0];
            inputName.SendKeys("Name");

            var inputDescr = inputs[1];
            inputDescr.SendKeys("Description");

            //поиск выпадающих списков Problem
            var dropDowns = myModalCreate.FindElements(By.TagName("select"));

            var dropDownStatus = dropDowns[0];
            var selectStatus = new SelectElement(dropDownStatus);
            selectStatus.SelectByIndex(0);

            var dropDownPerson = dropDowns[1];
            var selectPerson = new SelectElement(dropDownPerson);
            selectPerson.SelectByIndex(0);

            //кнопка создания Problem
            var modalCreateButt = myModalCreate.FindElements(By.TagName("button"));
            modalCreateButt[1].Click();

            //колличество строк таблицы после создания нового Problem
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.TagName("tr")));
            var trCountAfter = tBody.FindElements(By.TagName("tr")).Count;

            //сравнение колличества строк таблицы до и после создания нового Problem
            //если колличество строк не изменилось, то тест провален
            if (trCount == trCountAfter)
            {
                Assert.Fail("Test failed: New problem has not been created");
            }

            CloseBrowser();
        }

        [TestMethod]
        public void DeleteProblem()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));

            chromeDriver.Navigate().GoToUrl("http://localhost:62666");

            //поиск таблицы списка Problem
            var table = chromeDriver.FindElement(By.TagName("table"));
            var tBody = table.FindElement(By.TagName("tbody")); //tbody таблицы
            var trCount = tBody.FindElements(By.TagName("tr")).Count; //колличество строк таблицы до удаления нового Problem

            var deleteButt = table.FindElements(By.TagName("input"));
            deleteButt[0].Click();

            //колличество строк таблицы после удаления нового Problem
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.TagName("tr")));
            var trCountAfter = tBody.FindElements(By.TagName("tr")).Count;

            //сравнение колличества строк таблицы до и после удаления нового Problem
            //если колличество строк не изменилось, то тест провален
            if (trCount == trCountAfter)
            {
                Assert.Fail("Test failed: New problem has not been created");
            }

            CloseBrowser();
        }

        [TestMethod]
        public void UpdateProblem()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));

            chromeDriver.Navigate().GoToUrl("http://localhost:62666");

            //поиск таблицы списка Problem
            var table = chromeDriver.FindElement(By.TagName("table"));
            var tBody = table.FindElement(By.TagName("tbody")); //tbody таблицы
            var tr = tBody.FindElements(By.TagName("tr"));
            var updateTr = tr[1]; //строка таблицы до изменения Problem
            var td = updateTr.FindElements(By.TagName("td"));
            
            //поиск кнопки модального окна изменения Problem
            var updateButt = updateTr.FindElement(By.TagName("button"));
            updateButt.Click();

            //поиск модального окна изменения Problem
            var myModalUpdate = chromeDriver.FindElement(By.Id("myModalUpdate"));
            //поиск строк ввода Problem 
            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("input")));
            var inputs = myModalUpdate.FindElements(By.TagName("input"));
            var inputName = inputs[0];
            var searchName = "nnnnnn";
            Thread.Sleep(1000);                      
            inputName.Clear();
            inputName.SendKeys(searchName);

            var searchDescr = "dddddddd";
            var inputDescr = inputs[1];
            Thread.Sleep(1000);
            inputDescr.Clear();
            inputDescr.SendKeys(searchDescr);

            //поиск выпадающих списков Problem
            var dropDowns = myModalUpdate.FindElements(By.TagName("select"));

            var dropDownStatus = dropDowns[0];
            var selectStatus = new SelectElement(dropDownStatus);
            selectStatus.SelectByIndex(2);
            var searchStatus = selectStatus.Options[2].Text;

            var dropDownPerson = dropDowns[1];
            var selectPerson = new SelectElement(dropDownPerson);
            selectPerson.SelectByIndex(1);
            var searchPerson = selectPerson.Options[1].Text;


            var Name = td[0].Text; //Name строки таблицы после изменения Problem
            var Description = td[1].Text; //Description строки таблицы после изменения Problem
            var Status = td[2].Text; //Status строки таблицы после изменения Problem
            var Person = td[3].Text; //Person строки таблицы после изменения Problem


            //кнопка создания Problem
            var modalUpdateButt = myModalUpdate.FindElements(By.TagName("button"));
            modalUpdateButt[1].Click();
            
            if (searchName != Name)
            {
                Assert.Fail("Test failed: problem Name has not been changed");
            }

            if (searchDescr != Description)
            {
                Assert.Fail("Test failed: problem Description has not been changed");
            }

            if (searchStatus != Status)
            {
                Assert.Fail("Test failed: problem Status has not been changed");
            }

            if (searchPerson != Person)
            {
                Assert.Fail("Test failed: problem Person has not been changed");
            }
        }

            /// <summary>
            /// Закрытие браузера 
            /// </summary>
            public void CloseBrowser()
        {
            chromeDriver.Close();
            chromeDriver.Dispose();
        }
    }
}
