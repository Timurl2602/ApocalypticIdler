using IdleGame;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int clickableChance;
    [SerializeField] private float timerLength;

    [Header("Logic Visualization")]
    [SerializeField] private float timer;
    [SerializeField] private bool isTimerRunning;
    
    
    private void Start()
    {
        isTimerRunning = true;
        timer = timerLength;
    }

    private void Update()
    {
        
        if (isTimerRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                Roll();
            }
        }
    }
    
    private void Roll()
    {
        var randomNumber = Random.Range(0, 100);
        timer = timerLength;
        
        if (randomNumber <= clickableChance)
        {
            GameManager.Instance.SpawnRandom();
        }
        
    }
}
