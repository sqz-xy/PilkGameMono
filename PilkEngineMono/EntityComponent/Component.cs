using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PilkEngineMono.Managers;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.EntityComponent
{
    public class ComponentTransform : IComponent
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }
        public float Layer { get; set; }

        public ComponentTransform(Vector2 pPosition, Vector2 pScale, float pRotation, float pLayer)
        {
            Position = pPosition;
            Scale = pScale;
            Rotation = pRotation;
            Layer = pLayer;
        }
    }

    public class ComponentSprite : IComponent
    {
        public Texture2D Texture { get; set; }
        public Color Colour { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle SourceRect { get; set; }
        public int SpriteCount { get; set; }
        public float Timer { get; set; }
        public float Interval { get; set; } 
        public int CurrentPanel { get; set; }

        public ComponentSprite(Texture2D pTexture, Color pColour, Rectangle pRectangle, int pSpriteCount, float pInterval)
        {
            Texture = pTexture;
            Colour = pColour;
            Width = pTexture.Width; 
            Height = pTexture.Height;
            SourceRect = pRectangle;
            SpriteCount = pSpriteCount;
            Interval = pInterval;
            CurrentPanel = 1;
            Timer = 0;
        }
    }

    public class ComponentCamera : IComponent 
    { 
    
    }

    public class ComponentModel : IComponent
    {
        public Model Model { get; set; }

        public ComponentModel(Model pModel)
        {
            Model = pModel;
        }
    }
}
