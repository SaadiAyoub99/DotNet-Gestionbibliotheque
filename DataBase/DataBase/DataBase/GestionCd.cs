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
    public partial class GestionCd : Form
    {
        String parametres = "SERVER=127.0.0.1; DATABASE=gestion; UID=root; PASSWORD=";

        public GestionCd()
        {
            InitializeComponent();
            LoadCd();
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

        private void GestionCd_Load(object sender, EventArgs e)
        {

        }

        private void LoadCd()
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from cd";
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

            string Titre = textBox2.Text;
            string Auteur = textBox3.Text;

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into cd(titre, auteur) values(@titre, @auteur)";
            cmd.Parameters.AddWithValue("@titre", Titre);
            cmd.Parameters.AddWithValue("@auteur", Auteur);

            cmd.ExecuteNonQuery();

            connection.Close();
            textBox2.Clear();
            textBox3.Clear();
            LoadCd();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            string Titre = textBox2.Text;
            string Auteur = textBox3.Text;

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();



            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE cd SET auteur = @auteur, titre=@titre WHERE id_cd = @id ; ";
            cmd.Parameters.AddWithValue("@titre", Titre);
            cmd.Parameters.AddWithValue("@auteur", Auteur);
            cmd.Parameters.AddWithValue("@id", id);



            cmd.ExecuteNonQuery();

            connection.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            LoadCd();
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
                cmd.CommandText = "DELETE FROM cd WHERE id_cd = @id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

                LoadCd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionLivre f = new GestionLivre();
            this.Hide();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GestionPeriodique g = new GestionPeriodique();
            this.Hide();
            g.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionEmprunt h = new GestionEmprunt();
            this.Hide();
            h.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Auth d = new Auth();
            this.Hide();
            d.Show();
        }
    }
}
