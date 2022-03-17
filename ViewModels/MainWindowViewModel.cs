using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using lab5.Models;

namespace lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string text = "";
        string result = "";
        string pattern = "";

        RegExFinder finder = new RegExFinder();
        public string Input
        {
            set
            {
                this.RaiseAndSetIfChanged(ref text, value);
                this.ChangeOutput();
            }
            get
            {
                return this.text;
            }
        }
        public string Output
        {
            set
            {
                this.RaiseAndSetIfChanged(ref result, value);
            }
            get
            {
                return this.result;
            }
        }
        public string Regex
        {
            set
            {
                this.RaiseAndSetIfChanged(ref pattern, value);
                this.ChangeOutput();
            }
            get
            {
                return this.pattern;
            }
        }
        public void ChangeOutput()
        {
            var matches = finder.GetMatches(Regex, Input);
            String outString = "";
            foreach (string match in matches)
            {
                if (match.Length > 0)
                    outString += match + "\n";
            }

            this.Output = outString;

        }

        public void SaveOutputInFile(string path)
        {
            var fileIO = new FileController();
            fileIO.Write(this.Output, path);
        }

        public void ReadFileToInput(string path)
        {
            var fileIO = new FileController();
            this.Input = fileIO.Read(path);
        }
    }
}