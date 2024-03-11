using System;
using Godot;
using System.Collections.Generic;

public partial class Slider : Node2D
{

	[Signal]
	public delegate void SmileReachedEventHandler();
	
	[Export] public Sprite2D Handler { get; set; }

	[Export] public Texture2D[] EmojiSteps { get; set; }

	[Export] public Node2D StartingPosition { get; set; }

	[Export] public Node2D EndingPosition { get; set; }

	[Export] public float SmileDelta { get; set; }

	private float _smile;

	private bool _goalReached = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Handler.Position = StartingPosition.Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!_goalReached)
		{
			if (Input.IsActionJustPressed("Smile"))
			{
				_smile += SmileDelta;
			}
			else
			{
				_smile -= (SmileDelta * 0.01f);
			}

			_smile = Mathf.Clamp(_smile, 0, 185);

			Handler.Position = StartingPosition.Position + (Vector2.Right * _smile);
		}

		UpdateEmoji();

		if (_smile >= 180 && !_goalReached)
		{
			_goalReached = true;
			EmitSignal(SignalName.SmileReached);
		}
	}

	private void UpdateEmoji()
	{

		Handler.Texture = _smile switch
		{
			< 30 => EmojiSteps[0],
			< 60 => EmojiSteps[1],
			< 90 => EmojiSteps[2],
			< 120 => EmojiSteps[3],
			< 150 => EmojiSteps[4],
			>= 150 => EmojiSteps[5],
			_ => EmojiSteps[0]
		};

	}
}
