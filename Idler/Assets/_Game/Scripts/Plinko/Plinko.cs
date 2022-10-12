using UnityEngine;

public class Plinko : MonoBehaviour
{
    [SerializeField] private GameObject _display;
    [SerializeField] private GameObject _plinko;

    [SerializeField] private bool _isPlayable;
    
    [Header("Timer")]
    [SerializeField] private float _timerLength;
    [SerializeField] private float _timer;
    [SerializeField] private bool _isTimerRunning;
    
    private void Start()
    {
        _isPlayable = true;
        _timer = _timerLength;
        _plinko.SetActive(false);
    }

    private void Update()
    {
        if (!_isPlayable)
        {
            _isTimerRunning = true;
        }
        
        if (_isTimerRunning)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }

            if (_timer <= 0)
            {
                
            }
        }
        
    }

    public void OpenPlinko()
    {
        _plinko.SetActive(true);
    }
    
}
