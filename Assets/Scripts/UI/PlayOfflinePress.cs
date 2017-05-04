using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayOfflinePress : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler 

{

	public void OnPointerClick(PointerEventData PointerEventData) 
	{
//		Debug.Log ("ping");
		SceneManager.LoadScene("MainMenu");
	}

	public void OnPointerEnter(PointerEventData PointerEventData)
	{
		Debug.Log ("I'm in!");
	}

	public void OnPointerExit(PointerEventData PointerEventData)
	{
		Debug.Log ("I'm out!!");
	}

	public void OnPointerDown(PointerEventData PointerEventData) {
		Debug.Log("Pointer Down");
	}
}
