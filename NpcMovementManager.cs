using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class NpcMovementManager : MonoBehaviour
{
    [SerializeField] private List<Transform> wavePoints = new List<Transform>();
    private int currentWavePoint;
    private Vector2 moveTo;
    private float restTime;
    public bool isResting;
    private bool reverseWave;
    public float speed;
    private Rigidbody2D rb2D;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        restTime = Random.Range(2f, 5f);
    }

    private void Update()
    {
        if (isResting)
        {
            rb2D.velocity = Vector2.zero;
            restTime -= Time.deltaTime;
            if (!(restTime <= 0.1)) return;
            restTime = Random.Range(2f, 5f);
            if (currentWavePoint == wavePoints.Count - 1)
            {
                reverseWave = true;
            }
            else if(currentWavePoint == 0)
            {
                reverseWave = false;
            }

            if (reverseWave)
            {
                currentWavePoint -= 1;
            }
            else
            {
                currentWavePoint += 1;
            }
            moveTo = wavePoints[currentWavePoint].position - transform.position;
            isResting = false;
        }
        else
        {
            rb2D.velocity = moveTo * speed * Time.fixedDeltaTime;
        }
    }
}
