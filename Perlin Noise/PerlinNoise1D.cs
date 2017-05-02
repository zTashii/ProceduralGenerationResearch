using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise1D : MonoBehaviour
{
    //initialise the necessary values
    public float noiseScale = 0.2f;
    public float heightScale = 7f;
    public int width;

    //initialise and create game object to render the terrain
    public GameObject cube;

    void Start()
    {

        //Generates a set of cubes that are the length of the given width
        for (int x = 0; x < width; x++)
        {
            //instantiates gameobject (docs.unity3d.com)
            cube = Instantiate(cube, new Vector3(x, 0, 0), Quaternion.identity) as GameObject;
            cube.transform.parent = transform;
        }
    }

    void Update()
    {
        //failsafe to make sure that the noise scale doesnt go over 1 or below 0
        //the generation will then not work and the perlin noise line
        //will not look anything like a 1d perlin noise line
        if (noiseScale <= 0)
        {
            noiseScale = 0.1f;
        }
        if (noiseScale > 1f)
        {
            noiseScale = 1f;
        }
        //manipulates every game object based on the specified width. 
        //makes sure that the gameobject gets "transformed" to the value generation by the perlin noise function.
        foreach (Transform child in transform)
        {
            float yNoise;

            yNoise = heightScale * Mathf.PerlinNoise((child.transform.position.x * noiseScale), (child.transform.position.z * noiseScale));
            child.transform.position = new Vector3(child.transform.position.x, yNoise, child.transform.position.z);
        }
    }
}