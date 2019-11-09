using Godot;
using System;

public enum CellTypes {
    Empty = -1,
    Wall,
}

public class World : Node
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
        SyncMap();
    }
    private void SyncMap() {
        var map = this.GetNode<GridMap>("GridMap");
        for(var x = 0; x < worldXDimension; x++) {
            for(var z = 0; z < worldZDimension; z++) {
                for(var y = 0; y < worldYDimension; y++) {
                    map.SetCellItem(x,y,z, (int)_mapData[x,y,z]);
                }
            }
        }
        map.MakeBakedMeshes();
    }
}
