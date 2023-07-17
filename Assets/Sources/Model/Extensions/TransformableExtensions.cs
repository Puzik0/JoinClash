using System.Collections.Generic;
using System.Linq;
using Model.Transformables;

namespace Model.Extensions
{
	public static class TransformableExtensions
	{
		public static TTransformable ClosestTo<TTransformable>(this IEnumerable<TTransformable> entities, Transformable to) where TTransformable : Transformable
		{
			TTransformable closest = entities.First();

			foreach (TTransformable entity in entities)
			{
				if (SqrMagnitude(to, closest) > SqrMagnitude(to, entity))
					closest = entity;
			}
			
			return closest;

			float SqrMagnitude(Transformable a, Transformable b) => (a.Position - b.Position).sqrMagnitude;
		}
	}
}