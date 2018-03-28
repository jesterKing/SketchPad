namespace SketchPad
{
	public class SketchPadPlugIn : Rhino.PlugIns.PlugIn
	{
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