using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using PilkGame.Scenes;

using System;

namespace PilkGame.Managers
{
    public class SceneManager : Game
    {
        private GraphicsDeviceManager mGraphics;
        private SpriteBatch mSpriteBatch;
        private Scene mCurrentScene;

        public Load mLoad;
        public Updater mUpdater;
        public Renderer mRenderer;

        public delegate void Load();
        public delegate void Updater(GameTime pGameTime);
        public delegate void Renderer(GameTime pGameTime, SpriteBatch pSpriteBatch);

        public SceneManager()
        {
            mGraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            mCurrentScene = new MainMenuScene(this);
        }

        protected override void LoadContent()
        {
            mSpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //Exit();

            mUpdater(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            mRenderer(gameTime, mSpriteBatch);

            base.Draw(gameTime);
        }
  
    }
}