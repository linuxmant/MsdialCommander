//
//  Test.cs
//
//  Author:
//       Diego Pedrosa <dpedrosa@ucdavis.edu>
//
//  Copyright (c) 2016 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using NUnit.Framework;
using System;
using CommandLine;
using Fiehnlab.MsdialCommander.Logic;
using Fiehnlab.MsdialCommander.Util;

namespace Fiehnlab.MsdialCommander.UnitTests {
	[TestFixture()]
	public class CommanderTests {

		[Test()]
		public void CreateCommanderWithFileAndParamsOnly() {
			var options = new Options() {File = "data.abf", Params = "params.txt"};
			var cmd = new Commander(options);

			Assert.AreEqual(options.File, cmd.File);
			Assert.IsEmpty(cmd.Folder);
			Assert.AreEqual(options.Folder, cmd.ParamsFile);
		}


		[Test()]
		[ExpectedException(typeof(ArgumentException))]
		public void RunWithoutFileOrFolderThrowsException() {
			string[] args = {"-p", "params.txt"};
			Options options = new Options();

			Assert.IsTrue (CreateOptions(args, options));

			var cmd = new Commander(options);
		}

		private bool CreateOptions(string[] args, Options options) {
			return CommandLine.Parser.Default.ParseArguments(args, options);
		}
	}
}

