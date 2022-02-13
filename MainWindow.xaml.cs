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
using System.Data.SQLite;
using Record.Connection;
using System.Data;

namespace Record
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();      
            CbFill();
            CbMonth.IsEnabled = false;
            CbYears.IsEnabled = false;
            this.DGStudents.Columns[0].IsReadOnly = true;

        }
        
       
        public void CbFill()  //Данные для комбобоксов 
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                    connection.Open();
                    string query1 = $@"SELECT * FROM Groups"; // Группы
                    string query2 = $@"SELECT * FROM Months"; // Типы
                    string query3 = $@"SELECT * FROM Years"; // Типы

                    //----------------------------------------------
                    SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
                    SQLiteCommand cmd2 = new SQLiteCommand(query2, connection);
                    SQLiteCommand cmd3 = new SQLiteCommand(query3, connection);

                    //----------------------------------------------
                    SQLiteDataAdapter SDA1 = new SQLiteDataAdapter(cmd1);
                    SQLiteDataAdapter SDA2 = new SQLiteDataAdapter(cmd2);
                    SQLiteDataAdapter SDA3 = new SQLiteDataAdapter(cmd3);
                    //----------------------------------------------
                    DataTable dt1 = new DataTable("Groups");
                    DataTable dt2 = new DataTable("Months");
                    DataTable dt3 = new DataTable("Years");
                    //----------------------------------------------
                    SDA1.Fill(dt1);
                    SDA2.Fill(dt2);
                    SDA3.Fill(dt3);
                    //----------------------------------------------
                    CbGroups.ItemsSource = dt1.DefaultView;
                    CbGroups.DisplayMemberPath = "NameGroup";
                    CbGroups.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CbMonth.ItemsSource = dt2.DefaultView;
                    CbMonth.DisplayMemberPath = "Month";
                    CbMonth.SelectedValuePath = "ID";
                    //----------------------------------------------
                    CbYears.ItemsSource = dt3.DefaultView;
                    CbYears.DisplayMemberPath = "Year";
                    CbYears.SelectedValuePath = "ID";


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CbGroups_SelectionChanged(object sender, SelectionChangedEventArgs e) //Группы
        {
            if (CbGroups.SelectedIndex != -1) { CbMonth.IsEnabled = true; } else { CbMonth.IsEnabled = true; }
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    // MessageBox.Show(CbGroups.DisplayMemberPath.ToString());//нет
                    // MessageBox.Show(CbGroups.Items[CbGroups.SelectedIndex].ToString());// почти
                    String str = ((DataRowView)CbGroups.SelectedItem)["NameGroup"].ToString(); //Вывел
                    bool resultClass = int.TryParse(CbGroups.SelectedValue.ToString(), out Saver.idGroup);
                    Saver.groups = str ;

                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }
        }      
        public void Traffics()//дни
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    string query = $@"SELECT Students.NSM,Traffics.Day1 FROM Traffics
                                    JOIN Students On Traffics.IDStudents = Students.ID";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    //cmd.Parameters.AddWithValue("@Number", TbNumber.Text);
                    DataTable DT = new DataTable("Students");
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SDA.Fill(DT);
                    DGStudents.ItemsSource = DT.DefaultView;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }
        }

        private void CbYears_SelectionChanged(object sender, SelectionChangedEventArgs e)//Годы
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                  /*  String str = ((DataRowView)CbMonth.SelectedItem)["Years"].ToString();*/ //Вывел
                    bool resultClass = int.TryParse(CbYears.SelectedValue.ToString(), out Saver.idyears);
                    //Saver.month = str;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }
        }

        private void CbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e) //Месяцы
        {
            if (CbMonth.SelectedIndex != -1) { CbYears.IsEnabled = true; } else { CbYears.IsEnabled = true; }
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    // MessageBox.Show(CbGroups.DisplayMemberPath.ToString());//нет
                    // MessageBox.Show(CbGroups.Items[CbGroups.SelectedIndex].ToString());// почти
                    String str = ((DataRowView)CbMonth.SelectedItem)["Month"].ToString(); //Вывел
                    bool resultClass = int.TryParse(CbMonth.SelectedValue.ToString(), out Saver.idmonth);
                    Saver.month = str;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }
        }

        private void Search()//Поиск для DataGrid
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                     connection.Open();
                    string query = $@"SELECT Students.ID,Students.NSM, Groups.NameGroup, Months.Month,Years.Year, Traffics.Day1,Traffics.Day2,Traffics.Day3,Traffics.Day4,Traffics.Day5,Traffics.Day6,Traffics.Day7,Traffics.Day8,Traffics.Day9,Traffics.Day10,Traffics.Day11,Traffics.Day12,Traffics.Day13,Traffics.Day14,Traffics.Day15,Traffics.Day16,Traffics.Day17,Traffics.Day18,Traffics.Day19,Traffics.Day20,Traffics.Day21,Traffics.Day22,Traffics.Day23,Traffics.Day24,Traffics.Day25,Traffics.Day26,Traffics.Day27,Traffics.Day28,Traffics.Day29,Traffics.Day30,Traffics.Day31,Traffics.SumP,Traffics.SumH,Traffics.SumB  FROM Traffics 
                                        JOIN Months on Traffics.IDMonth = Months.ID
                                        JOIN Years on Traffics.IDYear = Years.ID
                                        JOIN Students on Traffics.IDStudent = Students.ID
                                        JOIN Groups on Students.IDGroup = Groups.ID
                                        WHERE  Groups.ID = '{Saver.idGroup}' and Traffics.IDMonth = '{Saver.idmonth}' and Years.ID = '{Saver.idyears}'";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    DataTable DT = new DataTable("Traffics");
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SDA.Fill(DT);
                    DGStudents.ItemsSource = DT.DefaultView;
                    cmd.ExecuteNonQuery();
                    foreach (DataRow row in DT.Rows)
                    {
                        int countB = 0, countP = 0, countH = 0;

                        for (int i = 1; i <= 31; i++)
                        {
                            string temp = Convert.ToString(row[$@"Day{i}"]);
                            if (temp == "б")
                            {
                                countB++;
                            }
                            if (temp == "п")
                            {
                                countP++;
                            }
                            if (temp == "н")
                            {
                                countH++;
                            }
                        }
                        row["SumB"] = countB;
                        row["SumP"] = countP;
                        row["SumH"] = countH;
                    }

                }
            }
            catch (Exception exp) 

            { MessageBox.Show(exp.Message); }

        }
        private void BtSearch_Click(object sender, RoutedEventArgs e)//Поиск по нажатия
        {
            if ((CbGroups.SelectedIndex != -1) && (CbMonth.SelectedIndex != -1) && (CbYears.SelectedIndex != -1)) 
            {
                Search();
                SumTotoalB();
                SumTotoalP();
                SumTotoalН();
                SumTotoalT();
            }
            else
            {
                MessageBox.Show("Выберите три критерия поиска");
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)//Сохранение данные при их изменениях(по кнопке), по сути не нужно(для вида)
        {
            //Stroka();
        }

        private void DGStudents_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)//обновляем данные при их изменениях(enter, ....
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    if (DGStudents.SelectedItems.Count > 0)
                    {
                        DataRowView row = (DataRowView)DGStudents.SelectedItems[0];
                        Stroka();
                        //TbNumber.Text = row["Day1"].ToString();
                        Saver.D1 = row["Day1"].ToString(); Saver.D2 = row["Day2"].ToString(); Saver.D3 = row["Day3"].ToString(); Saver.D4 = row["Day4"].ToString(); Saver.D5 = row["Day5"].ToString(); Saver.D6 = row["Day6"].ToString(); Saver.D7 = row["Day7"].ToString(); Saver.D8 = row["Day8"].ToString(); Saver.D8 = row["Day8"].ToString(); Saver.D9 = row["Day9"].ToString(); Saver.D10 = row["Day10"].ToString(); Saver.D11 = row["Day11"].ToString(); Saver.D12 = row["Day12"].ToString(); Saver.D13 = row["Day13"].ToString(); Saver.D14 = row["Day14"].ToString(); Saver.D15 = row["Day15"].ToString(); Saver.D16 = row["Day16"].ToString(); Saver.D17 = row["Day17"].ToString(); Saver.D18 = row["Day18"].ToString(); Saver.D19 = row["Day19"].ToString(); Saver.D20 = row["Day20"].ToString(); Saver.D21 = row["Day21"].ToString(); Saver.D22 = row["Day22"].ToString(); Saver.D23 = row["Day23"].ToString(); Saver.D24 = row["Day24"].ToString(); Saver.D25 = row["Day25"].ToString(); Saver.D26 = row["Day26"].ToString(); Saver.D27 = row["Day27"].ToString(); Saver.D28 = row["Day28"].ToString(); Saver.D29 = row["Day29"].ToString();
                        Saver.D30 = row["Day30"].ToString(); Saver.D31 = row["Day31"].ToString();
                        try  
                        {
                            connection.Open();
                            if (Saver.D1 == "н" | Saver.D1 == "б" | Saver.D1 == "п" | Saver.D1 == "") {  string query = $@"UPDATE  Traffics SET  Day1 = '{Saver.D1}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else {MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search();  }
                            if (Saver.D2 == "н" | Saver.D2 == "б" | Saver.D2 == "п" | Saver.D2 == "") {  string query = $@"UPDATE  Traffics SET  Day2 = '{Saver.D2}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D3 == "н" | Saver.D3 == "б" | Saver.D3 == "п" | Saver.D3 == "") {  string query = $@"UPDATE  Traffics SET  Day3 = '{Saver.D3}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D4 == "н" | Saver.D4 == "б" | Saver.D4 == "п" | Saver.D4 == "") {  string query = $@"UPDATE  Traffics SET  Day4 = '{Saver.D4}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D5 == "н" | Saver.D5 == "б" | Saver.D5 == "п" | Saver.D5 == "") {  string query = $@"UPDATE  Traffics SET  Day5 = '{Saver.D5}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D6 == "н" | Saver.D6 == "б" | Saver.D6 == "п" | Saver.D6 == "") {  string query = $@"UPDATE  Traffics SET  Day6 = '{Saver.D6}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D7 == "н" | Saver.D7 == "б" | Saver.D7 == "п" | Saver.D7 == "") {  string query = $@"UPDATE  Traffics SET  Day7 = '{Saver.D7}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D8 == "н" | Saver.D8 == "б" | Saver.D8 == "п" | Saver.D8 == "") {  string query = $@"UPDATE  Traffics SET  Day8 = '{Saver.D8}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D9 == "н" | Saver.D9 == "б" | Saver.D9 == "п" | Saver.D9 == "") {  string query = $@"UPDATE  Traffics SET  Day9 = '{Saver.D9}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D10 == "н" | Saver.D10 == "б" | Saver.D10 == "п" | Saver.D10 == "") {  string query = $@"UPDATE  Traffics SET  Day10 = '{Saver.D10}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D11 == "н" | Saver.D11 == "б" | Saver.D11 == "п" | Saver.D11 == "") {  string query = $@"UPDATE  Traffics SET  Day11 = '{Saver.D11}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D12 == "н" | Saver.D12 == "б" | Saver.D12 == "п" | Saver.D12 == "") {  string query = $@"UPDATE  Traffics SET  Day12 = '{Saver.D12}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D13 == "н" | Saver.D13 == "б" | Saver.D13 == "п" | Saver.D13 == "") {  string query = $@"UPDATE  Traffics SET  Day13 = '{Saver.D13}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D14 == "н" | Saver.D14 == "б" | Saver.D14 == "п" | Saver.D14 == "") {  string query = $@"UPDATE  Traffics SET  Day14 = '{Saver.D14}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D15 == "н" | Saver.D15 == "б" | Saver.D15 == "п" | Saver.D15 == "") {  string query = $@"UPDATE  Traffics SET  Day15 = '{Saver.D15}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D16 == "н" | Saver.D16 == "б" | Saver.D16 == "п" | Saver.D16 == "") {  string query = $@"UPDATE  Traffics SET  Day16 = '{Saver.D16}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D17 == "н" | Saver.D17 == "б" | Saver.D17 == "п" | Saver.D17 == "") {  string query = $@"UPDATE  Traffics SET  Day17 = '{Saver.D17}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D18 == "н" | Saver.D18 == "б" | Saver.D18 == "п" | Saver.D18 == "") {  string query = $@"UPDATE  Traffics SET  Day18 = '{Saver.D18}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D19 == "н" | Saver.D19 == "б" | Saver.D19 == "п" | Saver.D19 == "") {  string query = $@"UPDATE  Traffics SET  Day19 = '{Saver.D19}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D20 == "н" | Saver.D20 == "б" | Saver.D20 == "п" | Saver.D20 == "") {  string query = $@"UPDATE  Traffics SET  Day20 = '{Saver.D20}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D21 == "н" | Saver.D21 == "б" | Saver.D21 == "п" | Saver.D21 == "") {  string query = $@"UPDATE  Traffics SET  Day21 = '{Saver.D22}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D22 == "н" | Saver.D22 == "б" | Saver.D22 == "п" | Saver.D22 == "") {  string query = $@"UPDATE  Traffics SET  Day22 = '{Saver.D22}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D23 == "н" | Saver.D23 == "б" | Saver.D23 == "п" | Saver.D23 == "") {  string query = $@"UPDATE  Traffics SET  Day23 = '{Saver.D23}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D24 == "н" | Saver.D24 == "б" | Saver.D24 == "п" | Saver.D24 == "") {  string query = $@"UPDATE  Traffics SET  Day24 = '{Saver.D24}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D25 == "н" | Saver.D25 == "б" | Saver.D25 == "п" | Saver.D25 == "") {  string query = $@"UPDATE  Traffics SET  Day25 = '{Saver.D25}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D26 == "н" | Saver.D26 == "б" | Saver.D26 == "п" | Saver.D26 == "") {  string query = $@"UPDATE  Traffics SET  Day26 = '{Saver.D26}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D27 == "н" | Saver.D27 == "б" | Saver.D27 == "п" | Saver.D27 == "") {  string query = $@"UPDATE  Traffics SET  Day27 = '{Saver.D27}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D28 == "н" | Saver.D28 == "б" | Saver.D28 == "п" | Saver.D28 == "") {  string query = $@"UPDATE  Traffics SET  Day28 = '{Saver.D28}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D29 == "н" | Saver.D29 == "б" | Saver.D29 == "п" | Saver.D29 == "") { string query = $@"UPDATE  Traffics SET  Day29 = '{Saver.D29}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search();  }
                            if (Saver.D30 == "н" | Saver.D30 == "б" | Saver.D30 == "п" | Saver.D30 == "") {  string query = $@"UPDATE  Traffics SET  Day30 = '{Saver.D30}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            if (Saver.D31 == "н" | Saver.D31 == "б" | Saver.D31 == "п" | Saver.D31 == "") {  string query = $@"UPDATE  Traffics SET  Day31 = '{Saver.D31}' WHERE Traffics.ID = '{Saver.IDNSM}' and Traffics.IDMonth ='{Saver.idmonth}' "; SQLiteCommand cmd = new SQLiteCommand(query, connection); cmd.ExecuteNonQuery(); } else { MessageBox.Show("Введите 'н' или 'б' или 'п' или ничего"); Search(); }
                            connection.Close();
                        }
                        catch
                        { 
                        }
                        InfoPHB();
                        SumTotoalB();
                        SumTotoalP();
                        SumTotoalН();
                        SumTotoalT();
                        Search();
                    }
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); } 
        }
        public void SumTotoalT() //Колличество студентов присутствует()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    connection.Open();
                    string[] test = new string[31];
                    for (int i = 1; i <= 31; i++) {
                      
                        string query = $@"SELECT  count() FROM Traffics 
                        JOIN Months on Traffics.IDMonth = Months.ID 
                        JOIN Years on Traffics.IDYear = Years.ID 
                        JOIN Students on Traffics.IDStudent = Students.ID 
                        JOIN Groups on Students.IDGroup = Groups.ID  WHERE Groups.ID = '{Saver.idGroup}' and Traffics.IDMonth = '{Saver.idmonth}' and Years.ID = '{Saver.idyears}' and  (Day{i} is NULL or Day{i} = '')";
                        SQLiteCommand cmd = new SQLiteCommand(query, connection);
                        int DayB = Convert.ToInt32(cmd.ExecuteScalar());
                        string s = DayB.ToString();
                        test[i-1] = s;
                        Output.Text = string.Join("      ", test);

                    }


                }
            }
            catch (Exception exp)

            { MessageBox.Show(exp.Message); }
        }
        public void SumTotoalН() //Колличество студентов незаконно(н)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    connection.Open();
                    string[] test = new string[31];
                    for (int i = 1; i <= 31; i++)
                    {
                        string query = $@"SELECT  count() FROM Traffics  
                    JOIN Months on Traffics.IDMonth = Months.ID 
                    JOIN Years on Traffics.IDYear = Years.ID JOIN Students on Traffics.IDStudent = Students.ID 
					JOIN Groups on Students.IDGroup = Groups.ID
                    WHERE Groups.ID = '{Saver.idGroup}' and Traffics.IDMonth = '{Saver.idmonth}' and Years.ID = '{Saver.idyears}' and  Day1 = 'н'";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    int DayB = Convert.ToInt32(cmd.ExecuteScalar());
                    string s1 = DayB.ToString();
                   // H1.Text = s1;
                    test[i - 1] = s1;
                    H1.Text = string.Join("      ", test);
                    }

                }
            }
            catch (Exception exp)

            { MessageBox.Show(exp.Message); }
        }
        public void SumTotoalP() //Колличество студентов с причной
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    connection.Open();
                    string[] test = new string[31];
                    for (int i = 1; i <= 31; i++)
                    {
                        string query = $@"SELECT  count() FROM Traffics  
                    JOIN Months on Traffics.IDMonth = Months.ID 
                    JOIN Years on Traffics.IDYear = Years.ID JOIN Students on Traffics.IDStudent = Students.ID 
					JOIN Groups on Students.IDGroup = Groups.ID
                    WHERE Groups.ID = '{Saver.idGroup}' and Traffics.IDMonth = '{Saver.idmonth}' and Years.ID = '{Saver.idyears}' and  Day1 = 'п'";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    int DayB = Convert.ToInt32(cmd.ExecuteScalar());
                    string s1 = DayB.ToString();
                   // P1.Text = s1;
                    test[i - 1] = s1;
                    P1.Text = string.Join("      ", test);
                    }
                }
            }
            catch (Exception exp)

            { MessageBox.Show(exp.Message); }
        }

        public void SumTotoalB() //Колличество студентов с болезнью
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
                {
                    connection.Open();
                    string[] test = new string[31];
                    for (int i = 1; i <= 31; i++)
                    {
                        {
                            string query = $@"SELECT  count() FROM Traffics  
                    JOIN Months on Traffics.IDMonth = Months.ID 
                    JOIN Years on Traffics.IDYear = Years.ID JOIN Students on Traffics.IDStudent = Students.ID 
					JOIN Groups on Students.IDGroup = Groups.ID
                    WHERE Groups.ID = '{Saver.idGroup}' and Traffics.IDMonth = '{Saver.idmonth}' and Years.ID = '{Saver.idyears}' and  Day{i} = 'б'";
                            SQLiteCommand cmd = new SQLiteCommand(query, connection);
                            int DayB = Convert.ToInt32(cmd.ExecuteScalar());
                            string s = DayB.ToString();
                            test[i - 1] = s;
                            B1.Text = string.Join("      ", test);
                            //if (i == 1) { B1.Text = s; } if (i == 2) { B2.Text = s; } if (i == 3) { B3.Text = s; }  if (i == 4) { B4.Text = s; } if (i == 5) { B5.Text = s; } if (i == 6) { B6.Text = s; } if (i == 7) { B7.Text = s; }
                            //if (i == 8) { B8.Text = s; } if (i == 9) { B9.Text = s; } if (i == 10) { B10.Text = s; }

                            //if (i == 11) { B11.Text = s; } if (i == 12) { B12.Text = s; } if (i == 13) { B13.Text = s; } if (i == 14) { B14.Text = s; } if (i == 15) { B15.Text = s; } if (i == 16) { B16.Text = s; } 
                            //if (i == 17) { B17.Text = s; } if (i == 18) { B18.Text = s; } if (i == 19) { B19.Text = s; } if (i == 20) { B20.Text = s; }

                            //if (i == 21) { B21.Text = s; } if (i == 22) { B22.Text = s; } if (i == 23) { B23.Text = s; } if (i == 24) { B24.Text = s; } if (i == 25) { B25.Text = s; } if (i == 26) { B26.Text = s; }
                            //if (i == 27) { B27.Text = s; } if (i == 28) { B28.Text = s; } if (i == 29) { B29.Text = s; }
                            //if (i == 30) { B30.Text = s; } if (i == 31) { B31.Text = s; } 

                        }

                    }


                }
            }
            catch (Exception exp)

            { MessageBox.Show(exp.Message); }
        }

        public void InfoPHB()
        {
            //using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            //{
            //    try
            //    {
            //        connection.Open();
            //        string query1 = $@"SELECT  count() FROM Traffics  
            //        JOIN Months on Traffics.IDMonth = Months.ID 
            //        JOIN Years on Traffics.IDYear = Years.ID JOIN Students on Traffics.IDStudent = Students.ID 
            //        WHERE Traffics.ID = '{Saver.IDNSM}' and  IDMonth = '{Saver.idmonth}' and IDYear = '{Saver.idyears}'  and Day{Saver.Den} = 'б' "; //Количество Б у студента
            //        SQLiteCommand cmd1 = new SQLiteCommand(query1, connection);
            //        int DayB = Convert.ToInt32(cmd1.ExecuteScalar());
            //        MessageBox.Show($"{DayB}");


            //        string query2 = $@"	SELECT  SumB FROM Traffics  
            //        JOIN Months on Traffics.IDMonth = Months.ID 
            //        JOIN Years on Traffics.IDYear = Years.ID JOIN Students on Traffics.IDStudent = Students.ID 
            //        WHERE Traffics.ID = '{Saver.IDNSM}'  and  IDMonth = '{Saver.idmonth}' and IDYear = '{Saver.idyears}'  "; //Количество учеников с Б
            //        SQLiteCommand cmd2 = new SQLiteCommand(query2, connection);
            //        int SumB = Convert.ToInt32(cmd2.ExecuteScalar());
            //        MessageBox.Show("Сумма б в SuB" +$"{SumB}");

            //        if (Saver.D1 == "б")
            //        {
            //            SumB++;
            //        }
            //    }
            //    catch (Exception exp)
            //    {
            //        MessageBox.Show(exp.Message);
            //    }
            //}
        }
       
        public void Stroka()//Узнаем кого выбрали + его айди(в студентах)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                    foreach (var item in DGStudents.SelectedItems.Cast<DataRowView>())
                    {
                        DataRowView row = (DataRowView)DGStudents.SelectedItems[0];
                        Saver.NameFirst = row["NSM"].ToString(); 
                        connection.Open();
                        string query = $@"SELECT ID FROM  Students  WHERE NSM=@NSM ";
                        SQLiteCommand cmd = new SQLiteCommand(query, connection);
                        cmd.Parameters.AddWithValue("@NSM", Saver.NameFirst);
                        
                        int countID = Convert.ToInt32(cmd.ExecuteScalar());
                       // MessageBox.Show($@"{countID}" + " IDSTudent");
                        cmd.ExecuteNonQuery();
                        string query2 = $@"SELECT ID FROM Traffics WHERE IDStudent ='{countID}' and IDMonth='{Saver.idmonth}' and IDYear='{Saver.idyears}'"; //ID студента в таблице трафиика
                        SQLiteCommand cmd2 = new SQLiteCommand(query2, connection);
                        int TrafficID = Convert.ToInt32(cmd2.ExecuteScalar());
                        Saver.IDNSM = TrafficID;
                       // MessageBox.Show($@"{Saver.IDNSM}" + " IDTraffic");
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }
        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {

            AddStudents AdSt = new AddStudents();
            AdSt.Owner = this;
            //AdSt.Show();
            AdSt.ShowDialog();


        }

        private void w_Click(object sender, RoutedEventArgs e)
        {
            if ((CbGroups.SelectedIndex != -1) && (CbMonth.SelectedIndex != -1) && (CbYears.SelectedIndex != -1))
            {
                Window1 Wi = new Window1(CbGroups.Text, CbMonth.Text, CbYears.Text);
                Wi.Show();
            }
            else
            {
                MessageBox.Show("Выберите три критерия ");
            }
           
        }

        private void Obrat_Click(object sender, RoutedEventArgs e)
        {
            ObratConn AdSt = new ObratConn();
            AdSt.Owner = this;
            //AdSt.Show();
            AdSt.ShowDialog();
        }

        private void DGStudents_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                   // Saver.Den = DGStudents.CurrentCell.Column.DisplayIndex;
                   // DataRowView dataRow = (DataRowView)DGStudents.SelectedItem;

                    //string cellValue = dataRow.Row.ItemArray[index].ToString();
                   // MessageBox.Show($"{Saver.Den}");
                    // MessageBox.Show($"{cellValue}");

            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("");
            }
        }
    }  
}
