using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Dapper
{
    class JQDataTableModel
    {
    }
    public class PageSetting
    {
        public int TotoalRows { get; set; }
        public int CurrentPage { get; set; }
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
    }

    public class JDataTable<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> Data { get; set; }
        public PageSetting PageSetting { get; set; }
    }
    public class jsonAOData
    {
        public int draw { get; set; }
        public int start { get; set; } = 0;
        public int length { get; set; } = 100;
        public jsonAODataSearch search { get; set; }
        public List<OrderBy> order { get; set; }
        public object param { get; set; }

    }

    public class OrderBy
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    public class jsonAODataSearch
    {
        public string value { get; set; }
        public bool regex { get; set; }
    }
}
