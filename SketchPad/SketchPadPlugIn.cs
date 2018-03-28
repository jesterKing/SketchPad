namespace SketchPad
{
	public class SketchPadPlugIn : Rhino.PlugIns.PlugIn
	{
		public static SPConduit SPCond { get; private set; }
		public SketchPadPlugIn()
		{
			if (Instance == null)
			{
				Instance = this;
				SPCond = new SPConduit
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