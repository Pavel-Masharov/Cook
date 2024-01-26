using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		FoodPlace _place = null;
		float     _timer = 0f;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			float timeBtwTime = 0.5f;
			if( Time.realtimeSinceStartup - _timer < timeBtwTime ) {
				var food = _place.CurFood;
				if ( food == null ) {
					return;
				}

				if ( food.CurStatus == Food.FoodStatus.Overcooked ) {
					_place.FreePlace();
				}
			}
			else {
				_timer = Time.realtimeSinceStartup;
			}
		}
	}
}
