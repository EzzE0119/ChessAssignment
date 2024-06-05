using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private ChessPiece selectedPiece;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            // mouse click
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                ChessPiece piece = hit.collider.GetComponent<ChessPiece>();
                if (piece != null)
                {
                    if (selectedPiece != null)
                    {
                        ChessBoardPlacementHandler.Instance.ClearHighlights();
                    }
                    selectedPiece = piece;
                    HighlightLegalMoves(piece);
                }
            }
        }
    }

    private void HighlightLegalMoves(ChessPiece piece)
    {
        var legalMoves = piece.GetLegalMoves();
        foreach (var move in legalMoves)
        {
            ChessBoardPlacementHandler.Instance.Highlight(move.position.x, move.position.y, move.isCapture);
        }
    }
}
