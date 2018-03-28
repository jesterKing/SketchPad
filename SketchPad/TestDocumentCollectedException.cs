using Rhino;
using Rhino.Commands;

namespace SketchPad
{
	public class TestDocumentCollectedException : Command
	{
		public TestDocumentCollectedException()
		{
			Instance = this;
		}

		public static TestDocumentCollectedException Instance
		{
			get; private set;
		}

		public override string EnglishName
		{
			get { return "TestDocumentCollectedException"; }
		}

		protected override Result RunCommand(RhinoDoc doc, RunMode mode)
		{
			SketchPadPlugIn.SPCond.Enabled = !SketchPadPlugIn.SPCond.Enabled;

			return Result.Success;
		}
	}
}
