using Godot;
using System;

public class PlayerCamera : Camera
{
    public float XRotation;
    public float YRotation = 1.75f * (float)Math.PI;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_left"))
        {
            XRotation -= delta;
        }
        if (Input.IsActionPressed("ui_right"))
        {
            XRotation += delta;
        }
        if (Input.IsActionPressed("ui_up"))
        {
            YRotation -= delta;
        }
        if (Input.IsActionPressed("ui_down"))
        {
            YRotation += delta;
        }

        var offset = new Vector3(0f, 0f, 5f)
            .Rotated(Vector3.Right, YRotation)
            .Rotated(Vector3.Up, XRotation);
        
        var player = GetNode<Player>("../Player");
        Translation = player.Translation + offset;
        LookAt(player.Translation, Vector3.Up);
    }
}
