using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventoryHover : MonoBehaviour
{

    public Image hoverImage;

    void Start()
    {
        hoverImage = GetComponent<Image>();
        hoverImage.color = new Color(255, 255, 255, 0);
    }

    private void Update()
    {
        if(isMouseOver()) hoverImage.color = new Color(255, 255, 255, 0.1f);
        else hoverImage.color = new Color(255, 255, 255, 0);
    }

    private bool isMouseOver()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = Input.mousePosition;
        List<RaycastResult> rrl = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, rrl);
        for (int i = 0; i < rrl.Count; i++)
        {
            if(rrl[i].gameObject != gameObject) {
                rrl.RemoveAt(i);
                i--;
            }
        }

        return rrl.Count > 0;
    }
}
