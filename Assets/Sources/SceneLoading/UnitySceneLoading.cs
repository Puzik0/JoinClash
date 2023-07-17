using System.Threading.Tasks;
using Extensions;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
	public class UnitySceneLoading : IAsyncSceneLoading
	{
		public async Task LoadAsync(Scene scene)
		{
			await SceneManager.LoadSceneAsync(scene.Name, scene.LoadMode);
		}

		public async Task UnloadAsync(Scene scene)
		{
			await SceneManager.UnloadSceneAsync(scene.Name);
		}
	}
}