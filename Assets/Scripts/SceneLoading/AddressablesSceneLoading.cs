using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
	public class AddressablesSceneLoading : IAsyncSceneLoading
	{
		private readonly Dictionary<string, SceneInstance> _loadedScenes = new Dictionary<string, SceneInstance>();

		public async Task LoadAsync(Scene scene)
		{
			if (scene.LoadMode == LoadSceneMode.Single)
				_loadedScenes.Clear();

			SceneInstance sceneInstance = await Addressables.LoadSceneAsync(scene.Name, scene.LoadMode).Task;
			_loadedScenes.Add(scene.Name, sceneInstance);
		}

		public async Task UnloadAsync(Scene scene)
		{
			SceneInstance sceneToUnload = _loadedScenes[scene.Name];
			await Addressables.UnloadSceneAsync(sceneToUnload).Task;
		}
	}
}