using UnityEngine;

public class moveMe : MonoBehaviour
{

    public int colCount = 4; //set the number of columns of your sheet. 
    public int rowCount = 1; //set  the number of rows of your sheet. 
    public int fps = 10; //set the frames per second (speed)

    public int rowNumber = 0;
    public int colNumber = 0;
    public int totalCells;

    private Vector2 offset;

    void Start()
    {
        totalCells = colCount * rowCount;
    }

    void Update()
    {
        SetSpriteAnimation(colCount, rowCount, rowNumber, colNumber, totalCells, fps);
    }

    //SetSpriteAnimation
    void SetSpriteAnimation(int colCount, int rowCount, int rowNumber, int colNumber, int totalCells, int fps)
    {

        // Calculate index
        int index = (int)(Time.time * fps);
        // Repeat when exhausting all cells
        index = index % totalCells;

        // Size of every cell
        float sizeX = 1.0f / colCount;
        float sizeY = 1.0f / rowCount;
        Vector2 size = new Vector2(sizeX, sizeY);

        // split into horizontal and vertical index
        var uIndex = index % colCount;
        var vIndex = index / colCount;

        // build offset
        float offsetX = (uIndex + colNumber) * size.x;
        float offsetY = (1.0f - size.y) - (vIndex + rowNumber) * size.y;
        Vector2 offset = new Vector2(offsetX, offsetY);

        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
        GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
    }
}

