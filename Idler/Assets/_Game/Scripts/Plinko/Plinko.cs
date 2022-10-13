using IdleGame;
using TMPro;
using UnityEngine;

public class Plinko : MonoBehaviour
{
    [SerializeField] private GameObject _display;
    [SerializeField] private GameObject _plinko;
    [SerializeField] private GameObject _controlsText;
    [SerializeField] private TextMeshProUGUI _playableText;

    private bool _isPlinkoOpen;
    
    [Header("Timer")]
    [SerializeField] private float _timerLength;
    [SerializeField] private float _timer;
    [SerializeField] private bool _isTimerRunning;
    
    private void Start()
    {
        GameManager.Instance.PlinkoCanBePlayed = true;
        _timer = _timerLength;
        _plinko.SetActive(false);
    }

    private void Update()
    {
        if (!GameManager.Instance.PlinkoCanBePlayed)
        {
            _isTimerRunning = true;
            _playableText.text = "Come back soon";
        }
        else
        {
            _isTimerRunning = false;
            _playableText.text = "Ready to play";
        }

        if (_isTimerRunning)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }

            if (_timer <= 0)
            {
                GameManager.Instance.PlinkoCanBePlayed = true;
                _timer = _timerLength;
            }
            
        }
        

        if (_isPlinkoOpen)
        {
            _display.SetActive(false);
            _controlsText.SetActive(true);
        }
        else
        {
            _display.SetActive(true);
            _controlsText.SetActive(false);
        }
        
    }

    
    public void OpenPlinko()
    {
        _isPlinkoOpen = !_isPlinkoOpen;
        _plinko.SetActive(_isPlinkoOpen);
    }

}
