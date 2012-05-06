using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace DataAccess
{
    public class SnakeTexture
    {
        public Texture2D HeadLeft { set; get; }
        public Texture2D HeadRight { set; get; }
        public Texture2D HeadUp { set; get; }
        public Texture2D HeadDown { set; get; }
        public Texture2D BodyLR { set; get; }
        public Texture2D BodyUD { set; get; }
        public Texture2D CornerLeft { set; get; }
        public Texture2D CornerRight { set; get; }
        public Texture2D CornerUp { set; get; }
        public Texture2D CornerDown { set; get; }
        public Texture2D TailLeft { set; get; }
        public Texture2D TailRight { set; get; }
        public Texture2D TailUp { set; get; }
        public Texture2D TailDown { set; get; }
    }
}
