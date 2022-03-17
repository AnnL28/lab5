using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using lab5.ViewModels;
using ReactiveUI;
using System;
using System.Text.RegularExpressions;

namespace lab5.Views
{
    public partial class SetRegex : Window
    {
        public SetRegex()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("okButton").Click += delegate
            {
                var context = this.Owner.DataContext as MainWindowViewModel;
                var inputField = this.FindControl<TextBox>("RegexInputField");
                try
                {
                    Regex rg = new Regex(inputField.Text);
                    context.Regex = inputField.Text;
                    Close();
                }
                catch (Exception ex)
                {
                    inputField.Text = "INVALID REGEX";
                }
            };
            this.FindControl<Button>("cancelButton").Click += delegate
            {
                Close();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}