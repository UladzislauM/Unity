using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Clock harvestTimer;
    [SerializeField] private Clock eatingTimer;
    [SerializeField] private Image raidTimerImg;
    [SerializeField] private Image peasantTimerImg;
    [SerializeField] private Image warriorTimerImg;
    [SerializeField] private Button peasantButton;
    [SerializeField] private Button warriorButton;
    [SerializeField] private Text resursesText;
    [SerializeField] private Text CheckMotionText;
    [SerializeField] private Text resoultsText;
    [SerializeField] private Text pausePlayText;
    [SerializeField] private Text muteText;
    [SerializeField] private Text warriorsWinNum;
    [SerializeField] private int peasantCount;
    [SerializeField] private int warriorCount;
    [SerializeField] private int wheatCount;
    [SerializeField] private int wheatPerPeasant;
    [SerializeField] private int wheatToWarriors;
    [SerializeField] private int peasantCost;
    [SerializeField] private int warriorCost;
    [SerializeField] private float peasantCreateTime;
    [SerializeField] private float warriorCreateTime;
    [SerializeField] private float raidMaxTime;
    [SerializeField] private int raidIncrease;
    [SerializeField] private int nextRaid;
    [SerializeField] private bool gameOver;
    [SerializeField] private int checkMotion;
    [SerializeField] private GameObject gameOverLoseScr;
    [SerializeField] private GameObject gameOverWinScr;
    [SerializeField] private AudioSource soundBackboard;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource hireAPeasantSound;
    [SerializeField] private AudioSource hireAWarriorSound;
    [SerializeField] private AudioSource harvestingSound;
    [SerializeField] private AudioSource eatingSound;
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource pick;
    private int _winCount;
    private float _peasantTimer;
    private float _warriorTimer;
    private float _raidTimer;
    private int _motionCount;
    private int _checkRaid;
    private int _checkGrrains;
    private int _checkWarriors;
    private int _checkWarriorsDeads;
    private int _defaultWarriorCount;
    private bool _checkPause;
    private bool _checkMute;

    private void Start()
    {
        Time.timeScale = 0;
        UpdateText();
        _raidTimer = raidMaxTime;
        if (warriorCost > wheatCount)
        {
            warriorButton.interactable = false;
        }
        if (peasantCost > wheatCount)
        {
            peasantButton.interactable = false;
        }
        _checkGrrains = wheatCount;
        _checkWarriors = warriorCount;
        _defaultWarriorCount = warriorCount;
        pausePlayText.text = "Pause";
        soundBackboard.Play();
        _winCount = 40;
        _peasantTimer = -2;
        _warriorTimer = -2;
        _checkRaid = 0;
        _checkPause = true;
        _checkMute = true;
        gameOver = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            _raidTimer -= Time.deltaTime;
            raidTimerImg.fillAmount = _raidTimer / raidMaxTime;
            Timers();
            UpdateText();
            CheckMotion();
            Resoults();
            TrueFalseUnits();
            GameOverLose();
            GameOverWin();
            warriorsWinNum.text = warriorCount + "\n out of 40";
        }
    }

    private void Timers()
    {
        RaidTimer();
        HarvestTimer();
        EatingTimer();
        PeasantTimer();
        WarriorTimer();
    }

    private void RaidTimer()
    {
        if (_raidTimer <= 0)
        {
            _raidTimer = raidMaxTime;
            Debug.Log($"RaidTimer{_raidTimer}");
            checkMotion--;
            if (checkMotion < 0)
            {
                warriorCount -= nextRaid;
                _checkWarriorsDeads += nextRaid;
                nextRaid += raidIncrease;
                _checkRaid++;
                attackSound.Play();
            }
        }
    }

    private void HarvestTimer()
    {
        if (harvestTimer.TickCheck())
        {
            wheatCount += peasantCount * wheatPerPeasant;
            _checkGrrains += peasantCount * wheatPerPeasant;
            harvestingSound.Play();
        }
    }

    private void EatingTimer()
    {
        if (eatingTimer.TickCheck())
        {
            wheatCount -= warriorCount * wheatToWarriors;
            eatingSound.Play();
        }
    }

    private void PeasantTimer()
    {
        if (_peasantTimer > 0)
        {
            _peasantTimer -= Time.deltaTime;
            peasantTimerImg.fillAmount = _peasantTimer / peasantCreateTime;
        }
        else if (_peasantTimer > -1)
        {
            peasantTimerImg.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
            pick.Play();
            _peasantTimer = -2;
        }
    }

    private void WarriorTimer()
    {
        if (_warriorTimer > 0)
        {
            _warriorTimer -= Time.deltaTime;
            warriorTimerImg.fillAmount = _warriorTimer / warriorCreateTime;
        }
        else if (_warriorTimer > -1)
        {
            warriorTimerImg.fillAmount = 1;
            warriorButton.interactable = true;
            warriorCount += 1;
            pick.Play();
            _checkWarriors += 1;
            _warriorTimer = -2;
        }
    }

    private void TrueFalseUnits()
    {
        if (peasantCost <= wheatCount && wheatCount >= 0 && _peasantTimer == -2)
        {
            peasantButton.interactable = true;
        }
        else
        {
            peasantButton.interactable = false;
        }

        if (warriorCost <= wheatCount && wheatCount >= 0 && _warriorTimer == -2)
        {
            warriorButton.interactable = true;
        }
        else
        {
            warriorButton.interactable = false;
        }
    }

    public void Reset()
    {
        gameOver = true;
        Time.timeScale = 1f;
        gameOverLoseScr.SetActive(false);
        warriorCount = _defaultWarriorCount;
        _raidTimer = raidMaxTime;
        harvestTimer.currectTime = harvestTimer.maxTime;
        eatingTimer.currectTime = eatingTimer.maxTime;
        pausePlayText.text = "Pause";
    }

    public void GameOverLose ()
    {
        if (warriorCount <= 0)
        {
            Time.timeScale = 0;
            gameOverLoseScr.SetActive(true);
            gameOver = false;
        }
    }

    public void GameOverWin()
    {
        if (warriorCount >= _winCount)
        {
            Time.timeScale = 0;
            gameOverWinScr.SetActive(true);
            gameOver = false;
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        gameOver = false;
    }

    public void Pause()
    {
        if (_checkPause)
        {
            Time.timeScale = 0;
            gameOver = false;
            _checkPause = false;
            pausePlayText.text = "Play";
        }
        else
        {
            Time.timeScale = 1f;
            gameOver = true;
            _checkPause = true;
            pausePlayText.text = "Pause";
        }
    }

    public void Mute(Text mutrS)
    {
        if (_checkMute)
        {
            mutrS.text = "Sound";
            _checkMute = false;
            AudioListener.volume = 0;
        }
        else
        {
            mutrS.text = "Mute";
            _checkMute = true;
            AudioListener.volume = 1;
        }
    }
    
    public void Resoults()
    {
        resoultsText.text = _checkRaid + "\n" + _checkGrrains + "\n" + peasantCount + "\n"
            + _checkWarriors + "\n" + _checkWarriorsDeads;
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        gameOverLoseScr.SetActive(false);
        gameOver = true;
    }

    public void CheckMotion()
    {
        if (checkMotion >= 0)
            CheckMotionText.text = checkMotion + "\n" + 0;
        else
        {
            if (gameOver)
            {
                CheckMotionText.text = 0 + "\n" + _checkRaid;
            }
        }
    }

    public void CreatePeasant()
    {
        if (wheatCount >= 0 && peasantCost <= wheatCount)
        {
            wheatCount -= peasantCost;
            _peasantTimer = peasantCreateTime;
            peasantButton.interactable = false;
        }
    }

    public void CreateWarior()
    {
        if (wheatCount >= 0 && warriorCost <= wheatCount)
        {
            wheatCount -= warriorCost;
            _warriorTimer = warriorCreateTime;
            warriorButton.interactable = false;
        }
    }

    public void UpdateText()
    {
        resursesText.text = peasantCount + "\n" 
            + warriorCount + "\n" + nextRaid + "\n" + wheatCount;
    }
}
