using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerationAlgorithms : MonoBehaviour
{
    /*
     * Random walk algorithm
     * HashSet stores a list of values of type <T>. A set is a collection of values that cannot contain duplicate elements.
     * Returns a list of Vector2Int values that are representative of the units making up dimensions in the dungeon
     * Takes in the position to generate the path from as a Vector2Int, and the number of Vector2Int values
     * that the path should consist of
     */

    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        var path = new HashSet<Vector2Int> { startPosition };

        var previousPosition = startPosition;

        for (var i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }

        return path;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> CardinalDirectionsList = new()
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        return CardinalDirectionsList[Random.Range(0, CardinalDirectionsList.Count)];
    }
}