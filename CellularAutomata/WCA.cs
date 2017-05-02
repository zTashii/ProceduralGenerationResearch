using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCA : MonoBehaviour
{

    //inisialise a 1 dimensional array
    int[,] map;
    int[,] newMap;
    int generation;
    //initialise dimensions of the grid
    public int width;
    public int height;
    //int[] ruleset = { 0, 1, 0, 1, 0, 1, 1, 0 };
    int[] ruleset = { 1, 0, 1, 0, 0, 1, 1, 1 };

    void Start()
    {
        FillMap();
    }

    void Update()
    {
        Generate();
    }

    void FillMap()
    {
        map = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x, y] = 0;
            }
        }
        map[width / 2, 0] = 1;
        
        generation = 0;
    }

    void Generate()
    {
        int[,] newcells = new int[width,height];
        for (int x = 0; x < map.Length-1; x++)
        {
            for (int y = 0; y< height; y++)
            {
                int left = map[x - 1, y];
                int middle = map[x, y];
                int right = map[x + 1, y];
                int newMap = rule(left, middle, right);
                newcells[x, y] = newMap;
                map = newcells;
            }
        }

    }


    int rule(int a, int b, int c)
    {
        if (a == 1 && b == 1 && c == 1)
        {
            return ruleset[0];
        }
        else if (a == 1 && b == 1 && c == 0)
        {
            return ruleset[1];
        }
        else if (a == 1 && b == 0 && c == 1)
        {
            return ruleset[2];
        }
        else if (a == 1 && b == 0 && c == 0)
        {
            return ruleset[3];
        }
        else if (a == 0 && b == 1 && c == 1)
        {
            return ruleset[4];
        }
        else if (a == 0 && b == 1 && c == 0)
        {
            return ruleset[5];
        }
        else if (a == 0 && b == 0 && c == 1)
        {
            return ruleset[6];
        }
        else if (a == 0 && b == 0 && c == 0)
        {
            return ruleset[7];
        }
        return 0;
    }

    void OnDrawGizmos()
    {
        for(int x = 0; x< width; x++)
        {
            for(int y = 0; y< height; y++)
            {
                Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                Vector2 pos = new Vector2(-width /2+ x,y);
                Gizmos.DrawCube(pos, Vector2.one);
            }
        }
    }

}
