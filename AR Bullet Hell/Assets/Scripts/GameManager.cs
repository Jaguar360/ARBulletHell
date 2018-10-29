﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{

	[SerializeField]
	private Camera cam;
	[SerializeField]
	private Text title;
	[SerializeField]
	private Button playButton;
	[SerializeField]
	private FixedJoystick joystick;
	[SerializeField]
	private Button shootButton;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text timerText;
	[SerializeField]
	private Text liveText;
	[SerializeField]
	private Text gameoverText;
	[SerializeField]
	private Button restartButton;
    [SerializeField]
    private Text countdown;
	[SerializeField]
	private Player player;
	[SerializeField]
	private GameObject[] spawns;
	[SerializeField]
	private Enemy[] enemies;
	[SerializeField]
	private Enemy tank;
	[SerializeField]
	private Enemy drone;
	[SerializeField]
	private Enemy warrior;

	private int score;
    private float startTime;
	private int lives;
	private bool gameover;
	private Scene curScene;

	void Awake()
	{
		for (int i = 0; i < spawns.Length; i++) 
		{
			enemies[i].gameObject.SetActive(false);
			spawns[i].SetActive(false);
		}
        player.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        liveText.gameObject.SetActive(false);
        gameoverText.gameObject.SetActive(false);
        countdown.gameObject.SetActive(false);
		joystick.gameObject.SetActive(false);
		shootButton.gameObject.SetActive(false);
		title.gameObject.SetActive(true);
		playButton.gameObject.SetActive(true);
	}

	// Use this for initialization
	void Start () 
	{
		curScene = SceneManager.GetActiveScene();
		scoreText.text = "SCORE: 0";
		score = 0;
		timerText.text = "TIME: 0:00:00";
		startTime = Time.time;
		lives = 3;
        countdown.text = "";
		gameover = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		lives = player.GetLives();
		liveText.text = "LIVES: " + lives;

        //if (countdown.IsActive()) 
        //{
        //    float timeLeft = 5f;
        //    timeLeft -= Time.time;
        //    countdown.text = "" + Mathf.Round(timeLeft);
        //    if (timeLeft < 0)
        //    {
        //        countdown.gameObject.SetActive(false);
        //    }
        //}

        if (IsGameOver() == false && timerText.IsActive())
		{
			score++; // score increases every frame
			DisplayScore();
			float t = Time.time - 5 - startTime;
			string min = ((int)t / 60).ToString();
            string sec = (t % 60).ToString("f2"); // limit milliseconds to 2 decimals
            timerText.text = "Time: " + min + ":" + sec;
		}

        else if (IsGameOver() == true)
		{
			restartButton.gameObject.SetActive(true);
			gameoverText.gameObject.SetActive(true);
		}
	}

	private void LateUpdate()
	{
		for (int i = 0; i < spawns.Length; ++i)
        {
			if (enemies[i].IsDead() == true)
            {
                // instantiate random enemy at spawn's transform values after 3 seconds
                StartCoroutine(SpawnWait(4, i));
                enemies[i].MakeDead(false);
                // Debug.Log("Enemy number" + i + "has been replaced");
            }
        }
	}

	public void Play() 
	{      
		title.gameObject.SetActive(false);
		playButton.gameObject.SetActive(false);
		player.gameObject.SetActive(true);
		liveText.gameObject.SetActive(true);
		joystick.gameObject.SetActive(true);
		shootButton.gameObject.SetActive(true);
        //countdown.gameObject.SetActive(true);
		StartCoroutine(InitialSpawn(5));
	}

    public void AddScore(int scoreAdd)
	{
		score += scoreAdd;
	}

	public void DisplayScore()
	{
		if (score >= 9999999)
		{
			scoreText.text = "SCORE: MAX";
		}

		else
		{
            scoreText.text = "SCORE: " + score; 
		}      
	}

	public void GameOver(bool isover) 
	{
		gameover = isover;	
	}

	public bool IsGameOver() 
	{
		return gameover;
	}

    public void Restart()
	{
		SceneManager.LoadScene(curScene.name);
	}
    
	public IEnumerator InitialSpawn (int seconds) 
	{
		yield return new WaitForSeconds(seconds);
        timerText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
		for (int i = 0; i < spawns.Length; i++)
        {         
            spawns[i].SetActive(true);
            enemies[i].gameObject.SetActive(true);
        }

	}

	public IEnumerator SpawnWait(int seconds, int i) 
	{
		yield return new WaitForSeconds(seconds);
        int ran = Random.Range(1, 9);
        if (ran <= 3)
        {
            enemies[i] = Instantiate(tank, spawns[i].transform);
			enemies[i].MakeDead(false);
			Debug.Log("tank");
        }
        else if (ran <= 6 && ran > 3)
        {
			enemies[i] = Instantiate(drone, spawns[i].transform);
            enemies[i].MakeDead(false);
			Debug.Log("drone");
        }
        else if (ran <= 9 && ran > 6)
        {
			enemies[i] = Instantiate(warrior, spawns[i].transform);
            enemies[i].MakeDead(false);
			Debug.Log("warrior");
        }
	}
}
