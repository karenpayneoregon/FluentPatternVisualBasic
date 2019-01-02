using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("ItemsSold", typeof(string));
            table.Columns.Add("ItemIDs", typeof(string));
            table.Rows.Add("James Jo", "Shirt; Hat; Socks;", "SH11; HA22; SO33");

            var itemsSold = table.Rows[0].Field<string>("ItemsSold").Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
            var ItemIDs = table.Rows[0].Field<string>("ItemIDs").Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

            
            var sb = new StringBuilder();
            for (int index = 0; index < itemsSold.Length; index++)
            {
                sb.AppendLine(itemsSold[index] + " - " + ItemIDs[index]);   

            }

            var displayFormat = sb.ToString();
            Console.WriteLine(displayFormat);

        }
    }
}
