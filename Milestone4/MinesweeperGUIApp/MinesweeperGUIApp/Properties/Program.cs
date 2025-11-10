/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 4
 * References:
 */

namespace MinesweeperGUIApp.Properties
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new UI.Forms.MainForm());
        }
    }
}