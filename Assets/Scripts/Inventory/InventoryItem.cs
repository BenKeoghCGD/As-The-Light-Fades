using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    public Text debug;

    bool held = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseOver()) held = !held;
        if (held) transform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 1371.428f, 1861.513f), Mathf.Clamp(Input.mousePosition.y, 66.55463f, 892.437f));
        debug.text = Input.mousePosition.y + "";
    }

    private bool isMouseOver()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = Input.mousePosition;
        List<RaycastResult> rrl = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, rrl);
        for (int i = 0; i < rrl.Count; i++)
        {
            if (rrl[i].gameObject != gameObject)
            {
                rrl.RemoveAt(i);
                i--;
            }
        }

        return rrl.Count > 0;
    }
}
