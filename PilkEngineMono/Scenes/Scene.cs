using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PilkEngineMono.Managers;

using System;

namespace PilkEngineMono.Scenes;

public abstract class Scene : IScene
{
    protected readonly SceneManager mSceneManager;

    protected Scene(SceneManager pSceneManager)
    {
        mSceneManager = pSceneManager;
        pSceneManager.mUpdater = Update;
        pSceneManager.mRenderer = Render;
    }

    public abstract void Initialize();
    public abstract void Render();
    public abstract void Update();
    public abstract void Close();
    public void ChangeScene(Type pSceneType)
    {
        mSceneManager.ChangeScene(pSceneType);
    }
}