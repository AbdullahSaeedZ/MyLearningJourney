using System;
using System.Collections.Generic;


namespace Ajr
{
    internal static class categoriesData
    {

        public static Dictionary<string, List<string>> GetCategories()
        {
            return new Dictionary<string, List<string>>
            {

                { "ادعية",  new List<string>
                    {
                        "اللهم بك أصبحنا وبك أمسينا، وبك نحيا وبك نموت وإليك النشور.",
                        "أصبحنا وأصبح الملك لله، والحمد لله، لا إله إلا الله وحده لا شريك له."
                    } 
                } 

                , { "استغفار و تسبيح", new List<string>
                    {

                    } 
                }

                , { "صلاة على النبي",  new List<string>
                    {

                    } 
                }

                , { "تذكير متنوع", new List<string>
                    {

                    } 
                }



            };
        }

    }
}

