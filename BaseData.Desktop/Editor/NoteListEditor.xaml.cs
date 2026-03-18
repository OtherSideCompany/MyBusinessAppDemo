using BaseData.Adapter.TreeViewModels;
using OtherSideCore.Wpf.CustomControls;
using System.Windows.Controls;
using System.Windows.Input;

namespace BaseData.Desktop.Editor
{
   /// <summary>
   /// Interaction logic for NoteListEditor.xaml
   /// </summary>
   public partial class NoteListEditor : UserControl
   {
      public NoteListEditor()
      {
         InitializeComponent();
      }

      private async void AddNoteClickSelectTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Enter && !(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
         {
            var clickSelectTextbox = (ClickSelectTextBox)sender;

            var viewModel = (NoteTreeViewModel)clickSelectTextbox.DataContext;

            if (viewModel.CreateNewNoteAsyncCommand.CanExecute(null))
            {
               await viewModel.CreateNewNoteAsyncCommand.ExecuteAsync(null);
            }

            e.Handled = true;
         }
      }
   }
}
