using Godot;
using System;
using System.Data;
using Settlers.Enums;
using Settlers.Support.Grid;

[Tool]
public partial class Board : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GenerateBoard();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void GenerateBoard()
	{
		var tiles = new TileType[]
		{
			TileType.Desert,
			TileType.Clay,
			TileType.Clay,
			TileType.Clay,
			TileType.Ore,
			TileType.Ore,
			TileType.Ore,
			TileType.Grain,
			TileType.Grain,
			TileType.Grain,
			TileType.Grain,
			TileType.Sheep,
			TileType.Sheep,
			TileType.Sheep,
			TileType.Sheep,
			TileType.Forest,
			TileType.Forest,
			TileType.Forest,
			TileType.Forest
		};
		
		var shuffledTiles = new TileType[tiles.Length];
		var random = new Random();
		for (int i = 0; i < tiles.Length; i++)
		{
			var index = random.Next(tiles.Length);
			
			shuffledTiles[index] = tiles[i];
		}
		
		var tileInstances = new Tile[tiles.Length];
		for (int i = 0; i < tiles.Length; i++)
		{
			tileInstances[i] = MakeTile(shuffledTiles[i]);
		}
		
		foreach (var row in GetBoardLayout())
		{
			var grid = new HexGrid(0.66f);
			
			foreach (var column in row)
			{
				var tile = tileInstances[0];
				tileInstances = tileInstances[1..];

				var position = grid.HexToWorld(column);
				
				GD.Print(position);
				
				tile.Translate(new Vector3(position.X, 0, position.Y));
				AddChild(tile);
			}
		}
	}
	
	private Tile MakeTile(TileType type)
	{
		var tile = GD.Load<PackedScene>("res://src/Nodes/Board/Tile.tscn");
		var tileInstance = tile.Instantiate<Tile>();
		
		tileInstance.Type = type;
		
		return tileInstance;
	}

	private Vector2[][] GetBoardLayout()
	{
		return new Vector2[][]
		{
			new Vector2[]
			{
				new Vector2(0, 0),
				new Vector2(1, 0),
				new Vector2(2, 0),
			},
			
			new Vector2[]
			{
				new Vector2(-1, 1),
				new Vector2(0, 1),
				new Vector2(1, 1),
				new Vector2(2, 1),
			},
			
			new Vector2[]
			{
				new Vector2(-2, 2),
				new Vector2(-1, 2),
				new Vector2(0, 2),
				new Vector2(1, 2),
				new Vector2(2, 2),
			},
			
			new Vector2[]
			{
				new Vector2(-2, 3),
				new Vector2(-1, 3),
				new Vector2(0, 3),
				new Vector2(1, 3),
			},
			
			new Vector2[]
			{
				new Vector2(-2, 4),
				new Vector2(-1, 4),
				new Vector2(0, 4),
			},
		};
	}
}
