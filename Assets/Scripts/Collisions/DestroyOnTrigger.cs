using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers with the given tag.
 * using enemy counter to know if player won the lvl or we should reload same one
 */


public class DestroyOnTrigger : MonoBehaviour {

    [SerializeField] private TMPro.TextMeshPro winnerText;

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            EnemyCounter.setCount(0);
            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else {   
            EnemyCounter.EnemyDie();


            nextLevel();
            Destroy(other.gameObject);
        }

    }

    private void nextLevel() {

            if (EnemyCounter.getCount() == 0)
            {

                Debug.Log("enemy died");
                EnemyCounter.setCount(0);

            if (SceneManager.GetActiveScene().buildIndex < 4)
                {
                    Debug.Log("new scene");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    Debug.Log("win");
                    // player won
                    Time.timeScale = 0;
                    winnerText.text = "You win \n Great Job!";
                }
            }

        }

}
