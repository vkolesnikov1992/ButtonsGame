using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Infrastructure.Mono
{
	public class ButtonView : View
	{
		[SerializeField] private Button _button;
		[SerializeField] private Text _buttonText;

		private int _clickCounter;
		
		public event Action<int> OnButtonClicked; 

		private void Awake()
		{
			_button.onClick.AddListener(CLick);
		}

		public void CLick()
		{
			_clickCounter++;

			bool isBlackColor = _clickCounter % 2 != 0;

			_buttonText.color = isBlackColor ? Color.black : Color.white;
			_button.image.color = !isBlackColor ? Color.black : Color.white;

			int telephoneFormatValue = _clickCounter % 10;
			
			_buttonText.text = $"{telephoneFormatValue}";
			
			OnButtonClicked?.Invoke(telephoneFormatValue);
		}
	}
}