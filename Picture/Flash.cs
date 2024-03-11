using Godot;
using System;

public partial class Flash : Sprite2D
{
	[Export] public Node2D Picture { get; set; }

	[Export] public Node2D SmileSlider { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Visible)
		{
			var timer = GetNode<Timer>("../FlashTimer");

			Modulate = new Color(Modulate.R, Modulate.G, Modulate.B, (float) timer.TimeLeft);
		}
	}

	public void SwitchFlashOn()
	{
		Show();
		var timer = GetNode<Timer>("../FlashTimer");
		timer.Start();
		SmileSlider.Hide();
		Picture.Show();
	}

	public void OnFlashEnds()
	{
		Hide();
	}
}
