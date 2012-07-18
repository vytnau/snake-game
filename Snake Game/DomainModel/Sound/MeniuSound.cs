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
        SoundEffectInstance music;
        SoundEffectInstance keyInstance;
        public SoundEffect SoundArrowCrackle { set; get; }
        public SoundEffect MeniuMusic { set; get; }
        public SoundEffect KeyPressed { set; get; }
        private bool play = true;
        public void PlayMeniuMusic()
        {
            if (play)
            {
                music = MeniuMusic.CreateInstance();
                music.Volume = 0.50f;
                music.IsLooped = true;
                music.Play();
                play = false;
            }
        }
        
        public void Play()
        {
            soundEngineInstance = SoundArrowCrackle.CreateInstance();
            soundEngineInstance.Volume = 0.75f;
            //soundEngineInstance.IsLooped = true;
            soundEngineInstance.Play();
        }

        public void StopMusic()
        {
            music.Dispose();
            play = true;
        }

        public void KeyPress()
        {
            keyInstance = KeyPressed.CreateInstance();
            keyInstance.Volume = 0.75f;
            keyInstance.Play();
        }

        
    }
}
