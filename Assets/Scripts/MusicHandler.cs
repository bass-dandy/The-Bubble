using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	public float celloStartFade;
	public float celloEndFade;
	
	public float chordStartFade;
	public float chordEndFade;
	
	public float piano1StartFadeY;
	public float piano1FadeY;
	
	public float piano2StartFadeY;
	public float piano2FadeY;
	
	public Transform camera;

	public AudioSource arpCelloBeat;
	public AudioSource cello;
	public AudioSource heavyShit;
	public AudioSource piano1;
	public AudioSource piano2;
	public AudioSource prechorus;
	public AudioSource prechorusChord;
	public AudioSource transition;
	public AudioSource wubDoot;
	public AudioSource wubDootDrums;
	public AudioSource wubDootDrumsArp;
	
	public int state = 0;

	void Start () {
		Play();
		wubDoot.volume = 0.0f;
		StartCoroutine(Begin());
		InvokeRepeating("Play", 9.6f, 9.6f);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			Advance();
		
		// Handle position-based fade-ins
		switch(state) {
			case 2: 
				cello.volume = (camera.position.y - celloStartFade) / (celloEndFade - celloStartFade);
				break;
			case 4:
				prechorusChord.volume = (camera.position.y - chordStartFade) / (chordEndFade - chordStartFade);
				break;
			case 6:
				piano1.volume = (camera.position.y - piano1StartFadeY) / (piano1FadeY - piano1StartFadeY);
				piano2.volume = (camera.position.y - piano2StartFadeY) / (piano2FadeY - piano2StartFadeY);
				break;
		}
	}
	
	void Play() {
		switch(state) {
			case 0:
				wubDoot.Play();
				break;
			case 1:
				wubDootDrums.Play();
				break;
			case 2:
				wubDootDrumsArp.Play();
				cello.Play();
				break;
			case 3:
				arpCelloBeat.Play();
				break;
			case 4:
				prechorus.Play();
				prechorusChord.Play();
				break;
			case 5:
				transition.Play();
				Advance();
				break;
			default:
				heavyShit.Play();
				piano1.Play();
				piano2.Play();
				break;
		}
	}
	
	public void Advance() {
		state++;
		if(state > 6)
			StartCoroutine(End ());
	}
	
	IEnumerator Begin() {
		while(wubDoot.volume < 1.0f) {
			wubDoot.volume += Time.deltaTime / 2;
			yield return null;
		}
	}
	
	IEnumerator End() {
		while(heavyShit.volume > 0) {
			heavyShit.volume -= Time.deltaTime / 4;
			piano1.volume -= Time.deltaTime / 4;
			yield return null;
		}
		while(piano2.volume > 0) {
			piano2.volume -= Time.deltaTime / 8;
			yield return null;
		}
	}
}
