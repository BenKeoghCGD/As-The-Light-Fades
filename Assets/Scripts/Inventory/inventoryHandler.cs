using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Inventory_ItemHolder : System.Object
{
    public Image Item_Icon;
    public GameObject Item_Hover;
    public Image Item_Hover_Image;
    public int Item_Position_X, Item_Position_Y;
    public inventoryHandler.Inventory_Category Item_Category;
}

[System.Serializable]
public class Inventory_Item : System.Object
{
    public Image Item_Image;
    public int Item_Position_X, Item_Position_Y;
    public float Item;
    public inventoryHandler.Inventory_Category Item_Category;
}

public class inventoryHandler : MonoBehaviour
{
    [Header("Canvas Items")]
    public Canvas Inventory_Canvas;
    public GameObject Inventory_Foreground;
    public List<Inventory_ItemHolder> Inventory_ItemHolders = new List<Inventory_ItemHolder>();
    public List<Inventory_Item> Inventory_Items = new List<Inventory_Item>();

    [HideInInspector] public enum Inventory_Category
    {
        Light, Part, Battery, Misc, KeyCard
    };

    private bool Inventory_Shown;
    private Vector3 Inventory_Foreground_Hidden = new Vector3(350, 0, 0);
    private Vector3 Inventory_Foreground_Shown = new Vector3(0, 0, 0);

    private Vector3 vVelocity = Vector3.zero;

    void Start()
    {
        Inventory_Shown = false;
        Inventory_Foreground.transform.localPosition = Inventory_Foreground_Hidden;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) Inventory_Shown = !Inventory_Shown;
        if (!Inventory_Shown) Inventory_Foreground.transform.localPosition = Vector3.SmoothDamp(Inventory_Foreground.transform.localPosition, Inventory_Foreground_Hidden, ref vVelocity, 0.3f);
        else Inventory_Foreground.transform.localPosition = Vector3.SmoothDamp(Inventory_Foreground.transform.localPosition, Inventory_Foreground_Shown, ref vVelocity, 0.3f);

        Cursor.visible = Inventory_Shown;
        Cursor.lockState = !Inventory_Shown ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
