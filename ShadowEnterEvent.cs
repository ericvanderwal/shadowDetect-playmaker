// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using UnityEngine;
using ShadowDetect;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Shadow Detect")]
	[Tooltip("Triggers an event when a shadow has been entered")]
	
	public class  ShadowEnterEvent : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(ShadowDetect.ShadowDetect))]    
		public FsmOwnerDefault gameObject;
		
		[TitleAttribute("Shadow Enter Event")]
		public FsmEvent sendEvent;
		
		
		private	ShadowDetect.ShadowDetect shadowEvent;
		
		public override void Reset()
		{
			
			gameObject = null;
			
		}
		
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			
			shadowEvent = go.GetComponent<ShadowDetect.ShadowDetect>();
			if (shadowEvent == null)
			{
				shadowEvent = go.AddComponent<ShadowDetect.ShadowDetect>();
			}
			
			shadowEvent.OnEnterShadow.AddListener(enteredShadow);
			
		}
		
		public override void OnExit()
		{
			
			shadowEvent.OnEnterShadow.RemoveListener(enteredShadow);
			
		}
		
		private void enteredShadow()
		{
			
			Fsm.Event(sendEvent);	
			
		}
		
	}
	
}
