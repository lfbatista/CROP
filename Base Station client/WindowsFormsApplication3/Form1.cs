using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }
        
        CropWS.WebServiceSoapClient servico = new CropWS.WebServiceSoapClient();
        string dados1 = "";
        string dados2 = "";
        string[] partes1;
        string[] partes2;
        string porta_inicial1 = "COM3";
        string porta_inicial2 = "COM8";
        int baud1, baud2;
        int tbArduino = 0;

        static SerialPort porta1, porta2;

        private void Form1_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
            string[] portas = SerialPort.GetPortNames();

            for (int i = 0; i < portas.Length; i++) {
                comboBox1.Items.Add(portas[i]);
                comboBox4.Items.Add(portas[i]);
            }

            comboBox5.DataSource = servico.LerComentarios("BDA_PFERNANDES_user_tec", "BDA_1011931");
            comboBox5.ValueMember = "COMENTARIO";
            comboBox5.DisplayMember = "COMENTARIO";

            comboBox6.DataSource = servico.LerComentarios("BDA_PFERNANDES_user_tec", "BDA_1011931");
            comboBox6.ValueMember = "COMENTARIO";
            comboBox6.DisplayMember = "COMENTARIO";

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;

        }
        
        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {

            label12.Text = "Porta " + comboBox1.SelectedItem.ToString() + ":";
            porta_inicial1 = comboBox1.Text;
            baud1 = Convert.ToInt32(comboBox2.Text);
            textBox1.Text = "";

            try {
                porta1.Open();
                if (!porta1.IsOpen) {
                    porta1 = new SerialPort(porta_inicial1, baud1);
                    porta1.ReadTimeout = 5000;
                    porta1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler1);
                } else {
                    porta1.Close();
                    porta1 = new SerialPort(porta_inicial1, baud1);
                    porta1.ReadTimeout = 5000;
                    porta1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler1);
                }
            } catch {
                porta1 = new SerialPort(porta_inicial1, baud1);
                porta1.ReadTimeout = 5000;
                porta1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler1);
            }

            porta1.Open();

            porta1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler1);
            //MessageBox.Show(" Porta 1 Aberta", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e) {
            try {
                porta1.Close();
                MessageBox.Show(" Porta Fechada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch {
                MessageBox.Show(" A Porta indicada já se Encontra Fechada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button5_Click(object sender, EventArgs e) {

            label10.Text = "Porta " + comboBox4.SelectedItem.ToString() + ":";
            porta_inicial2 = comboBox4.Text;
            baud2 = Convert.ToInt32(comboBox3.Text);
            textBox10.Text = "";

            try {
                porta2.Open();
                if (!porta2.IsOpen) {
                    porta2 = new SerialPort(porta_inicial2, baud2);
                    porta2.ReadTimeout = 5000;
                    porta2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler2);
                } else {
                    porta2.Close();
                    porta2 = new SerialPort(porta_inicial2, baud2);
                    porta2.ReadTimeout = 5000;
                    porta2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler2);
                }
            } catch {
                porta2 = new SerialPort(porta_inicial2, baud2);
                porta2.ReadTimeout = 5000;
                porta2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler2);
            }

            porta2.Open();
            porta2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler2);
            //MessageBox.Show(" Porta Aberta", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e) {
            try {
                porta2.Close();
                MessageBox.Show(" Porta Fechada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch {
                MessageBox.Show(" A Porta indicada já se Encontra Fechada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DataReceivedHandler1(object sender, SerialDataReceivedEventArgs e) {

            if (porta1.BytesToRead >= 0) {
                dados1 = porta1.ReadExisting ();

                textBox1.Text += dados1;
                string txt1 = textBox1.Text;

                int pos1 = txt1.IndexOf('$');

                if (pos1 > -1) {
                    string txt2 = txt1.Substring(pos1 + 1);
                    int pos2 = txt2.IndexOf('$');

                    if (pos2 > -1) {
                        //pacote arduino completo fazer o split
                        tbArduino += 1;
                        if (tbArduino == 50) {
                            textBox10.Text = "";
                            tbArduino = 0;
                        }

                        string txt3 = txt2.Remove(pos2, txt2.Length - pos2);
                        textBox10.Text += "$" + txt3 + "$";
                        textBox12.Text = txt3;
                        textBox1.Text = textBox1.Text.Remove(pos1, pos2 + 2);

                        float humid = Convert.ToSingle(txt3.Replace("$", ""));
                        string comentario = "NULL";
                        if (checkBox9.Checked) comentario = comboBox6.Text;

                        if (checkBox10.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "1", humid / 1023 * 100, 235000001, comentario);
                    }
                }

                pos1 = txt1.IndexOf('*');

                if (pos1 > -1) {
                    string txt2 = txt1.Substring(pos1 + 1);
                    int pos2 = txt2.IndexOf('*');

                    if (pos2 > -1) {
                        //pacote waspmote completo fazer o split
                        string txt3 = txt2.Remove(pos2, txt2.Length - pos2);
                        textBox2.Text = "*" + txt3 + "*";
                        textBox1.Text = textBox1.Text.Remove(pos1, pos2 + 2);

                        partes1 = txt3.Split('#');
                        textBox3.Text = partes1[1];
                        textBox4.Text = partes1[3];
                        textBox5.Text = partes1[4];
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = partes1[5];
                        textBox9.Text = "";
                        
                        float temp = Convert.ToSingle(partes1[4].Replace(".", ","));
                        float batt = Convert.ToSingle(partes1[5].Replace(".", ","));
                        int sensor_id = Convert.ToInt32(partes1[1]);
                        string comentario = "NULL";
                        if (checkBox8.Checked) comentario = comboBox5.Text;

                        if (checkBox3.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "17", temp, sensor_id, comentario);
                        if (checkBox6.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "19", batt, sensor_id, comentario);
                    }
                }
                
                pos1 = txt1.IndexOf('>');

                if (pos1 > -1) {
                    string txt2 = txt1.Substring(pos1 + 1);
                    int pos2 = txt2.IndexOf('<');

                    if (pos2 > -1) {
                        //pacote completo fazer o slite
                        string txt3 = txt2.Remove(pos2, txt2.Length - pos2);
                        textBox2.Text = txt3;

                        partes1 = txt3.Split('#');
                        textBox1.Text = textBox1.Text.Substring(pos2 + pos1 + 1);

                        textBox3.Text = partes1[1];
                        textBox4.Text = partes1[3];
                        textBox5.Text = partes1[4].Substring(4);
                        textBox6.Text = partes1[5];
                        textBox7.Text = partes1[6];
                        textBox8.Text = partes1[7].Substring(4);
                        textBox9.Text = partes1[8].Substring(4);

                        float temp = Convert.ToSingle(partes1[4].Substring(4).Replace(".", ","));
                        float batt = Convert.ToSingle(partes1[7].Substring(4).Replace(".", ","));
                        float humid = Convert.ToSingle(partes1[8].Substring(4).Replace(".", ","));
                        int sensor_id = Convert.ToInt32(partes1[1]);
                        string comentario = "NULL";
                        if (checkBox8.Checked) comentario=comboBox5.Text;

                        if (checkBox3.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "17", temp, sensor_id, comentario);
                        if (checkBox6.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "19", batt, sensor_id, comentario);
                        if (checkBox7.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "1", humid, sensor_id, comentario);
                    }
                }
            }
        }


        private void DataReceivedHandler2(object sender, SerialDataReceivedEventArgs e) {

            if (porta2.BytesToRead >= 0){
                dados2 = porta2.ReadExisting();

                textBox11.Text += dados2;
                string txt1 = textBox11.Text;

                int pos1 = txt1.IndexOf('$');

                if (pos1 > -1) {
                    string txt2 = txt1.Substring(pos1 + 1);
                    int pos2 = txt2.IndexOf('$');

                    if (pos2 > -1) {
                        //pacote arduino completo fazer o split
                        tbArduino += 1;
                        if (tbArduino == 50) {
                            textBox10.Text = "";
                            tbArduino = 0;
                        }

                        string txt3 = txt2.Remove(pos2, txt2.Length - pos2);
                        textBox10.Text += "$" + txt3 + "$";
                        textBox12.Text = txt3;
                        textBox11.Text = textBox11.Text.Remove(pos1, pos2 + 2);

                        float humid = Convert.ToSingle(txt3.Replace("$", ""));
                        string comentario = "NULL";
                        if (checkBox9.Checked) comentario = comboBox6.Text;

                        if (checkBox10.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "1", humid / 1023 * 100, 235000001, comentario);
                    }
                }

                pos1 = txt1.IndexOf('*');

                if (pos1 > -1) {
                    string txt2 = txt1.Substring(pos1 + 1);
                    int pos2 = txt2.IndexOf('*');

                    if (pos2 > -1) {
                        //pacote waspmote completo fazer o split
                        string txt3 = txt2.Remove(pos2, txt2.Length - pos2);
                        textBox2.Text = "*" + txt3 + "*";
                        textBox11.Text = textBox11.Text.Remove(pos1, pos2 + 2);

                        partes2 = txt3.Split('#');
                        textBox3.Text = partes2[1];
                        textBox4.Text = partes2[3];
                        textBox5.Text = partes2[4];
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = partes2[5];
                        textBox9.Text = "";

                        float temp = Convert.ToSingle(partes2[4].Replace(".", ","));
                        float batt = Convert.ToSingle(partes2[5].Replace(".", ","));
                        int sensor_id = Convert.ToInt32(partes2[1]);
                        string comentario = "NULL";
                        if (checkBox8.Checked) comentario = comboBox5.Text;

                        if (checkBox3.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "17", temp, sensor_id, comentario);
                        if (checkBox6.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "19", batt, sensor_id, comentario);
                    }
                }
                
                pos1 = txt1.IndexOf('>');

                if (pos1 > 0) {
                    string txt2 = txt1.Substring(pos1 + 1);
                    int pos2 = txt2.IndexOf('<');

                    if (pos2 > 0) {
                        //pacote completo fazer o slite
                        string txt3 = txt2.Remove(pos2, txt2.Length - pos2);
                        textBox2.Text = txt3;
                        textBox11.Text = textBox11.Text.Substring(pos2 + pos1 + 1);

                        partes2 = txt3.Split('#');
                        textBox3.Text = partes2[1];
                        textBox4.Text = partes2[3];
                        textBox5.Text = partes2[4].Substring(4);
                        textBox6.Text = partes2[5];
                        textBox7.Text = partes2[6];
                        textBox8.Text = partes2[7].Substring(4);
                        textBox9.Text = partes2[8].Substring(4);

                        float temp = Convert.ToSingle(partes2[4].Substring(4).Replace(".", ","));
                        float batt = Convert.ToSingle(partes2[7].Substring(4).Replace(".", ","));
                        float humid = Convert.ToSingle(partes2[8].Substring(4).Replace(".", ","));
                        int sensor_id = Convert.ToInt32(partes2[1]);
                        string comentario = "NULL";
                        if (checkBox8.Checked) comentario = comboBox5.Text;

                        if (checkBox3.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "17", temp, sensor_id, comentario);
                        if (checkBox6.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "19", batt, sensor_id, comentario);
                        if (checkBox7.Checked) servico.RegistarLeituraWSNMobile("BDA_PFERNANDES_user_tec", "BDA_1011931", "1", humid, sensor_id, comentario);
                    }
                }
            }
        }
    }
}
    
