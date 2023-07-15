using System.Threading.Tasks;

namespace SceneLoading
{
	public interface IAsyncSceneLoading
	{
		Task LoadAsync(Scene scene);
		Task UnloadAsync(Scene scene);
	}
}