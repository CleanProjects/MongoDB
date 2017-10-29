using ConnectDataBase;
namespace ChainOfResponsibility
{
    internal class TranslatePL : Translate
    {
        Translate nextTranslate = new TranslateAny();

        public override string GetTranslate(Request request)
        {
            // szukam w bazie tłumaczenia po angielsku
            string tranlsatePL = DB.FindTranslatePL(request.Code);

            if (string.IsNullOrEmpty(tranlsatePL))
            {
                return nextTranslate.GetTranslate(request);
            }
            else
            {
                return tranlsatePL;
            }
        }
    }
}