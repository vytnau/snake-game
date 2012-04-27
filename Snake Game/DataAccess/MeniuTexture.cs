using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace DataAccess
{
    public class MeniuTexture
    {
            public Texture2D background { set; get; }
            public Texture2D gameTitle { set; get; }
            public Texture2D meniu { set; get; }
            public Texture2D signPole { set; get; }
            public Texture2D new_game { set; get; }
            public Texture2D new_game_marked { set; get; }
            public Texture2D help { set; get; }
            public Texture2D help_marked { set; get; }
            public Texture2D quit { set; get; }
            public Texture2D quit_marked { set; get; }
            public Texture2D highscores { set; get; }
            public Texture2D highscores_marked { set; get; }
    }
}
