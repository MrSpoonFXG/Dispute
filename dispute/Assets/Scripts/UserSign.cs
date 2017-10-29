using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System;
using UnityEngine.UI;
public class UserSign : MonoBehaviour {
	// Use this for initialization
	private GameObject Center;
	private GameObject Bg2;
	void Start () {
		Center = GameObject.Find ("Center");
		Bg2 = Center.transform.Find ("BG2").gameObject;
//		var obj1 = GameObject.Find ("Center");
//		var obj1_2 = obj1.transform.Find ("BG2");
//		var obj2 = GameObject.Find ("Center/BG1/PassWord/Text");
//		Debug.Log (obj1_2);
//		Debug.Log (obj2.transform.parent);

	}
	public void Logon(){
		StartCoroutine (LogonIn());
	}
	IEnumerator LogonIn(){
		string Info_M = null;
		Dictionary<string,string> LogonInfo = new Dictionary<string,string>();
		LogonInfo.Add("Content-Type", "application/Json");
		string data = "{'email':" + GameObject.Find("Center/BG1/AccountNumber").GetComponent<InputField>().text + ",'password':" + GameObject.Find("Center/BG1/PassWord").GetComponent<InputField>().text + "}";
		Debug.Log (GameObject.Find ("Center/BG1/AccountNumber").GetComponent<InputField> ().text);
		Debug.Log (GameObject.Find ("Center/BG1/PassWord").GetComponent<InputField> ().text);
		byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes (data);
		WWW www = new WWW ("http://123.56.50.222:8050/userReqister", bs, LogonInfo);
		yield return www;
		if (www.error!=null) {
			Info_M = www.error;
			yield return null;
		}
		Info_M = www.text;
		Debug.Log (Info_M);
		JsonData jd = JsonMapper.ToObject (Info_M);
		if ((string)jd ["rstcode"] == "201") {

			Bg2.GetComponent<Text> ().text = "注册成功";
			Debug.Log (Bg2);
		} else {
			Bg2.GetComponent<Text> ().text = "用户名已被使用，请重新输入";
		}
	}
	public void LgBgYes(){

	}
	// Update is called once per frame
	void Update () {
	
	}
}
