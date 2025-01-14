using System.Runtime.InteropServices;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public Sprite WallSprite;
    public Sprite FloorSprite;

    public int width = 10;
    public int height = 10;


    private Tile[,] map;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        map = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x, y] = new Tile();
                map[x, y].x = x;
                map[x, y].y = y;
                map[x, y].cost = 1;
                map[x, y].type = "floor";

                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                {
                    map[x, y].type = "wall";
                    map[x, y].cost = 99;
                }
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject go = new GameObject();
                go.transform.position = new Vector3(x, y, 0);
                go.transform.parent = this.transform;
                go.name = "Tile_" + x + "_" + y;

                SpriteRenderer sr = go.AddComponent<SpriteRenderer>();

                if (map[x, y].type == "wall")
                {
                    sr.sprite = WallSprite;
                }
                else
                {
                    sr.sprite = FloorSprite;
                }
            }
        }

    }

    public bool isPassable(int x, int y)
    {
        // get Tile at x, y
        Tile t = map[x, y];
        if(t.cost == 99)
        {
            return false;
        }

        return true;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
