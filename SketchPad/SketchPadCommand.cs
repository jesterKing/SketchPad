using Rhino;
using Rhino.Commands;

namespace SketchPad
{
	public class SketchPadCommand : Command
	{
		public SketchPadCommand()
		{
			Instance = this;
		}

		public static SketchPadCommand Instance
		{
			get; private set;
		}

		public override string EnglishName
		{
			get { return "SketchPadCommand"; }
		}

		protected override Result RunCommand(RhinoDoc doc, RunMode mode)
		{
			SketchPadPlugIn.SPCond.Enabled = !SketchPadPlugIn.SPCond.Enabled;
			DocumentCollectedExceptionCRMProvider dcecrm = new DocumentCollectedExceptionCRMProvider();

			return Result.Success;
		}
	}
}
