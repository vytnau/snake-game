using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace DomainModel.Sound
{
    public class MeniuSound
    {
        SoundEffectInstance soundEngineInstance;
        public SoundEffect SoundArrowCrackle { set; get; }
        public void Creat()
        {
            soundEngineInstance = SoundArrowCrackle.CreateInstance();
        }

        public void Play()
        {
            soundEngineInstance.Volume = 0.75f;
            //soundEngineInstance.IsLooped = true;
            soundEngineInstance.Play();
        }

        
    }
}
