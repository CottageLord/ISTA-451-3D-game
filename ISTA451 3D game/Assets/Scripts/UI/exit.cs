using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class exit : MonoBehaviour, IPointerDownHandler {

	public void OnPointerDown(PointerEventData pointerEventData)
    {
        Application.Quit();
    }
}
