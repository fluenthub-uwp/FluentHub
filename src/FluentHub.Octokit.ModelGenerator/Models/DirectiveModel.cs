﻿// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

using System;
using System.Collections.Generic;
using Octokit.GraphQL.Core.Introspection;

namespace FluentHub.Octokit.ModelGenerator.Models
{
	public class DirectiveModel
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public IList<DirectiveLocation> Locations { get; set; }

		public IList<InputValueModel> Args { get; set; }
	}
}
