using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public class ItemBase{
		public string name;
		public string file_name;

		public ItemBase(string name ,string file_name){
			this.name = name;
			this.file_name = file_name;
		}
	}

	//create a bool variable called (is_exist)
	const int item_slots = 5;
	int curr_items;
	ItemBase[] current_inventory = new ItemBase[item_slots];

	// Use this for initialization
	void Start () {
		//Inventory is empty
		curr_items = 0;
	}

	bool flag = true;
	// Update is called once per frame
	void Update () {
		//We really dont need to update the inventory by frame
		if (flag == true) {

			add_to_inventory ("mushroom", "new_pic");
			remove_from_inventory("mushroom");
			flag = false;
		}
	}
//
	void add_to_inventory(string new_item_name, string new_item_filename){
//		Check for full inventory, throw error if full
		if (curr_items == item_slots) {
//			player.printMessage("my inventory is full!");
		} else {
			//Updating the sprite image for inventory slot

			GameObject new_item = this.transform.GetChild(0).GetChild (curr_items).gameObject;
			Sprite new_sprite = Resources.Load<Sprite> (new_item_filename);
			new_item.GetComponent<Image> ().sprite = new_sprite;


			current_inventory [curr_items] = new ItemBase(new_item_name, new_item_filename);
			curr_items++;

			print ("Added " + new_item_name);
		}
	}

//	void rotate_focus(){
//	
//	}

	void remove_from_inventory(string item_name){
		for (int i = 0; i < curr_items; i++) {
			if (current_inventory [i].name == item_name) {
				GameObject remove_target = this.transform.GetChild(0).GetChild (i).gameObject;
				remove_target.GetComponent<Image> ().sprite = null;
				current_inventory [i] = null;
				curr_items--;

				print ("Removed " + item_name);

				return;
			}
		}

		//The fact that you reached this part of the code means that
		//you didn't find the code.

		print ("ERROR COULD NOT FIND ITEM");
	}
}
