﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogOut : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler 

{
	public GameObject signOutButton;
	public GameObject signInButton;

	public void Awake() 
	{
		signInButton.SetActive(false);
		signOutButton.SetActive(true);
	}



	public void OnPointerClick(PointerEventData PointerEventData) 
	{
//		Debug.Log ("ping");
		Application.ExternalEval ("logOut()");
	}

	public void OnPointerEnter(PointerEventData PointerEventData)
	{
//		Debug.Log ("I'm in!");

	}

	public void OnPointerExit(PointerEventData PointerEventData)
	{
//		Debug.Log ("I'm out!!");
	}

	public void OnPointerDown(PointerEventData PointerEventData) {
//		Debug.Log("Pointer Down");
	}



}
