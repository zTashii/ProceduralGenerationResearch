using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularAutomata : MonoBehaviour
{
    //Dimensions
    public int width;
    public int height;
    //percentage of black/white cells, between 25-90 for a decent generation
    [Range(25, 90)]
    public int randomFillPercent;

    //specifying a seed so it doesnt keep generating the same thing
    public string seed;
    
    //random seed for random generation
    public bool randomSeed;
    //initialise the grid
    int[,] map;

    //on variable change so that i can update the view of the render whilst changing the settings
    public delegate void OnVariableCHangeDelegate(int newPercent);
    public event OnVariableCHangeDelegate OnVariableChange;
    public int oldFill;
    void Start()
    {
        //generate map
        GenMap();
        OnVariableChange += VariableChangeHandler;
    }

    private void VariableChangeHandler(int newPercent)
    {
        GenMap();
    }

    void Update()
    {
        //for the variable change
        if (randomFillPercent != oldFill && OnVariableChange != null)
        {
            oldFill = randomFillPercent;
            OnVariableChange(randomFillPercent);
        }
    }

    void GenMap()
    {
        //generate a map with the height and width that have been specified
        map = new int[width, height];
        FillMap();
    }

    //fill map function
    void FillMap()
    {
        //random alphanumeric seed generator
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVQXYZ0123456789";
        char[] seedChars = new char[8];
        System.Random random = new System.Random(seed.GetHashCode());
        
        if (randomSeed)
        {
            for (int i = 0; i < seedChars.Length; i++)
            {
                seedChars[i] = characters[random.Next(characters.Length)];
            }
            seed = new string(seedChars);
        }
        //nested loop to go through botht he x and y axis of the grid
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //if statement to make sure that the perimeter of the map is set to 1, which is a wall tile
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    //else, it will fill the rest of the tiles with a random state based on the seed generati
                    map[x, y] = (random.Next(0,100) < randomFillPercent)? 1:0;
                }

            }
        }
    }

    //Draw function
    void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                    Vector3 pos = new Vector3(-width / 2 + x + 0.5f, 0, -height / 2 + y + 0.5f);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}


