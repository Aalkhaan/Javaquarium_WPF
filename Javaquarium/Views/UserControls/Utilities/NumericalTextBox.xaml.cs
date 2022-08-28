using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Javaquarium.Views.UserControls.Utilities
{
    public partial class NumericalTextBox : UserControl
    {
        public static readonly DependencyProperty NumValueProperty = DependencyProperty.Register(nameof(NumValue),
                                                                                                 typeof(double),
                                                                                                 typeof(UserControl),
                                                                                                 new(0d));
        public static readonly DependencyProperty IntegersOnlyProperty = DependencyProperty.Register(nameof(IntegersOnly),
                                                                                                     typeof(bool),
                                                                                                     typeof(UserControl),
                                                                                                     new(false));
        public static readonly DependencyProperty IncrementProperty = DependencyProperty.Register(nameof(Increment),
                                                                                                  typeof(double),
                                                                                                  typeof(UserControl),
                                                                                                  new(1d));
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(nameof(Maximum),
                                                                                                typeof(double),
                                                                                                typeof(UserControl),
                                                                                                new(double.MaxValue));
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(nameof(Minimum),
                                                                                                typeof(double),
                                                                                                typeof(UserControl),
                                                                                                new(double.MinValue));

        public double NumValue
        {
            get => _numValue;
            set
            {
                if (Minimum > Maximum)
                    _numValue = 0;
                else if (value < Minimum)
                    _numValue = Minimum;
                else if (value > Maximum)
                    _numValue = Maximum;
                else
                    _numValue = value;

                txtBox.Text = NumValue.ToString(CultureInfo.InvariantCulture);
            }
        }
        private double _numValue;
        public double Increment
        {
            get => (double)GetValue(IncrementProperty);
            set
            {
                SetValue(IncrementProperty, value);
                if (IntegersOnly)
                    IntIncrement = (int)Math.Round(Increment);
            }
        }
        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }
        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public bool IntegersOnly
        {
            get => (bool)GetValue(IntegersOnlyProperty);
            set => SetValue(IntegersOnlyProperty, value);
        }
        private int IntNumValue
        {
            get => _intNumValue;
            set
            {
                if (Minimum > Maximum)
                    _intNumValue = 0;
                else if (value < Minimum)
                    _intNumValue = (int)Math.Ceiling(Minimum);
                else if (value > Maximum)
                    _intNumValue = (int)Math.Floor(Maximum);
                else
                    _intNumValue = value;

                txtBox.Text = IntNumValue.ToString(CultureInfo.InvariantCulture);
            }
        }
        private int _intNumValue;
        private int IntIncrement { get; set; }

        public NumericalTextBox()
        {
            InitializeComponent();

            if (IntegersOnly)
                txtBox.Text = _intNumValue.ToString(CultureInfo.InvariantCulture);
            else
                txtBox.Text = _numValue.ToString(CultureInfo.InvariantCulture);

            IntIncrement = (int)Math.Round(Increment);
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (IntegersOnly)
                IntNumValue += IntIncrement;
            else
                NumValue += Increment;
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (IntegersOnly)
                IntNumValue -= IntIncrement;
            else
                NumValue -= Increment;
        }

        private void Num_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBox == null)
                return;

            if (IntegersOnly)
            {
                if (!int.TryParse(txtBox.Text, out _intNumValue))
                    txtBox.Text = _intNumValue.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                if (!double.TryParse(txtBox.Text, out _numValue))
                    txtBox.Text = _numValue.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
