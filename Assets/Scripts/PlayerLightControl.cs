using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerLightControl : MonoBehaviour
{
    [SerializeField] private Light2D playerLight;

    private Light2D lamp;
    private BoxCollider2D lampCollider;

    [SerializeField] private TextMeshProUGUI scoreAmount;
    private int score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoodLamp"))
        {
            playerLight.shapeLightFalloffSize += 0.5f;

            lamp = collision.GetComponentInChildren<Light2D>();
            lampCollider = collision.GetComponentInChildren<BoxCollider2D>();

            if (lamp != null) {
                lamp.intensity = 0.1f;
                lampCollider.enabled = false;
            }
            score += 1;
            scoreAmount.text = "" + score;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BadLamp"))
        {
            playerLight.shapeLightFalloffSize -= 0.5f;

            lamp = collision.GetComponentInChildren<Light2D>();
            lampCollider = collision.GetComponentInChildren<BoxCollider2D>();

            if (lamp != null)
            {
                lamp.intensity = 0.1f;
                lampCollider.enabled = false;
            }
            score -= 1;
            scoreAmount.text = "" + score;
        }

        if(playerLight.shapeLightFalloffSize <= 1)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
