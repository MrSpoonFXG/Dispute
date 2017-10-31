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
	private bool Welcome;
	void Start () {
		Welcome = false;
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
//		Debug.Log (GameObject.Find ("Center/BG1/AccountNumber").GetComponent<InputField> ().text);
//		Debug.Log (GameObject.Find ("Center/BG1/PassWord").GetComponent<InputField> ().text);
		byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes (data);
		WWW www = new WWW ("http://123.56.50.222:8050/userRegister", bs, LogonInfo);
		yield return www;
		if (www.error!=null) {
			Info_M = www.error;
			yield return null;
		}
		Info_M = www.text;
		Debug.Log (Info_M);
		JsonData jd = JsonMapper.ToObject (Info_M);
		LgBgYes ();
		if ((string)jd ["rstcode"] == "201") {

			Bg2.transform.Find("Text").GetComponent<Text> ().text = "注册成功";
		} else {
			Bg2.transform.Find("Text").GetComponent<Text> ().text = (string)jd["rsttext"];
		}
	}
	public void Sign(){
		StartCoroutine (SignIn());
	}
	IEnumerator SignIn(){
		string Info_m = null;
		Dictionary<string,string> SignInfo = new Dictionary<string,string> ();
		SignInfo.Add ("Content-Type", "application/Json");
		string data = "{'email':"+GameObject.Find("Center/BG1/AccountNumber").GetComponent<InputField>().text+",'password':"+GameObject.Find("Center/BG1/PassWord").GetComponent<InputField>().text+"}";
		byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes (data);
		WWW www = new WWW ("http://123.56.50.222:8050/userLogin", bs, SignInfo);
		yield return www;
		if (www.error != null) {
			Info_m = www.error;
			yield return null;
		}
		Info_m = www.text;
		JsonData jd = JsonMapper.ToObject (Info_m);
		LgBgYes ();
		if ((string)jd["rstcode"]=="202") {
			Center.transform.Find ("BG1").gameObject.SetActive (false);
			LgBgNo ();
			Welcome = true;
			Invoke ("ChooseServer",2f);
		} else {
			Bg2.transform.Find("Text").GetComponent<Text>().text = (string)jd["rsttext"];
		}
	}
	void OnGUI(){
		if (Welcome) {
			GUI.TextArea (new Rect (Center.transform.position.x-50, Center.transform.position.y-10, 100, 20), "欢迎来到纷争！");
		}
	}
	public void LgBgYes(){
		Bg2.SetActive (true);
	}
	public void LgBgNo(){
		Bg2.SetActive (false);
	}
	void ChooseServer(){
		Welcome = false;
		this.transform.Find ("StartGame").gameObject.SetActive (true);
		this.transform.Find ("Server").gameObject.SetActive (true);
	}
	// Update is called once per frame
	void Update () {

	}
}
