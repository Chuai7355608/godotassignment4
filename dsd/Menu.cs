using Godot;
using System;

public partial class Menu : Node3D, ILevelManagerDependent
{

	private LevelManager _levelManager;

    public void SetLevelManager(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }


	[Export]
	public Button start;
	[Export]
	public Button option;
	[Export]
	public Button exit;
	[Export]
	public Label highscore;


	public void OnStartPressed()
	{
		_levelManager.LoadGame();
	}

	public void OnOptionPressed()
	{
		_levelManager.LoadOptions();
	}

	public void OnExitPressed()
	{
		GameManager.Singleton.QuitGame();
	}

    public override void _Ready()
    {

        start.Pressed += OnStartPressed;
		option.Pressed += OnOptionPressed;
		exit.Pressed += OnExitPressed;

		Updatelabel();

    }

	public void Updatelabel()
	{
		float theNum = GameManager.Singleton.ClosestNumber;
		if(theNum < 10)
		{
			highscore.Text = "highscore: "+ theNum; 
		}
		else
		{
			highscore.Text = "highscore: 99.99999.9.9.9";
		}
	}

	
	public override void _Process(double delta)
	{
		Updatelabel();
	}
}
