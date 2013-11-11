using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake_Game.ServiceContracts.SoundsInterface;
using DomainModel.Sound;
using Microsoft.Xna.Framework.Audio;

namespace Snake_Game.Service.SoundsService
{
    public class GameBackgroundSoundsService : IGameBackgroundSoundsService
    {
        GameSound sounds;
        SoundEffectInstance soundEngineInstance;
        SoundEffectInstance music;
        SoundEffectInstance soundsEffect;
        int time = 0;
        const int PAUSE_TIME = 105;

        public GameBackgroundSoundsService(GameSound sounds){
            this.sounds = sounds; 
        }

        public void PlayBirdsSound()
        {
            if (sounds.BirdsSound != null)
            {
                soundEngineInstance = sounds.BirdsSound.CreateInstance();
                soundEngineInstance.Volume = 0.50f;
                soundEngineInstance.IsLooped = true;
                soundEngineInstance.Play();
            }
        }

        public void StartMusic()
        {
        }

        public void StopPlaySounds()
        {
            if(soundEngineInstance != null)
                soundEngineInstance.Dispose();
            if(music != null)
                music.Dispose();
            if (soundsEffect != null)
                soundsEffect.Dispose();
        }


        public void PlayMusic()
        {
            if (sounds.Music != null)
            {
                music = sounds.Music.CreateInstance();
                music.Volume = 0.65f;
                music.IsLooped = true;
                music.Play();
            }
        }

        public void SurvivalMusic()
        {
            if (sounds.BirdsSound != null && sounds.LongSnakeMusic != null)
            {
            
            soundEngineInstance = sounds.BirdsSound.CreateInstance();
            soundEngineInstance.Volume = 0.50f;
            soundEngineInstance.IsLooped = true;
            soundEngineInstance.Play();

            music = sounds.LongSnakeMusic.CreateInstance();
            music.Volume = 0.65f;
            music.IsLooped = true;
            music.Play();
        }
    }


        public void NightSound()
        {
            if (sounds.NightMusic != null && sounds.Night != null)
            {
                time = 0;
                music = sounds.NightMusic.CreateInstance();
                music.Volume = 0.65f;
                music.IsLooped = true;
                music.Play();

                soundsEffect = sounds.Night.CreateInstance();
                soundsEffect.Volume = 0.70f;
                soundsEffect.IsLooped = true;
                soundsEffect.Play();
            }
        }


        public void PlayOwl()
        {
            if (time == PAUSE_TIME)
            {
                if (sounds.OwlSound != null)
                {
                    soundEngineInstance = sounds.OwlSound.CreateInstance();
                    soundEngineInstance.Volume = 0.50f;
                    soundEngineInstance.Play();
                    time = 0;
                }
            }
            else
                time++;
        }


        public void CatchBugsMusic()
        {
            if (sounds.BirdsSound != null && sounds.CatchBugsMusic != null)
            {
                soundEngineInstance = sounds.BirdsSound.CreateInstance();
                soundEngineInstance.Volume = 0.50f;
                soundEngineInstance.IsLooped = true;
                soundEngineInstance.Play();

                music = sounds.CatchBugsMusic.CreateInstance();
                music.Volume = 0.65f;
                music.IsLooped = true;
                music.Play();
            }
        }
    }
}
