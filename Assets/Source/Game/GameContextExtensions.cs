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
        return i < 0 || i >= slots.GetLength(0)
                     || j < 0 || j >= slots.GetLength(1)
                     || slots[i, j] == null
                     || !slots[i, j].isEnabled
                     || !((GameEntity) slots[i, j]).isBalloon;
    }

    public static bool IsUnbalanced(this IEntity[,] slots, int i, int j)
    {
        if (j < 0 || i < 0) throw new System.ArgumentException("Invalid argument for index values");

        if (j == 0) return false;

        if (slots.IsEmpty(i, j - 1)) return true;

        var index = i + (j % 2 == 0 ? -1 : 1);

        if (index > 0 && index < slots.GetLength(0))
        {
            return slots.IsEmpty(index, j - 1);
        }

        return false;
    }

    /// <summary>
    /// This method calculates the weight of a slot entry by taking into account
    /// how many occupied slots are above the source point
    /// </summary>
    /// <param name="slots"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    public static int CalculateWeight(this IEntity[,] slots, int i, int j)
    {
        if (j == 0)
        {
            return slots.IsEmpty(i, j) ? 0 : 1;
        }

        if (j > 0)
        {
            var weight = slots.IsEmpty(i, j) ? 0 : 1;

            weight += slots.CalculateWeight(i, j - 1);
            weight += slots.CalculateWeight(i + (j % 2 == 0 ? -1 : 1), j - 1);

            return weight;
        }

        return 0;
    }


    public static Vector2Int? OptimalNextEmptySlot(this IEntity[,] slots, int i, int j)
    {
        if (j <= 0) return null;

        var options = new Vector2Int[]
        {
            new Vector2Int(i, j - 1),
            new Vector2Int(i + (j % 2 == 0 ? -1 : 1), j - 1),
        };

        var weight = 0;
        var optionIndex = -1;

        for (int k = 0; k < options.Length; k++)
        {
            var index = options[k];

            // the index is within the possible values
            if (index.x >= 0 && index.x < slots.GetLength(0) && index.y >= 0 && index.y < slots.GetLength(1))
            {
                // the position is empty so it can be taken
                if (slots.IsEmpty(index.x, index.y))
                {
                    var slotWeight = slots.CalculateWeight(index.x, index.y);

                    if (slotWeight >= weight)
                    {
                        weight = slotWeight;
                        optionIndex = k;
                    }
                }
            }
        }

        if (optionIndex >= 0) return options[optionIndex];

        return null;
    }
}