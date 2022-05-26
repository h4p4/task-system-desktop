using System;
using System.Windows;
using System.Windows.Controls;
using TaskSystem.Models;

namespace TaskSystem
{
    public static class Helper
    {
        public static TaskSystemContext taskSystemContext = new TaskSystemContext();
        public static User currentUser;
        public static void HandleFocus(TextBlock textBlock, TextBox textBox)
        {
            if (!String.IsNullOrWhiteSpace(textBox.Text) | textBox.IsFocused)
            {
                textBlock.Visibility = Visibility.Hidden;
                return;
            }
            textBlock.Visibility = Visibility.Visible;
        }
        //public static void HandleFocus(PasswordBox passwordBox, string defaultPass)
        //{
        //    if (String.IsNullOrWhiteSpace(passwordBox.Password))
        //    {
        //        passwordBox.Password = defaultPass;
        //        return;
        //    }
        //    if (passwordBox.Password == defaultPass)
        //        passwordBox.Clear();
        //}
    }
}
