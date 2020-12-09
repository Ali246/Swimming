using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swimming.CustomModel;
using Swimming.Data;
using Swimming.IService;

namespace Swimming.Service
{
    public class ReportService: IReportService
    {
        private readonly NavigationManager navigationManager;

        public ReportService(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }
        public void Export(string table, string type, Radzen.Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"/export/northwind/{table}/{type}") : $"/export/northwind/{table}/{type}", true);
        }

    }
}
