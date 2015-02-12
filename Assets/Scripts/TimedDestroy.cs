using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimedDestroy : MonoBehaviour {

	public float duration;
	public float fadeDuration;
	public bool isEndGame;
	public bool isStartGame;
	
	private CanvasGroup cg;
	private Text text;

	void Start() {
		cg = GetComponent<CanvasGroup>();
		text = GetComponentInChildren<Text>();
		
		if(isStartGame)
			StartCoroutine(FadeOut());
		else
			StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn() {
		while(cg.alpha < 1.0f) {
			cg.alpha += fadeDuration * Time.deltaTime;
			
			if(cg.alpha > 1.0f)
				cg.alpha = 1.0f;
				
			yield return null;
		}
		StartCoroutine(Countdown());
	}

	IEnumerator Countdown() {
		while(duration > 0) {
			duration -= Time.deltaTime;
			yield return null;
		}
		if(isEndGame)
			StartCoroutine(GameOver());
		else
			StartCoroutine(FadeOut());
	}
	
	IEnumerator FadeOut() {
		while(cg.alpha > 0) {
			cg.alpha -= fadeDuration * Time.deltaTime;
			yield return null;
		}
		Destroy(gameObject);
	}
	
	IEnumerator GameOver() {
		while(text.color.a > 0) {
			Color next = text.color;
			next.a -= fadeDuration * Time.deltaTime;
			text.color = next;
			yield return null;
		}
		Application.LoadLevel("Menu");
	}
}
