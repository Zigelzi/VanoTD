using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class TileLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color walkableColour = Color.green;
    [SerializeField] Color exploredColour = new Color(0.85f, 0.4f, 0.7f);
    [SerializeField] Color pathColour = Color.yellow;

    TextMeshPro tileLabel;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;
    // Start is called before the first frame update
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        tileLabel = GetComponentInChildren<TextMeshPro>();
        tileLabel.enabled = false;
        if (Debug.isDebugBuild)
        {
            SetTileText();
            SetLabelColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying && Debug.isDebugBuild)
        {
            tileLabel.enabled = true;
            SetTileText();
            SetGameObjectName();

        }
        if (Debug.isDebugBuild)
        {
            ToggleLabels();
            SetLabelColor();
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

    void SetLabelColor()
    {
        if (gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return; }

        if (!node.isWalkable)
        {
            tileLabel.color = blockedColor;
        }
        else if (node.isPath)
        {
            tileLabel.color = pathColour;
        }
        else if (node.isExplored) {
            tileLabel.color = exploredColour;
        } 
        else if (node.isWalkable)
        {
            tileLabel.color = walkableColour;
        }
        else
        {
            tileLabel.color = defaultColor;
        }
        

    }

    void ToggleLabels()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            tileLabel.enabled = !tileLabel.enabled;
        }
    }
}
