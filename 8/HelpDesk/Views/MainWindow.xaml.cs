using System; 
using System.Windows; 
using System.Windows.Controls; 
using System.Collections.Generic; 
using System.Linq; 
using HelpDesk.Models; 

namespace HelpDesk.Views 
{ 
    public partial class MainWindow : Window 
    { 
        private List<Ticket> tickets; 
        public MainWindow()
        {
            InitializeComponent(); 
            tickets=new List<Ticket>
            {
                new Ticket
                {
                    Id=1,Category="Сеть",Description="Нет доступа в Интернет",Priority="Высокий",Status="Новая",CreatedAt=DateTime.Now
                },
                new Ticket
                {
                    Id=2,Category="ПО",Description="Не запускается Microsoft Word",Priority="Средний",Status="В работе",CreatedAt=DateTime.Now
                },
                new Ticket
                {
                    Id=3,Category="Оборудование",Description="Не работает принтер",Priority="Низкий",Status="Выполнена",CreatedAt=DateTime.Now
                }
            }; 
            StatusComboBox.SelectionChanged+=(s,e)=>Filter(); Filter();} 
        private void Filter()
        {
            var q=SearchTextBox.Text.Trim().ToLower(); 
            var status=((ComboBoxItem)StatusComboBox.SelectedItem)?.Content.ToString(); 
            var result=tickets.Where(t=>(t.Description.ToLower().Contains(q)||t.Category.ToLower().Contains(q)||t.Status.ToLower().Contains(q))&&(status=="Все"||t.Status==status)).ToList(); TicketsDataGrid.ItemsSource=result; 
            CountText.Text="Заявок: "+result.Count;
        } 
        private void SearchButton_Click(object s,RoutedEventArgs e)
        {
            Filter();
        } 
        private void ResetFilterButton_Click(object s,RoutedEventArgs e)
        {
            SearchTextBox.Clear();StatusComboBox.SelectedIndex=0;Filter();
        } 
        private void AddTicketButton_Click(object s,RoutedEventArgs e)
        {
            new TicketCreateWindow{Owner=this}.ShowDialog();
        } 
        private void EditTicketButton_Click(object s,RoutedEventArgs e)
        {
            if(!(TicketsDataGrid.SelectedItem is Ticket t))
            {
                MessageBox.Show("Сначала выберите заявку.");return;
            } 
            if(new TicketEditWindow(t){Owner=this}.ShowDialog()==true)Filter();
        } 
        private void DeleteTicketButton_Click(object s,RoutedEventArgs e)
        {
            if(TicketsDataGrid.SelectedItem==null)
            {
                MessageBox.Show("Выберите заявку для удаления.");return;
            } 
            if(MessageBox.Show("Вы действительно хотите удалить выбранную заявку?","Подтверждение удаления",MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)MessageBox.Show("На следующих занятиях здесь будет выполняться удаление записи из MS SQL Server.");
        } 
        private void LogoutButton_Click(object s,RoutedEventArgs e)
        {
            if(MessageBox.Show("Выйти из учётной записи?","HelpDesk",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                new LoginWindow().Show();Close();
            }
        } 
    } 
}