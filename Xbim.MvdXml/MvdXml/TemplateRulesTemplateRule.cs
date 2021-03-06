﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xbim.MvdXml.Validation;

// ReSharper disable once CheckNamespace
namespace Xbim.MvdXml
{
    public partial class TemplateRulesTemplateRule : ITemplateRule
    {
        IEnumerable<MvdPropertyRuleValue> ITemplateRule.RecursiveProperiesRuleValues()
        {
            return MvdPropertyRuleValue.GetValues(Parameters);
        }

        bool ITemplateRule.PassesOn(DataTable ret)
        {
            var thisLevelVal = MvdPropertyRuleValue.BuildSql(Parameters);
            var v = ret.Select(thisLevelVal).Any();
            return v;
        }
    }
}
