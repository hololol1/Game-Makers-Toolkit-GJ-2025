using UnityEngine;
using System.Collections.Generic;
public class S_VOPlayer : MonoBehaviour
{
    public float firstVODelay;
    public float spawnIntervalMin = 25;
    public float spawnIntervalMax = 40;
    private float spawnInterval;

    public List<AudioClip> aiVoiceClips = new List<AudioClip>();
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource audioSourceKnock;

    [SerializeField]
    private Animator animator;
    public List<string> animNames = new List<string>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("StartVOClip", firstVODelay);
    }

	void StartVOClip()
	{
        animator.Play(animNames[Random.Range(0, animNames.Count)], -1, 0f);
        audioSourceKnock.Play();
        audioSource.clip = aiVoiceClips[Random.Range(0, aiVoiceClips.Count)];
        audioSource.Play();

        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Invoke("StartVOClip", spawnInterval);
    }

}
