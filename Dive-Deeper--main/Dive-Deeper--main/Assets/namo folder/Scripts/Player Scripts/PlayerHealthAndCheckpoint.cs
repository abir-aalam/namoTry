using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
	

public class PlayerHealthAndCheckpoint : MonoBehaviour
{

	

    //----------- Checkpoint Vars
    public Transform[] CheckPoints;
    public int CheckpointNum;

    //----------- Health Vars
    public int lives = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject gameOver_panel;

    // We can seperate game over lines in other script by making the var "lives" as static


    

    #region Collision and Trigger

    void OnCollisionEnter2D(Collision2D collision)
	{
        // Player touch Obstacle
		if (collision.gameObject.CompareTag("Obstacle"))
		{
            
            TakeDamage();
            TeleportToCheckpoint();
        }
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player touch Checkpoint
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            //
            //FindObjectOfType<SoundManager>().PlaySound("playerCheckpoint");
            //FindObjectOfType<SoundManager>().PlaySound("playerTakeBreath");

            //disable the circle collider of the check point
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;

            //Checkpoint passed
            CheckpointNum++;

        }
    }
    #endregion

    #region The Functions

    
    void TeleportToCheckpoint()
    {
        // Teleport the player into the right checkpoint
        transform.position = CheckPoints[CheckpointNum].position;
    }

    void TakeDamage()
    {
        //FindObjectOfType<SoundManager>().PlaySound("playerHurt");

        if (lives >= 0)
        {
            // lost one heart
            lives -= 1;
            // Replace the full heart with empty heart image (In the UI)
            hearts[lives].sprite = emptyHeart;

            // If player lost all his hearts so Game Over
            if (lives == 0)
            {
                GameOver();
            }
        }
        


    }

    void GameOver()
    {
        // Enable the GameOver panel
        gameOver_panel.gameObject.SetActive(true);
    }
    #endregion


}
