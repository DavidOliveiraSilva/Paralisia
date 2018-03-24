using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
		public int delay = 1;
		private Vector3 offset;
		public float distance = 3;

        private void FixedUpdate()
        {
			transform.position = new Vector3 ((transform.position.x * delay + target.position.x) / (delay + 1.0f), 
				(transform.position.y * delay + target.position.y) / (delay + 1.0f), transform.position.z);

		}
    }
}
