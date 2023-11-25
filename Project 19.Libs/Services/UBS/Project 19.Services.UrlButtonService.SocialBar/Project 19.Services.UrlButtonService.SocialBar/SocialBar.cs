﻿using Microsoft.Extensions.Options;

namespace Project_19.Services;

/// <summary>
/// Служба панели кнопок социальных сетей
/// </summary>
public class SocialBar : IUrlButtonService
{
	#region IUrlButtonService

	/// <inheritdoc/>
	public IEnumerable<IUrlScript> Scripts { get; set; }
	/// <inheritdoc/>
	public IEnumerable<IUrlButton> Buttons { get; set; }

	#endregion

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="options">Опции службы <see cref="SocialBar"/> из конфигурации</param>
	public SocialBar(IOptions<SocialBarOptions> options)
	{
		Scripts = options.Value.Scripts;
		Buttons = options.Value.Buttons;
	}
}
