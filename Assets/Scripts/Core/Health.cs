using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
	private const int MAX_HEALTH = 3;
	public int health;
	public GameObject[] healthObjects;
	public TextMeshProUGUI healthText;

	private GodModeManager godModeManager;

	private AudioSource audioSource;

	public void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}
	public void Start()
	{
		godModeManager = FindObjectOfType<GodModeManager>();
		health = gameObject.CompareTag("Player") ? MAX_HEALTH : health;
		UpdateUI();
	}

	public void TakeDamage(int damage)
	{
		if (godModeManager.IsGodModeActive()) return;

		health -= damage;
		if (health <= 0)
		{
			Die();
		}
		UpdateUI();
		if (gameObject.CompareTag("Player"))
		{
			audioSource.Play();
		}

	}

	public void Heal(int heal)
	{
		health += heal;
		if (health > MAX_HEALTH)
		{
			health = MAX_HEALTH;
		}
		UpdateUI();
	}

	private void UpdateUI()
	{
		if (gameObject.CompareTag("Player"))
		{
			for (int i = 0; i < healthObjects.Length; i++)
			{
				if (i < health)
				{
					healthObjects[i].SetActive(true);
				}
				else
				{
					healthObjects[i].SetActive(false);
				}
			}
		}
		else
		{
			healthText.text = "Dummy HP : " + health.ToString();
		}
	}


	private void Die()
	{
		if (gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}

