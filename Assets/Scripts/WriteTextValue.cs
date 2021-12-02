using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteTextValue : MonoBehaviour
{
    [SerializeField]
    PlayerController2D controller2D;

    [SerializeField]
    PlayerEntity livingEntity;

    [SerializeField]
    AsteroidSpawner asteroidSpawner;


    TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller2D != null && livingEntity != null)
        {
            string velocity = controller2D.Velocity.ToString();
            string playerInput = controller2D.PlayerInput.ToString();
            string position = new Vector2(controller2D.transform.position.x, controller2D.transform.position.y).ToString();
            string currentHp = livingEntity.CurrentHP.ToString();
            string aliveTime = livingEntity.AliveTime.ToString("0.00");
            string asteroidsKilled = asteroidSpawner.AsteroidsKilled.ToString();
            string totalScore = (((livingEntity.AliveTime * livingEntity.AliveTime) * 0.1) + asteroidSpawner.AsteroidsKilled * 100).ToString("0");
            //text.SetText("Velocity: " + velocity + "\nInput: " + playerInput + "\nPosition: " + position + "\nHP: " + currentHp + "\nAlive Time: " + aliveTime + "\nAsteroids Killed: " + asteroidsKilled + "\nScore: " + totalScore);
            text.SetText("HP: " + currentHp + "\nAlive Time: " + aliveTime + "\nAsteroids Killed: " + asteroidsKilled + "\nScore: " + totalScore);
        }
            
    }
}
