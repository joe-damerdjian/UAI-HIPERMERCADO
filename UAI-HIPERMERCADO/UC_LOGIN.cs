﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Seguridad;


namespace UAI_HIPERMERCADO
{
    public partial class UC_LOGIN : UserControl
    {
        public UC_LOGIN()
        {
            InitializeComponent();
            oBeUsuario = new BEUsuario();
            oBLLUsuario = new BLLUsuario();
        }
        BEUsuario oBeUsuario;
        BLLUsuario oBLLUsuario;
        private MDI oMDI;

        private void UC_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void btnAcceso_Click(object sender, EventArgs e)
        {
            try
            {


                BEUsuario BE_Login = new BEUsuario();
                BE_Login.Usuario = txt_Usuario.Text;
                BE_Login.Contrasenia = Encripta.Encriptar(txt_Contrsenia.Text);

                if (ValidarEntradaALFoSIM(txt_Usuario.Text) && ValidarEntradaALFoSIM(txt_Contrsenia.Text))
                {

                    if (oBLLUsuario.ListarObjeto(BE_Login))
                    {
                        if (oMDI == null)
                        {
                            oMDI = new MDI();
                            this.Hide();
                            oMDI.Show();
                        }
                        else
                        {
                            oMDI.Activate();
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Por favor ingrese un usuario y contraseña válidos", "Error de login");
                    }
                }

                else
                {
                    throw new ArgumentException("Caracteres no validos!!", "Error de login");
                }


            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (Exception ex)
            {

                { MessageBox.Show(ex.Message); }
            }
        }

        public static bool ValidarEntradaALFoSIM(string linea)
        {
            return Regex.IsMatch(linea, @"^[A-Za-z]+$|^[0-9]+$|^[A-Za-z0-9]+$");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txt_Usuario.Clear();
            txt_Contrsenia.Clear();
        }
    }
}