using System;
namespace SpectrumCC.Interfaces
{
    public interface IDialogService
    {
        void ShowDialog(string title, string message, string buttonText);
    }
}
