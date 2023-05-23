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
    public partial class TeamStatsForm : Form
    {
        Equipo team;
        ListaEnlazadaJugadores listado;
        ArbolAVL arbolAVL;
        public TeamStatsForm()
        {
            InitializeComponent();
        }

        public TeamStatsForm(ArbolAVL arbolAVL)
        {
            InitializeComponent();
            this.arbolAVL = arbolAVL;
            lblMiembros.Hide();
            richListado.Hide();
            lblEquipo.Hide();
            lblTitulo.Hide();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        public TeamStatsForm(Equipo team, ListaEnlazadaJugadores listado, ArbolAVL arbolAVL)
        {
            InitializeComponent();
            this.team = team;
            this.listado = listado;
            this.arbolAVL = arbolAVL;
            btnIngreso.Enabled = false;
            cargarDatos();
        }

        public TeamStatsForm(Equipo team, ListaEnlazadaJugadores listado)
        {
            InitializeComponent();
            this.team = team;
            this.listado = listado;
            btnIngreso.Enabled=false;
            
            cargarDatos();
        }

        public void cargarDatos()
        {
            lblEquipo.Text = team.teamName;
            txtNombre.Text = team.teamName;
            txtNombreComun.Text = team.commonName;
            txtTemporada.Text = team.season;
            txtPartidosJugados.Text = team.matchesPlayed.ToString();
            txtPartidosGanados.Text = team.wins.ToString();
            txtPartidosPerdidos.Text = team.losses.ToString();
            txtPosicionLiga.Text = team.leaguePosition.ToString();
            txtGolesAnotados.Text = team.goalsScored.ToString();
            txtGolesConcedidos.Text = team.goalsConceded.ToString();
            txtPromedioPosesionBalon.Text = team.averagePossession.ToString();
            txtPorcentajePartidosGanados.Text = team.winPercentage.ToString();

            // Carga los nombres de los jugadores del equipo en txtListado.
            List<string> nombresJugadores = listado.JugadoresPorEquipo(team.commonName);
            
            richListado.Text = String.Join(Environment.NewLine, nombresJugadores);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            Equipo newTeam = new Equipo();


            newTeam.teamName = txtNombre.Text;
            newTeam.commonName = txtNombreComun.Text;
            newTeam.season = txtTemporada.Text;
            newTeam.matchesPlayed = Int32.Parse(txtPartidosJugados.Text);
            newTeam.wins = Int32.Parse(txtPartidosGanados.Text);
            newTeam.losses = Int32.Parse(txtPartidosPerdidos.Text);
            newTeam.leaguePosition = Int32.Parse(txtPosicionLiga.Text);
            newTeam.goalsScored = Int32.Parse(txtGolesAnotados.Text);
            newTeam.goalsConceded = Int32.Parse(txtGolesConcedidos.Text);
            newTeam.averagePossession = Int32.Parse(txtPromedioPosesionBalon.Text);
            newTeam.winPercentage = Int32.Parse(txtPorcentajePartidosGanados.Text);

            arbolAVL.Insertar(newTeam);
            limpiaFormulario();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Equipo newTeam = this.team;

            newTeam.teamName = txtNombre.Text;
            newTeam.commonName = txtNombreComun.Text;
            newTeam.season = txtTemporada.Text;
            newTeam.matchesPlayed = Int32.Parse(txtPartidosJugados.Text);
            newTeam.wins = Int32.Parse(txtPartidosGanados.Text);
            newTeam.losses = Int32.Parse(txtPartidosPerdidos.Text);
            newTeam.leaguePosition = Int32.Parse(txtPosicionLiga.Text);
            newTeam.goalsScored = Int32.Parse(txtGolesAnotados.Text);
            newTeam.goalsConceded = Int32.Parse(txtGolesConcedidos.Text);
            newTeam.averagePossession = Int32.Parse(txtPromedioPosesionBalon.Text);
            newTeam.winPercentage = Int32.Parse(txtPorcentajePartidosGanados.Text);

            arbolAVL.Actualizar(team,newTeam);
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            arbolAVL.Eliminar(team.teamName);
            this.Close();
        }

        private void limpiaFormulario()
        {
            txtNombre.Text = "";
            txtNombreComun.Text = "";
            txtTemporada.Text = "";
            txtPartidosJugados.Text = "";
            txtPartidosGanados.Text = "";
            txtPartidosPerdidos.Text = "";
            txtPosicionLiga.Text = "";
            txtGolesAnotados.Text = "";
            txtGolesConcedidos.Text = "";
            txtPromedioPosesionBalon.Text = "";
            txtPorcentajePartidosGanados.Text = "";
        }
    }
}
