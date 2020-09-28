using System.Collections;
using UnityEngine;

public static class GameContextExtensions
{
    public static IEnumerable BottomSlotsIndexes(this GameContext context)
    {
        var indexer = context.slotsIndexer.Value;

        for (int i = 0; i < indexer.GetLength(0); i++)
        {
            for (int j = 0; j < indexer.GetLength(1); j++)
            {
                if (indexer[i, j] != null) continue;

                yield return new Vector2Int(i, j);
                break;
            }
        }
    }

    public static Vector3 IndexToPosition(this Vector2Int slot, IGameConfiguration configuration)
    {
        var hIndex = slot.x * 2 + slot.y % 2;

        var position = new Vector3
        (
            (hIndex - configuration.SlotsOffset.x) * configuration.SlotSeparation.x -
            configuration.SlotSeparation.x / 2f,
            -slot.y * configuration.SlotSeparation.y + configuration.SlotsOffset.y,
            0
        );

        return position;
    }
}