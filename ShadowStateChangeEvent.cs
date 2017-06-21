// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using UnityEngine;
using ShadowDetect;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Shadow Detect")]
	[Tooltip("Bool changes to true / false when a shadow state has change. Both enter or exit.")]
	
	public class  ShadowStateChangeEvent : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(ShadowDetect.ShadowDetect))]    
		public FsmOwnerDefault gameObject;
		
		public FsmBool shadowCurrentState;
		

		private	ShadowDetect.ShadowDetect shadowEvent;
		
		public override void Reset()
		{
			
			gameObject = null;
			shadowCurrentState = false;
			
		}
		
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			
			shadowEvent = go.GetComponent<ShadowDetect.ShadowDetect>();
			if (shadowEvent == null)
			{
				shadowEvent = go.AddComponent<ShadowDetect.ShadowDetect>();
			}
			
			//		shadowEvent.OnChangeState.AddListener((bool value);
			shadowEvent.OnChangeState.AddListener ((value) => shadowState(value));
			
		}
		

		private void shadowState(bool isOn)
		{
			
			if(isOn){
				
				shadowCurrentState.Value = true;
				Debug.Log("Yes");
			}
			
			else {
				
				shadowCurrentState.Value = false;
				Debug.Log("No");
				
			}				
				
	
		}
		
	}
	
}
