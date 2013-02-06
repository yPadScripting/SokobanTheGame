using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace Sokoban {
    class Destination : Hokje {

        public Destination() {
            this.Source = new BitmapImage(new Uri("Images/bestemming.png", UriKind.Relative));
        }

    }
}
