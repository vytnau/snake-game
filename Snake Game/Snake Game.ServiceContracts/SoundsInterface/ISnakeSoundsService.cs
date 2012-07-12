using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace Snake_Game.ServiceContracts
{
    public interface ISnakeSoundsService
    {
        void PlaySnakeHit();

        void PlayeSnakeEat();

    }
}
