using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PilkEngineMono.EntityComponent;
using PilkEngineMono.Managers;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PilkEngineMono.Systems
{
    public class SystemRender2D : ISystem
    {
        public Dictionary<string, IComponent> mTransforms;
        public Dictionary<string, IComponent> mSprites;
        float rot = 0.0f;

        public SystemRender2D() 
        {
            GetComponents();
        }

        public void GetComponents()
        {
            // References
            mTransforms = ComponentManager.GetComponents(typeof(ComponentTransform));
            mSprites = ComponentManager.GetComponents(typeof(ComponentSprite));
        }

        public void OnAction()
        {
            foreach (var transform in mTransforms)
            {
                if (mSprites.ContainsKey(transform.Key))
                {
                    var trans = (ComponentTransform)transform.Value;
                    var sprite = (ComponentSprite)mSprites[transform.Key];

                    var originX = (sprite.Height * 0.5f); // the width of a frame
                    var originY = (sprite.Height * 0.5f);

                    var panelWidth = sprite.Width / sprite.SpriteCount;

                    // Fix rotation centering
                    SceneManager.SpriteBatch.Draw(sprite.Texture, trans.Position, sprite.SourceRect, sprite.Colour, trans.Rotation, new Vector2(originX, originY), trans.Scale, SpriteEffects.None, 1);

                    // Sprite Sheets
                    if (sprite.Timer > sprite.Interval && sprite.SpriteCount > 1)
                    {
                        if (sprite.CurrentPanel == sprite.SpriteCount)
                        {
                            sprite.SourceRect = new Rectangle(0, 0, panelWidth, sprite.Height);
                            sprite.CurrentPanel = 1;
                        }
                        else
                        {
                            sprite.SourceRect = new Rectangle(panelWidth * sprite.CurrentPanel, 0, panelWidth, sprite.Height);
                            sprite.CurrentPanel++;
                        }
                        sprite.Timer = 0;
                    }
                    sprite.Timer += (float)SceneManager.GameTime.ElapsedGameTime.Milliseconds;
                }
            }
        }
    }
}
