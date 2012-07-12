using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace DomainModel.Sound
{
    public class SnakeSound
    {
        public SoundEffect Eat { set; get; }
        public SoundEffect Hit { set; get; }
    }
}
