using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	private Dictionary<string, InventoryButton.ItemType> items = new Dictionary<string, InventoryButton.ItemType>();

	public Dictionary<string, InventoryButton.ItemType> Items {
		get {
			return items;
		}
		set {
			items = value;
		}
	}

	public static InventoryManager Instance;

	private void Awake()
	{
		Instance = this;
	}
    
	// Use this for initialization
	void Start () {
		Items.Clear();
	}
	
	public void AddInventoryItem(string i, InventoryButton.ItemType type) {
		Items.Add(i, type);
		UpdateInventoryUI();
	}
	public void RemoveInventoryItem(string i, InventoryButton.ItemType type) {
		Items.Remove(i);
		UpdateInventoryUI();
	}
	public bool InventoryContains(string item) {
		if(Items.ContainsKey(item)) {
			return true;
		}
		else {
			return false;
		}
	}
    
	private void UpdateInventoryUI() {
		foreach(Transform t in RoomManager.Instance.inventoryUI.transform) {
			Destroy(t.gameObject);
		}
        
		foreach(string s in Items.Keys) {
			GameObject go = Instantiate(RoomManager.Instance.inventoryButtonPrefab);
			Sprite icon = Resources.Load<Sprite>(string.Format("Sprites/{0}_Icon", s));
			go.GetComponent<InventoryButton>().UpdateButtonProperties(icon, Items[s]);

			go.transform.SetParent(RoomManager.Instance.inventoryUI.transform, false);
		}
	}
}
