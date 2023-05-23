using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace EstadisticasDeportivas
{
    public partial class frmPartidos : Form
    {
        ArbolAVL arbolAVL;
        ListaEnlazadaJugadores listado;
        AdministradorPartidos partidos;
        String path = @"C:\bd\Partidos.csv";

        private BindingSource bs = new BindingSource();

        public frmPartidos()
        {
            InitializeComponent();
            partidos = new AdministradorPartidos(path);
            dataGridPartidos.AutoGenerateColumns = true;
        }

        public frmPartidos(ArbolAVL arbolAVL, ListaEnlazadaJugadores listado, AdministradorPartidos partidos)
        {
            InitializeComponent();
            this.partidos = partidos;
            dataGridPartidos.AutoGenerateColumns = true;
            this.arbolAVL = arbolAVL;
            this.listado = listado;
            this.arbolAVL.imprimir();
        }

        private void frmPartidos_Load(object sender, EventArgs e)
        {


            Hashtable tablaPartidos = new Hashtable();
            String partidos = @"C:\bd\Partidos.csv";
            tablaPartidos = AdministradorPartidos.LeerPartidos(partidos);
            /*
            foreach (DictionaryEntry entry in tablaPartidos)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }*/
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarPartidos();
        }

        private void CargarPartidos()
        {
            var partido = partidos.ObtenerTodos();
            bs.DataSource = partido;
            dataGridPartidos.DataSource = bs;
            dataGridPartidos.Columns["HomeTeamName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridPartidos.Columns["AwayTeamName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            //dataGridPartidos.Refresh();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filter = txtBusqueda.Text;
            var filteredList = partidos.ObtenerTodos().Where(p =>
                p.HomeTeamName.Contains(filter) ||
                p.AwayTeamName.Contains(filter) ||
                p.StadiumName.Contains(filter)
            ).ToList();

            dataGridPartidos.DataSource = null;
            dataGridPartidos.DataSource = filteredList;
            dataGridPartidos.Columns["HomeTeamName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridPartidos.Columns["AwayTeamName"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

        }

        private void dataGridPartidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridPartidos.Columns["HomeTeamName"].Index || e.ColumnIndex == dataGridPartidos.Columns["AwayTeamName"].Index))
            {
                string teamName = dataGridPartidos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                teamName = teamName.Trim();
                Console.WriteLine(teamName);
                Equipo team = arbolAVL.Buscar(teamName);
                //Console.WriteLine(team.teamName);

                if (team != null)
                {
                    // Asume que tienes un formulario llamado TeamStatsForm que toma un objeto Equipo como parámetro
                    TeamStatsForm teamStatsForm = new TeamStatsForm(team,listado);
                    teamStatsForm.MdiParent = this.MdiParent;
                    teamStatsForm.Show();
                }
            }

            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridPartidos.Columns["Id"].Index))
            {
                string id = dataGridPartidos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                id = id.Trim();
                int idNum = int.Parse(id);
                Partido partido = partidos.buscar(idNum);
                //Console.WriteLine(partido.Id);
                //Console.WriteLine(part);
                if (partido != null)
                {
                    // Asume que tienes un formulario llamado TeamStatsForm que toma un objeto Equipo como parámetro
                    TeamForms teamForms = new TeamForms(partido,partidos);
                    teamForms.MdiParent = this.MdiParent;
                    teamForms.Show();
                }
            }


        }
    }
}
