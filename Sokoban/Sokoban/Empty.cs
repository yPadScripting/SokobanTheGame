using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace Sokoban {
    class Empty : Hokje {

        public Empty() {
            this.Source = new BitmapImage(new Uri("Images/vloer.png", UriKind.Relative));
        }
    }
}
