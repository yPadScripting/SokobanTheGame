using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace Sokoban {
    class Box : Hokje {

        public Box() {
            this.Source = new BitmapImage(new Uri("Images/krat.png", UriKind.Relative));
        }
    }
}
