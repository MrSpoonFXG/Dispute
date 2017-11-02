using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseServer : MonoBehaviour {
	GameObject[] Btns;
	GameObject ServerText;
	void Start(){
		ServerText = GameObject.Find ("Server/Text");
		Btns = GameObject.FindGameObjectsWithTag ("button");
		foreach (GameObject obj in Btns) {
			GameObject item = GameObject.Find (obj.name);
			item.GetComponent<Button> ().onClick.AddListener (delegate() {
				this.Choose (item);
			});
		}
	}
	void Choose(GameObject obj){
		ServerText.GetComponent<Text> ().text = obj.transform.Find ("Text").GetComponent<Text> ().text;
		GameObject.Find ("BG3").SetActive (false);
	}
}
