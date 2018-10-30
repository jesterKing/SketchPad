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
			RhinoDoc.NewDocument += RhinoDoc_NewDocument;
			return base.OnLoad(ref errorMessage);
		}

		private void RhinoDoc_NewDocument(object sender, DocumentEventArgs e)
		{
			RhinoApp.WriteLine($"SketchPad NewDocument: {e.DocumentSerialNumber}");
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