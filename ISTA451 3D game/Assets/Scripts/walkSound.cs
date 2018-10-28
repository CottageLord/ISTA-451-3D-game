using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.CharacterController
{
	public class walkSound : MonoBehaviour {

		public Animator player;
		public AudioClip[] clips;
		public AudioSource footstepsSource;
		public float footstepInterval = 0.5f;
		public Rigidbody walker;
		
		int lastFootstep = -1;

		public void Start() {
			StartCoroutine( PlayFootsteps() );
		}

		public void Update() {
			if(player.GetBool("reset")) {
				StartCoroutine( PlayFootsteps() );
				player.SetBool("reset", false);
			}
		}
		IEnumerator PlayFootsteps() {
			while( enabled ) {
				float moveSpeed = walker.velocity.magnitude;
				
				if(walker.velocity.magnitude > 3.5) {
					footstepInterval = 0.25f;
				} else {
					footstepInterval = 0.5f;
				}
				if(walker.velocity.magnitude > 1 && player.GetBool("IsGrounded")) {
					int randomFootstep = lastFootstep;
					while( randomFootstep == lastFootstep ) {
						randomFootstep = Random.Range( 0, clips.Length );
					}
					lastFootstep = randomFootstep;

					footstepsSource.clip = clips[randomFootstep];
					footstepsSource.Play();
				} else {
					footstepsSource.Stop();
				}
				yield return new WaitForSeconds( footstepInterval );
			}
		}
	}
}