using System;
using System.Collections.Generic;
using System.Text;
using ConnectDataBase;
namespace ChainOfResponsibility
{
    class SpecificTranslate :Translate
    {
        Translate nextTranslate = new TranslateEN();
        public override string GetTranslate(Request request)
        {
            //znajdź tłumaczenie wg request.Translate
            // pobieram z bazy tłumaczeni wg. kodu i kraju
            string transletingFromDb = DB.FindSpecificTranslate(request.Code, request.Language);

            if (string.IsNullOrEmpty(transletingFromDb))
            {
                return nextTranslate.GetTranslate(request);
            }
            else
            {
                return transletingFromDb;
            }
            
        }
    }
}
