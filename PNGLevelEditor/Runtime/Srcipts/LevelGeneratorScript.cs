
using System;
using UnityEngine;
using UnityEditor;

public class LevelGeneratorScript : MonoBehaviour
{
    [Header("Add Your Maps here (PNG)")]
    public Texture2D[] maps;
    private Texture2D map;
    
    [Header("Add the prefab to use as floor here (plane)")]
    [Space]
    public GameObject FloorObject;
    
    [Header("Add your color Mapings here (Color , Prefab, SpawnHeight)")]
    [Space]
    public ColorToPrefab[] colorMapings;
    // Start is called before the first frame update
    void Start()
    {
        map = maps[UnityEngine.Random.Range(0, maps.Length)];
        
        GenerateLevel();


    }

    private void GenerateLevel()
    {
        var floor = Instantiate(FloorObject, Vector3.zero, Quaternion.identity);
        floor.transform.localScale = new Vector3(map.width /8, 1, map.height/8);
        floor.transform.position = new Vector3(map.width / 2, 0, map.height / 2);
        for(int x = 0; x < map.width; x++)
        {
            for(int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach(ColorToPrefab colorMaming in colorMapings)
        {
            if (colorMaming.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x,colorMaming.ObjectYParameter,y);
                Instantiate(colorMaming.Prefab, position, Quaternion.identity);
            }
        }
    }
}
