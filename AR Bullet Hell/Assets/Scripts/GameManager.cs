using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{

	[SerializeField]
	private Camera cam;
	[SerializeField]
	private FixedJoystick joystick;   
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text timerText;
	[SerializeField]
	private Text liveText;
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

	// Use this for initialization
	void Start () 
	{
		scoreText.text = "SCORE: 0";
		score = 0;
		timerText.text = "TIME: 0:00:00";
		startTime = Time.time;
		lives = 3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		lives = player.GetLives();
		liveText.text = "LIVES: " + lives;

		if (player.IsAlive() == true)
		{
			score++; // score increases every frame
			DisplayScore();
			float t = Time.time - startTime;
			string min = ((int)t / 60).ToString();
            string sec = (t % 60).ToString("f2"); // limit milliseconds to 2 decimals
            timerText.text = "Time: " + min + ":" + sec;
		}
		else 
		{
			Destroy(player);	
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
