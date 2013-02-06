using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
//using System.Windows.Forms.OpenFileDialog;

namespace Sokoban {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private Bord bord;
        private System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow() {
            InitializeComponent();

            bord = new Bord();

            /*
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "doc";
            // The Filter property requires a search string after the pipe ( | )
            openFile.Filter = "Word documents (*.doc)|*.doc";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0) {
                foreach (string filename in openFile.FileNames) {
                    // Insert code here to process the files.
                }
            }*/
            /*

            int rows = 7;
            int cols = 7;
            int cellSize = 40;

            for (int i = 0; i < cols; i++) {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(cellSize);
                VakjesView.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < rows; i++) {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(cellSize);
                VakjesView.RowDefinitions.Add(row);
            }

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    Hokje hokje = new Hokje();
                    if (i == 0 || j == 0 || i == rows - 1 || j == cols - 1) {
                        hokje.Source = new BitmapImage(new Uri("Images/muur.png", UriKind.Relative));
                    }
                    else {
                        hokje.Source = new BitmapImage(new Uri("Images/vloer.png", UriKind.Relative));
                    }

                    hokje.SetValue(Grid.ColumnProperty, i);
                    hokje.SetValue(Grid.RowProperty, j);
                    VakjesView.Children.Add(hokje);
                }
            }*/


        }

        public void showMap(int rowCount, int colCount, Hokje[,] map) {

            int rows = rowCount;
            int cols = colCount;
            int cellSize = 40;

            for (int i = 0; i < cols; i++) {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(cellSize);
                VakjesView.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < rows; i++) {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(cellSize);
                VakjesView.RowDefinitions.Add(row);
            }

            for (int i = 0; i < cols; i++) {
                for (int j = 0; j < rows; j++) {
                    map[j, i].SetValue(Grid.ColumnProperty, i);
                    map[j, i].SetValue(Grid.RowProperty, j);

                    //hokje.SetValue(Grid.ColumnProperty, i);
                    //hokje.SetValue(Grid.RowProperty, j);
                    VakjesView.Children.Add(map[j, i]);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            VakjesView.Children.Clear();
            bord.fillBord("Maps/doolhof1.txt");
            showMap(bord.Rows, bord.Cols, bord.Bord1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            VakjesView.Children.Clear();
            bord.fillBord("Maps/doolhof2.txt");
            showMap(bord.Rows, bord.Cols, bord.Bord1);
        }

        private void MenuItem_Open(object sender, RoutedEventArgs e) {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "this";
            openFileDialog.Filter = "Map File (*.map)|*.map";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
             bool? userClickedOK = openFileDialog.ShowDialog();
            if (userClickedOK == true) {
                try {
                    if ((myStream = openFileDialog.OpenFile()) != null) {
                        using (myStream) {
                            VakjesView.Children.Clear();
                            bord.fillBord(openFileDialog.FileName.ToString());
                            showMap(bord.Rows, bord.Cols, bord.Bord1);
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void MenuItem_Quit(object sender, RoutedEventArgs e) {
            System.Environment.Exit(0);
        }

        public void StartTimer(object o, RoutedEventArgs sender) {            
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 100 Milliseconds 
            myDispatcherTimer.Tick += new EventHandler(Each_Tick);
            myDispatcherTimer.Start();
        }

        // A variable to count with.
        int seconde = 0;
        int minuten = 0;

        // Raised every 1000 miliseconds while the DispatcherTimer is active.
        public void Each_Tick(object o, EventArgs sender) {
            seconde++;
            if (seconde == 60) {
                seconde = 0;
                minuten++;
            }

            myTextBlock.Text = "Tijd: " + minuten.ToString() + ":" + seconde.ToString();
        }
    }
}

