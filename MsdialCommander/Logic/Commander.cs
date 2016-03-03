//
//  Commander.cs
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
using Fiehnlab.MsdialCommander.Util;
using System.IO;

namespace Fiehnlab.MsdialCommander.Logic {
	public class Commander {
		private string folder;
		private string file;
		private string paramsFile;
		private ProcessMode mode;

		public string File { get; set; }
		public string Folder { get; set; }
		public string ParamsFile { get; set; }

		public Commander (Options args) {
			file = args.File;
			folder = args.Folder;
			paramsFile = args.Params;

			if(!string.IsNullOrEmpty (file)) {
				if(!string.IsNullOrEmpty (folder)) {
					mode = ProcessMode.Mixed;
				} else {
					mode = ProcessMode.File;
				}
			} else {
				if(!string.IsNullOrEmpty (folder)) {
					mode = ProcessMode.Folder;
				} else {
					throw new ArgumentException ("Invalid options. Need a file or a folder or both.");
				}
			}
		}

		public MsdialResult process() {
			Console.WriteLine ("processing...");

			return new MsdialResult();
		}
	}
}

