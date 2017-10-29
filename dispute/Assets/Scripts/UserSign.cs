using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class UserSign : MonoBehaviour {
	public GameObject AccNumInput;
	public GameObject PWInput;
	// Use this for initialization
	void Start () {
	
	}
	public void Logon(){
		StartCoroutine (LogonIn());
	}
	IEnumerator LogonIn(){
		string Info_M = null;
		Dictionary<string,string> LogonInfo = new Dictionary<string,string>();
		LogonInfo.Add("Content-Type","application/Json");
		string date = "{'email':" + AccNumInput.transform.FindChild("Text") + ",'password':" + PWInputText + "}";
	}
	// Update is called once per frame
	void Update () {
	
	}
}
