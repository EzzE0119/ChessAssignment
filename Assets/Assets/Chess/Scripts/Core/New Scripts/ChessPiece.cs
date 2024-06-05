using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public int row, column;
    public bool isWhite;

    private void Start()
    {
        transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
        ChessBoardPlacementHandler.Instance.RegisterPiece(this, row, column);
    }

    public abstract List<Move> GetLegalMoves();

}
