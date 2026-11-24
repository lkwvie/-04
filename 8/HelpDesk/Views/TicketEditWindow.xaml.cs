using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using HelpDesk.Models;

namespace HelpDesk.Views
{
    public partial class TicketEditWindow : Window
    {
        private Ticket ticket;

        public TicketEditWindow(Ticket t)
        {
            InitializeComponent();

            ticket = t;

            TicketNumber.Text = "Заявка № " + t.Id;

            Select(CategoryComboBox,
                t.Category == "ПО"
                    ? "Программное обеспечение"
                    : t.Category);

            DescriptionTextBox.Text = t.Description;

            Select(PriorityComboBox, t.Priority);
            Select(StatusComboBox, t.Status);
        }

        private void Select(ComboBox box, string value)
        {
            foreach (ComboBoxItem item in box.Items)
            {
                if (item.Content.ToString() == value)
                {
                    box.SelectedItem = item;
                    break;
                }
            }
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

            ticket.Category =
                ((ComboBoxItem)CategoryComboBox.SelectedItem).Content.ToString();

            ticket.Description = DescriptionTextBox.Text;

            ticket.Priority =
                ((ComboBoxItem)PriorityComboBox.SelectedItem).Content.ToString();

            ticket.Status =
                ((ComboBoxItem)StatusComboBox.SelectedItem).Content.ToString();

            DialogResult = true;
        }

        private void CancelButton_Click(object s, RoutedEventArgs e)
        {
            Close();
        }
    }
}