namespace TwistedCloud.UI {

	class SelectListInterop {

		public componentMethodExample(dialogId: string) {

		}

	}


	export function AttachSelectListInterop(): void {
		window['SelectListInterop'] = new SelectListInterop;
	}
}

TwistedCloud.UI.AttachSelectListInterop();