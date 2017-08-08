using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject hazard; // 陨石对象
    public GameObject enemy;// 敌人战机对象

    public Vector3 spawnValue; // 生成范围
    public int hazardCount;// 每波生成数量
    public float spawnWait;// 下一个陨石等待时间
    public float startWait;// 开始等待时间
    public float waveWait;// 每波等待时间


    public GameObject background;// 背景移动
    public float backgroundSpeed;// 背景移动速度
    private Vector3 backgroundOriginal;// 背景原始位置

	private int score;// 分数
    public Text scoreText;// 显示分数控件


    // 游戏结束
    public Text gameOverText;
    private bool gameOver;

    // 游戏重新开始
    public Text restartText;
    private bool restart;

	// Use this for initialization
	void Start () {
        // 清零计分板
        score = 0;
        // 生成陨石
        StartCoroutine(SpawnWaves());
        // 游戏结束
        gameOverText.text = "";
        gameOver = false;
        // 重新开始
        restartText.text = "";
        restart = false;
        backgroundOriginal = background.transform.position;
	}

    private void Update(){
        if(restart){
            if(Input.GetKey(KeyCode.R)){
                Application.LoadLevel(Application.loadedLevel);
            }
        }


        background.transform.Translate(Vector3.back * backgroundSpeed,Space.World);
        if (background.transform.position.z <= -12){
            background.transform.position = backgroundOriginal;
        }
    }


    // 生成陨石
    IEnumerator SpawnWaves(){
        yield return new WaitForSeconds(startWait);
        while(true){
			for (int i = 0; i < hazardCount; i++) {
                
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
                if(i == hazardCount-1 || i == 0){ // 每波第一个和最后一个生成地方战机
                    Vector3 enemyPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                    Quaternion enemyRotation = Quaternion.identity;
                    Instantiate(enemy, enemyPosition, enemyRotation);
                }
				
				yield return new WaitForSeconds(spawnWait);

                if (gameOver){
                    restart = true;
                    restartText.text = "Press 'R' to Restart";
                }
			}
            yield return new WaitForSeconds(waveWait);
        }
	}

    // 得分方法
	public void addScore(int value) {
		score += value;
		UpdateScore();
	}
	private void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

    // 游戏结束
    public void GameOver(){
        gameOver = true;
        gameOverText.text = "Game Over";
    }
}
