using Rhino;
using Rhino.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SketchPad.Commands
{
	public class FunkyException:Exception {}

	public class TestCauseFunkyException : Command
	{
		public override string EnglishName => "TestCauseFunkyException";

		protected override Result RunCommand(RhinoDoc doc, RunMode mode)
		{
			throw new FunkyException();
		}
	}
}
