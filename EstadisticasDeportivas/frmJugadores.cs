using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstadisticasDeportivas
{
    public partial class frmJugadores : Form
    {
        ListaEnlazadaJugadores listaJugadores;
        public frmJugadores()
        {
            InitializeComponent();
        }
        public frmJugadores(ListaEnlazadaJugadores listaJugadores)
        {
            InitializeComponent();
            this.listaJugadores = listaJugadores;
        }

        private void frmJugadores_Load(object sender, EventArgs e)
        {
            
            Jugador jugador = listaJugadores.BuscarJugador("Zechariah Medley");
            //Console.WriteLine(jugador.ToString());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarJugadores();
        }

        private void CargarJugadores()
        {
            var jugadores = listaJugadores.ObtenerTodos(); // Aquí necesitas un método que obtenga todos los jugadores de la lista enlazada.
            dataGridJugadores.DataSource = jugadores;
            dataGridJugadores.Columns["FullName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            //dataGridJugadores.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = txtBusqueda.Text;
            var filteredList = listaJugadores.ObtenerTodos().Where(p =>
                p.FullName.Contains(filter)).ToList();

            dataGridJugadores.DataSource = null;
            dataGridJugadores.DataSource = filteredList;
            dataGridJugadores.Columns["FullName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

        }

        private void dataGridJugadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridJugadores.Columns["FullName"].Index))
            {
                string fullName = dataGridJugadores.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                fullName = fullName.Trim();
                Console.WriteLine(fullName);
                Jugador player = listaJugadores.BuscarJugador(fullName);
                //Console.WriteLine(team.teamName);

                if (player != null)
                {
                    // Asume que tienes un formulario llamado TeamStatsForm que toma un objeto Equipo como parámetro
                    PlayerStatsForm teamStatsForm = new PlayerStatsForm(player,listaJugadores);
                    teamStatsForm.MdiParent = this.MdiParent;
                    teamStatsForm.Show();
                }
            }
        }
    }
}
