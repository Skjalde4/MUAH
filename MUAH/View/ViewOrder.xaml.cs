﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MUAH.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUAH.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewOrder : Page
    {
        List<CustomerSession> Sessions = new List<CustomerSession>();

        public ViewOrder()
        {
            this.InitializeComponent();
        }

        private double totalPrice;

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            int i = 0;

            foreach (var items in MenuPage.session)
            {
                Sessions.Add(items);
                Sessions[i].TotalPrice = items.NoOfProduct * items.ProductPrice;
                totalPrice += Sessions[i].TotalPrice;
                i++;
            }

            txtTotalPrice.Text = totalPrice.ToString();
        }
    }
}
