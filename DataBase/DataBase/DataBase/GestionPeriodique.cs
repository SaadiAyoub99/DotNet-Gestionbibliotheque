using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace DataBase
{
    public partial class GestionPeriodique : Form
    {
        String parametres = "SERVER=127.0.0.1; DATABASE=gestion; UID=root; PASSWORD=";

        public GestionPeriodique()
        {
            InitializeComponent();
            LoadP();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.textBox1.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value).ToString();
                this.textBox2.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value).ToString();
                this.textBox3.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionEmprunt l = new GestionEmprunt();
            this.Hide();
            l.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Auth d = new Auth();
            this.Hide();
            d.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GestionLivre k = new GestionLivre();
            this.Hide();
            k.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionCd m = new GestionCd();
            this.Hide();
            m.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GestionPeriodique_Load(object sender, EventArgs e)
        {

        }

        private void LoadP()
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from periodique";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView1.DataSource = data;
            connection.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            string Nom = textBox2.Text;
            string periodicite = textBox3.Text;

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into periodique(nom, periodicite) values(@nom, @periodicite)";
            cmd.Parameters.AddWithValue("@nom", Nom);
            cmd.Parameters.AddWithValue("@periodicite", periodicite);

            cmd.ExecuteNonQuery();

            connection.Close();
            textBox2.Clear();
            textBox3.Clear();
            LoadP();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            string Nom = textBox2.Text;
            string periodicite = textBox3.Text;

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE periodique SET Nom = @Nom, periodicite=@periodicite WHERE id_p = @id ; ";
            cmd.Parameters.AddWithValue("@Nom", Nom);
            cmd.Parameters.AddWithValue("@periodicite", periodicite);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            connection.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            LoadP();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer cette Périodique", "Supprimer une Périodique", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();

                int id = Int32.Parse(textBox1.Text);

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM periodique WHERE id_p = @id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                LoadP();
            }
        }
    }
}
