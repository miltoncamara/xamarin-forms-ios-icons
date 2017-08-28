using System.Collections.Generic;
using ios_native_icons.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(NavigationPageIconesCustomizado))]
namespace ios_native_icons.iOS
{
	public class NavigationPageIconesCustomizado : NavigationRenderer
	{
		public override void PushViewController(UIKit.UIViewController viewController, bool animated)
		{
			base.PushViewController(viewController, animated);
            this.AdicionarIconesNaBarradeFerramentas();
		}

		const string TOOLBAR_ADD = "adicionar";
		const string TOOLBAR_CAMERA = "camera";
		const string TOOLBAR_FAVORITOS = "favoritos";
		const string TOOLBAR_ATUALIZAR = "atualizar";

		/// <summary>
		/// Troca os textos pelos icones na barra de ferramentas
		/// </summary>
		private void AdicionarIconesNaBarradeFerramentas()
		{
			var listaIcones = new List<UIBarButtonItem>();

			foreach (var item in TopViewController.NavigationItem.RightBarButtonItems)
			{
				if (string.IsNullOrEmpty(item.Title))
				{
					continue;
				}

				if (item.Title.ToLower() == TOOLBAR_ADD)
				{
					var novoIcone = new UIBarButtonItem(UIBarButtonSystemItem.Add)
					{
						Action = item.Action,
						Target = item.Target
					};

					listaIcones.Add(novoIcone);
				}

				if (item.Title.ToLower() == TOOLBAR_CAMERA)
				{
					var newItem = new UIBarButtonItem(UIBarButtonSystemItem.Camera)
					{
						Action = item.Action,
						Target = item.Target
					};

					listaIcones.Add(newItem);
				}

				if (item.Title.ToLower() == TOOLBAR_FAVORITOS)
				{
					var newItem = new UIBarButtonItem(UIBarButtonSystemItem.Bookmarks)
					{
						Action = item.Action,
						Target = item.Target
					};

					listaIcones.Add(newItem);
				}

				if (item.Title.ToLower() == TOOLBAR_ATUALIZAR)
				{
					var newItem = new UIBarButtonItem(UIBarButtonSystemItem.Refresh)
					{
						Action = item.Action,
						Target = item.Target
					};

					listaIcones.Add(newItem);
				}

				TopViewController.NavigationItem.RightBarButtonItems = listaIcones.ToArray();
			}
		}
	}
}
