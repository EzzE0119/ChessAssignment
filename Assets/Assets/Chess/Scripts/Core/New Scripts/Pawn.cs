using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Move> GetLegalMoves()
    {
        
        var legalMoves = new List<Move>();
        int direction = isWhite ? -1 : 1;

        // Normal move
        if (IsValidMove(row + direction, column) && ChessBoardPlacementHandler.Instance.GetPieceAtTile(row + direction, column) == null)
        {
            legalMoves.Add(new Move(new Vector2Int(row + direction, column), false));
        }

        // Capture moves
        if (IsValidCapture(row + direction, column + 1))
        {
            legalMoves.Add(new Move(new Vector2Int(row + direction, column + 1), true));
        }
        if (IsValidCapture(row + direction, column - 1))
        {
            legalMoves.Add(new Move(new Vector2Int(row + direction, column - 1), true));
        }
        Debug.Log($"Legal moves for Pawn at ({row}, {column}): {legalMoves.Count}");
        return legalMoves;
    }

    private bool IsValidMove(int newRow, int newCol)
    {
        return newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8;
    }

    private bool IsValidCapture(int newRow, int newCol)
    {
        if (newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8)
            return false;

        ChessPiece piece = ChessBoardPlacementHandler.Instance.GetPieceAtTile(newRow, newCol);
        return piece != null && piece.isWhite != isWhite; // Capture only enemy pieces
    }
}
