using Godot;
using System;
using System.Dynamic;

public partial class GameManager : Node
{
	public static GameManager Singleton { get; private set; }
	public float ClosestNumber = 10f;
	
	public override void _Ready()
	{
		Singleton = this;
		loadscore();
	}

	public void savescore()
	{
		using var file = FileAccess.Open("user://highscore.save", FileAccess.ModeFlags.Write);
        file.StoreFloat(ClosestNumber);
        file.Close();
	}

	public void loadscore()
	{
		if (FileAccess.FileExists("user://highscore.save"))
        {
            using var file = FileAccess.Open("user://highscore.save", FileAccess.ModeFlags.Read);
            ClosestNumber = file.GetFloat();
            file.Close();
        }
		else
		{
			ClosestNumber = 10f;
		}
	}

	public void UpdateClosestNumber(float current)
	{
		if(current<ClosestNumber && current>0)
		{
			ClosestNumber = current;
			savescore();
		}
	}

	public void reset()
	{
		ClosestNumber = 10f;
		savescore();
	}

	 public void QuitGame()
    {
        GetTree().Quit();
    }
	
}
