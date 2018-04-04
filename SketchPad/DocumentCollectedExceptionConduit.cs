using Rhino.Display;

namespace SketchPad
{
	public class DocumentCollectedExceptionConduit : DisplayConduit
	{

		private bool done = false;
		protected override void PreDrawObject(DrawObjectEventArgs e)
		{
			if (!done)
			{
				try
				{
					if (e.RhinoObject.Geometry is Rhino.Geometry.Mesh)
					{
						if (!done) Rhino.RhinoApp.WriteLine("predrawob mesh");
					}
				}
				catch (Rhino.Runtime.DocumentCollectedException)
				{
					if (!done) Rhino.RhinoApp.WriteLine("DisplayConduit DocumentCollectedEcxeption");
				}
				if (!done) done = true;
			}

			//base.PreDrawObject(e);
		}
	}
}
