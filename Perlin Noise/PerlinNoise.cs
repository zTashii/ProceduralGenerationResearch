using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PerlinNoise{
    
    //public static method returning a 2D array of float values
    //uses arguments that are needed 
    public static float[,] GenNoiseMap(int mWidth, int mHeight, float scale)
    {
        //failsafe to make sure that the scale never = 0 as it will return an
        //error if you divide by a 0
        if(scale <= 0)
        {
            scale = 0.1f;
        }

        //creates a 2D array
        float[,] mNoise = new float[mWidth, mHeight];
        //Nested loop to go through the array on both the x and y axis
        for (int x = 0; x < mWidth; x++) 
        {
            for (int y = 0; y < mHeight; y++)
            {
                //allows the ability to change the size/scale of the noise that is generated
                float xCoord = x/scale;
                float yCoord = y/scale;

                //in Built perlin noise function
                float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);
                //applies the value given by the perlin noise function to the mNoise map array.
                mNoise[x, y] = perlinValue;
            }
        }
        return mNoise;
    }
}
