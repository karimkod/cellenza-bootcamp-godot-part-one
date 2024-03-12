using Godot;
using System;

public partial class TechnologyLogo : Sprite2D
{
	public const string TechnologyGroupName = "TECHNOLOGY";

	private TechnologyDetectionManager _technologyDetectionManager;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_technologyDetectionManager = GetNode<TechnologyDetectionManager>("..");
		AddToGroup(TechnologyGroupName);
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnTechnologyLogoClicked(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event.IsPressed())
		{
			_technologyDetectionManager.TechnologyFound();
			QueueFree();
		}
	}
}
