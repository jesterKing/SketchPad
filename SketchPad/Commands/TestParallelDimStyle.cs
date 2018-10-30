using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchPad.Commands
{

	public class TestParallelDimStyle : Command
	{
		public override string EnglishName => "TestParallelDimStyle";

		protected override Result RunCommand(RhinoDoc doc, RunMode mode)
		{
			DimensionStyle ds = doc.DimStyles.BuiltInStyles[0];
			Parallel.For(int.MinValue, int.MaxValue, x => DoDimStyle(x, ds));
			return Result.Success;
		}

		private void DoDimStyle(int i, DimensionStyle ds)
		{
			using (var x = ds.Duplicate())
			{
				if (i % 10000 == 0) RhinoApp.WriteLine($"{i}");
			}
		}
	}
}
