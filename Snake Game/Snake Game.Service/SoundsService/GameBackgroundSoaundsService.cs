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

        public GameBackgroundSoundsService(GameSound sounds){
            this.sounds = sounds; 
        }
        public void PlayBirdsSound()
        {
           /* SoundEffectInstance*/ soundEngineInstance = sounds.BirdsSound.CreateInstance();
            soundEngineInstance.Volume = 0.75f;
            soundEngineInstance.IsLooped = true;
            soundEngineInstance.Play();
        }

        public void StartMusic()
        {
        }

        public void StopPlaySounds()
        {
            if(soundEngineInstance != null)
           // if (soundEngineInstance.State == SoundState.Playing)
           // {
                soundEngineInstance.Dispose();
            if(music != null)
                music.Dispose();
        }


        public void PlayMusic()
        {
            music = sounds.Music.CreateInstance();
            music.Volume = 0.75f;
            music.IsLooped = true;
            music.Play();
        }


        public void NightSound()
        {
            soundEngineInstance = sounds.Wind.CreateInstance();
            soundEngineInstance.Volume = 0.95f;
            soundEngineInstance.IsLooped = true;
            soundEngineInstance.Play();
           /* music = sounds.OwlSound.CreateInstance();
            music.Volume = 0.35f;
            music.IsLooped = true;
            music.Play();*/
        }
    }
}
