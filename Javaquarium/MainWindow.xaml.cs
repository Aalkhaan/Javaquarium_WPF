﻿using Javaquarium.Models;
using Javaquarium.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Javaquarium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowVM MainWindowVM { get; init; }

        public MainWindow()
        {
            InitializeComponent();

            Aquarium aquarium = new();
            MainWindowVM = new MainWindowVM(aquarium);

            DataContext = MainWindowVM;
        }
    }
}
