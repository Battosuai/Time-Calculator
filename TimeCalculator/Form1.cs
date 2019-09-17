using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateCombobox();
            DynamicDatatable();
        }

        private void DynamicDatatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Time",typeof(TimeSpan));

            int year = int.Parse(FilterUserInput(textBox1.Text));
            int month = (comboBox1.SelectedItem as Month).Value;
            int days = DateTime.DaysInMonth(year, month);

            for (int i = 1;i<=days;i++) {
                dt.Rows.Add(i.ToString(), new TimeSpan(0, 0, 0));
            }
            
            dataGridView1.DataSource = dt;

            CalculateGridColumn();
        }

        private void CalculateGridColumn()
        {
            TimeSpan sum = new TimeSpan(0, 0, 0);
            int year = int.Parse(FilterUserInput(textBox1.Text));
            int month = (comboBox1.SelectedItem as Month).Value;
            int days = DateTime.DaysInMonth(year, month);
            for (int i = 0; i < days; ++i)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "" && dataGridView1.Rows[i].Cells[1].Value.ToString() != "00:00:00")
                {
                    Console.WriteLine(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    sum += TimeSpan.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                }
            }
            textBoxResultGrid.Text = (int)double.Parse(sum.TotalHours.ToString()) +":" +sum.Minutes.ToString()+":"+sum.Seconds.ToString();
        }

        private void PopulateCombobox()
        {
            var dataSource = new List<Month>();

            dataSource.Add(new Month() { Name = "January", Value = 1 });
            dataSource.Add(new Month() { Name = "February", Value = 2 });
            dataSource.Add(new Month() { Name = "March", Value = 3 });
            dataSource.Add(new Month() { Name = "April", Value = 4 });
            dataSource.Add(new Month() { Name = "May", Value = 5 });
            dataSource.Add(new Month() { Name = "June", Value = 6 });
            dataSource.Add(new Month() { Name = "July", Value = 7 });
            dataSource.Add(new Month() { Name = "August", Value = 8 });
            dataSource.Add(new Month() { Name = "September", Value = 9 });
            dataSource.Add(new Month() { Name = "October", Value = 10 });
            dataSource.Add(new Month() { Name = "November", Value = 11 });
            dataSource.Add(new Month() { Name = "December", Value = 12 });

            //Setup data binding
            this.comboBox1.DataSource = dataSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Value";

            // make it readonly
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void TextBoxHour1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}

        }

        private void TextBoxMinute1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBoxSecond1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBoxHour2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBoxMinute2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBoxSecond2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBoxHour1_Click(object sender, EventArgs e)
        {
            textBoxHour1.SelectAll();
        }

        private void TextBoxMinute1_Click(object sender, EventArgs e)
        {
            textBoxMinute1.SelectAll();
        }

        private void TextBoxSecond1_Click(object sender, EventArgs e)
        {
            textBoxSecond1.SelectAll();
        }

        private void TextBoxHour2_Click(object sender, EventArgs e)
        {
            textBoxHour2.SelectAll();
        }

        private void TextBoxMinute2_Click(object sender, EventArgs e)
        {
            textBoxMinute2.SelectAll();
        }

        private void TextBoxSecond2_Click(object sender, EventArgs e)
        {
            textBoxSecond2.SelectAll();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int hour1 = int.Parse(FilterUserInput(textBoxHour1.Text));
            int hour2 = int.Parse(FilterUserInput(textBoxHour2.Text));
            int minute1 = int.Parse(FilterUserInput(textBoxMinute1.Text));
            int minute2 = int.Parse(FilterUserInput(textBoxMinute2.Text));
            int second1 = int.Parse(FilterUserInput(textBoxSecond1.Text));
            int second2 = int.Parse(FilterUserInput(textBoxSecond2.Text));

            TimeSpan firstTimeSpan = new TimeSpan(hour1, minute1, second1);
            TimeSpan secondTimeSpan = new TimeSpan(hour2, minute2, second2);

            TimeSpan result = firstTimeSpan + secondTimeSpan;

            textBoxResult.Text = result.ToString();
        }

        private string FilterUserInput(string text)
        {
            string str;
            if (text != "")
            {
                str = String.Join("", text.Split('.'));
            }
            else
            {
                str = "0";
            }
 
            return str;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int hour1 = int.Parse(FilterUserInput(textBoxHour1.Text));
            int hour2 = int.Parse(FilterUserInput(textBoxHour2.Text));
            int minute1 = int.Parse(FilterUserInput(textBoxMinute1.Text));
            int minute2 = int.Parse(FilterUserInput(textBoxMinute2.Text));
            int second1 = int.Parse(FilterUserInput(textBoxSecond1.Text));
            int second2 = int.Parse(FilterUserInput(textBoxSecond2.Text));

            TimeSpan firstTimeSpan = new TimeSpan(hour1, minute1, second1);
            TimeSpan secondTimeSpan = new TimeSpan(hour2, minute2, second2);

            TimeSpan result = firstTimeSpan - secondTimeSpan;

            textBoxResult.Text = result.ToString();
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            DynamicDatatable();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)  //example-'Column index=4'
            {
                dataGridView1.BeginEdit(true);
                CalculateGridColumn();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            CalculateGridColumn();
            test();
        }

        private void test()
        {
            TimeSpan time = TimeSpan.Parse("21:34:51") + TimeSpan.Parse("6:01:06");
            Console.WriteLine(time);
        }
    }
}
