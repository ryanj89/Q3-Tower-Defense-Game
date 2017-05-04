using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	public Transform startPosition;
	public float StartDelay = 3f;         
	public float EndDelay = 3f;
	public float startingTime;
	public float endingTime;
	public float playTime;
	public Text waveText;
	public GameObject energyCore;
	public WaveSpawner waveSpawner;
	public GameObject waveZoom;
	public PlayerStats playerStats;
	public Animator anim;

	private int roundNumber;              
	private WaitForSeconds StartWait;     
	private WaitForSeconds EndWait;
	private PlayerInfoPost playerInfo;
	public HighScoreSubmission scoreSubmission;
	TowerHealth coreHealth;


	private void Start()
	{	
		startPosition = waveZoom.transform;
		startingTime = Time.time;
		StartWait = new WaitForSeconds(StartDelay);
		EndWait = new WaitForSeconds(EndDelay);
		coreHealth = energyCore.GetComponent<TowerHealth> ();

		playerStats.enemyKills = 0;
		playerStats.totalScore = 0;

		roundNumber = 1;

		StartCoroutine(GameLoop());
	}
		
	private IEnumerator GameLoop()
	{
		yield return StartCoroutine(RoundStarting());
		yield return StartCoroutine(RoundPlaying());
		yield return StartCoroutine(RoundEnding());

		if (GameOver() == true)
		{
			endingTime = Time.time;
			playTime = endingTime - startingTime;
			playerInfo = new PlayerInfoPost ();
			playerInfo.duration = (int)playTime;
			playerInfo.difficulty = 0;
			playerInfo.score = playerStats.totalScore;
			playerInfo.kills = playerStats.enemyKills;

			Debug.Log (playerInfo.duration);
			Debug.Log (playerInfo.difficulty);
			Debug.Log (playerInfo.score);
			Debug.Log (playerInfo.kills);
			scoreSubmission.HighScoreSubmit (playerInfo);
		}
		else
		{
			++roundNumber;
			StartCoroutine(GameLoop());
		}
	}
		
	private IEnumerator RoundStarting()
	{
		waveSpawner.SpawnWave(1 + (((roundNumber * roundNumber) * (roundNumber + 1) + 4) / 2), 2f);
		Debug.Log ("Round " + roundNumber + " starting!");

		waveText.text = "Wave " + roundNumber;

		yield return StartWait;


	}
		
	private IEnumerator RoundPlaying()
	{
		Debug.Log("Round " + roundNumber + " playing!");
		while (!NoEnemiesLeft() && !GameOver())
		{
			yield return null;
		}
	}
		
	private IEnumerator RoundEnding() 
	{
		int roundBonus = (1 + (int)Mathf.Floor(Mathf.Log (roundNumber))) * 5;
		Debug.Log ("Round " + roundNumber + " ending!");
		yield return EndWait;
	}
		
	private bool NoEnemiesLeft()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
						
		return enemies.Length <= 0;
	}

	public bool GameOver()
	{
		if (coreHealth.currentHealth <= 0f) 
		{
			Debug.Log ("Game Over");
		}

		return coreHealth.currentHealth <= 0f;
	}
}