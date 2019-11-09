using Godot;
using System;

public class Playground : Node
{
    public int worldXDimension = 100;
    public int worldZDimension = 100;
    public int worldYDimension = 5;
    CellTypes[,,] _mapData;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Generate a basic map
        this._mapData = new CellTypes[this.worldXDimension,this.worldYDimension,this.worldZDimension];
        var rand = new Random();
        for(var x = 0; x < worldXDimension; x++) {
            for(var z = 0; z < worldZDimension; z++) {
                for(var y = 0; y < worldYDimension; y++) {
                    this._mapData[x,y,z] = CellTypes.Empty;
                    if(x == 0 || x == worldXDimension - 1) {
                        this._mapData[x,y,z] = CellTypes.Wall;
                    }
                    if(z == 0 || z == worldZDimension - 1) {
                        this._mapData[x,y,z] = CellTypes.Wall;
                    }
                    if(y == 0) {
                        this._mapData[x,y,z] = CellTypes.Wall;
                    }
                    if(rand.Next(0, 10) < 3) {
                        this._mapData[x,y,z] = CellTypes.Wall;
                    }
                }
            }
        }
        _MapMe();
    }
	
    private void _MapMe()
    {
        this._mapData.ForEach((cell, x, y, z) =>
        {
            if (cell == CellTypes.Wall)
            {
                var translation = new Vector3(-50f + x, y, -50f + z);
                var solid = x % 2 == 0 && y % 2 == 0 && z % 2 == 0;
                if (solid)
                {
                    AddChild(_WallMe(translation, solid));

                }
            }
        });
  	}

    private Spatial _WallMe(Vector3 translation, bool solid)
    {
        // quick and dirty, this should be its own kind of node
        var res = solid ? new StaticBody() : new Spatial();
        res.Translation = translation;

        if (solid)
        {
            var collisionData = new CollisionShape();
            collisionData.Shape = new BoxShape();
            res.AddChild(collisionData);
        }

        var vizData = new CSGBox();
        res.AddChild(vizData);

        return res;
    }
}
