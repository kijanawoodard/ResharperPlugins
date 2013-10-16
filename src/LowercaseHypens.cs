using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace ResharperPlugins
{
	//https://github.com/markcapaldi/ReSharperMacros/blob/master/ReSharperMacros/TestFixtureVariableExpansionMacro.cs
	//https://github.com/joaroyen/ReSharperExtensions

	[Macro("CustomMacros.LowercaseHypens",
	  ShortDescription = "Value of {#0:another variable} to lowercase and spaces to hyphens",
	  LongDescription = "Take the value of {#0:another variable}, lowercase it, and replace spaces with hyphens")]
    public class LowercaseHypens : IMacro
    {
	    public string GetPlaceholder(IDocument document)
	    {
		    return "a";
	    }

	    public bool HandleExpansion(IHotspotContext context, IList<string> arguments)
	    {
		    return false;
	    }

	    public HotspotItems GetLookupItems(IHotspotContext context, IList<string> arguments)
	    {
		    return null;
	    }

	    public string EvaluateQuickResult(IHotspotContext context, IList<string> arguments)
	    {
			if (arguments.Count != 1 || arguments[0] == null) return null;

		    return arguments[0].ToLower().Replace(' ', '-');
	    }

		public ParameterInfo[] Parameters { get { return new[] { new ParameterInfo(ParameterType.VariableReference) }; } }
    }
}
