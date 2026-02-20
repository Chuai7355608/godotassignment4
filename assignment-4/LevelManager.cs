using Godot;
using System;

public partial class LevelManager : Node
{
    private readonly string[] _scenePaths =
    {
        "res://menu.tscn", 
        "res://game.tscn",
        "res://option.tscn" 
    };


    public void LoadLevel(int levelIndex)
    {
		if (levelIndex < 0 || levelIndex >= _scenePaths.Length)
        {
            GD.PrintErr("Invalid level index: " + levelIndex);
            return;
        }

        string scenePath = _scenePaths[levelIndex];
        PackedScene packedScene = GD.Load<PackedScene>(scenePath);
        
        if (packedScene == null)
        {
            GD.PrintErr("Failed to load scene at path: " + scenePath);
            return;
        }

        Node instance = packedScene.Instantiate();
        
        if (instance is ILevelManagerDependent dependent)
        {
            dependent.SetLevelManager(this);
        }

        GetTree().Root.RemoveChild(GetTree().CurrentScene);
        GetTree().CurrentScene.QueueFree();
        GetTree().Root.AddChild(instance);
        GetTree().CurrentScene = instance;
        
    }


    public void LoadMenu() => LoadLevel(0);
    public void LoadGame() => LoadLevel(1);
    public void LoadOptions() => LoadLevel(2);

    public override void _Ready()
    {
        LoadMenu();
    }
}