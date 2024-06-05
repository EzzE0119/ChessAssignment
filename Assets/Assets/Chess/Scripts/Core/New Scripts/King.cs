using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override List<Move> GetLegalMoves()
    {
        
        List<Move> legalMoves = new List<Move>();

        // king one step in all direction
        Vector2Int[] directions = {
            new Vector2Int(1, 0),    // Up
            new Vector2Int(-1, 0),   // Down
            new Vector2Int(0, 1),    // Right
            new Vector2Int(0, -1),   // Left
            new Vector2Int(1, 1),    // Up-Right
            new Vector2Int(-1, 1),   // Down-Right
            new Vector2Int(1, -1),   // Up-Left
            new Vector2Int(-1, -1)   // Down-Left
        };

        foreach (var direction in directions)
        {
            int newRow = row + direction.x;
            int newCol = column + direction.y;

            if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8) //check in bound
            {
                ChessPiece pieceAtNewPosition = ChessBoardPlacementHandler.Instance.GetPieceAtTile(newRow, newCol);
                if (pieceAtNewPosition == null || pieceAtNewPosition.isWhite != isWhite)
                {
                    legalMoves.Add(new Move(new Vector2Int(newRow, newCol), pieceAtNewPosition != null)); // Empty tile or enemy piece
                }
            }
        }
        Debug.Log($"Legal moves for King at ({row}, {column}): {legalMoves.Count}");
        return legalMoves;
    }
}
