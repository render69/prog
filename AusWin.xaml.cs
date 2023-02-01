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
using System.Windows.Shapes;

namespace usersapp
{
    /// <summary>
    /// Логика взаимодействия для AusWin.xaml
    /// </summary>
    public partial class AusWin : Window
    {
        public AusWin()
        {
            InitializeComponent();
        }

        private void Button_aus_Click(object sender, RoutedEventArgs e)
        {
            string login = textboxlog.Text.Trim();
            string pass1 = textboxpass1.Password.Trim();

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
            else
            {
                textboxlog.ToolTip = "";
                textboxlog.Background = Brushes.Transparent;
                textboxpass1.ToolTip = "";
                textboxpass1.Background = Brushes.Transparent;

                User authUser = null;
                using (AppCont db = new AppCont())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass1).FirstOrDefault();
                }

                if(authUser != null)
                    MessageBox.Show("Всё хорошо");
                else
                    MessageBox.Show("Что то не так");
            }
        }
    }
}
