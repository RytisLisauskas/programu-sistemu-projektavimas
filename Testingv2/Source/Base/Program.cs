using System;
namespace ValidatorsUnitTests.Source.Base
{
    public class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            ui.FetchData();
            ui.StartMenu();
            ui.SendData();
        }
    }
}
