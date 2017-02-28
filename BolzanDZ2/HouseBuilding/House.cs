using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilding
{
    class House
    {
        public Basement basement;
        public Wall[] walls;
        public Roof roof;
        public Door door;
        public Window[] windows;
        public House()
        {
            basement = new Basement();
            walls = new Wall[4];
            for (int i = 0; i < 4; i++)
            {
                walls[i] = new Wall();
            }
            roof = new Roof();
            door = new Door();
            windows = new Window[4];
            for (int i = 0; i < 4; i++)
            {
                windows[i] = new Window();
            }
        }
        public bool wallsIsBuilt()
        {
            bool result = true;
            foreach (var item in walls)
            {
                if (!item.IsBuilt) result = false;
            }
            return result;
        }
        public bool windowsIsBuilt()
        {
            bool result = true;
            foreach (var item in windows)
            {
                if (!item.IsBuilt) result = false;
            }
            return result;
        }
        public string housePictrue = @"
                           (   )
                          (    )
                           (    )
                          (    )
                            )  )
                           (  (                  /\
                            (_)                 /  \  /\
                    ________[_]________      /\/    \/  \
           /\      /\        ______    \    /   /\/\  /\/\
          /  \    //_\       \    /\    \  /\/\/    \/    \
   /\    / /\/\  //___\       \__/  \    \/
  /  \  /\/    \//_____\       \ |[]|     \
 /\/\/\/       //_______\       \|__|      \
/      \      /XXXXXXXXXX\                  \
        \    /_I_II  I__I_\__________________\
               I_I|  I__I_____[]_|_[]_____I
               I_II  I__I_____[]_|_[]_____I
               I II__I  I     XXXXXXX     I
            ~~~~~'   '~~~~~~~~~~~~~~~~~~~~~~~~";
    }
}
