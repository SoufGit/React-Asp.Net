using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var Client = new HttpClient())
            {
           
                HttpResponseMessage response = Client.GetAsync(
                "http://localhost:62463/api/authenticate/"+textBox1.Text+"/" + textBox2.Text).Result;

                string responsecontentString = response.Content.ReadAsStringAsync().Result;

               Class1 resultat = Newtonsoft.Json.JsonConvert.DeserializeObject<Class1>(responsecontentString);
                textBox3.Text = resultat.retour.ToString();
               IEnumerable<string> values=new List<string> ();
                bool op = response.Headers.TryGetValues("Authorization", out values);
                if (op)
                {
                    textBox4.Text = values.First();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Add("Authorization", textBox4.Text);
                HttpResponseMessage response = Client.GetAsync(
                "http://localhost:62463/api/confidentials/" + textBox1.Text + "/" ).Result;

                string responsecontentString = response.Content.ReadAsStringAsync().Result;

                Class1 resultat = Newtonsoft.Json.JsonConvert.DeserializeObject<Class1>(responsecontentString);
                textBox3.Text = resultat.retour.ToString();
                IEnumerable<string> values = new List<string>();
                bool op = response.Headers.TryGetValues("Authorization", out values);
                if (op)
                {
                    textBox4.Text = values.First();
                }
            }
        }
    }
}
