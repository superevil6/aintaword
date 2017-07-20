using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class availableItems{
	public Item _item;
	public string ItemName;
	public int Price;
	public string Information;

	public availableItems(Item item){
		this._item = item;
		this.ItemName = item.Title;
		this.Information = item.Description;
		this.Price = item.Gold;
	}
}
public class StoreManager : MonoBehaviour {
public ItemDatabase itemDatabase;
public Player player;
public Button purchasableItemPrefab;
public GameObject playerInventory;
public GameObject storeInventory;
public List<availableItems> storeAvailableItems = new List<availableItems>();
public List<availableItems> playerAvailableItems = new List<availableItems>();
[SerializeField]private int availableItemCount;
public ShopType shopType; 
public enum ShopType{
	Weapon,
	Armor,
	Skill
}
	// Use this for initialization
	void Start () {
		player.inventory.Add(itemDatabase.weaponDatabase[0]);
		generateStoreInventory();
		refreshPlayerInventory();
	}
	
public void generateStoreInventory(){
	availableItemCount = Random.Range(3, 10);
	for(int i = 0; i < availableItemCount; i++){
			if(shopType == ShopType.Weapon)
			{
				storeAvailableItems.Add(new availableItems(itemDatabase.returnWeaponByLevel(player.level)));
			}
			else if(shopType == ShopType.Armor){
				storeAvailableItems.Add(new availableItems(itemDatabase.returnArmorByLevel(player.level)));
			}
		}
		foreach(availableItems item in storeAvailableItems){
			Button purchasableItem = Instantiate(purchasableItemPrefab);
			Text itemTitle = purchasableItem.transform.Find("itemTitle").GetComponent<Text>();
			itemTitle.text = item.ItemName;
			Text itemInformation = purchasableItem.transform.Find("itemInformation").GetComponent<Text>();
			itemInformation.text = item.Information + "\n" + item.Price.ToString();
			purchasableItem.transform.SetParent(storeInventory.transform, false);

		}
	}

	public void refreshPlayerInventory(){
		for(int i = 0; i < player.inventory.Count; i++){
			playerAvailableItems.Add(new availableItems(player.inventory[i]));
		}
		foreach(availableItems item in playerAvailableItems){
			Button sellableItem = Instantiate(purchasableItemPrefab);
			Text itemTitle = sellableItem.transform.Find("itemTitle").GetComponent<Text>();
			itemTitle.text = item.ItemName;
			Text itemInformation = sellableItem.transform.Find("itemInformation").GetComponent<Text>();
			itemInformation.text = item.Information + "\n" + item.Price.ToString();
			sellableItem.transform.SetParent(playerInventory.transform, false);
		}
	}
}

