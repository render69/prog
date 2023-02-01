using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace usersapp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AppCont db;

        public MainWindow()
        {
            InitializeComponent();
            db = new AppCont();
        }

        private void regbuttonclic(object sender, RoutedEventArgs e)
        {
            string login = textboxlog.Text.Trim();
            string pass1 = textboxpass1.Password.Trim();
            string pass2 = textboxpass2.Password.Trim();
            string email = textboxemail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textboxlog.ToolTip = "Логин короткий, символов меньше чем 5 ";
                textboxlog.Background = Brushes.DarkRed;
            }
            else if (pass1.Length < 5)
            {
                textboxpass1.ToolTip = "Это поле не коректное, надо больше 5 символов";
                textboxpass1.Background = Brushes.DarkRed;
            }
            else if (pass1 != pass2)
            {
                textboxpass2.ToolTip = "Пароли не совпадают";
                textboxpass2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textboxemail.ToolTip = "Ошибка в E-mail";
                textboxemail.Background = Brushes.DarkRed;
            }
            else
            {
            textboxlog.ToolTip = "";
            textboxlog.Background = Brushes.Transparent;
            textboxpass1.ToolTip = "";
            textboxpass1.Background = Brushes.Transparent;
            textboxpass2.ToolTip = "";
            textboxpass2.Background = Brushes.Transparent;
            textboxemail.ToolTip = "";
            textboxemail.Background = Brushes.Transparent;

            MessageBox.Show("Всё хорошо");
            User user = new User(login, email, pass2);
            db.Users.Add(user);
            db.SaveChanges();

            }
        }
    }
}
