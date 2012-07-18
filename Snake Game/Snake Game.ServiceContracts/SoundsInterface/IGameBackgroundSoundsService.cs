using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Game.ServiceContracts.SoundsInterface
{
    public interface IGameBackgroundSoundsService
    {
        void PlayBirdsSound();
        void StopPlaySounds();
        void PlayMusic();
        void NightSound();
        void SurvivalMusic();
        void PlayOwl();
        void CatchBugsMusic();
    }
}
