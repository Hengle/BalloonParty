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

    public static Vector3 IndexToPosition(this Vector2Int slot, IGameConfiguration configuration)
    {
        var position = new Vector3
        (
            (slot.x - configuration.SlotsOffset.x) * configuration.SlotSeparation.x - configuration.SlotSeparation.x / 2f,
            slot.y * configuration.SlotSeparation.y + configuration.SlotsOffset.y,
            0
        );

        return position;
    }
}