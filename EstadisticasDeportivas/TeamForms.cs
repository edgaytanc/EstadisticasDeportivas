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
    public partial class TeamForms : Form
    {
        AdministradorPartidos partidos;
        Partido partido;
        public TeamForms()
        {
            InitializeComponent();
        }

        public TeamForms(AdministradorPartidos partidos)
        {
            InitializeComponent();
            this.partidos = partidos;
        }

        public TeamForms(Partido partido, AdministradorPartidos partidos)
        {
            InitializeComponent();
            this.partido = partido;
            this.partidos=partidos;

            btnIngreso.Enabled = false;
            cargarPartido();
        }

        private void cargarPartido()
        {
            txtLocal.Text = partido.HomeTeamName;
            txtVisitante.Text = partido.AwayTeamName;
            txtFecha.Text = partido.DateGMT.ToString();
            txtEstado.Text = partido.Status.ToString();
            txtGolesLocal.Text = partido.HomeTeamGoalCount.ToString();
            txtGolesVisitante.Text = partido.AwayTeamGoalCount.ToString();
            txtTotalGoles.Text = partido.TotalGoalCount.ToString();
            txtTirosLocal.Text = partido.HomeTeamShotsOnTarget.ToString();
            txtTirosVisitante.Text = partido.AwayTeamShotsOnTarget.ToString();
            txtPosicionBalonLocal.Text = partido.HomeTeamPossession.ToString();
            txtPosicionBalonVisitante.Text = partido.AwayTeamPossession.ToString();
            txtTotalRojasLocal.Text = partido.HomeTeamRedCards.ToString();
            txtTotalRojasVisitante.Text = partido.AwayTeamRedCards.ToString();
            txtTotalExpectadores.Text = partido.Attendance.ToString();
            
        }

        private void limpiarFormulario()
        {
            txtLocal.Text = "";
            txtVisitante.Text = "";
            txtFecha.Text = "";
            txtEstado.Text = "";
            txtGolesLocal.Text = "";
            txtGolesVisitante.Text = "";
            txtTotalGoles.Text = "";
            txtTirosLocal.Text = "";
            txtTirosVisitante.Text = "";
            txtPosicionBalonLocal.Text = "";
            txtPosicionBalonVisitante.Text = "";
            txtTotalRojasLocal.Text = "";
            txtTotalRojasVisitante.Text = "";
            txtTotalExpectadores.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            Partido nuevoPartido = new Partido();

            nuevoPartido.HomeTeamName = txtLocal.Text;
            nuevoPartido.AwayTeamName = txtVisitante.Text;
            nuevoPartido.DateGMT = DateTime.Parse(txtFecha.Text);
            nuevoPartido.Status = txtEstado.Text;
            nuevoPartido.HomeTeamGoalCount = int.Parse(txtGolesLocal.Text);
            nuevoPartido.AwayTeamGoalCount = int.Parse(txtGolesVisitante.Text);
            nuevoPartido.TotalGoalCount = int.Parse(txtTotalGoles.Text);
            nuevoPartido.HomeTeamShotsOnTarget = int.Parse(txtTirosLocal.Text);
            nuevoPartido.AwayTeamShotsOnTarget = int.Parse(txtTirosVisitante.Text);
            nuevoPartido.HomeTeamPossession = int.Parse(txtPosicionBalonLocal.Text);
            nuevoPartido.AwayTeamPossession = int.Parse(txtPosicionBalonVisitante.Text);
            nuevoPartido.HomeTeamRedCards = int.Parse(txtTotalRojasLocal.Text);
            nuevoPartido.AwayTeamRedCards = int.Parse(txtTotalRojasVisitante.Text);
            nuevoPartido.Attendance = int.Parse(txtTotalExpectadores.Text);

            partidos.Ingresar(nuevoPartido);
            limpiarFormulario();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Partido nuevoPartido = this.partido;

            nuevoPartido.HomeTeamName = txtLocal.Text;
            nuevoPartido.AwayTeamName = txtVisitante.Text;
            nuevoPartido.DateGMT = DateTime.Parse(txtFecha.Text);
            nuevoPartido.Status = txtEstado.Text;
            nuevoPartido.HomeTeamGoalCount = int.Parse(txtGolesLocal.Text);
            nuevoPartido.AwayTeamGoalCount = int.Parse(txtGolesVisitante.Text);
            nuevoPartido.TotalGoalCount = int.Parse(txtTotalGoles.Text);
            nuevoPartido.HomeTeamShotsOnTarget = int.Parse(txtTirosLocal.Text);
            nuevoPartido.AwayTeamShotsOnTarget = int.Parse(txtTirosVisitante.Text);
            nuevoPartido.HomeTeamPossession = int.Parse(txtPosicionBalonLocal.Text);
            nuevoPartido.AwayTeamPossession = int.Parse(txtPosicionBalonVisitante.Text);
            nuevoPartido.HomeTeamRedCards = int.Parse(txtTotalRojasLocal.Text);
            nuevoPartido.AwayTeamRedCards = int.Parse(txtTotalRojasVisitante.Text);
            nuevoPartido.Attendance = int.Parse(txtTotalExpectadores.Text);

            partidos.Actualizar(nuevoPartido);
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            partidos.Eliminar(this.partido);
            this.Close();
        }
    }
}
