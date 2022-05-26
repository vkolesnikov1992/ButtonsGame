using Source.Infrastructure.Data;
using Source.Infrastructure.Mono;
using Source.Infrastructure.Services;
using UnityEngine;

namespace Source.Infrastructure.GameLogic
{
	public class ButtonsGame
	{
		private readonly IViewService _viewService;
		private readonly IMonobehaviourService _monobehaviourService;

		private const string DataPath = "Data/GameSettings";
		private GameSettings _gameSettings;
		private CanvasView _canvasView;
		private ButtonView _buttonView;
		private ButtonView[] _buttonViews;

		public ButtonsGame(IViewService viewService, IMonobehaviourService monobehaviourService)
		{
			_viewService = viewService;
			_monobehaviourService = monobehaviourService;
			
			StartGame();
		}

		private void StartGame()
		{
			LoadResources();
			SetNewCellSize();
			CreateButtons();
		}

		private void LoadResources()
		{
			_gameSettings = _monobehaviourService.LoadScriptableObject<GameSettings>(DataPath);

			_canvasView = Object.Instantiate(_viewService.LoadView<CanvasView>());

			_buttonView = _viewService.LoadView<ButtonView>();
		}

		private void CreateButtons()
		{
			_buttonViews = new ButtonView[_gameSettings.ButtonsCount];


			for(int i = 0; i < _buttonViews.Length; i++)
			{
				_buttonViews[i] = Object.Instantiate(_buttonView, _canvasView.GridLayoutGroup.transform);
				_buttonViews[i].OnButtonClicked += CheckButtons;
			}
		}

		private void SetNewCellSize()
		{
			const int maxWidthCount = 3;
			const int offset = 10;
			
			int lessScreenValue = Screen.width > Screen.height ? Screen.height : Screen.width;
			int currentOffset = offset * maxWidthCount + offset;
			int cellSize = (lessScreenValue - currentOffset) / maxWidthCount;

			_canvasView.GridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
		}

		

		private void CheckButtons(int clickCount)
		{
			if(clickCount < _gameSettings.ButtonsCount)
			{
				return;
			}

			foreach(ButtonView buttonView in _buttonViews)
			{
				buttonView.CLick();
			}
		}
	}
}