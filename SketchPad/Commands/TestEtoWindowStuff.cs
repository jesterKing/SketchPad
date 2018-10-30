using Rhino;
using Rhino.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchPad.Commands
{

	public class TestEtoWindowStuff : Command
	{
		public override string EnglishName => "TestEtoWindowStuff";

		protected override Result RunCommand(RhinoDoc doc, RunMode mode)
		{
			var mw = Rhino.UI.RhinoEtoApp.MainWindow;
			RhinoApp.WriteLine($"{mw.Location}");
			RhinoApp.WriteLine($"{mw.Size}");
			mw.SizeChanged += MainWindow_SizeChanged;
			mw.LocationChanged += MainWindow_LocationChanged;
			var mwh = RhinoApp.MainWindowHandle();
			var ctrl = Rhino.UI.Runtime.PlatformServiceProvider.Service.GetEtoWindow(mwh);
			RhinoApp.WriteLine($"{ctrl.Location}");
			RhinoApp.WriteLine($"{ctrl.Size}");

			return Result.Success;
		}

		private void MainWindow_LocationChanged(object sender, EventArgs e)
		{
			RhinoApp.WriteLine($"{sender}");
			RhinoApp.WriteLine($"{Rhino.UI.RhinoEtoApp.MainWindow.Location}");
			RhinoApp.WriteLine($"{Rhino.UI.RhinoEtoApp.MainWindow.Size}");
		}

		private void MainWindow_SizeChanged(object sender, EventArgs e)
		{
			RhinoApp.WriteLine($"{sender}");
			RhinoApp.WriteLine($"{Rhino.UI.RhinoEtoApp.MainWindow.Location}");
			RhinoApp.WriteLine($"{Rhino.UI.RhinoEtoApp.MainWindow.Size}");
		}
	}
}
