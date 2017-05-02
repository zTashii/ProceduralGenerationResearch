using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    //Dimensions of the Map
    public int mWidth;
    public int mHeight;
    //The scale of noise that is rendered
    public float noiseScale;

    //generate map function
    public void GenMap()
    {
        //initialise 2D array and use the "PerlinNoise" class to complete the calculations
        //to compute the noise map with the parameters that we set.
        float[,] noiseMap = PerlinNoise.GenNoiseMap(mWidth, mHeight, noiseScale);
        //pass information to another class called "DisplayMap" that displays the map
        DisplayMap display = FindObjectOfType<DisplayMap>();
        display.DrawNoise(noiseMap);
    }
    
}
