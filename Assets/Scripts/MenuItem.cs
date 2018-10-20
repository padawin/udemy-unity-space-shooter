using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	Menu menu;

	public void setMenu(Menu menu) {
		this.menu = menu;
	}

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
		menu.setCurrentItem(gameObject);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
		menu.setCurrentItem(null);
    }
}
