using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashBox.Models
{

    public class Connection
    {

        public string Source { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
    }

    public class Chart
    {

        public string Nom { get; set; }
        public string ConnectionId { get; set; }
        public string ChartType { get; set; }
        public string Entity { get; set; }
        public string SerieColumnName { get; set; }
        public string CategorieColumnName { get; set; }
        public string Categorie2ColumnName { get; set; }
        public string SerieAgregationType { get; set; }
    }

    public class Dashboard
    {

        public string Nom { get; set; }
        public string LayoutId { get; set; }
        public ChartComponent[] Charts { get; set; }
    }


    public class ChartComponent
    {
        public string ChartId { get; set; }
        public int ChartIndex { get; set; }
    }
}
