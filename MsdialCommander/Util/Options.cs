//
//  Options.cs
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
using System;
using CommandLine;
using CommandLine.Text;

namespace Fiehnlab.MsdialCommander.Util {
	public class Options {
		[Option('f', "file", HelpText = "Full path of the file to process.", MutuallyExclusiveSet="input")]
		public string File { get; set; }

		[Option ('d', "folder", HelpText = "The folder containing all the files to process.", MutuallyExclusiveSet="input")]
		public string Folder { get; set; }

		[Option('p', "parameters", Required = true, HelpText = "The Path of the file that contains the parameters for the analisys.")]
		public string Params { get; set; }

		[ParserState]
		public IParserState LastParserState { get; set; }

		[HelpOption]
		public string GetUsage()
		{
			var help = new HelpText () {
				Heading = new HeadingInfo("MsDial Commander", "ver 1.0a"),
				AdditionalNewLineAfterOption = false,
				AddDashesToOption = true
			};

			if (this.LastParserState.Errors.Count > 0)
			{
				var errors = help.RenderParsingErrorsText(this, 2); // indent with two spaces
				if (!string.IsNullOrEmpty(errors))
				{
					help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR(S):"));
					help.AddPreOptionsLine(errors);
				}
			}

			help.AddOptions(this);
			help.AddPostOptionsLine(string.Format("Usage: launcher < -f file.abf | -d folder > -p params.txt{0}", Environment.NewLine));

			return help;
		}
	}
}

