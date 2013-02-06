using System;
using System.IO;
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

namespace Sokoban {
    public class Bord {

        private Hokje[,] bord;

        public Hokje[,] Bord1 {
            get { return bord; }
            set { bord = value; }
        }

        private char[,] bordje;
        private int rows;

        public int Rows {
            get { return rows; }
            set { rows = value; }
        }
        private int cols;

        public int Cols {
            get { return cols; }
            set { cols = value; }
        }

        public Bord() {
           /*
            try {
                using (StreamReader sr = new StreamReader("Maps/doolhof1.txt")) {
                   rows = 0;
                    List<String> regels = new List<String>();
                   while (sr.ReadLine() != null) {
                       rows++;
                    }

                  sr.BaseStream.Position = 0;
                  sr.DiscardBufferedData();

                  cols = sr.ReadLine().ToCharArray().Length;

                  sr.BaseStream.Position = 0;
                  sr.DiscardBufferedData();


                  bordje = new char[rows, cols];
                  bord = new Hokje[rows, cols];

                  int rownumber = 0;
                  while (!sr.EndOfStream && rownumber < rows) {
                      String currentLine = sr.ReadLine();
                      char[] characters = currentLine.ToCharArray();

                      for (int i = 0; i < cols; i++) {
                          bordje[rownumber, i] = characters[i];
                      }
                      rownumber++;
                  }                    
                }
            }
            catch (Exception e) {
                MessageBox.Show("File could not be read");
                MessageBox.Show(e.Message);
            }

            for (int j = 0; j < rows; j++) {
                for (int i = 0; i < cols; i++) {
                    switch (bordje[j, i]) {
                        case '#':
                            bord[j, i] = new Wall();
                            break;
                        case 'o':
                            bord[j, i] = new Box();
                            break;
                        case 'x':
                            bord[j, i] = new Destination();
                            break;
                        case ' ':
                            bord[j, i] = new Empty();
                            break;
                        case '@':
                            bord[j, i] = new Player();
                            break;
                    }
                    Console.Write(bordje[j, i]);
                }
                Console.Write("\n");
            }*/
        }

        public void fillBord(String filepath) {

            try {
                using (StreamReader sr = new StreamReader(filepath)) {
                    rows = 0;
                    cols = 0;
                    List<String> regels = new List<String>();
                    while (sr.ReadLine() != null) {
                        rows++;
                    }

                    sr.BaseStream.Position = 0;
                    sr.DiscardBufferedData();

                    cols = sr.ReadLine().ToCharArray().Length;

                    sr.BaseStream.Position = 0;
                    sr.DiscardBufferedData();


                    bordje = new char[rows, cols];
                    bord = new Hokje[rows, cols];

                   int rownumber = 0;
                    while (!sr.EndOfStream && rownumber < rows) {
                        String currentLine = sr.ReadLine();
                        char[] characters = currentLine.ToCharArray();

                        for (int i = 0; i < cols; i++) {
                            bordje[rownumber, i] = characters[i];
                        }
                        rownumber++;
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show("File could not be read");
                MessageBox.Show(e.Message);
            }

            for (int j = 0; j < rows; j++) {
                for (int i = 0; i < cols; i++) {
                    switch (bordje[j, i]) {
                        case '#':
                            bord[j, i] = new Wall();
                            break;
                        case 'o':
                            bord[j, i] = new Box();
                            break;
                        case 'x':
                            bord[j, i] = new Destination();
                            break;
                        case ' ':
                            bord[j, i] = new Empty();
                            break;
                        case '@':
                            bord[j, i] = new Player();
                            break;
                    }
                    Console.Write(bordje[j, i]);
                }
                Console.Write("\n");
            }
        }

        public void clearBord() {

        }
    }
}
