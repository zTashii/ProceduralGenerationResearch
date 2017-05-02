using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMap : MonoBehaviour {

    public Renderer tRender;

    public void DrawNoise(float[,] noiseMap)
    {
        //gets dimensions of the noise map from the other classes
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D noiseTexture = new Texture2D(width, height);

        Color[] colourMap = new Color[width * height];
        //nested for loop to go through the 2D array
        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++)
            {
                //sets colour of the map to be either black or white
                //Lerp is linear interpolation, interpolates between the two vectors.
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            } 
        }
        //applies texture to the map
        noiseTexture.SetPixels(colourMap);
        noiseTexture.Apply();

        tRender.material.mainTexture = noiseTexture;
        tRender.transform.localScale = new Vector3(width, 1, height);
    }
}
