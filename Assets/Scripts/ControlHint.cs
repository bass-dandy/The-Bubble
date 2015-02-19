using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlHint : MonoBehaviour {

	public float duration;

	private CanvasGroup controls;
	private float elapsed;

	void Start() {
		controls = GetComponent<CanvasGroup>();
		elapsed = 0.0f;
	}

	void Show() {
		StartCoroutine(FadeIn());
	}
	
	IEnumerator FadeIn() {
		while(controls.alpha < 1.0f) {
			controls.alpha += Time.deltaTime;
			
			if(controls.alpha > 1.0f)
				controls.alpha = 1.0f;
				
			yield return null;
		}
		while(elapsed < duration) {
			elapsed += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(FadeOut());
	}
	
	IEnumerator FadeOut() {
		while(controls.alpha > 0.0f) {
			controls.alpha -= Time.deltaTime;
			
			if(controls.alpha < 0.0f)
				controls.alpha = 0.0f;
			
			yield return null;
		}
	}
}
