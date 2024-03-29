using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileMapper : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorMap;

    [SerializeField]
    private Tilemap wallMap;

    [SerializeField]
    private Tile[] floorTiles;

    [SerializeField]
    private Tile[] dummyWalls, metalWalls, brickWalls, rockWalls;

    [SerializeField]
    private Dropdown styleSelector;

    private Tile[] wallTiles;
    private Tile[][] styles;

    /// <summary>
    /// Iterates over the given data and lays tiles accordingly.
    /// </summary>
    /// <param name="mazeData">The data table generated by the Maze Generator.</param>
    /// <param name="mazeWidth">Width of the maze to draw.</param>
    /// <param name="mazeHeight">Height of the maze draw.</param>
    public void PaintMap(int[,] mazeData, int mazeWidth, int mazeHeight)
    {
        // Visualize the data as numbers. Uncomment if needed
        /*Debug.Log("Maze generated");
        String s = "";
        for (int y = 0; y < mazeHeight; y++)
        {
            for (int x = 0; x < mazeWidth; x++)
            {
                if (mazeData[x, y] < 10)
                {
                    s += "0" + mazeData[x, y] + " ";
                }
                else
                {
                    s += mazeData[x, y] + " ";
                }
            }
            s += "\n";
        }
        Debug.Log(s);*/

        floorMap.ClearAllTiles();
        wallMap.ClearAllTiles();

        Vector3Int pos = new Vector3Int(0, 0, 0);
        Tile floorTile;
        floorTile = (styleSelector.value == 0) ? floorTiles[0] : floorTiles[1];

        for (int y = 0; y < mazeHeight; y++)
        {
            for (int x = 0; x < mazeWidth; x++)
            {
                pos.x = x - mazeWidth / 2;
                pos.y = y - mazeHeight / 2;
                
                floorMap.SetTile(pos, floorTile);
                wallMap.SetTile(pos, wallTiles[mazeData[x, mazeHeight - y - 1]]);
            }
        }
    }

    /// <summary>
    /// Changes the style of the tiles to the one selected in the dropdown.
    /// </summary>
    public void ChangeStyle()
    {
        wallTiles = styles[styleSelector.value];
    }

    /// <summary>
    /// Returns the maps bound size.
    /// </summary>
    /// <returns>The number of set tiles.</returns>
    public Bounds GetBounds()
    {
        wallMap.CompressBounds();
        return wallMap.localBounds;
    }
    private void Start()
    {
        styles = new Tile[styleSelector.options.Count][];
        styles[0] = dummyWalls;
        styles[1] = metalWalls;
        styles[2] = brickWalls;
        styles[3] = rockWalls;

        wallTiles = styles[styleSelector.value];
    }
}
