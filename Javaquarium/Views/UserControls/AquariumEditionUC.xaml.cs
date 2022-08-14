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

namespace Javaquarium.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AquariumEditionUC.xaml
    /// </summary>
    public partial class AquariumEditionUC : UserControl
    {
        public AquariumEditionUC()
        {
            InitializeComponent();
        }

        // Permet d'ouvrir les combobox dès que la souris y entre.
        private void FishRaceCb_OnMouseEnter(object sender, MouseEventArgs e) => FishRaceCb.IsDropDownOpen = true;
        private void FishSexCb_OnMouseEnter(object sender, MouseEventArgs e) => FishSexCb.IsDropDownOpen = true;

        // Permet de fermer les combobox dès que la souris en sort.
        private void FishRaceCb_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e) => FishRaceCb.IsDropDownOpen = false;
        private void FishSexCb_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e) => FishSexCb.IsDropDownOpen = false;
    }
}
