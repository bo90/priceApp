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
using System.Data;
using System.Data.OleDb;

namespace PriceApp
{
    /// <summary>
    /// Логика взаимодействия для NewGoods.xaml
    /// </summary>
    public partial class NewGoods : Window
    {
        public NewGoods()
        {
            InitializeComponent();
        }

        public void Loadsklad()
        {
            try
            {
                ConnectLayer con = new ConnectLayer();
                con.ConnectionOpen();
                numberSklad.ItemsSource = con.GetAllSkladAsTable().DefaultView;
                numberSklad.DisplayMemberPath = "ID_Sklad";
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // уникального номера
        private void LoadUniqueID()
        {
            try
            {
                ConnectLayer con = new ConnectLayer();
                con.ConnectionOpen();
                idComBoBox.ItemsSource = con.LoadUniqueID().DefaultView;
                idComBoBox.DisplayMemberPath = "ID";
                con.ConnectionOpen();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // загрузка истории цен
        private void LoadHistoryPrice()
        {
            try
            {
                ConnectLayer con = new ConnectLayer();
                con.ConnectionOpen();
                int idGoods = Convert.ToInt32(idGoodsTxtBox.Text);
                historyGrid.ItemsSource = con.TablePrice(idGoods).DefaultView;
                con.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUniqueID();
            Loadsklad();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddNewGoods()
        {
            try
            {
                //полуение параметров из текстовых полей формы
                // номер товара
                int idGoods = Convert.ToInt32(idGoodsTxtBox.Text);
                //номер склада
                int id_sklad = Convert.ToInt32(numberSklad.Text);
                //название товара
                string nameGoods = nameGoodstxtBox.Text;
                // вид товара
                string viewGoods = viewTxtBox.Text;
                // описание товара
                string descript = descriptTxtBox.Text;
                // кол-во товара
                int countGoods = Convert.ToInt32(CountTxtBox.Text);
                ConnectLayer con = new ConnectLayer();
                con.ConnectionOpen();
                con.InsertNewGoods(idGoods, id_sklad, nameGoods, viewGoods, descript, countGoods);
                MessageBox.Show("Товар создан!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddNewGoods();
        }

        private void IdComBoBox_DropDownClosed(object sender, EventArgs e)
        {
            // загрзука всех окон
            LoadinAllWind();
            LoadHistoryPrice();
        }

       

        // метод загрузки
        private void LoadinAllWind()
        {
            try
            {
                int numberId = Convert.ToInt32(idComBoBox.Text);
                string query = "select * from Goods where id =" + numberId ;
                string conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=PriceDB.mdb;";
                OleDbConnection myConn = new OleDbConnection(conn);
                myConn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    OleDbDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    idGoodsTxtBox.Text = dr["ID_Goods"].ToString();
                    numberSklad.Text = dr["ID_Sklad"].ToString();
                    CountTxtBox.Text = dr["CountGoods"].ToString();
                    nameGoodstxtBox.Text = dr["NameGoods"].ToString();
                    viewTxtBox.Text = dr["ViewGoods"].ToString();
                    descriptTxtBox.Text = dr["Descript"].ToString();
                }
                myConn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            NewPrice();
        }

        private void NewPrice()
        {
            try
            {
                ConnectLayer con = new ConnectLayer();
                int _id = Convert.ToInt32(idGoodsTxtBox.Text);
                int _pr = Convert.ToInt32(NewPriceTxtBox.Text);
                con.ConnectionOpen();
                con.NewPrice(_id, _pr);
                con.CloseConnection();
                MessageBox.Show("Новая цена установлена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            try
            {
                ConnectLayer con = new ConnectLayer();
                con.ConnectionOpen();
                int id = Convert.ToInt32(idComBoBox.Text);
                int idGoods = Convert.ToInt32(idGoodsTxtBox.Text);
                int idSklad = Convert.ToInt32(numberSklad.Text);
                string nameGoods = nameGoodstxtBox.Text;
                string desc = descriptTxtBox.Text;
                string view = viewTxtBox.Text;
                int count = Convert.ToInt32(CountTxtBox.Text);
                con.UpdateRecord(idGoods, idSklad, nameGoods, view, desc, count, id);
                
                MessageBox.Show("Запись обновлена!");
                con.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
