using Project.Entities;
using Project.Services;
using System.Collections.ObjectModel;

namespace Project;

public partial class HotelService : ContentPage
{
    private IDbService _dbService;
    
	public HotelService(IDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        int selectedIndex = picker.SelectedIndex;

        ServicesView.ItemsSource = _dbService.GetServices(selectedIndex + 1).
            Select(d => d.ToString()).ToList();
    }

    private void OnPageLoad(object sender, EventArgs e)
    {
        _dbService.Init();
        HotelRoomPicker.ItemsSource = _dbService.GetAllRooms().Select(r => r.Name).ToList();
        HotelRoomPicker.ItemsSource = HotelRoomPicker.GetItemsAsArray();
    }
}