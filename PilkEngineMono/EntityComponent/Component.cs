using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.EntityComponent
{
    public struct ComponentTransform : IComponent
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

    public struct ComponentSprite : IComponent
    {
        public Texture2D Texture { get; set; }
        public Color Colour { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ComponentSprite(Texture2D pTexture, Color pColour)
        {
            Texture = pTexture;
            Colour = pColour;
            Width = pTexture.Width; 
            Height = pTexture.Height;
        }
    }
}
