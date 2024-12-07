using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backprop;

namespace BPNN
{
    public partial class Form1 : Form
    {
        NeuralNet neural_net;
        //int curr_epoch;
        //int[,] inputs;

        public Form1()
        {
            InitializeComponent();
            //inputs = new int[8, 4];

        }

        //input button
        private void button1_Click(object sender, EventArgs e)
        {
            neural_net = new NeuralNet(2,1000, 1);
        }

        //train dataset
        //if 1000 -> 1 1 = 0.999
        //and 0 0 = 0.000001

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0; i<1000; i++){
                //0 to 0 = 0
                neural_net.setInputs(0, 0.0);
                neural_net.setInputs(1,0.0);
                neural_net.setDesiredOutput(0, 0.0);
                neural_net.learn();

                //0 to 1 = 1
                neural_net.setInputs(0, 0.0);
                neural_net.setInputs(1, 1.0);
                neural_net.setDesiredOutput(0, 1.0);
                neural_net.learn();

                //1 to 0 = 1
                neural_net.setInputs(0, 1.0);
                neural_net.setInputs(1, 0.0);
                neural_net.setDesiredOutput(0, 1.0);
                neural_net.learn();

                //1 to 1 = 1
                neural_net.setInputs(0, 1.0);
                neural_net.setInputs(1, 1.0);
                neural_net.setDesiredOutput(0, 1.0);
                neural_net.learn();
            }
        }

        //test button
        private void button3_Click(object sender, EventArgs e)
        {
            neural_net.setInputs(0, Convert.ToDouble(textBox1.Text));
            neural_net.setInputs(1, Convert.ToDouble(textBox2.Text));
            neural_net.run();
            textBox3.Text = "" + neural_net.getOuputData(0);
        }
    }
}
