using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Computer;
public partial class ListViewPage : ContentPage
{
    private List<Singer> singers;
    public List<Singer> Singers
    {
        get => singers;
        set
        {
            singers = value;
            OnPropertyChanged(nameof(Singers));
        }
    }

    private Singer selSinger;
    public Singer SelSinger
    {
        get => selSinger;
        set
        {
            selSinger = value;
            OnPropertyChanged(nameof(SelSinger));
        }
    }

    public ListViewPage()
    {
        InitializeComponent();
        BindingContext = this;
        
        GetData(new DataBase());
    }

    private async void GetData(DataBase a)
    {
        Singers = await a.GetAllSingers();
    }

    private void BackClick(object sender, EventArgs e) => Navigation.PopModalAsync();
    private async void AddClick(object sender, EventArgs e) => Singers = await OpenWindowMethods.Instance.OpenAdd();
    private async void EditClick(object sender, EventArgs e) { if (SelSinger != null)  Singers = await OpenWindowMethods.Instance.OpenEdit(SelSinger); }
    private async void DeleteClick(object sender, EventArgs e) { if (SelSinger != null) Singers = await OpenWindowMethods.Instance.OpenDel(SelSinger); }
}