using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class TileLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;

    TextMeshPro tileLabel;
    Vector2Int coordinates = new Vector2Int();
    // Start is called before the first frame update
    void Awake()
    {
        if (Debug.isDebugBuild)
        {
            tileLabel = GetComponentInChildren<TextMeshPro>();
            tileLabel.enabled = true;
            SetTileText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            SetTileText();
            SetGameObjectName();
        }
        if (Debug.isDebugBuild)
        {
            ToggleLabels();
        }
    }

    void SetTileText()
    {
        float gridSize = 10;
        coordinates.x = Mathf.RoundToInt(transform.position.x / gridSize);
        coordinates.y = Mathf.RoundToInt(transform.position.z / gridSize);
        tileLabel.text = $"{coordinates.x}, {coordinates.y}";
    }

    void SetGameObjectName()
    {
        gameObject.transform.name = $"Tile_{coordinates.x}_{coordinates.y}";
    }

    void ToggleLabels()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            tileLabel.enabled = !tileLabel.enabled;
        }
    }
}
