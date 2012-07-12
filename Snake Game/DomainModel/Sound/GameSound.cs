using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace DomainModel.Sound
{
    public class GameSound
    {
        public SoundEffect BirdsSound { set; get; }
        public SoundEffect Wind { set; get; }
        public SoundEffect OwlSound { set; get; }
        public SoundEffect Music { set; get; }
    }
}
