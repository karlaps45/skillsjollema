using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCs : MonoBehaviour
{
    [SerializeField] Tilemap myTilemap;

    BoundsInt bounds;
    int width, height;
    int x0, y0;

    void Start()
    {
        bounds = myTilemap.cellBounds;
        width = bounds.size.x;
        height = bounds.size.y;
        x0 = bounds.xMin;
        y0 = bounds.yMin;

        // Unlock color flags on every cell
        for (int i = x0; i < x0 + width; i++)
            for (int j = y0; j < y0 + height; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                myTilemap.SetTileFlags(pos, TileFlags.None);
            }
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3Int cellPos = myTilemap.WorldToCell(worldPos);

            ColorAllCells(Color.white);  
            myTilemap.SetColor(cellPos, Color.red);  

            Debug.Log("tilepressed" + cellPos.ToString());
        }
    }

    void ColorAllCells(Color color)
    {
        for (int i = x0; i < x0 + width; i++)
            for (int j = y0; j < y0 + height; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                myTilemap.SetColor(pos, color);
            }
    }
}