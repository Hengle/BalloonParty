using System.Collections;
using UnityEngine;

public static class GameContextExtensions
{
    public static IEnumerable BottomSlotsIndexes(this GameContext context)
    {
        var indexer = context.slotsIndexer.Value;

        for (int i = 0; i < indexer.GetLength(1); i++)
        {
            for (int j = 0; j < indexer.GetLength(0); j++)
            {
                if (indexer[j, i] != null) continue;

                yield return new Vector2Int(i, j);
                break;
            }
        }
    }
}