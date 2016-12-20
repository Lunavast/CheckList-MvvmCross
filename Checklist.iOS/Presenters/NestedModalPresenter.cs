using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace Checklist.iOS.Presenters
{
	public class NestedModalPresenter : MvxIosViewPresenter
	{
		public NestedModalPresenter(UIApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
		}

		private readonly Stack<UIViewController> _modalViewControllers = new Stack<UIViewController>();

		protected override UIViewController CurrentTopViewController
		{
			get
			{
				return _modalViewControllers.FirstOrDefault() ?? MasterNavigationController.TopViewController;
			}
		}

		private UINavigationController CurrentNavigationController
		{
			get { return (CurrentTopViewController as UINavigationController) ?? MasterNavigationController; }
		}

		public override void Show(IMvxIosView view)
		{
			var viewControllerToShow = (UIViewController)view;

			if (view is IMvxModalIosView)
			{
				var newNav = new UINavigationController(viewControllerToShow);

				PresentModalViewController(newNav, true);

				return;
			}

			if (MasterNavigationController == null)
				ShowFirstView(viewControllerToShow);
			else
				CurrentNavigationController.PushViewController(viewControllerToShow, true);
		}

		public override bool PresentModalViewController(UIViewController viewController, bool animated)
		{
			CurrentNavigationController.PresentViewController(viewController, animated, null);

			_modalViewControllers.Push(viewController);

			return true;
		}
		public override void CloseModalViewController()
		{
			var currentNav = _modalViewControllers.Pop();

			currentNav.DismissViewController(true, null);
		}

		public override void Close(IMvxViewModel toClose)
		{
			if (_modalViewControllers.Any() && CurrentNavigationController.ViewControllers.Count() == 1)
			{
				CloseModalViewController();

				return;
			}

			CurrentNavigationController.PopViewController(true);
		}
	}
}
