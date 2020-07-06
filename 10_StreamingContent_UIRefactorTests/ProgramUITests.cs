using System;
using System.Collections.Generic;
using _09_StreamingContent_Console;
using _09_StreamingContent_Console.UI;
using _10_StreamingContent_UIRefactorTests.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _10_StreamingContent_UIRefactorTests
{
    [TestClass]
    public class ProgramUITests
    {
        [TestMethod]
        public void GetList_OutputShouldContainList()
        {
            //Arrange 
            List<string> commandList = new List<string> { "1", "5" };
            MockConsole console = new MockConsole(commandList);
            ProgramUI program = new ProgramUI(console);

            // ACT
            program.Run();
            Console.WriteLine(console.Output);
            // ASSERT
            Assert.IsTrue(console.Output.Contains("Hitman falls in love or something"));
        }
        [TestMethod]
        public void AddToList_ShouldSeeItemInList()
        {
            //Arrange 
            var customDesc = "Hey Hi Hello! This is my Custom Description.";
            var commandList = new List<string> { "3", "Fake Movie", customDesc, "5", "20", "6", "1", "5" };
            var console = new MockConsole(commandList);
            var ui = new ProgramUI(console);

            //ACT
            ui.Run();
            Console.WriteLine(console.Output);
            //ASSERT
            Assert.IsTrue(console.Output.Contains(customDesc));
        }
        [TestMethod]
        public void RemoveFromList_ShouldSeeRemovedMessage()
        {
            //Arrange 
            List<string> commandList = new List<string> { "4", "2", "1","5"};
            var console = new MockConsole(commandList);
            var ui = new ProgramUI(console);
            //act 
            ui.Run();
            //Assert
            Assert.IsFalse(console.Output.Contains("The best show."));
        }

        [TestMethod]
        public void GetByTitle_ShouldGetCorrectTitle()
        {
            // arrange
            //command list 
            var fakeUserInput = new List<string> { "2", "Mr. Right", "2","Toy Story","5" };
            //console
            var console = new MockConsole(fakeUserInput);
            //ui
            var ui = new ProgramUI(console);

            //Act 
            ui.Run();
            Console.WriteLine(console.Output);
            //running the program 

            //Assert 
            Assert.IsTrue(console.Output.Contains("Genre: Romance"));
        }
    }
}
