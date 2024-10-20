using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startPosition; // The initial position from which the random walk algorithm is ran

    [SerializeField] private int iterations = 10; // The number of times to run the random walk algorithm
    public int walkLength = 10; // The number of positions that the dungeon consists of
    public bool startRandomlyEachIteration = true;

    public void RunProceduralGeneration()
    {
        var floorPositions = RunRandomWalk();
    }

    /*
     * A function responsible for running the random walk algorithm in order to generate a HashSet of positions that represents
     * the dungeon units.
     * Uses the startPosition, iteration, walkLength and startRandomlyEachIteration variables0
     */
    private HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition; // The position that 
        var dungeonPositions = new HashSet<Vector2Int>();

        for (var i = 0; i < iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, walkLength);
            dungeonPositions.UnionWith(path); // Modifies the floorPositions HashSet to include all positions in path

            if (startRandomlyEachIteration)
                currentPosition = dungeonPositions.ElementAt(Random.Range(0, dungeonPositions.Count));
        }

        return dungeonPositions;
    }
}