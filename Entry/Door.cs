using Godot;
using System;

public partial class Door : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnDoorClicked(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event.IsPressed())
		{
			var timer = GetNode<Timer>("../NextTimer");
			
			if(timer.IsStopped())
				timer.Start();
		}
	}

}
