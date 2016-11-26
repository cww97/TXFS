using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CognitiveServices.SpeechRecognition;
using TXFSAnalyze.Analyze;

namespace UI_Meeting
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listen a = new Listen();
            var s = a.output();
            Console.Out.Write(1);
            MessageBox.Show(s);
           // AnalyzeSocket.query();
        }
    }
}
