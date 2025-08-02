using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class S_UI : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
	[SerializeField]
	private TextMeshProUGUI timer;
	[SerializeField]
	private TextMeshProUGUI highScore;

	public S_CanOpenerLogic score;
    public Slider audioSlider;


	private float elapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float value;
        bool hasValue = audioMixer.GetFloat("Master", out value);
        if (hasValue)
        {
            audioSlider.value = Mathf.Pow(10, value / 20);
        }
    }

    // Update is called once per frame
    void Update()
    {
		//timer
		elapsedTime += Time.deltaTime;
		int minutes = Mathf.FloorToInt(elapsedTime / 60);
		int seconds = Mathf.FloorToInt(elapsedTime % 60);
		timer.text = string.Format("Canned time: {0:00}:{1:00}", minutes, seconds);

		//score
		highScore.text = string.Format("Canned cans: {0}", score.score);
	}

	public void SetVolume()
	{

		if (audioSlider.value == 0)
		{
			audioMixer.SetFloat("Master", -80);
		}
		else
		{
			audioMixer.SetFloat("Master", Mathf.Log10(audioSlider.value) * 20);
		}
	}

	public float GetMasterLevel()
	{
		float value;
		bool result = audioMixer.GetFloat("Master", out value);
		if (result)
		{
			return value;
		}
		else
		{
			return 0f;
		}
	}
}
