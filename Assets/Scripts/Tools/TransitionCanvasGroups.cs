using System.Linq;
using UnityEngine;
using System;

namespace ZHTgames.DanzaCultura.Components{
	///<summary>
	///Class in charge of making transitions to canvas group
	///</summary>
	public class TransitionCanvasGroups: MonoBehaviour {

		#region Consts
		///<summary>
		///Constant float value to reference the zero alpha value
		///</summary>
		private const float Invisible = 0f;
		#endregion

		private void OnDestroy() {
			LeanTween.cancel(this.gameObject);
		}

		///<summary>
		///Makes a single CanvasGroup transition.
		///If go to 0 the interactable are disable automatically from the begining.
		///If go to 1 the interactable are activate after the time transition.
		///</summary>
		///<param name="canvasGroup">The canvas group to transition.</param>
		///<param name="to">The final alpha value (0-1).</param>
		///<param name="time">The time with which to fade the object. Default time = 0.3f</param>
		public static void AlphaCanvas(CanvasGroup canvasGroup, float to, float time, Action callback = null){
			if(time == 0f){
				canvasGroup.alpha 			= 0f;
				canvasGroup.interactable 	= false;
				canvasGroup.blocksRaycasts 	= false;
				callback?.Invoke();
				return;
			}

			if(LeanTween.isTweening(canvasGroup.gameObject)){
				LeanTween.cancel(canvasGroup.gameObject);
			}
			
			LeanTween.value(canvasGroup.gameObject, canvasGroup.alpha, to, time)
			.setOnStart(()=>{
				canvasGroup.interactable 	= false;
				canvasGroup.blocksRaycasts 	= false;

			}).setOnUpdate((value)=> {
				if(canvasGroup != null) canvasGroup.alpha = value;
				else LeanTween.cancel(canvasGroup.gameObject);

			}).setOnComplete(()=> {
				if(canvasGroup.alpha != 0){
					canvasGroup.interactable 	= true;
					canvasGroup.blocksRaycasts 	= true;
				}
				callback?.Invoke();
			});
		}

		///<summary>
		///Makes a transition to a canvas group array, and show an specific canvas referenced
		///</summary>
		///<param name="allCanvasGroup">A canvas group array of all canvas references to transition.<param>
		///<param name="specificCanvasGroup">The specific canvas group to transition. The rest fade out.<param>
		///<param name="to">The final alpha value (0-1). Default to = 1f<param>
		///<param name="time">The time with which to fade the object. Default time = 0.3f<param>
		public static void SpecificAlphaCanvas(CanvasGroup[] allCanvas, CanvasGroup specificCanvasGroup, float to = 1f, float time = 0.3f, Action callback = null){
			allCanvas.ToList().ForEach( canvas => AlphaCanvas(
				(canvas.name == specificCanvasGroup.name)? specificCanvasGroup : canvas,
				(canvas.name == specificCanvasGroup.name)? to : Invisible,
				time,
				()=> callback?.Invoke()
			));
		}

		///<summary>
		///Makes invisible all the canvas referenced.
		///</summary>
		///<param name="allCanvas">A canvas group array to transition.</param>
		///<param name="time">The time with which to fade the object. Default time = 0.3f</param>
		public static void InvisibleAllCanvas(CanvasGroup[] allCanvas, float time = 0.3f, Action callback = null){
			allCanvas.ToList().ForEach( 
				canvas => AlphaCanvas( canvas, Invisible, time, ()=> callback?.Invoke()));
		}
	}
}