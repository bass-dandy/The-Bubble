using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	public float singleNoteFadeY;
	
	public float heavyDootStartFadeY;
	public float heavyDootFadeY;
	
	public float piano1StartFadeY;
	public float piano1FadeY;
	
	public float piano2StartFadeY;
	public float piano2FadeY;
	
	public Transform camera;

	public AudioSource doot;
	public AudioSource eDrums;
	public AudioSource heavyDoot;
	public AudioSource heavyShit;
	public AudioSource mellowArp;
	public AudioSource ocean;
	public AudioSource piano1;
	public AudioSource piano2;
	public AudioSource prechorus;
	public AudioSource realDrums;
	public AudioSource singleNote;
	public AudioSource wavesBegin;
	public AudioSource wavesEnd;
	public AudioSource wubs;
	
	public int state = 0;

	void Start () {
		Play();
		ocean.volume = 0.0f;
		wubs.volume = 0.0f;
		StartCoroutine(Begin());
		InvokeRepeating("Play", 9.6f, 9.6f);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			Advance();
		
		// Handle position-based fade-ins
		switch(state) {
			case 0: 
				doot.volume = camera.position.y / singleNoteFadeY;
				eDrums.volume = camera.position.y / singleNoteFadeY * 3;
				singleNote.volume = camera.position.y / (singleNoteFadeY * 3);
				break;
			case 4:
				heavyDoot.volume = (camera.position.y - heavyDootStartFadeY) / (heavyDootFadeY - heavyDootStartFadeY);
				piano1.volume = (camera.position.y - piano1StartFadeY) / (piano1FadeY - piano1StartFadeY);
				piano2.volume = (camera.position.y - piano2StartFadeY) / (piano2FadeY - piano2StartFadeY);
				break;
		}
	}
	
	void Play() {
		switch(state) {
			case 0:
				ocean.Play();
				wubs.Play();
				doot.Play();
				eDrums.Play();
				singleNote.Play();
				break;
			case 1:
				ocean.Play();
				doot.Play();
				wubs.Play();
				eDrums.Play();
				singleNote.Play();
				mellowArp.Play();
				break;
			case 2:
				ocean.Play();
				wubs.Play();
				realDrums.Play();
				prechorus.Play();
				break;
			case 3:
				ocean.Play();
				wubs.Play();
				realDrums.Play();
				prechorus.Play();
				wavesBegin.Play();
				Advance();
				break;
			case 4:
			case 5:
				heavyShit.Play();
				heavyDoot.Play();
				piano1.Play();
				piano2.Play();
				break;
		}
	}
	
	public void Advance() {
		state++;
		if(state > 4)
			StartCoroutine(End ());
	}
	
	IEnumerator Begin() {
		while(ocean.volume < 1.0f) {
			ocean.volume += Time.deltaTime / 2;
			yield return null;
		}
		while(wubs.volume < 1.0f) {
			wubs.volume += Time.deltaTime / 8;
			yield return null;
		}
	}
	
	IEnumerator End() {
		while(heavyShit.volume > 0) {
			heavyShit.volume -= Time.deltaTime / 4;
			heavyDoot.volume -= Time.deltaTime / 4;
			piano1.volume -= Time.deltaTime / 4;
			yield return null;
		}
		while(piano2.volume > 0) {
			piano2.volume -= Time.deltaTime / 8;
			yield return null;
		}
	}
}
