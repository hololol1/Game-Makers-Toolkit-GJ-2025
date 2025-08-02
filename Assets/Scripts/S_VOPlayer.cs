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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("StartVOClip", firstVODelay);
    }

    void StartVOClip()
	{
        audioSourceKnock.Play();
        audioSource.clip = aiVoiceClips[Random.Range(0, aiVoiceClips.Count)];
        audioSource.Play();

        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Invoke("StartVOClip", spawnInterval);
    }

}
