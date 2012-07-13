using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Snake_Game.Service
{
    public class KeyboardInput
    {
        private readonly int TEXTSIZE = 12;
        private string text;
        private KeyboardState oldKey;
        private bool capsLock = false;
        private bool lShift = false;
        private bool rShift = false;
        private bool shift = false;

        public KeyboardInput()
        {
            text = "";
        }

        public void Clean()
        {
            text = "";
        }

        public string PressKey(KeyboardState newKey)
        {
            int length = text.Length;
            //Remove last letter.
            if (newKey.IsKeyUp(Keys.Delete) && oldKey.IsKeyDown(Keys.Delete))
            {
                if (length > 0)
                    text = text.Remove(length - 1);
            }
            if (newKey.IsKeyUp(Keys.Back) && oldKey.IsKeyDown(Keys.Back))
            {
                if (length > 0)                
                    text = text.Remove(length - 1);                  
            }
            shift = ShiftCase(newKey, oldKey);
            capsLock = CapsLockCase(newKey, oldKey);

            if (length <= TEXTSIZE)
            {
                //Letters
                if (newKey.IsKeyUp(Keys.A) && oldKey.IsKeyDown(Keys.A))
                {
                    text += UpCaseLetters('a', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.B) && oldKey.IsKeyDown(Keys.B))
                {
                    text += UpCaseLetters('b', capsLock, shift);

                }
                if (newKey.IsKeyUp(Keys.C) && oldKey.IsKeyDown(Keys.C))
                {
                    text += UpCaseLetters('c', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.D) && oldKey.IsKeyDown(Keys.D))
                {
                    text += UpCaseLetters('d', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.E) && oldKey.IsKeyDown(Keys.E))
                {
                    text += UpCaseLetters('e', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.F) && oldKey.IsKeyDown(Keys.F))
                {
                    text += UpCaseLetters('f', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.G) && oldKey.IsKeyDown(Keys.G))
                {
                    text += UpCaseLetters('g', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.H) && oldKey.IsKeyDown(Keys.H))
                {
                    text += UpCaseLetters('h', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.I) && oldKey.IsKeyDown(Keys.I))
                {
                    text += UpCaseLetters('i', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.J) && oldKey.IsKeyDown(Keys.J))
                {
                    text += UpCaseLetters('j', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.K) && oldKey.IsKeyDown(Keys.K))
                {
                    text += UpCaseLetters('k', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.L) && oldKey.IsKeyDown(Keys.L))
                {
                    text += UpCaseLetters('l', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.M) && oldKey.IsKeyDown(Keys.M))
                {
                    text += UpCaseLetters('m', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.N) && oldKey.IsKeyDown(Keys.N))
                {
                    text += UpCaseLetters('n', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.O) && oldKey.IsKeyDown(Keys.O))
                {
                    text += UpCaseLetters('o', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.P) && oldKey.IsKeyDown(Keys.P))
                {
                    text += UpCaseLetters('p', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.Q) && oldKey.IsKeyDown(Keys.Q))
                {
                    text += UpCaseLetters('q', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.R) && oldKey.IsKeyDown(Keys.R))
                {
                    text += UpCaseLetters('r', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.S) && oldKey.IsKeyDown(Keys.S))
                {
                    text += UpCaseLetters('s', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.T) && oldKey.IsKeyDown(Keys.T))
                {
                    text += UpCaseLetters('t', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.U) && oldKey.IsKeyDown(Keys.U))
                {
                    text += UpCaseLetters('u', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.V) && oldKey.IsKeyDown(Keys.V))
                {
                    text += UpCaseLetters('v', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.W) && oldKey.IsKeyDown(Keys.W))
                {
                    text += UpCaseLetters('w', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.X) && oldKey.IsKeyDown(Keys.X))
                {
                    text += UpCaseLetters('x', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.Y) && oldKey.IsKeyDown(Keys.Y))
                {
                    text += UpCaseLetters('y', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.Z) && oldKey.IsKeyDown(Keys.Z))
                {
                    text += UpCaseLetters('z', capsLock, shift);
                }
                if (newKey.IsKeyUp(Keys.Space) && oldKey.IsKeyDown(Keys.Space))
                {
                    text += " ";
                }
                if (newKey.IsKeyUp(Keys.D0) && oldKey.IsKeyDown(Keys.D0))
                {
                    System.Console.WriteLine(Keys.D0.ToString());
                    text += UpCaseLetters('ą', capsLock, shift);
                }
            }

            oldKey = newKey;
            return text;
        }

        public string GetText()
        {
            return text;
        }

        private char UpCaseLetters(char letter, bool capsLock, bool shift)
        {
            if(capsLock || shift)
                return Char.ToUpper(letter);
            else
                return letter;
        }

        private bool ShiftCase(KeyboardState newKey, KeyboardState oldKey)
        {
            if (newKey.IsKeyDown(Keys.RightShift))
            {
                rShift = true;
            }
            if (oldKey.IsKeyDown(Keys.LeftShift))
            {
                lShift = true;
            }

            if (newKey.IsKeyUp(Keys.RightShift))
            {
                rShift = false;
            }
            if (oldKey.IsKeyUp(Keys.LeftShift))
            {
                lShift = false;
            }
            if (lShift || rShift)
                return true;
            else
                return false;
        }

        private bool CapsLockCase(KeyboardState newKey, KeyboardState oldKey)
        {
            if (newKey.IsKeyUp(Keys.CapsLock) && oldKey.IsKeyDown(Keys.CapsLock))
            {
                if (capsLock)
                    capsLock = false;
                else
                    capsLock = true;
            }
            return capsLock;
        }
    }
}
