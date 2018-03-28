using Rhino.Display;

namespace SketchPad
{
	public class SPConduit : DisplayConduit
	{

		protected override void PreDrawObject(DrawObjectEventArgs e)
		{
			try
			{
				if(e.RhinoObject.Geometry is Rhino.Geometry.Curve)
				{
					Rhino.RhinoApp.WriteLine("spconduit curve");
				}
			} catch(Rhino.Runtime.DocumentCollectedException)
			{
				Rhino.RhinoApp.WriteLine("exception");
			}

			base.PreDrawObject(e);
		}
	}
}
