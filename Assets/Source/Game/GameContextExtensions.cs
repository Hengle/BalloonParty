using System.Collections;
using Entitas;
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

    public static bool IsEmpty(this IEntity[,] slots, int i, int j)
    {
        return slots[i, j] == null || !slots[i, j].isEnabled || !((GameEntity) slots[i, j]).isBalloon;
    }

    public static bool IsUnbalanced(this IEntity[,] slots, int i, int j)
    {
        if (j < 0 || i < 0) throw new System.ArgumentException("Invalid argument for index values");

        if (j == 0) return false;

        // border cases
        if (i == 0 || i == slots.GetLength(0) - 1)
        {
            return slots.IsEmpty(i, j - 1);
        }

        if (i < slots.GetLength(0) && j < slots.GetLength(1))
        {
            return slots.IsEmpty(i, j - 1) || slots.IsEmpty(i + (i % 2 == 0 ? -1 : 1), j - 1);
        }

        return true;
    }
}