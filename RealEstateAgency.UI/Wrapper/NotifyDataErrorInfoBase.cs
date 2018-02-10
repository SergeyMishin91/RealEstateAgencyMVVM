using RealEstateAgency.UI.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class NotifyDataErrorInfoBase: ViewModelBase, INotifyDataErrorInfo
{
    private Dictionary<string, List<string>> errorsByPropertyName =
            new Dictionary<string, List<string>>();

    public bool HasErrors => errorsByPropertyName.Any();

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    public IEnumerable GetErrors(string propertyName)
    {
        return errorsByPropertyName.ContainsKey(propertyName)
            ? errorsByPropertyName[propertyName]
            : null;
    }

    protected virtual void OnErrorChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        base.OnPropertyChanged(nameof(HasErrors));
    }

    protected void AddError(string propertyName, string error)
    {
        if (!errorsByPropertyName.ContainsKey(propertyName))
        {
            errorsByPropertyName[propertyName] = new List<string>();
        }

        if (!errorsByPropertyName[propertyName].Contains(error))
        {
            errorsByPropertyName[propertyName].Add(error);
            OnErrorChanged(propertyName);
        }
    }

    protected void ClearErrors(string propertyName)
    {
        if (errorsByPropertyName.ContainsKey(propertyName))
        {
            errorsByPropertyName[propertyName].Remove(propertyName);
            OnErrorChanged(propertyName);
        }
    }
}
