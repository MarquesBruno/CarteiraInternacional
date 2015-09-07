﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CarteiraInternacional.Entidade;
using CarteiraInternacional.Repositorio;

namespace CarteiraInternacional
{
    public partial class CadastroClassif : PhoneApplicationPage
    {
        public Classificacao cla { get; set; }
        public CadastroClassif()
        {
            InitializeComponent();
        }

        private void btnClassif_Click(object sender, RoutedEventArgs e)
        {
            if (TxtClassif.Text == string.Empty)
            {
                MessageBox.Show(" A Classificação deve ser preenchida");
                return;
            }

            

            Classificacao classificacao = new Classificacao
            {
                nome = TxtClassif.Text
            };

            ClassificRepositorio.Create(classificacao);
            MessageBox.Show("Cadastrada com Sucesso.");

            
            NavigationService.GoBack();

           
        }
    }
}