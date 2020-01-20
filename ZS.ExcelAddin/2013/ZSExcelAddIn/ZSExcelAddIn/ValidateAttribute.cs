using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSExcelAddIn
{
    internal class ValidateAttribute:Attribute
    {
        public ValidateAttribute() { }

        private String _UserName = String.Empty;
        public ValidateAttribute(String userName) {
            this._UserName = userName;
        }

        public Boolean IsUserAccess()
        {
            return false;
        }

      
    }
}
