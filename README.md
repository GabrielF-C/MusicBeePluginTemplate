# MusicBeePluginTemplate

A clean template to get you started making your own MusicBee plugin. Tested with MusicBee v3.5.8698. Requires .NET Framework 4.0.

## How to use the template

> [!CAUTION]
> The name of the DLL must start with `mb__`.

<details>
	<summary>
		<i>(click this to show images)</i> Start by changing values in csproj properties and AssemblyInfo.
	</summary>
	<img src="docs/1.png" style="max-width: 75vw;">
	<img src="docs/2.png" style="max-width: 75vw;">x
</details>

Then modify `MusicBeePlugin.Plugin` to do what you want.

## How this template works

Subscribe to events using the observer pattern in the PluginStartup method.

Use the Api field to interact with MusicBee's API.

## How to install a plugin

Essentially, just drop your DLL into `%APPDATA%/MusicBee/Plugins/`.

Or you can install using MusicBee's UI by going into the menu `MusicBee > Edit > Edit Preferences > Plugins`.

## How to debug a plugin

For simple things, you can look at the error log in MusicBee's UI directly : `MusicBee > Help > Support > View Error Log`.

Apparently there is a way to hook into the MusicBee process to properly debug your plugin.
I do not know if it works but here is some doc : [Tutorial: Creating A Simple Plugin](https://musicbee.fandom.com/wiki/Tutorial:_Creating_A_Simple_Plugin#Setting_up_Visual_Studio_to_work_with_MusicBee)