using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUi;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverUi.activeInHierarchy)
        {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.R)){
            restart();
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            mainMenu();
        }
    }
    
    public void gameOver()
    {
        gameOverUi.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void mainMenu(){
        SceneManager.LoadScene("MainMenu");
        {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Quit(){
       Application.Quit();
    }
}