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

namespace PriceApp
{
    /// <summary>
    /// Логика взаимодействия для CreateWarehouse.xaml
    /// </summary>
    public partial class CreateWarehouse : Window
    {
        public CreateWarehouse()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // проверка на наличие в textbox'ах текстовой информации
            if (idSkladTxtBox.Text != null && nameSkladTxtBox.Text != null)
            {
                //инициализация метода по созданию нового склада
                CreateNewRecord();
                MessageBox.Show("Склад создан!");
            }
            else
            {
                // если поля textBox'ов пусты, будет выведено сообщение
                MessageBox.Show("Введите значения для нового склада");
                return;
            }
        }
        // метод создания новой записи
        private void CreateNewRecord()
        {
            try
            {
                ConnectLayer con = new ConnectLayer();
                con.ConnectionOpen();
                // получение нового номера склада
                int idSklad = Convert.ToInt32(idSkladTxtBox.Text);
                // получение названия склада
                string nameSklad = nameSkladTxtBox.Text;
                con.InsertNewwarehoue(idSklad, nameSklad);
                con.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
