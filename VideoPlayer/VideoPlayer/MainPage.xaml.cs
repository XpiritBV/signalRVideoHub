﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VideoPlayer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            Constants.signalrHub
        }

        private void Button_Clicked_Windows(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_Web(object sender, EventArgs e)
        {

        }
    }
}
