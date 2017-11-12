using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public class ItemBase{
		public string name;
		public string file_name;

		public ItemBase(string name /*string file_name*/){
			this.name = name;
//			this.file_name = file_name;
		}
	}



	//create a bool variable called (is_exist)
	const int item_slots = 6;
	int curr_items;
	int curr_focus;
	ItemBase[] current_inventory = new ItemBase[item_slots];
//	public string focusItem;
	public string currItem;

	// Use this for initialization
	void Start () {
//		focusItem = current_inventory [curr_focus].name;
		//Inventory is empty
		curr_items = 0;
		curr_focus = 0;
//		add_to_inventory ("mushroom", "new_pic");
	}




//
//	bool flag = true;
//	int count = 0;
	// Update is called once per frame
	void Update () {
		//We really dont need to update the inventory by frame
//		if (flag == true) {
//			add_to_inventory ("mushroom", "new_pic");
//			add_to_inventory ("mushroom", "new_pic");
//			add_to_inventory ("mushroom", "new_pic");
//			add_to_inventory ("mushroom", "new_pic");
//			add_to_inventory ("mushroom", "new_pic");
//
//			flag = false;
//		}
//
		if (Input.GetKeyUp ("e")) {
			rotate_focus_right ();
		}
		if (Input.GetKeyUp ("q")) {
			rotate_focus_left ();
		}

		if (current_inventory [curr_focus] != null) {
			currItem = current_inventory[curr_focus].name;
		}

	}
//
	public void add_to_inventory(string new_item_name, Sprite new_sprite /*string new_item_filename*/){
//		Check for full inventory, throw error if full
		if (curr_items == item_slots) {
//			player.printMessage("my inventory is full!");
		} else {
			//Updating the sprite image for inventory slot

			GameObject new_item = this.transform.Find("inventory").GetChild(curr_items).gameObject;
//			Sprite new_sprite = Resources.Load<Sprite> (new_item_filename);
			new_item.GetComponent<Image> ().sprite = new_sprite;


			current_inventory [curr_items] = new ItemBase(new_item_name);
			curr_items++;

			print ("Added " + new_item_name);
		}

	}

	public void rotate_focus_right(){
		GameObject focus_box = this.transform.Find("focus_box").gameObject;

		if (curr_items == 0) {
			return;
		}
		else if (curr_focus != curr_items-1) {
			GameObject next_slot = this.transform.Find ("inventory").GetChild (curr_focus+1).gameObject;
			//We want the index+1, but since curr_item starts at 1, curr_item IS our index+1
			Vector2 next_slot_pos = next_slot.GetComponent<RectTransform> ().anchoredPosition;
			focus_box.GetComponent<RectTransform> ().anchoredPosition = next_slot_pos;

		} else {
			GameObject first_slot = this.transform.Find ("inventory").GetChild (0).gameObject;
			Vector2 first_slot_pos = first_slot.GetComponent<RectTransform> ().anchoredPosition;
			focus_box.GetComponent<RectTransform> ().anchoredPosition = first_slot_pos;
		}

		curr_focus = (curr_focus + 1) % curr_items;
	
	}

	public void rotate_focus_left(){
		GameObject focus_box = this.transform.Find("focus_box").gameObject;

		if (curr_items == 0) {
			return;
		}
		if (curr_focus != 0) {
			GameObject next_slot = this.transform.Find ("inventory").GetChild (curr_focus-1).gameObject;
			//We want the index+1, but since curr_item starts at 1, curr_item IS our index+1
			Vector2 next_slot_pos = next_slot.GetComponent<RectTransform> ().anchoredPosition;
			focus_box.GetComponent<RectTransform> ().anchoredPosition = next_slot_pos;

		} else {
			GameObject last_slot = this.transform.Find ("inventory").GetChild (curr_items-1).gameObject;
			//curr_items starts at 1, so -1 to get index
			Vector2 last_slot_pos = last_slot.GetComponent<RectTransform> ().anchoredPosition;
			focus_box.GetComponent<RectTransform> ().anchoredPosition = last_slot_pos;
		}

		curr_focus = (curr_focus + curr_items -1) % curr_items;

	}

	public void remove_from_inventory(string item_name){
		for (int i = 0; i < curr_items; i++) {
			if (current_inventory [i].name == item_name) {
				GameObject remove_target = this.transform.Find("inventory").GetChild (i).gameObject;
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

	public bool checkInteraction(string interaction_item){
		if (curr_items != 0) {
			if (current_inventory [curr_focus].name == interaction_item) {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}


}
