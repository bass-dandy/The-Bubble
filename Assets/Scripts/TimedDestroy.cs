using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimedDestroy : MonoBehaviour {

	public float duration;
	public float fadeDuration;
	private CanvasGroup cg;

	void Start() {
		cg = GetComponent<CanvasGroup>();
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn() {
		while(cg.alpha < 1.0f) {
			cg.alpha += fadeDuration * Time.deltaTime;
			yield return null;
		}
		cg.alpha = 1.0f;
		StartCoroutine(Countdown());
	}

	IEnumerator Countdown() {
		while(duration > 0) {
			duration -= Time.deltaTime;
			yield return null;
		}
		StartCoroutine(FadeOut());
	}
	
	IEnumerator FadeOut() {
		while(cg.alpha > 0) {
			cg.alpha -= fadeDuration * Time.deltaTime;
			yield return null;
		}
		Destroy(gameObject);
	}
}
