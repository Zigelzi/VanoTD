using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceTower();
    }

    bool PlaceTower()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log($"You clicked to tile: {transform.position}");
            return true;
        } else
        {
            return false;
        }
    }
}
