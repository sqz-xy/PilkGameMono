using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.EntityComponent
{

    /*
     * public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
     */

    public class ComponentTransform : Component
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
}
