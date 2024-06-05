using UnityEngine;

public struct Move
{
    public Vector2Int position;
    public bool isCapture;

    public Move(Vector2Int position, bool isCapture)
    {
        this.position = position;
        this.isCapture = isCapture;
    }
}
