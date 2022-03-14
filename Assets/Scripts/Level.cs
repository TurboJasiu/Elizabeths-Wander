using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static Level instance;
    public bool startNextLevel = false;
    float nextLevelDelay = 1.5f;
    public int score = 0;
    Text scoreText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            scoreText = GameObject.Find("scoreValue").GetComponent<Text>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        
    }
    private void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelDelay <= 0)
            {
                {
                    if (SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCountInBuildSettings)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                    else
                    {
                        Debug.Log("game over");
                    }
                    nextLevelDelay = 3.0f;
                    startNextLevel = false;
                }
            }
            else
            {
                nextLevelDelay -= Time.deltaTime;
            }
        }
    }
    public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
        scoreText.text = score.ToString();
    }

    public void LoseScore(int amountToSubtract)
    {
        score -= amountToSubtract;
        scoreText.text = score.ToString();
    }
}
