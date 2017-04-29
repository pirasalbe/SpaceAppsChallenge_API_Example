using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Taxon
    {
        public string id;
        public string name;
        public string observations_count;
        public string listed_taxa_count;
        public string wikipedia_summary;

        public Taxon(string id, string name, string observations_count, string listed_taxa_count, string wikipedia_summary)
        {
            this.id = id;
            this.name = name;
            this.observations_count = observations_count;
            this.listed_taxa_count = listed_taxa_count;
            this.wikipedia_summary = wikipedia_summary;
        }
    }
}
