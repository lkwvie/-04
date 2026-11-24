using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using HelpDesk.Models;
namespace HelpDesk.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow() { InitializeComponent(); }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        { 
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text)) 
            { 
                MessageBox.Show("Введите логин."); return; 
            } 

            if (string.IsNullOrWhiteSpace(PasswordInput.Password))
            { 
                MessageBox.Show("Введите пароль."); return;
            } 

            if (LoginTextBox.Text == "admin" && PasswordInput.Password == "12345")
            { 
                new MainWindow().Show(); Close();
            } 
            
            else MessageBox.Show("Неверный логин или пароль."); 
        }
    }
}