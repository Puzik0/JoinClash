using UnityEngine;

namespace Sources.CompositeRoot.Extensions
{
	public static class ComponentExtensions
	{
		public static GameObject GoToParent(this Component component) => 
			component.transform.parent.gameObject;
	}
}