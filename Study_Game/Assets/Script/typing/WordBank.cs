using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBank : MonoBehaviour
{
   private static string[] wordListcb ={"a","s","d","f","g","h","j","k","l",";"};
   private static string[] wordListhd ={"z","x","c","v","b","n","m",",",".","/"};
   private static string[] wordListht ={"q","w","e","r","t","y","u","i","o","p"};
   private static string[] wordListps ={"0","1","2","3","4","5","6","7","8","9"};
   private static string[] wordListot ={"a","s","d","f","g","h","j","k","l",";","z","x","c","v","b","n","m",",",".","/","q","w","e","r","t","y","u","i","o","0","1","2","3","4","5","6","7","8","9"};
   	level lv;	
	int randomIndex =0;
	public GameObject GO;
	public GameObject imgcb;
	 private string randomWord ;

	 private void Start()
	{
		 lv = GO.GetComponent<level>();
		 
	}
	public  string GetRandomWord ()
	{
		
		if(lv.tlevel == "BtnCB" )
		{
			randomIndex = Random.Range(0, wordListcb.Length);
			randomWord = wordListcb[randomIndex];
			//imgcb.SetActive(true);

		}
		if(lv.tlevel == "BtnHD")
		{
			randomIndex = Random.Range(0, wordListhd.Length);
			randomWord = wordListhd[randomIndex];
		}
		if(lv.tlevel == "BtnHT")
		{
			randomIndex = Random.Range(0, wordListht.Length);
			randomWord = wordListht[randomIndex];
		}
		if(lv.tlevel == "BtnPS")
		{
			randomIndex = Random.Range(0, wordListps.Length);
			randomWord = wordListps[randomIndex];
		}
		if(lv.tlevel == "BtnOT")
		{
			randomIndex = Random.Range(0, wordListot.Length);
			randomWord = wordListot[randomIndex];
		}
		Debug.Log(lv.tlevel);
		return randomWord;
	}
	

}
