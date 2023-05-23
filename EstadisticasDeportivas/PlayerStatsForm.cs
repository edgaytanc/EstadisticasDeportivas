using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EstadisticasDeportivas
{
    public partial class PlayerStatsForm : Form
    {
        Jugador player;
        ListaEnlazadaJugadores listaJugadores;
        public PlayerStatsForm()
        {
            InitializeComponent();
            this.lblTitulo.Hide();
            this.lblJugador.Hide();
            this.btnActualizar.Enabled=false;
            this.btnEliminar.Enabled=false;
        }

        public PlayerStatsForm(ListaEnlazadaJugadores listaJugadores)
        {
            InitializeComponent();

            this.listaJugadores = listaJugadores;

            this.lblTitulo.Hide();
            this.lblJugador.Hide();
            this.btnActualizar.Enabled = false;
            this.btnEliminar.Enabled = false;
        }

        public PlayerStatsForm(Jugador player,ListaEnlazadaJugadores listaJugadores)
        {
            InitializeComponent();
            btnIngreso.Enabled=false;
            this.player = player;
            this.listaJugadores = listaJugadores;

            lblJugador.Text = player.FullName;

            txtNombreCompleto.Text = player.FullName;
            txtEdad.Text = player.Age.ToString();
            txtCumple.Text = player.Birthday.ToString("dd/MM/yyyy");
            txtClub.Text = player.Club.ToString();
            txtLiga.Text = player.League.ToString();
            txtPosicion.Text = player.Position;
            txtTotalGoles.Text = player.GoalsOverall.ToString();
            txtTotalAsistencias.Text = player.AssistsOverall.ToString();
            txtMinutosJuego.Text = player.MinutesPlayedOverall.ToString();
            txtTarjetasAmarillas.Text = player.YellowCardsOverall.ToString();
            txtTarjetasRojas.Text = player.RedCardsOverall.ToString();
            txtNacionalidad.Text = player.Nationality;
            txtTemporada.Text = player.Season;

            // Deshabilita el botón de maximizar
            this.MaximizeBox = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Jugador nuevoJugador = player;
            nuevoJugador.FullName = txtNombreCompleto.Text;
            nuevoJugador.Age = Int32.Parse(txtEdad.Text);
            nuevoJugador.Birthday = DateTime.Parse(txtCumple.Text);
            nuevoJugador.Club = txtClub.Text;
            nuevoJugador.League = txtLiga.Text;
            nuevoJugador.Position = txtPosicion.Text;
            nuevoJugador.GoalsOverall = Int32.Parse(txtTotalGoles.Text);
            nuevoJugador.AssistsOverall = Int32.Parse(txtTotalAsistencias.Text);
            nuevoJugador.MinutesPlayedOverall = Int32.Parse(txtMinutosJuego.Text);
            nuevoJugador.YellowCardsOverall = Int32.Parse(txtTarjetasAmarillas.Text);
            nuevoJugador.RedCardsOverall = Int32.Parse(txtTarjetasRojas.Text);
            nuevoJugador.Nationality = txtNacionalidad.Text;
            nuevoJugador.Season = txtTemporada.Text;

            listaJugadores.ActualizarJugador(txtNombreCompleto.Text, nuevoJugador);
            this.Close();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            listaJugadores.EliminarJugador(txtNombreCompleto.Text);
            this.Close();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            Jugador nuevoJugador = new Jugador();
            nuevoJugador.FullName = txtNombreCompleto.Text;
            nuevoJugador.Age = Int32.Parse(txtEdad.Text);
            nuevoJugador.Birthday = DateTime.Parse(txtCumple.Text);
            nuevoJugador.Club = txtClub.Text;
            nuevoJugador.League = txtLiga.Text;
            nuevoJugador.Position = txtPosicion.Text;
            nuevoJugador.GoalsOverall = Int32.Parse(txtTotalGoles.Text);
            nuevoJugador.AssistsOverall = Int32.Parse(txtTotalAsistencias.Text);
            nuevoJugador.MinutesPlayedOverall = Int32.Parse(txtMinutosJuego.Text);
            nuevoJugador.YellowCardsOverall = Int32.Parse(txtTarjetasAmarillas.Text);
            nuevoJugador.RedCardsOverall = Int32.Parse(txtTarjetasRojas.Text);
            nuevoJugador.Nationality = txtNacionalidad.Text;
            nuevoJugador.Season = txtTemporada.Text;

            listaJugadores.AgregarJugador(nuevoJugador);
            limpiaFormulario();
        }

        private void limpiaFormulario()
        {
            txtNombreCompleto.Text = "";
            txtEdad.Text = "";
            txtCumple.Text = "";
            txtClub.Text = "";
            txtLiga.Text = "";
            txtPosicion.Text = "";
            txtTotalGoles.Text = "";
            txtTotalAsistencias.Text = "";
            txtMinutosJuego.Text = "";
            txtTarjetasAmarillas.Text = "";
            txtTarjetasRojas.Text = "";
            txtNacionalidad.Text = "";
            txtTemporada.Text = "";
        }
    }
}
