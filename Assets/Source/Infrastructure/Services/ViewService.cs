using Source.Infrastructure.Mono;

namespace Source.Infrastructure.Services
{
	public class ViewService : IViewService
	{
		private readonly IMonobehaviourService _monobehaviourService;
		private const string ViewPath = "ViewContainer";

		public ViewService(IMonobehaviourService monobehaviourService)
		{
			_monobehaviourService = monobehaviourService;
		}

		public T LoadView<T>() where T : View
		{
			var view = _monobehaviourService.ResourcesLoad<T>(ViewPath);
			
			return view;
		}
	}
}