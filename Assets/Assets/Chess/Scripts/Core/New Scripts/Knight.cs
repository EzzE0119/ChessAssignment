using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Move> GetLegalMoves()
    {
        
        List<Move> legalMoves = new List<Move>();
        int[] dRow = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] dCol = { 1, -1, 1, -1, 2, -2, 2, -2 };

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + dRow[i];
            int newCol = column + dCol[i];

            if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
            {
                ChessPiece pieceAtNewPosition = ChessBoardPlacementHandler.Instance.GetPieceAtTile(newRow, newCol);
                if (pieceAtNewPosition == null)
                {
                    legalMoves.Add(new Move(new Vector2Int(newRow, newCol), false)); // Empty tile
                }
                else if (pieceAtNewPosition.isWhite != isWhite)
                {
                    legalMoves.Add(new Move(new Vector2Int(newRow, newCol), true)); // Enemy piece
                }
            }
        }
        Debug.Log($"Legal moves for Knight at ({row}, {column}): {legalMoves.Count}");
        return legalMoves;
    }
}
