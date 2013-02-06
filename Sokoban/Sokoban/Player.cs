using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace Sokoban {
    class Player : Hokje {

        public Player() {
            this.Source = new BitmapImage(new Uri("Images/heftruck.png", UriKind.Relative));
        }
    }
}
