using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>(); // Grabbing only canvas group      
        fadeGroup.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
        
    }

    public void OnPlayBtnClick()
    {
        Debug.Log("Play Button Clicked");
    }
}
