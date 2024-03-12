using Godot;
using System;

public partial class TechnologyDetectionManager : Node2D
{
	[Signal]
	public delegate void GameDoneEventHandler(); 
	
	[Export]
	public Label RemainingTechnologiesLabel { get; set; }

	private int _numberOfTechnologiesToFind;
	
	private int _technologiesFound = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_numberOfTechnologiesToFind = GetTree().GetNodesInGroup(TechnologyLogo.TechnologyGroupName).Count;
		UpdateLabel();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void TechnologyFound()
	{
		_technologiesFound++;
		UpdateLabel();
		if (_technologiesFound == _numberOfTechnologiesToFind)
		{
			EmitSignal(SignalName.GameDone);
		}
	}

	private void UpdateLabel()
	{
		RemainingTechnologiesLabel.Text = (_numberOfTechnologiesToFind - _technologiesFound).ToString();
	}
	
	public void LoadLastScene()
	{
		GetTree().ChangeSceneToFile("Ending/Ending.tscn");
	}
}
