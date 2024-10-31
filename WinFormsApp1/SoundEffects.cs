using System;
using System.IO;
using System.Media;

namespace SOUNDEFFECTS
{
    class SoundEffects
    {
        static string currentLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        SoundPlayer winSFX = new SoundPlayer(currentLocation + "\\SFX\\Win.wav");
        SoundPlayer loseSFX = new SoundPlayer(currentLocation + "\\SFX\\Lose.wav");
        SoundPlayer popSFX = new SoundPlayer(currentLocation + "\\SFX\\Pop.wav");
        SoundPlayer WrongSFX = new SoundPlayer(currentLocation + "\\SFX\\Wrong.wav");
        public SoundEffects() { }

        public void Win()
        {
            winSFX.Play();
        }
        public void Lose()
        {
            loseSFX.Play();
        }
        public void Pop()
        {
            popSFX.Play();
        }
        public void Wrong()
        {
            WrongSFX.Play();
        }
    }
}
