using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace DataAccess
{
    public class GameStageTexture
    {
        public Texture2D Background { set; get; }
        public Texture2D Wall1 { set; get; }
        public Texture2D Wall2 { set; get; }
        public Texture2D Panel { set; get; }
        public Texture2D LifeIcon { set; get; }
        public Texture2D TLife { set; get; }
        public Texture2D TPoints { set; get; }
        public Texture2D TTIme { set; get; }
        public Texture2D NightBackground { set; get; }
        public Texture2D NightSquare { set; get; }
        public Texture2D FogGrass { set; get; }
        public Effect LightEffect { set; get; }
        public Texture2D PanelLayer { set; get; }
    }
}
