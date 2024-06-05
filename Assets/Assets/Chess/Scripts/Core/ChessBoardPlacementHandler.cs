using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class ChessBoardPlacementHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;
    [SerializeField] private GameObject _highlightEnemyPrefab;
    private GameObject[,] _chessBoard;
    private Dictionary<Vector2Int, ChessPiece> _piecePositions;

    internal static ChessBoardPlacementHandler Instance;

    private void Awake()
    {
        Instance = this;
        GenerateArray();
        _piecePositions = new Dictionary<Vector2Int, ChessPiece>();
    }

    private void GenerateArray()
    {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j)
    {
        try
        {
            return _chessBoard[i, j];
        }
        catch (Exception)
        {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int row, int col, bool isEnemy = false)
    {
        var tile = GetTile(row, col).transform;
        if (tile == null)
        {
            Debug.LogError("Invalid row or column.");
            return;
        }

        var highlightPrefab = isEnemy ? _highlightEnemyPrefab : _highlightPrefab;
        Instantiate(highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    internal void ClearHighlights()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform)
                {
                    Destroy(childTransform.gameObject);
                }
            }
        }
    }
    public ChessPiece GetPieceAtTile(int row, int col)
    {
        _piecePositions.TryGetValue(new Vector2Int(row, col), out ChessPiece piece);
        return piece;
    }

    public void RegisterPiece(ChessPiece piece, int row, int col)
    {
        var position = new Vector2Int(row, col);
        if (_piecePositions.ContainsKey(position))
        {
            _piecePositions[position] = piece;
        }
        else
        {
            _piecePositions.Add(position, piece);
        }
    }

    public void UnregisterPiece(int row, int col)
    {
        var position = new Vector2Int(row, col);
        if (_piecePositions.ContainsKey(position))
        {
            _piecePositions.Remove(position);
        }
    }
}
