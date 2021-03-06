﻿//-----------------------------------------------------------------------
// <copyright file="GitErrorException.cs" company="(none)">
//  Copyright © 2011 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>
//-----------------------------------------------------------------------

namespace WebGitNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class GitErrorException : Exception
    {
        private readonly string command;
        private readonly int exitCode;
        private readonly string errorOutput;

        public GitErrorException(string command, string workingDir, int exitCode, string errorOutput)
            : base("Fatal error executing git command in '" + workingDir + "'." + Environment.NewLine + errorOutput)
        {
            this.command = command;
            this.exitCode = exitCode;
            this.errorOutput = errorOutput;
        }

        public string Command
        {
            get { return this.command; }
        }

        public int ExitCode
        {
            get { return this.exitCode; }
        }

        public string ErrorOutput
        {
            get { return this.errorOutput; }
        }
    }
}
