using Godot;
using System;

public partial class Game : Node3D,ILevelManagerDependent
{
	private LevelManager _levelManager;

    public void SetLevelManager(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }


	
	[Export]
	public Label countdown;

	public float counting = 10f;


	public void countdownText()
	{
		countdown.Text = "Time: "+ counting;
	}

    public override void _ExitTree()
    {
        counting = 10f;
    }

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if(counting>= 0)
		{
			counting -= (float)delta;
			countdownText();
		}
		else
		{
			_levelManager.LoadMenu();
		}

		if (Input.IsActionJustPressed("click_left"))
        {
            GameManager.Singleton.UpdateClosestNumber(counting);
            
            _levelManager.LoadMenu();
        }
	}
}
