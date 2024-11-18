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
using System.Windows.Threading;

namespace mastermindPE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        SolidColorBrush[] colorCode = { Brushes.Red, Brushes.Green, Brushes.White, Brushes.Yellow, Brushes.Blue, Brushes.Orange };
        string[] colorName = { "Red", "Green", "White", "Yellow", "Blue", "Orange" };
        int[] randomColors = new int[4];
        DispatcherTimer timer = new DispatcherTimer();
        TimeSpan elapsedTime;
        DateTime startTime;
        public MainWindow()
        {
            InitializeComponent();
            RandomColorCode();
            ComboBoxItems();
            StartCountDown();
        }
        private void RandomColorCode()
        {
            for (int i = 0; i < randomColors.Length; i++)
            {
                int index = random.Next(colorCode.Length);
                randomColors[i] = random.Next(1, 6);
            }
                      
        }
        private void ComboBoxItems()
        {
            firstColorCombo.ItemsSource = colorName;
            secondColorCombo.ItemsSource = colorName;
            thirdColorCombo.ItemsSource = colorName;
            fourthColorCombo.ItemsSource = colorName;
        }
        private void FirstComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as System.Windows.Controls.ComboBox;

            string selectedColor = comboBox.SelectedItem.ToString();

            switch (selectedColor)
            {
                case "Red":
                    firstCodeLabel.Background = Brushes.Red;
                    break;
                case "Green":
                    firstCodeLabel.Background = Brushes.Green;
                    break;
                case "White":
                    firstCodeLabel.Background = Brushes.White;
                    break;
                case "Yellow":
                    firstCodeLabel.Background = Brushes.Yellow;
                    break;
                case "Blue":
                    firstCodeLabel.Background = Brushes.Blue;
                    break;
                case "Orange":
                    firstCodeLabel.Background = Brushes.Orange;
                    break;
                default:
                    firstCodeLabel.Background = Brushes.Gray;
                    break;
            }
        }
        private void SecondComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as System.Windows.Controls.ComboBox;

            string selectedColor = comboBox.SelectedItem.ToString();

            switch (selectedColor)
            {
                case "Red":
                    secondCodeLabel.Background = Brushes.Red;
                    break;
                case "Green":
                    secondCodeLabel.Background = Brushes.Green;
                    break;
                case "White":
                    secondCodeLabel.Background = Brushes.White;
                    break;
                case "Yellow":
                    secondCodeLabel.Background = Brushes.Yellow;
                    break;
                case "Blue":
                    secondCodeLabel.Background = Brushes.Blue;
                    break;
                case "Orange":
                    secondCodeLabel.Background = Brushes.Orange;
                    break;
                default:
                    secondCodeLabel.Background = Brushes.Gray;
                    break;
            }
        }
        private void ThirdComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as System.Windows.Controls.ComboBox;
            string selectedColor = comboBox.SelectedItem.ToString();

            switch (selectedColor)
            {
                case "Red":
                    thirdCodeLabel.Background = Brushes.Red;
                    break;
                case "Green":
                    thirdCodeLabel.Background = Brushes.Green;
                    break;
                case "White":
                    thirdCodeLabel.Background = Brushes.White;
                    break;
                case "Yellow":
                    thirdCodeLabel.Background = Brushes.Yellow;
                    break;
                case "Blue":
                    thirdCodeLabel.Background = Brushes.Blue;
                    break;
                case "Orange":
                    thirdCodeLabel.Background = Brushes.Orange;
                    break;
                default:
                    thirdCodeLabel.Background = Brushes.Gray;
                    break;
            }
        }
        private void FourthComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as System.Windows.Controls.ComboBox;

            string selectedColor = comboBox.SelectedItem.ToString();

            switch (selectedColor)
            {
                case "Red":
                    fourthCodeLabel.Background = Brushes.Red;
                    break;
                case "Green":
                    fourthCodeLabel.Background = Brushes.Green;
                    break;
                case "White":
                    fourthCodeLabel.Background = Brushes.White;
                    break;
                case "Yellow":
                    fourthCodeLabel.Background = Brushes.Yellow;
                    break;
                case "Blue":
                    fourthCodeLabel.Background = Brushes.Blue;
                    break;
                case "Orange":
                    fourthCodeLabel.Background = Brushes.Orange;
                    break;
                default:
                    fourthCodeLabel.Background = Brushes.Gray;
                    break;
            }
        }
        private void CheckCodeButton_Click(object sender, RoutedEventArgs e)
        {
            CheckCode();
            StartCountDown();  
        }

        private void CheckCode()
        {
            var userSelection = new string[4];
            userSelection[0] = firstColorCombo.SelectedItem?.ToString();
            userSelection[1] = secondColorCombo.SelectedItem?.ToString();
            userSelection[2] = thirdColorCombo.SelectedItem?.ToString();
            userSelection[3] = fourthColorCombo.SelectedItem?.ToString();

            UpdateLabelFeedback(firstCodeLabel, userSelection[0], randomColors[0], 0);
            UpdateLabelFeedback(secondCodeLabel, userSelection[1], randomColors[1], 1);
            UpdateLabelFeedback(thirdCodeLabel, userSelection[2], randomColors[2], 2);
            UpdateLabelFeedback(fourthCodeLabel, userSelection[3], randomColors[3], 3);

            int attempts = 1;

            if (CheckCode != RandomColorCode)
            {
                this.Title = $"Poging {attempts.ToString()}";
                attempts++;
            }

        }

        private void UpdateLabelFeedback(Label label, string userColor, int correctColorIndex, int position)
        {
            if (userColor == colorName[correctColorIndex])
            {
                label.BorderBrush = Brushes.DarkRed;
            }
            else if (colorName.Contains(userColor) && randomColors.Contains(Array.IndexOf(colorName, userColor)))
            {
                label.BorderBrush = Brushes.Wheat;
            }
            else
            {
                label.BorderBrush = Brushes.Gray;
            }
        }

        private void ToggleDebug(object sender, KeyEventArgs e)
        {            
            if (e.Key == Key.F12 )
            {
                debugInfotextBox.Text = $"{colorName[randomColors[0]].ToString()}, {colorName[randomColors[1]].ToString()}, {colorName[randomColors[2]].ToString()}, {colorName[randomColors[3]].ToString()}";
                
            }
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - startTime;
            timerTextBox.Text = elapsedTime.ToString(@"ss\:fff");
        }
        private void StartCountDown()
        {
            startTime = DateTime.Now;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
                        
        }
        
    }
}