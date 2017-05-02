using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolframCellularAutomata : MonoBehaviour {

    //inisialise a 1 dimensional array
    int[] map;
    int generation;
    //initialise dimensions of the grid
    public int width;
    public int height;
    //int[] ruleset = { 0, 1, 0, 1, 0, 1, 1, 0 };
    //int[] ruleset = { 1, 0, 1, 0, 0, 1, 1, 1 };
    int[] ruleset = { 0, 0, 1, 1, 0, 1, 1, 0 };
    public int w = 9;

    void Start()
    {
        FillMap();
    }

    void Update()
    {
        Generate();   
    }

    //Fill the Array
    void  FillMap()
    {
        map = new int[width];
        for(int i = 0;i< map.Length; i++)
        {
            map[i] = 0;
        }
        map[map.Length / 2] = 1;
        generation = 0;
    }


    void Generate()
    {
        int[] nextGen = new int[width];
        for(int i = 1; i< map.Length-1; i++)
        {
            int left = map[i - 1];
            int middle = map[i];
            int right = map[i + 1];
            nextGen[i] = rule(left, middle, right);
        }
        map = nextGen;
        generation++;
    }


    int rule(int a, int b, int c)
    {
        if (a == 1 && b == 1 && c == 1)
        {
            return ruleset[0];
        }
        if (a == 1 && b == 1 && c == 0)
        {
            return ruleset[1];
        }
        if (a == 1 && b == 0 && c == 1)
        {
            return ruleset[2];
        }
        if (a == 1 && b == 0 && c == 0)
        {
            return ruleset[3];
        }
        if (a == 0 && b == 1 && c == 1)
        {
            return ruleset[4];
        }
        if (a == 0 && b == 1 && c == 0)
        {
            return ruleset[5];
        }
        if (a == 0 && b == 0 && c == 1)
        {
            return ruleset[6];
        }
        if (a == 0 && b == 0 && c == 0)
        {
            return ruleset[7];
        }
        return 0;
    }


    void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x] == 1) ? Color.black : Color.white;
                    Vector2 pos = new Vector2(-width / 2 + x + 0.5f, y);
                    Gizmos.DrawCube(pos, Vector2.one);
                }
                
            }
        }
    }



}
