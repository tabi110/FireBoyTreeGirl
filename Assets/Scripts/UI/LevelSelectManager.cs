//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class LevelSelectManager : MonoBehaviour
//{
//    public GameObject[] levelButtons;  // Assign Level1Button to Level8Button here in Inspector
//    [SerializeField]
//    private AudioClip buttonClickSound; // Assign your button click sound here
//    void Start()
//    {
//        PlayerPrefs.SetInt("LevelUnlocked", 1);
//        PlayerPrefs.Save();
//        int levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);

//        for (int i = 0; i < levelButtons.Length; i++)
//        {
//            bool isUnlocked = (i + 1) <= levelUnlocked;

//            Hide / show the entire button GameObject
//            levelButtons[i].SetActive(isUnlocked);
//        }
//    }

//    public void LoadLevel(string levelName)
//    {
//        AudioManager.Instance.PlaySound(buttonClickSound);
//        SceneManager.LoadScene(levelName);
//    }

//    public string levelName;               // e.g., "Level1"
//    public int requiredLevelToUnlock = 1;  // The minimum level unlock value needed
//    public GameObject lockIcon;            // Drag your LockIcon here
//    public GameObject levelIcon;           // Drag your LevelIcon here
//    public Button button;                  // Drag the Button component here

//    void Start()
//    {
//        int levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);

//        bool isUnlocked = levelUnlocked >= requiredLevelToUnlock;

//        if (lockIcon != null) lockIcon.SetActive(!isUnlocked);
//        if (levelIcon != null) levelIcon.SetActive(isUnlocked);

//        button.enabled = false;
//    }

//    public void LoadLevel()
//    {
//        SceneManager.LoadScene(levelName);
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public GameObject[] levelButtons;  // Assign Level1Button to Level8Button here

    void Start()
    {
        //PlayerPrefs.SetInt("LevelUnlocked", 1);
        //PlayerPrefs.Save();
        int levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            bool isUnlocked = (i + 1) <= levelUnlocked;

            Transform lockIcon = levelButtons[i].transform.Find("LockIcon");
            Transform levelIcon = levelButtons[i].transform.Find("LevelIcon");

            if (lockIcon != null) lockIcon.gameObject.SetActive(!isUnlocked);
            if (levelIcon != null) levelIcon.gameObject.SetActive(isUnlocked);

            Button btn = levelButtons[i].GetComponent<Button>();
            if (btn != null)
            {   
                //btn.interactable = isUnlocked;
                btn.enabled = isUnlocked;
            }
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
