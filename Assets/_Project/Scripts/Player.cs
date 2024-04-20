using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts
{
  public class Player : MonoBehaviour
  {
    [SerializeField] private Joystick joystick;
    [SerializeField] private TextMeshProUGUI keysCountText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float speedMovement;
    [SerializeField] private float movementSharpness;
    [SerializeField] private float cameraSharpness;
    [SerializeField] private float maxKeys;
    [SerializeField] private float timeForGame;
    
    private Rigidbody ballRigidbody;
    
    private int countKeys;
    private float timer;
    private bool endGame;
    
    public bool IsAllKeys => countKeys >= maxKeys;
    
    private void Awake()
    {
      ballRigidbody = GetComponent<Rigidbody>();
      keysCountText.text = $"{countKeys} / {maxKeys}";
      timer = timeForGame;
    }
    
    private void Update()
    {
      var direction = !endGame ? new Vector3(joystick.Horizontal, 0, joystick.Vertical) : Vector3.zero;
      
      var movement = direction * speedMovement;
      ballRigidbody.velocity = Vector3.Lerp(ballRigidbody.velocity, movement, Time.deltaTime * movementSharpness);
      
      mainCamera.position = Vector3.Lerp(mainCamera.position, transform.position, Time.deltaTime * cameraSharpness);
      
      var minutes = (int)(timer / 60);
      var seconds = (int)(timer % 60);
      
      if (endGame) return;
      
      timer -= Time.deltaTime;
      timerText.text = $"{minutes:00}:{seconds:00}";
      
      if (!(timer <= 0)) return;
      
      timer = 0;
      Lose();
    }
    
    public void AddKey()
    {
      countKeys++;
      keysCountText.text = $"{countKeys} / {maxKeys}";
    }

    public void Win()
    {
      endGame = true;
      endGamePanel.SetActive(true);
      endGameText.text = "You winner";
      endGameText.color = Color.green;
    }
    
    private void Lose()
    {
      endGame = true;
      endGamePanel.SetActive(true);
      endGameText.text = "You lose";
      endGameText.color = Color.red;
    }

    public void Restart()
    {
      SceneManager.LoadScene("SampleScene");
    }
    
    public void Exit()
    {
      Application.Quit();
    }
  }
}