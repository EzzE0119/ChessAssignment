using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    public override List<Move> GetLegalMoves()
    {
        
        List<Move> legalMoves = new List<Move>();

        // bishop all diagonals
        Vector2Int[] directions = {
            new Vector2Int(1, 1),    // Up-Right
            new Vector2Int(-1, 1),   // Up-Left
            new Vector2Int(1, -1),   // Down-Right
            new Vector2Int(-1, -1)   // Down-Left
        };

        foreach (var direction in directions)
        {
            int newRow = row;
            int newCol = column;

            while (true)
            {
                newRow += direction.x;
                newCol += direction.y;

                if (newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8)
                {
                    break; // Out of bounds
                }

                ChessPiece pieceAtNewPosition = ChessBoardPlacementHandler.Instance.GetPieceAtTile(newRow, newCol);
                if (pieceAtNewPosition == null)
                {
                    legalMoves.Add(new Move(new Vector2Int(newRow, newCol), false)); // Empty tile
                }
                else
                {
                    if (pieceAtNewPosition.isWhite != isWhite)
                    {
                        legalMoves.Add(new Move(new Vector2Int(newRow, newCol), true)); // Enemy piece
                    }
                    break; // Stop at the first piece (either enemy or friendly)
                }
            }
        }
        Debug.Log($"Legal moves for Bishop at ({row}, {column}): {legalMoves.Count}");
        return legalMoves;
    }
}
