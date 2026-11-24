using System;
using System.Windows;

namespace HelpDesk.Views
{
    public partial class TicketCreateWindow : Window
    {
        public TicketCreateWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object s, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите категорию заявки.");
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Введите описание проблемы.");
                return;
            }

            if (PriorityComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите приоритет заявки.");
                return;
            }

            MessageBox.Show(
                "Данные заявки заполнены корректно.\n" +
                "На следующих занятиях заявка будет сохраняться в MS SQL Server.");
        }

        private void CancelButton_Click(object s, RoutedEventArgs e)
        {
            Close();
        }
    }
}