using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	[SerializeField] Color32 activeItemColor;
	[SerializeField] Color32 inactiveItemColor;
	List<GameObject> items;
	int currentItemIndex = 0;

	// Use this for initialization
	void Start () {
		items = new List<GameObject>();
		foreach (Transform item in transform) {
			item.GetComponent<MenuItem>().setMenu(this);
			items.Add(item.gameObject);
		}
		setCurrentItem(items[currentItemIndex]);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Vertical") < 0 && currentItemIndex < items.Count - 1) {
			currentItemIndex = currentItemIndex + 1;
			setCurrentItem(items[currentItemIndex]);
		}
		else if (Input.GetAxis("Vertical") > 0 && currentItemIndex > 0) {
			currentItemIndex = currentItemIndex - 1;
			setCurrentItem(items[currentItemIndex]);
		}
		else if (Input.GetButtonDown("Submit")) {
			items[currentItemIndex].GetComponent<Button>().onClick.Invoke();
		}
	}

	public void setCurrentItem(GameObject item) {
		currentItemIndex = -1;
		for (int i = 0; i < items.Count; i++) {
			TextMeshProUGUI text = items[i].GetComponentInChildren<TextMeshProUGUI>();
			Image icon = items[i].GetComponentInChildren<Image>(true);
			if (items[i] == item) {
				currentItemIndex = i;
				text.fontStyle = FontStyles.Bold;
				text.faceColor = activeItemColor;
				icon.enabled = true;
			}
			else {
				text.fontStyle = FontStyles.Normal;
				text.faceColor = inactiveItemColor;
				icon.enabled = false;
			}
		}
	}
}
