using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEGOCIO;



namespace DataShop
{
    
    public partial class LOGIN : Form
    {
        String hola;
        public LOGIN()
        {
            InitializeComponent();
        }

        private void ENTRAR_Click(object sender, EventArgs e)
        {
            login reg = new login();
           // String resu;
          //  VariablesGlobales.tipoUsuario = ;
            MenuPrincipal hijo = new MenuPrincipal();
          //  LOGIN sal = new LOGIN();
            String resu;
            resu = reg.obtenerpermiso(text_usuar.Text, text_contraseña.Text);
            //i= Convert.ToBoolean(resu);
            // int hola = Convert.ToInt16(text_usuar.Text);
            
            if (resu=="True" || resu == "False")
            {
             //i = true;

               resu= reg.obtenerpermiso(text_usuar.Text, text_contraseña.Text);
                
               
                VariablesGlobales.tipoUsuario = resu; ;
                //MessageBox.Show(hola);
                

               // VariablesGlobales.tipoUsuario = hola;

                MessageBox.Show("BIENVENIDO AL SISTEMA " + text_usuar.Text);
              
                hijo.Show();
                 
            //    hijo.Location = this.Location;
            //   this.Close();
                this.Hide();

                
                



            }
            else
            {
                MessageBox.Show("ERROR USTED NO EXISTE COMO USUARIO EN ESTE PROGRAMA");
            }
            ///


            ///
            
        }

        


        private void LOGIN_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
           
        }

        private void SALIR_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void text_contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
