using Godot;
using System;
using Settlers.Enums;

[Tool]
public partial class Tile : Node3D
{
	[Export]
	public TileType Type;
	
	
	public override void _Ready()
	{
		var scene = GD.Load<PackedScene>(GetModelPath());
		var model = scene.Instantiate<Node3D>();
		
		AddChild(model);
	}

	public override void _EnterTree()
	{
		var scene = GD.Load<PackedScene>(GetModelPath());
		var model = scene.Instantiate<Node3D>();
		
		AddChild(model);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private string GetModelPath()
	{
		switch (Type)
		{
			case TileType.Desert:
				return "res://assets/models/tiles/sand.glb";
			
			case TileType.Sheep:
				return "res://assets/models/tiles/grass_hill.glb";
			
			case TileType.Forest:
				return "res://assets/models/tiles/grass_forest.glb";
			
			case TileType.Clay:
				return "res://assets/models/tiles/dirt.glb";
			
			case TileType.Ore:
				return "res://assets/models/tiles/stone_rocks.glb";
			
			case TileType.Grain:
				return "res://assets/models/tiles/grass.glb";
			
			default:
				return "res://assets/models/tiles/water.glb";
		}
	}
}
