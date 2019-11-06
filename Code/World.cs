using Godot;
using System;

public enum CellTypes {
    Empty,
    Wall,
}

public class World : Node
{
    public int worldXDimension = 100;
    public int worldYDimension = 100;
    public int worldZDimension = 20;
    CellTypes[,,] _mapData;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Generate a basic map
        this._mapData = new CellTypes[this.worldXDimension,this.worldYDimension,this.worldZDimension];
        for(var x = 0; x < worldXDimension; x++) {
            for(var y = 0; y < worldYDimension; y++) {
                for(var z = 0; z < worldZDimension; z++) {
                    this._mapData[x,y,z] = CellTypes.Empty;
                    if(x == 0 || x == worldXDimension - 1) {
                        this._mapData[x,y,z] = CellTypes.Wall;
                    }
                    if(y == 0 || y == worldYDimension - 1) {
                        this._mapData[x,y,z] = CellTypes.Wall;
                    }
                    if(z == 0) {
                        this._mapData[x,y,z] = CellTypes.Wall;
                    }
                }
            }
        }
    }
}
