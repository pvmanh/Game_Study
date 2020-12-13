using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBank : MonoBehaviour
{
   private static string[] wordListcb ={"a","s","d","f","g","h","j","k","l",";","A","S","D","F","G","H","J","K","L"};
   private static string[] wordListhd ={"z","x","c","v","b","n","m",",",".","/","Z","X","C","V","B","N","M"};
   private static string[] wordListht ={"q","w","e","r","t","y","u","i","o","p","Q","W","E","R","T","Y","U","I","O","P"};
   private static string[] wordListps ={"0","1","2","3","4","5","6","7","8","9"};
   private static string[] wordListot ={"a","s","d","f","g","h","j","k","l",";","z","x","c","v","b","n","m",",",".","/","q","w","e","r","t","y","u","i","o","0","1","2","3","4","5","6","7","8","9", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" };
   	level lv;	
	int randomIndex =0;
	public GameObject GO;
	public GameObject imgcb;
	private string randomWord ;
	private string level;

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
        else  if(lv.tlevel == "BtnHD")
		{
			randomIndex = Random.Range(0, wordListhd.Length);
			randomWord = wordListhd[randomIndex];
		}
		else if (lv.tlevel == "BtnHT")
		{
			randomIndex = Random.Range(0, wordListht.Length);
			randomWord = wordListht[randomIndex];
		}
		else if (lv.tlevel == "BtnPS")
		{
			randomIndex = Random.Range(0, wordListps.Length);
			randomWord = wordListps[randomIndex];
		}
		else if (lv.tlevel == "BtnOT")
		{
			randomIndex = Random.Range(0, wordListot.Length);
			randomWord = wordListot[randomIndex];
		}
		Debug.Log(lv.tlevel);
		return randomWord;
	}

}
