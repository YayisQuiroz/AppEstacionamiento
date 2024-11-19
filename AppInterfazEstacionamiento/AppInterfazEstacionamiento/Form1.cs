using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using GroupBox = System.Windows.Forms.GroupBox;


namespace AppInterfazEstacionamiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var checkBox in groupBoxRow1.Controls.OfType<CheckBox>())
                checkBox.CheckedChanged += CheckBox_CheckedChanged;

            foreach (var checkBox in groupBoxRow2.Controls.OfType<CheckBox>())
                checkBox.CheckedChanged += CheckBox_CheckedChanged;

            foreach (var checkBox in groupBoxRow3.Controls.OfType<CheckBox>())
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
            UpdateProgressBar();
            UpdateLabel();
        }
        private void UpdateProgressBar()
        {
            int totalSpaces = 15;
            int occupiedSpaces = groupBoxRow1.Controls.OfType<CheckBox>().Count(cb => cb.Checked) +
                                 groupBoxRow2.Controls.OfType<CheckBox>().Count(cb => cb.Checked) +
                                 groupBoxRow3.Controls.OfType<CheckBox>().Count(cb => cb.Checked);

            progressBar1.Maximum = totalSpaces;
            progressBar1.Value = occupiedSpaces;
        }
        private void UpdateLabel()
        {
            int totalSpaces = 15;
            int occupiedSpaces = groupBoxRow1.Controls.OfType<CheckBox>().Count(cb => cb.Checked) +
                                 groupBoxRow2.Controls.OfType<CheckBox>().Count(cb => cb.Checked) +
                                 groupBoxRow3.Controls.OfType<CheckBox>().Count(cb => cb.Checked);

            int availableSpaces = totalSpaces - occupiedSpaces;

            labelStatus.Text = $"Espacios Ocupados: {occupiedSpaces} | Disponibles: {availableSpaces}";

            if (occupiedSpaces == totalSpaces)
            {
                buttonStatus.BackColor = System.Drawing.Color.Red;

                labelStatus1.Text = "Estacionamiento: LLENO";
            }
            else
            {
                buttonStatus.BackColor = System.Drawing.Color.Green;
                labelStatus1.Text = "Estacionamiento: DISPONIBLE";
            }
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
            UpdateLabel();
        }
        private void btnReset_Click_1(object sender, EventArgs e)
        {
            foreach (var checkBox in Controls.OfType<GroupBox>()
                                              .SelectMany(gb => gb.Controls.OfType<CheckBox>()))
            {
                checkBox.Checked = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateProgressBar(); // Actualiza el progreso
            UpdateLabel(); // Actualiza el texto del Label
        }
    }
}
