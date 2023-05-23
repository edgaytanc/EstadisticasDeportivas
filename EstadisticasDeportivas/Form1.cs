using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        ListaEnlazadaJugadores enlazadaJugadores;
        String pathJugadores = @"C:\bd\Jugadores.csv";
        ArbolAVL arbolAVL;
        String pathEquipos = @"C:\bd\Equipos.csv";
        AdministradorPartidos partidos;
        String pathPartidos = @"C:\bd\Partidos.csv";
        public Form1()
        {
            InitializeComponent();
            enlazadaJugadores = AdministradorJugadores.LeerJugadores(pathJugadores);
            arbolAVL = AdministradorEquipos.LeerEquipos(pathEquipos);
            //arbolAVL.imprimir();
            partidos = new AdministradorPartidos(pathPartidos);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;


        }

        private void btnCargarJugadores_Click(object sender, EventArgs e)
        {
            ListaEnlazadaJugadores listaJugadores = new ListaEnlazadaJugadores();
            String jugadores = @"C:\bd\Jugadores.csv";
            listaJugadores = AdministradorJugadores.LeerJugadores(jugadores);
            listaJugadores.ImprimirJugadores();

            ArbolAVL arbolEquipo = new ArbolAVL();
            String equipos = @"C:\bd\Equipos.csv";
            arbolEquipo = AdministradorEquipos.LeerEquipos(equipos);
            arbolEquipo.imprimir();

            Hashtable tablaPartidos = new Hashtable();
            String partidos = @"C:\bd\Partidos.csv";
            tablaPartidos = AdministradorPartidos.LeerPartidos(partidos);

            foreach (DictionaryEntry entry in tablaPartidos)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

        }

        private void jugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void equiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void partidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            enlazadaJugadores.GuardarListaEnArchivo(pathJugadores);
            arbolAVL.GuardarArbolEnArchivo(pathEquipos);
            partidos.GuardarTablaEnArchivo(pathPartidos);
        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerStatsForm playerStatsForm = new PlayerStatsForm(enlazadaJugadores)
            {
                MdiParent = this
            };
            playerStatsForm.Show();
            
        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJugadores jugadores = new frmJugadores(enlazadaJugadores)
            {
                MdiParent = this
            };
            jugadores.Show();
        }

        private void busquedaYModificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEquipos equipos = new frmEquipos(arbolAVL, enlazadaJugadores)
            {
                MdiParent = this
            };
            equipos.Show();
        }

        private void busquedaYModificaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPartidos partidos = new frmPartidos(arbolAVL, enlazadaJugadores, this.partidos)
            {
                MdiParent = this
            };
            partidos.Show();
        }

        private void ingresoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TeamStatsForm teamStatsForm = new TeamStatsForm(arbolAVL)
            {
                MdiParent= this
            };
            teamStatsForm.Show();
        }

        private void ingresoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TeamForms teamForms = new TeamForms(partidos)
            {
                MdiParent = this
            };
            teamForms.Show();
        }
    }
}
