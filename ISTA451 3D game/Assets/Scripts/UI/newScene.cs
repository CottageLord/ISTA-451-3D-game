using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class newScene : MonoBehaviour, IPointerDownHandler {
    public int sceneNum;
	public void OnPointerDown(PointerEventData pointerEventData)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneNum);
    }
}
