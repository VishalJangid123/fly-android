using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.4f;

    public RectTransform menuContainer;
    public Transform levelPanel;

    private Vector3 desiredMenuPosition;
    // Start is called before the first frame update
    void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>(); // Grabbing only canvas group      
        fadeGroup.alpha = 1;

        InitLevel(); // Level 
    }
    void InitLevel()
    {
        int i = 0;
        foreach( Transform t in levelPanel)
        {
            int currentIndex = i;
            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => onLevelSelect(currentIndex));

            i++;
        }
        i = 0; // Reseting the index
    }

    void NavigateTo(int menuIndex)
    {
        switch (menuIndex)
        {
            default:
            case 0: desiredMenuPosition = Vector3.zero; // case 0  for main menu screen
                break;
            case 1: desiredMenuPosition = Vector3.right * Screen.width;// case 1 for level selector
                break;
        }
    }
    private void onLevelSelect(int currentIndex)
    {
        Debug.Log("Button Clicked : " + currentIndex);
    }

    // Update is called once per frame
    void Update()
    {
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;

        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);
    }

    public void OnPlayBtnClick()
    {
        NavigateTo(1); // Play btn on menu to switch to level select
    }
    
    public void BackBtnClick()
    {
        NavigateTo(0); //  Level to Main screen
    }
}
