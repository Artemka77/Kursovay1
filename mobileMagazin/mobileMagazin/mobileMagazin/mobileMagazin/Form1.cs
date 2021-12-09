using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace mobileMagazin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            всеТелефоныВНаличииDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        bool chekDgvSelected(DataGridView dgv, int position, string messErr = "", bool errShow = false)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                if (errShow) MessageBox.Show(messErr);
                return false;
            }

            if (dgv[0, dgv.SelectedRows[0].Index].Value == null)
            {
                if (errShow) MessageBox.Show(messErr);
                return false;
            }

            if (dgv[0, dgv.SelectedRows[0].Index].Value.ToString() == "")
            {
                if (errShow) MessageBox.Show(messErr);
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!chekDgvSelected(всеТелефоныВНаличииDataGridView, 0))
            {
                MessageBox.Show("Выберите продажу!");
                return;
            }

            String id = всеТелефоныВНаличииDataGridView[0, всеТелефоныВНаличииDataGridView.SelectedRows[0].Index].Value.ToString();
            
            this.prodazhaTableAdapter.Insert(Convert.ToInt64(id), DateTime.Now, Convert.ToDecimal(textBox1.Text), 
                Convert.ToInt32(textBox2.Text));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.ПроданныеТелефоныПоДате". При необходимости она может быть перемещена или удалена.
            this.проданныеТелефоныПоДатеTableAdapter.Fill(this.dataSet1.ПроданныеТелефоныПоДате);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Prodazha". При необходимости она может быть перемещена или удалена.
            this.prodazhaTableAdapter.Fill(this.dataSet1.Prodazha);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Postavka". При необходимости она может быть перемещена или удалена.
            this.postavkaTableAdapter.Fill(this.dataSet1.Postavka);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Postavshik". При необходимости она может быть перемещена или удалена.
            this.postavshikTableAdapter.Fill(this.dataSet1.Postavshik);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Model". При необходимости она может быть перемещена или удалена.
            this.modelTableAdapter.Fill(this.dataSet1.Model);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.OC". При необходимости она может быть перемещена или удалена.
            this.oCTableAdapter.Fill(this.dataSet1.OC);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Mark". При необходимости она может быть перемещена или удалена.
            this.markTableAdapter.Fill(this.dataSet1.Mark);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Proizvoditel". При необходимости она может быть перемещена или удалена.
            this.proizvoditelTableAdapter.Fill(this.dataSet1.Proizvoditel);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.ВсеТелефоныВНаличии". При необходимости она может быть перемещена или удалена.
            this.всеТелефоныВНаличииTableAdapter.Fill(this.dataSet1.ВсеТелефоныВНаличии);
        }
    }
}
