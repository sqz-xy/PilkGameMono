namespace PilkEngineMono.Scenes;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;


/// <summary>
/// Interface for implementing a new scene
/// </summary>
public interface IScene
{
    /// <summary>
    /// Initialization logic for the scene goes in here
    /// </summary>
    void Initialize();
    
    /// <summary>
    /// Render logic for the scene goes in here
    /// </summary>
    void Render();
    
    /// <summary>
    /// Update logic for the scene goes in here
    /// </summary>
    void Update();

    /// <summary>
    /// Change to a different scene
    /// </summary>
    /// <param name="pSceneType">Type of scene to change to</param>
    void ChangeScene(Type pSceneType);
    
    /// <summary>
    /// Cleanup logic for the scene goes here
    /// </summary>
    void Close();
}