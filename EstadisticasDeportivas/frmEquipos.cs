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
    public partial class frmEquipos : Form
    {
        ArbolAVL arbolEquipo;
        ListaEnlazadaJugadores listado;
        public frmEquipos()
        {
            InitializeComponent();
        }

        public frmEquipos(ArbolAVL arbolAVL, ListaEnlazadaJugadores listado)
        {
            InitializeComponent();
            this.arbolEquipo = arbolAVL;
            this.listado = listado;
        }

        private void frmEquipos_Load(object sender, EventArgs e)
        {
            //ArbolAVL arbolEquipo = new ArbolAVL();
            //String equipos = @"C:\bd\Equipos.csv";
            //arbolEquipo = AdministradorEquipos.LeerEquipos(equipos);
            //this.arbolEquipo = arbolEquipo;

            arbolEquipo.imprimir();
            Equipo equipo = arbolEquipo.Buscar("Burnley FC");
            Console.WriteLine( equipo );
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarJugadores();
        }

        private void CargarJugadores()
        {
            var equipos = arbolEquipo.ObtenerTodos(); // Aquí necesitas un método que obtenga todos los jugadores de la lista enlazada.
            dataGridEquipos.DataSource = equipos;
            dataGridEquipos.Columns["teamName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridEquipos.Columns["commonName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridEquipos.Refresh();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filter = txtBusqueda.Text;
            var filteredList = arbolEquipo.ObtenerTodos().Where(p =>
                p.teamName.Contains(filter)).ToList();

            dataGridEquipos.DataSource = null;
            dataGridEquipos.DataSource = filteredList;
            dataGridEquipos.Columns["teamName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridEquipos.Columns["commonName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        private void dataGridEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridEquipos.Columns["teamName"].Index || e.ColumnIndex == dataGridEquipos.Columns["commonName"].Index))
            {
                string teamName = dataGridEquipos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                teamName = teamName.Trim();
                Console.WriteLine(teamName);
                Equipo team = arbolEquipo.Buscar(teamName);
                //Console.WriteLine(team.teamName);

                if (team != null)
                {
                    // Asume que tienes un formulario llamado TeamStatsForm que toma un objeto Equipo como parámetro
                    TeamStatsForm teamStatsForm = new TeamStatsForm(team, listado, arbolEquipo);
                    teamStatsForm.MdiParent = this.MdiParent;
                    teamStatsForm.Show();
                }
            }
        }
    }
}
