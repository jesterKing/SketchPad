using Rhino;
using Rhino.PlugIns;

namespace SketchPad
{
	public class SketchPadPlugIn : Rhino.PlugIns.PlugIn
	{
		public override PlugInLoadTime LoadTime => PlugInLoadTime.AtStartup;

		protected override LoadReturnCode OnLoad(ref string errorMessage)
		{
			//Rhino.Render.CustomRenderMeshProvider2.RegisterProviders(Assembly, Id);
			return base.OnLoad(ref errorMessage);
		}

		public static DocumentCollectedExceptionConduit SPCond { get; private set; }
		public SketchPadPlugIn()
		{
			if (Instance == null)
			{
				Instance = this;
				SPCond = new DocumentCollectedExceptionConduit
				{
					Enabled = false
				};
			}
		}

		public static SketchPadPlugIn Instance
		{
			get; private set;
		}
	}
}