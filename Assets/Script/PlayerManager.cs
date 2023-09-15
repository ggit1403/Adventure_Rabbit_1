using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static Vector2 lastCheckPointPos = new Vector2(-3, 8); 


    
    private void Awake()
    {
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos; 
    }
    // Start is called before the first frame update
     
    // Update is called once per frame
    void Update()
        {
            if (isGameOver)
            {
                gameOverScreen.SetActive(true);
            }
        }

        public void ReplayLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
   }

