using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using PilkEngineMono.Scenes;

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PilkEngineMono.Managers
{
    public class SceneManager : Game
    {
        // Static Vars
        public static SpriteBatch SpriteBatch;
        public static GameTime GameTime;
        // ----------

        private GraphicsDeviceManager mGraphics;
        private Scene mCurrentScene;

        public Updater mUpdater;
        public Renderer mRenderer;

        public delegate void Updater();
        public delegate void Renderer();

        private int mWindowWidth;
        private int mWindowHeight;

        public SceneManager(Type pSceneType)
        {
            mGraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            mWindowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            mWindowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            mGraphics.PreferredBackBufferWidth = mWindowWidth;
            mGraphics.PreferredBackBufferHeight = mWindowHeight;
            //mGraphics.ToggleFullScreen();

            if (!ChangeScene(pSceneType))
            {
                Debug.WriteLine("Starting Scene not valid!");
                Exit();
            }
        }

        protected override void Initialize()
        {
            if (mCurrentScene != null)
                mCurrentScene.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            GameTime = gameTime;

            if (mUpdater != null)
                mUpdater();

            KeyboardState ks = Keyboard.GetState();

            if(ks.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();

            if (mRenderer != null)
                mRenderer();

            base.Draw(gameTime);

            SpriteBatch.End();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            if (mCurrentScene != null)
                mCurrentScene.Close();

            base.OnExiting(sender, args);
        }

        public bool ChangeScene(Type pSceneType)
        {
            if (pSceneType.BaseType != typeof(Scene))
            {
                Debug.WriteLine("Scene type not valid");
                return false;
            }

            if (mCurrentScene == null)
            {
                mCurrentScene = (Scene)Activator.CreateInstance(pSceneType, this);
                return true;
            }

            mCurrentScene.Close();
            mCurrentScene = (Scene)Activator.CreateInstance(pSceneType, this);
            mCurrentScene.Initialize();

            return true;
        }
    }
}