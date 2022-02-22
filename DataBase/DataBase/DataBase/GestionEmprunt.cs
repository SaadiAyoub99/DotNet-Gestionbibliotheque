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
    public partial class GestionEmprunt : Form
    {
        String parametres = "SERVER=127.0.0.1; DATABASE=gestion; UID=root; PASSWORD=";

        public GestionEmprunt()
        {
            InitializeComponent();
            LoadE();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.textBox1.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value).ToString();
                dateTimePicker1.Text = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value).ToString();
                this.textBox4.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value).ToString();
                this.comboBox1.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value).ToString();
                this.textBox2.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value).ToString();
                textBox3.Text      = (dataGridView1.Rows[e.RowIndex].Cells[5].Value).ToString();
            }
        }

        private void GestionEmprunt_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();



            String request = "SELECT titre FROM livre";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["titre"].ToString());
            }
            reader.Close();

            String request1 = "SELECT titre FROM cd";
            MySqlCommand cmd1 = new MySqlCommand(request1, connection);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox1.Items.Add(reader1["titre"].ToString());
            }
            reader1.Close();

            String request2 = "SELECT nom FROM periodique";
            MySqlCommand cmd2 = new MySqlCommand(request2, connection);
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox1.Items.Add(reader2["nom"].ToString());
            }
            reader2.Close();



            connection.Close();


        }

        private void LoadE()
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from emprunt";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView1.DataSource = data;
            connection.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection connection1 = new MySqlConnection(parametres);
            MySqlConnection connection2 = new MySqlConnection(parametres);
            //connection1.Open();
            string cin1 = textBox3.Text;
            string nom_ouvrage = comboBox1.Text;

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM emprunt WHERE cin ='" + cin1 + "' ", connection1);


            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);

            MySqlDataAdapter sda1 = new MySqlDataAdapter("SELECT * FROM emprunt WHERE nom_ouvrage ='" + nom_ouvrage + "' ", connection2);


            DataTable dt1 = new DataTable(); //this is creating a virtual table  
            sda1.Fill(dt1);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(" Ce Client a déja emprunter un ouvrage ");

            }
            else if(dt1.Rows.Count > 0)
            {
                MessageBox.Show(" Ce Ouvrage a ete déja emprunter par un client ");
            } 
            else
            {

                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();

                string nom_client = textBox2.Text;
                string cin = textBox3.Text;
                string periode_emprunt = textBox4.Text;
                DateTime date_emprunt = DateTime.Parse(dateTimePicker1.Text);


                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "insert into emprunt(nom_client, nom_ouvrage, date_emprunt, Periode_emprunt, cin) values(@nom_client, @nom_ouvrage, @date_emprunt, @periode_emprunt, @cin)";
                cmd.Parameters.AddWithValue("@nom_client", nom_client);
                cmd.Parameters.AddWithValue("@nom_ouvrage", nom_ouvrage);
                cmd.Parameters.AddWithValue("@periode_emprunt", periode_emprunt);
                cmd.Parameters.AddWithValue("@date_emprunt", date_emprunt);
                cmd.Parameters.AddWithValue("@cin", cin);


                cmd.ExecuteNonQuery();



                connection.Close();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                //textBox5.Clear();
                LoadE();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            string nom_client = textBox2.Text;
            string periode_emprunt = textBox4.Text;
            string nom_ouvrage = comboBox1.Text;
            string cin = textBox3.Text;
            DateTime date_emprunt = DateTime.Parse(dateTimePicker1.Text);

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE emprunt SET nom_client = @nom_client, nom_ouvrage = @nom_ouvrage, periode_emprunt = @periode_emprunt, date_emprunt = @date_emprunt, cin = @cin WHERE id_em = @id ; ";
            cmd.Parameters.AddWithValue("@nom_client", nom_client);
            cmd.Parameters.AddWithValue("@nom_ouvrage", nom_ouvrage);
            cmd.Parameters.AddWithValue("@periode_emprunt", periode_emprunt);
            cmd.Parameters.AddWithValue("@date_emprunt", date_emprunt);
            cmd.Parameters.AddWithValue("@cin", cin);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            connection.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            //comboBox1.Clear();
            LoadE();
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
                cmd.CommandText = "DELETE FROM emprunt WHERE id_em = @id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                connection.Close();
              //  textBox5.Clear();
                textBox3.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox1.Clear();
                LoadE();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionCd k = new GestionCd();
            this.Hide();
            k.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GestionPeriodique j = new GestionPeriodique();
            this.Hide();
            j.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionLivre i = new GestionLivre();
            this.Hide();
            i.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Auth d = new Auth();
            this.Hide();
            d.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
