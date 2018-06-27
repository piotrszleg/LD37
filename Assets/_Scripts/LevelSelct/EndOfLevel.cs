using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour, SaveSystem.Savable {

    bool finished = false;
    int unlockedStars=0;//Stars previously unlocked by player.
    public int stars { get; set; }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finished = true;
            SceneManager.LoadScene(0);
        }
    }

    public void GetValues(ref SaveSystem.Data data)
    {
        if (finished)
        {
            Debug.Log("Player collected " + stars + " stars loading level 0");
            if (data.levels != null)
            {
                data.levels[SceneManager.GetActiveScene().buildIndex].unlocked = true;
                if (stars > unlockedStars)
                {
                    data.levels[SceneManager.GetActiveScene().buildIndex-1].stars = stars;
                }
            }
        }
    }
    public void SetValues(SaveSystem.Data data)
    {
        if (data.levels != null)
        {
            unlockedStars = data.levels[SceneManager.GetActiveScene().buildIndex].stars;
        }
    }
}
