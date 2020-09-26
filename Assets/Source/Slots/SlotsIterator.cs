using System.Collections;
using UnityEngine;

public class SlotsIterator : IEnumerable
{
    private readonly int _horizontalSize;
    private readonly int _verticalSize;
    private readonly int _startVertical;
    private readonly int _startHorizontal;

    public SlotsIterator(int horizontalSize, int verticalSize, int startVertical = 0, int startHorizontal = 0)
    {
        _horizontalSize = horizontalSize;
        _verticalSize = verticalSize;
        _startVertical = startVertical;
        _startHorizontal = startHorizontal;
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = _startVertical; i < _verticalSize; i++)
        {
            for (int j = _startHorizontal; j < _horizontalSize; j++)
            {
                var horizontalIndex = j * 2 + i % 2;
                var verticalIndex = i;

                yield return new Vector2Int(horizontalIndex, verticalIndex);
            }
        }
    }
}