using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject levelButtons;

    private void Awake()
    {
        ButtonstoArray();
        int unlockedLevel1 = PlayerPrefs.GetInt("UnlockedLevel1" ,1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0;  i < unlockedLevel1 ; i++){
            buttons[i].interactable = true ;
        }
    }


    public void OpenLevel(int levelId)
    {
        string leveName = "lv" + levelId; 
        SceneManager.LoadScene(leveName);
    }

    void ButtonstoArray()
    {
        int childCount = levelButtons.transform.childCount;
        buttons = new Button[childCount];
        for(int i = 0; i < childCount; i++)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
