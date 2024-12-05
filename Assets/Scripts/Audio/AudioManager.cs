using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[Header("-------- Audio Source --------")]
	[SerializeField] AudioSource musicSource;
	[SerializeField] AudioSource SFXSource;

	[Header("-------- Audio Clip --------")]
	public AudioClip background;
	public AudioClip death;
	public AudioClip checkpoint;
	public AudioClip wallTouch; 
	public AudioClip PortalIn;
	public AudioClip PortalOut;

	private void Start()
	{
		musicSource.clip = background;
		musicSource.Play();
	}

	// Use this function we can play the sound effect we want
	public void PlaySFX(AudioClip clip)
	{
		SFXSource.PlayOneShot(clip);
	}

}
