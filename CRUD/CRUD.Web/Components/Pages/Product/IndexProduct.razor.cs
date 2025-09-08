﻿using Blazored.Toast.Services;
using CRUD.Model.Entities;
using CRUD.Model.Models;
using CRUD.Web.Components.BaseComponents;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CRUD.Web.Components.Pages.Product
{
    public partial class IndexProduct
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<ProductModel> ProductModels { get; set; }
        public AppModal Modal { get; set; }
        public int DeleteID { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
         
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadProduct();
        }
        protected async Task LoadProduct()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Product");
            if (res != null && res.Success)
            {
                ProductModels = JsonConvert.DeserializeObject<List<ProductModel>>(res.Data.ToString());
            }
        }
        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Product/{DeleteID}");
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Delete product successfully");
                await LoadProduct();
                Modal.Close();
            }
        } 
    }
}
