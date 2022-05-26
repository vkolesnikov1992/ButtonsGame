using Source.Infrastructure.Mono;

namespace Source.Infrastructure.Services
{
	public interface IViewService : IService
	{
		T LoadView<T>() where T : View;
	}
}