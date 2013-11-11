using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake_Game.ServiceContracts;
using DomainModel.Sound;
using Microsoft.Xna.Framework.Audio;

namespace Snake_Game.Service
{
    class SnakeSoundsService : ISnakeSoundsService
    {
        private SnakeSound sound;

        public SnakeSoundsService(SnakeSound sounds)
        {
            sound = sounds;
        }

        public void PlaySnakeHit()
        {
            if (sound.Hit != null)
            {
                SoundEffectInstance soundEngineInstance = sound.Hit.CreateInstance();
                soundEngineInstance.Volume = 0.75f;
                soundEngineInstance.Play();
            }
        }

        public void PlayeSnakeEat()
        {
            if (sound.Eat != null)
            {
                SoundEffectInstance soundEngineInstance = sound.Eat.CreateInstance();
                soundEngineInstance.Volume = 0.75f;
                soundEngineInstance.Play();
            }
        }
    }
}
