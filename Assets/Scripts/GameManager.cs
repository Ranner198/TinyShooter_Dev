using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //singleton
    public static GameManager instance;
    //public List<EnemyAi> enemyAi = new List<EnemyAi>();
    public PlayerMovement player;
    public float totalTimeSpent = 0f;
    public float levelTimeSpent = 0f;
    public int totalKills = 0;
    public GameObject youDiedText;
    public Camera maincam;
    private float shakeAmt;
    private Vector3 cameraOrigin;

    private void Awake() {
        instance = this;
    }


    private void Start() {
        player = PlayerMovement.playerInstance;
        youDiedText.SetActive(false);
    }

    public void Kill() {
        totalKills++;
    }

    public void PlayerKilled() {
        player.transform.position = new Vector3(1000, player.transform.position.y, 1000);
        youDiedText.SetActive(true);
        /*
        foreach (EnemyAi ai in enemyAi) {
            ai.StopSearching();
        }
        */
        //CameraShake(0.1f, 0.5f);
    }

    public void CameraShake(float shakeAmount) {
        cameraOrigin = transform.position;
        CameraShake(shakeAmount, 0.3f);
    }

    public void CameraShake(float shakeAmount, float shakeTime) {
        shakeAmt = shakeAmount;
        InvokeRepeating("Shake", 0, 0.01f);
        Invoke("StopShake", shakeTime);
    }

    private void Shake() {
        if (shakeAmt > 0f) {
            Vector3 camPos = maincam.transform.position;
            float shakeX = Random.value * shakeAmt * 2 - shakeAmt;
            float shakeY = Random.value * shakeAmt * 2 - shakeAmt;
            camPos.x += shakeX;
            camPos.z += shakeY;

            maincam.transform.position = camPos;
        }
    }

    private void StopShake() {
        CancelInvoke("Shake");
        maincam.transform.position = cameraOrigin;
    }
}