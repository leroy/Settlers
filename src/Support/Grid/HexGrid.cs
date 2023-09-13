using System;
using Godot;

namespace Settlers.Support.Grid;

public class HexGrid
{
    private float _size;
    
    public HexGrid(float size)
    {
        this._size = size;

    }

    public Vector2 WorldToHex(Vector2 world)
    {
        var q = (Mathf.Sqrt(3) / 3 * world.X - 1.0f / 3 * world.Y) / _size;
        var r = (2.0f / 3 * world.Y) / _size;
        
        return AxialRound(new Vector2(q, r));
    }

    public Vector2 HexToWorld(Vector2 hex)
    {
        var x = _size * (MathF.Sqrt(3) * hex.X + MathF.Sqrt(3) / 2 * hex.Y);
        var y = _size * (3.0f / 2 * hex.Y);
            
        return new(x, y);
    }
    
    private Vector2 AxialRound(Vector2 position)
    {
        float xgrid = (float) Math.Round(position.X);
        float ygrid = (float) Math.Round(position.Y);
        
        var x = -xgrid;
        var y = -ygrid;
        
        var dx = (float) Math.Round(x + 0.5 * y) * ((x * x >= y * y) ? 1 : 0);
        var dy = (float) Math.Round(y + 0.5 * x) * ((x * x < y * y) ? 1 : 0);
        
        return new Vector2(xgrid + dx, ygrid + dy);
    }
}