﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Renci.Wwt.DataManager.Common.Framework;
using Renci.Wwt.DataManager.Common.ViewModels;

namespace Renci.Wwt.DataManager.NetCDF.Views
{
    /// <summary>
    /// Interaction logic for TextWorkspaceView.xaml
    /// </summary>
    public partial class TextWorkspaceView : UserControl
    {
        public TextWorkspaceView(DataSourceInfoViewModel viewModel)
        {
            InitializeComponent();

            ViewModelBinder.Bind(viewModel, this);
        }

    }
}
