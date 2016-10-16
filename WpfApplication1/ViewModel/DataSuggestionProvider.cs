using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{



    using System.Collections.Generic;
    using System.IO;
    using WpfControls.Editors;
    using System.Linq;
    using System.Threading;
    using Model;

    public class DataSuggestionProvider : ISuggestionProvider 
    {
        public System.Collections.IEnumerable GetSuggestions(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return null;
            }
            if (filter.Length < 3)
            {
                return null;
            }

            /*
            if (filter[1] != ':')
            {
                return null;
            }*/
            var cities = DataSource.GetSimilarCities(filter);
            return cities;


        }

    }
}
