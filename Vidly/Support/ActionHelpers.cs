using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Support
{
    public class ActionHelpers
    {
        //=================Using these fields to avoid mistakes in @html.ActionLink
        //Every Field represent the name of a Controller and its methods.
        //The list is updated
        public static string Index = "Index";
        public static string Home = "Home";

        //===========MoviesController Methods=======
        public static string Movies = "Movies";  
        public static string MovieNew = "New";
        
        public static string MovieEdit = "Edit";
        public static string MovieDetails = "Details";

        //==========CustomersController Methods=======
        public static string Customers = "Customers";
        
        public static string CustomerDetails = "Details";
        public static string CustomerEdit = "Edit";
        public static string CustomerNew = "New";
        //======================

    }
}