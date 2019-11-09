using Godot;
using System;

public class Player : KinematicBody
{
    private const float GRAVITY = 98f;
    private const float JUMP_SPEED = 50f;
    private const float MOVE_SPEED = 10f;

    private float _vspeed = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }

    public override void _PhysicsProcess(float delta)
    {
		var velocity = _GetMovementVector();
        velocity.y = _vspeed;
        var newVelo = MoveAndSlide(velocity, Vector3.Up);

        _vspeed = newVelo.y - (GRAVITY * delta);
        if (IsOnFloor() && Input.IsActionJustPressed("ui_select"))
        {
            _vspeed = 50f;
        }
    }

    private Vector3 _GetMovementVector()
    {
        var result = new Vector3();
		if (Input.IsActionPressed("player_left"))
        {
            result.x -= 1;
        }
        if (Input.IsActionPressed("player_right"))
        {
            result.x += 1;
        }
        if (Input.IsActionPressed("player_forward"))
        {
            result.z -= 1;
        }
        if (Input.IsActionPressed("player_backward"))
        {
            result.z += 1;
        }
        result = result.Normalized() * MOVE_SPEED;

        // Always move relative to the camera
        var rotation = GetNode<PlayerCamera>("../PlayerCamera").XRotation;
        return result.Rotated(Vector3.Up, rotation);
    }
}
