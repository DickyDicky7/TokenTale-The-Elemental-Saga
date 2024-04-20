using Godot;

namespace TokenTaleTheElementalSaga;

[Tool]
[GlobalClass]
public partial class GenerationStrategyIceWallHorizontal : GenerationStrategy
{
    [Export]
    public byte        IceWallSinglePiecesCount      { get; set; }
    [Export]
    public PackedScene IceWallSinglePiecePackedScene { get; set; }

    [Export]
    public float MinGenerationPositionX;
    [Export]
    public float MaxGenerationPositionX;
    [Export]
    public float MinGenerationPositionY;
    [Export]
    public float MaxGenerationPositionY;
    [Export]
    public float MinGenerationPositionZ;
    [Export]
    public float MaxGenerationPositionZ;

    [Export]
    public float MinGenerationRotationDegreesX;
    [Export]
    public float MaxGenerationRotationDegreesX;
    [Export]
    public float MinGenerationRotationDegreesY;
    [Export]
    public float MaxGenerationRotationDegreesY;
    [Export]
    public float MinGenerationRotationDegreesZ;
    [Export]
    public float MaxGenerationRotationDegreesZ;

    public override void Generate(Node3D @generationSpace)
    {
        for (int index = 1; index <= IceWallSinglePiecesCount; ++index)
        {
            Node3D
            iceWallSinglePiece = (Node3D)
            IceWallSinglePiecePackedScene.Instantiate();
            iceWallSinglePiece.Position        = new(
                (float)GD.RandRange(MinGenerationPositionX, MaxGenerationPositionX),
                (float)GD.RandRange(MinGenerationPositionY, MaxGenerationPositionY),
                (float)GD.RandRange(MinGenerationPositionZ, MaxGenerationPositionZ)
            );
            iceWallSinglePiece.RotationDegrees = new(
                (float)GD.RandRange(MinGenerationRotationDegreesX, MaxGenerationRotationDegreesX),
                (float)GD.RandRange(MinGenerationRotationDegreesY, MaxGenerationRotationDegreesY),
                (float)GD.RandRange(MinGenerationRotationDegreesZ, MaxGenerationRotationDegreesZ)
            );
            @generationSpace.AddChild(
            iceWallSinglePiece       );
        }
    }
}
