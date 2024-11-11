using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AuthApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            if (regLoginBox.Text == "" || regPasswordBox.Text == "" || confirmPasswordBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else if (regPasswordBox.Text != confirmPasswordBox.Text)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else if (!Regex.IsMatch(regPasswordBox.Text,"^(?=.*[A-ZА-Я])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-zа-я]).{8}$"))
            {
                MessageBox.Show("Пароль небезопасен, он должен содержать большие и маленькие буквы, цифры и специальные символы");
            }
            else
            {
                UsersSingleton.Instance.Reg(regLoginBox.Text, regPasswordBox.Text);
                MessageBox.Show("Вы успешно зарегистрированы");
            }
        }
    }
}
