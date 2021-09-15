# DeepFakePOC

This is a POC (Probe of Concept) of a DeepFake Detector Plugin for tool FOCA

## Installation
To use these plugin is necessary to reach some technical requirements described in https://github.com/ElevenPaths/FOCA/tree/master/FOCA.

Once FOCA is compiled and running, the plugin should be compiled using Visual Studio Code.

This link is very usefull to understand how a FOCA plugin works and how to compile it on the VSC:
* https://www.youtube.com/watch?v=nzH4ozKJQVI

## Use the plugin

* Open the FOCA tool
* Go to Plugins > Load/Unload Plugins from toolbar
* Load the .dll generated during the Plugin compilation

Once the plugin is successfully loaded, only is necessary a valid URL to start a DeepFake analisys