using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace Sokoban {
    class Wall : Hokje {

        public Wall() {
            this.Source = new BitmapImage(new Uri("Images/muur.png", UriKind.Relative));
        }
    }
}
