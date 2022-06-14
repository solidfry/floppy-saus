using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatManager : MonoBehaviour
{
    public List<AudioClip> clips;
    private AudioSource source;
    System.Random rand;

    private void OnEnable()
    {
        GameEvents.OnSplatCollisionEvent += PlayClip;
    }

    private void OnDisable()
    {
        GameEvents.OnSplatCollisionEvent -= PlayClip;
    }

    private void Start()
    {
        source = this.GetComponent<AudioSource>();
        rand = new System.Random(GetInstanceID());
    }

    void PlayClip()
    {
        int clipToPlay = rand.Next(0, clips.Count);
        source.clip = clips[clipToPlay];
        source.Play();
        //Debug.Log("Play audio clips of splat " + clips[clipToPlay]);
    }
}
