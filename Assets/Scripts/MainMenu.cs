using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuObj;
    public GameObject Levels;

    public void LevelsClicked()
    {
        MainMenuObj.SetActive(false);
        Levels.SetActive(true);
    }

    public void BackClicked()
    {
        MainMenuObj.SetActive(true);
        Levels.SetActive(false);
    }
    
}
