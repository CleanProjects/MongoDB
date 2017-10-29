using System;
using System.Collections.Generic;
using System.Text;
using ConnectDataBase;
namespace ChainOfResponsibility
{
  internal  class TranslateEN:Translate
    {
        Translate nextTranslate = new TranslatePL();
        public override string GetTranslate(Request request)
        {
            // szukam w bazie tłumaczenia po angielsku
            string tranlsateEN = DB.FindTranslateEN(request.Code);

            if(string.IsNullOrEmpty(tranlsateEN))
            {
                return nextTranslate.GetTranslate(request);
            }
            else
            {
                return tranlsateEN;
            }
        }
    }
}
