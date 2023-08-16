using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private AudioSource _music;
    [SerializeField]
    private bool _startPlaying;
    [SerializeField]
    private BeatScroller _beatScroller;
    [SerializeField]
    private int _currentScore;
    [SerializeField]
    private int _scorePerNormalNote = 100;
    [SerializeField]
    private int _scorePerGoodNote = 200;
    [SerializeField]
    private int _scorePerPerfectNote = 400;
    [SerializeField]
    private int _currentMultilpier = 1;
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _multiplierText;
    [SerializeField]
    private int[] _multiplierThreashholds;

    private int _comboTracker;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_startPlaying)
        {
            if (Input.anyKeyDown)
            {
                _startPlaying = true;
                _beatScroller.hasStarted = _startPlaying;

                _music.Play();
            }
        }
    }

    public void NoteHit()
    {
        if (_currentMultilpier - 1 < _multiplierThreashholds.Length)
        {
            _comboTracker++;
            if (_multiplierThreashholds[_currentMultilpier - 1] <= _comboTracker)
            {
                _comboTracker = 0;
                _currentMultilpier++;
            }
        }

        _multiplierText.text = "Multiplier: x" + _currentMultilpier;
        _scoreText.text = "Score: " + _currentScore;
    }
    public void NormalHit()
    {
        Debug.Log("Normal hit");
        _currentScore += _scorePerNormalNote * _currentMultilpier;
        NoteHit();
    }
    public void GoodHit()
    {
        Debug.Log("Good hit");
        _currentScore += _scorePerGoodNote * _currentMultilpier;
        NoteHit();
    }
    public void PerfectHit()
    {
        Debug.Log("Perfect Hit");
        _currentScore += _scorePerPerfectNote * _currentMultilpier;
        NoteHit();
    }
    public void MissedNote()
    {
        Debug.Log("Missed note");
        _comboTracker = 0;
        _currentMultilpier = 1;
        _multiplierText.text = "Multiplier: x" + _currentMultilpier;
    }
}
