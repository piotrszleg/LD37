using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUIElement : MonoBehaviour {

    public Button openButton;
    public Image[] stars;

	void Start () {
        openButton.onClick.AddListener(()=>SceneManager.LoadScene(transform.GetSiblingIndex() + 1));
	}

	void Update () {
	
	}

    public void Set(bool unlocked, int unlockedStars)
    {
        openButton.interactable = unlocked;
        for (int s = 0; s < stars.Length; s++) 
        {
            if (s < unlockedStars)
            {
                stars[s].color = Color.white;
            }else
            {
                stars[s].color = Color.gray;
            }
        }
    }
}
