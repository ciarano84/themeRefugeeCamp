using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileMap : MonoBehaviour {

    public GameObject selectedUnit;

    public TileType[] tiletypes;

    int[,] tiles;
    Node[,] graph;

    int mapSizeX = 10;
    int mapSizeZ = 10;

    void Start() {
        GenerateMapData();
        GeneratePathfindingGraph();
        GenerateMapVisuals();
    }

    void GenerateMapData() {
        //allocate map tiles
        tiles = new int[mapSizeX, mapSizeZ];

        //initialize map tiles to be grass
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeZ; z++)
            {
                tiles[x, z] = 0;
            }
        }

        //create a swamp area
        for (int x = 2; x < 7; x++)
        {
            for (int z = 1; z < 5; z++)
            {
                tiles[x, z] = 1;
            }
        }

        // Let's make a u-shaped mountain
        tiles[4, 4] = 2;
        tiles[5, 4] = 2;
        tiles[6, 4] = 2;
        tiles[7, 4] = 2;
        tiles[8, 4] = 2;

        tiles[4, 5] = 2;
        tiles[4, 6] = 2;
        tiles[8, 5] = 2;
        tiles[8, 6] = 2;
    }

    class Node {
        List<Node> neighbours;

        public Node() {
            neighbours = new List<Node>();
        }
    }

    void GeneratePathfindingGraph() {
        graph = new Node[mapSizeX, mapSizeZ];
    }

    void GenerateMapVisuals() {
        //Spawns the visual prefabs according to map data.
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeZ; z++)
            {
                TileType tt = tiletypes[tiles[x, z]];

                GameObject go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, -0.5f, z), Quaternion.identity);

                ClickableTile ct = go.GetComponent<ClickableTile>();
                ct.tileX = x;
                ct.tileZ = z;
                ct.map = this;
            }
        }
    }

    public Vector3 TileCoordToWorldCoord(int x, int z) {
        return new Vector3 (x, 0, z);
    }

    public void MoveSelectedUnitTo(int x, int z) {
        selectedUnit.GetComponent<Unit>().tileX = x;
        selectedUnit.GetComponent<Unit>().tileZ = z;
        selectedUnit.transform.position = new Vector3(x, 0, z);
    }
}
