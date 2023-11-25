using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Project_19.Models;

/// <summary>
/// Implementation of <see cref="INotifyPropertyChanged"/>
/// </summary>
public class PropertyChangedNotifier : INotifyPropertyChanged
{
	#region INotifyPropertyChanged

	/// <inheritdoc/>
	public event PropertyChangedEventHandler? PropertyChanged;
	/// <summary>
	/// Invokes <see cref="PropertyChanged"/>.
	/// </summary>
	/// <param name="propertyName">Name of property.</param>
	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	/// <summary>
	/// Sets the property value and invokes <see cref="PropertyChanged"/>.
	/// </summary>
	/// <typeparam name="T">Property type</typeparam>
	/// <param name="field">Property field</param>
	/// <param name="value">Value</param>
	/// <param name="propertyName">Property name</param>
	/// <returns></returns>
	protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value)) return false;
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	#endregion
}
