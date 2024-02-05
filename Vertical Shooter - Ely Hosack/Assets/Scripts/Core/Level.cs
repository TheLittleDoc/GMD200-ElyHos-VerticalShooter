using UnityEngine;

public class Level
{
    public static int MAX_STARS = 3;
    public static int MAX_SCORE = 500000;
    public static int HEALTH_BONUS = 1000;
    public int finalHealth, finalShots, finalHits, finalScore, stars, targetEnemies;
    public float accuracy;

    //constructor
    public Level(int finalHealth, int finalShots, int finalHits, int targetEnemies)
    {
        this.finalHealth = finalHealth;
        this.finalShots = finalShots;
        this.finalHits = finalHits;
        this.targetEnemies = targetEnemies;
        this.accuracy = ((float)finalHits / (float)finalShots);

        this.finalScore = (int)((finalHealth * HEALTH_BONUS) + (accuracy * MAX_SCORE) + ((finalHits / targetEnemies) * 10000));
        this.stars = (finalScore / (MAX_SCORE / MAX_STARS));

        Debug.Log("Score: " + finalScore + " Stars: " + stars + "\nAccuracy: " + accuracy);
    }
}