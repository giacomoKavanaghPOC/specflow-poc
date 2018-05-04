using OpenQA.Selenium;
using System;

namespace SpecflowPOC.framework.model
{
    public class Element
    {
        public string PageElementName;
        public bool optional;
        public By Identifier;

        //enforce an identifier
        public Element(By identifier)
        {
            Identifier = identifier;
        }

        public Element IsOptional()
        {
            optional = true;
            return this;
        }
    }
}
