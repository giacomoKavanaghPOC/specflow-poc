using System;

namespace SpecflowPOC.framework.model
{
    public class Element
    {
        public string PageElementName;
        public string Name;
        public string ClassName;
        public string Text;
        public string Value;
        public string Id;
        public string CssSelector;
        public string XPath;
        public bool optional;
        public ElementIdentifierType IdentifierType;

        //enforce an identifier
        public Element(ElementIdentifierType identifierType, string identifier)
        {
            IdentifierType = identifierType;
            SetIdentifier(identifier);
        }

        private void SetIdentifier(string identifier)
        {
            switch (IdentifierType)
            {
                case ElementIdentifierType.ClassName:
                    ClassName = identifier;
                    break;

                case ElementIdentifierType.Id:
                    Id = identifier;
                    break;

                case ElementIdentifierType.Name:
                    Name = identifier;
                    break;

                case ElementIdentifierType.CssSelector:
                    CssSelector = identifier;
                    break;

                case ElementIdentifierType.XPath:
                    XPath = identifier;
                    break;

                default:
                    throw new ArgumentException("Element Identifier Type not recognised: " + IdentifierType);
            }
        }

        public Element IsOptional()
        {
            optional = true;
            return this;
        }

        //Extend as desired, potentially split into different types of elements as it becomes too large to decipher
    }
}
