using Godot;
using System;

public partial class Option : Node3D,ILevelManagerDependent
{

	private LevelManager _levelManager;

    public void SetLevelManager(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }

	[Export]
	public Button clearScore;
	[Export]
	public Button Back;

	public void OnClearPressed()
	{
		GameManager.Singleton.reset();
	}

	public void OnReturnPressed()
	{
		_levelManager.LoadMenu();
	}

	public override void _Ready()
	{
		clearScore.Pressed += OnClearPressed;
		Back.Pressed += OnReturnPressed;
	}

	public override void _Process(double delta)
	{
	}
}
