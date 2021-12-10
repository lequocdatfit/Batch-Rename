﻿using RenameRuleContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BatchRename
{
    public class RegexRule : IRenameRule
    {
        public string Pattern { get; set; }
        public string Value { get; set; }

        public string Name => "Regex";

        public RegexRule()
        {
            Pattern = "";
            Value = "";
        }
        public RegexRule(string regex, string value)
        {
            Pattern = regex;
            Value = value;
        }

        public bool SetAttribute(string key, object value)
        {
            if (value == null) return false;
            string strValue = (string)value;
            switch (key)
            {
                case "Pattern":
                    Pattern = strValue;
                    break;
                case "Replace":
                    Value = strValue;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public object? GetAttribute(string key)
        {
            switch (key)
            {
                case "Pattern":
                    return Pattern;
                case "Replace":
                    return Value;
                default:
                    return null;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string[] GetAllAttributesName()
        {
            return new string[] {"Pattern", "Replace"};
        }

        public void Rename(FileInfo original)
        {
            string oldName = original.NewName;
            string newName = Regex.Replace(oldName, Pattern, Value);
            original.NewName = newName;
        }
    }
}