using UnityEngine.SceneManagement;

namespace SceneLoading
{
	[System.Serializable]	
	public struct Scene
	{
		public string Name;
		public LoadSceneMode LoadMode;
	}
}