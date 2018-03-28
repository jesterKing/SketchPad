using Rhino.Display;

namespace SketchPad
{
	public class DocumentCollectedExceptionConduit : DisplayConduit
	{

		protected override void PreDrawObject(DrawObjectEventArgs e)
		{
			try
			{
				if(e.RhinoObject.Geometry is Rhino.Geometry.Curve)
				{
					Rhino.RhinoApp.WriteLine("curve");
				}
			} catch(Rhino.Runtime.DocumentCollectedException)
			{
				Rhino.RhinoApp.WriteLine("DisplayConduit DocumentCollectedEcxeption");
			}

			base.PreDrawObject(e);
		}
	}
}
