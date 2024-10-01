
using MauiStockTake.Shared.Inventory.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiStockTake.UI.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        private readonly IInventoryService _inventoryService;

        public ObservableCollection<InventoryItemDto> Inventory { get; set; } = new();

        public ICommand ShowAboutPageCommand { get; set; }

        public ReportViewModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            IsLoading = true;
            ShowAboutPageCommand = new Command(ShowAboutPage);

        }

        public async Task Init()
        {
            if (initialised)
                return;

            initialised = true;

            await Refresh();
        }

        private async Task Refresh()
        {
            IsLoading = true;
            Inventory.Clear();

            var inventory = await _inventoryService.GetInventory();

            foreach (var item in inventory)
            {
                Inventory.Add(item);
            }

            IsLoading = false;
        }
        public void ShowAboutPage()
        {
            var newWindow = new Window(new AboutPage())
            {
                Title = "About",
                Width = 300,
                Height = 300
            };
            Application.Current.OpenWindow(newWindow);
        }



    }
}
