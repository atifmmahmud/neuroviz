# neuroviz

Neuroviz is an interactive brain anatomy visualization platform. This app allows the user to click on brain areas and learn about their functionality including internal regions like the limbic system.

To try the project, you can visit the [NeuroViz Webpage](https://atifm.com/neuroviz/index.html).

 ![A GIF walkthrough of using Neuroviz](/Neuroviz-GIF.gif)


This project uses some external assets, listed as follows:

- The 3D model of the brain was downloaded from TurboSquid: <https://www.turbosquid.com/FullPreview/624395>  
- The outline effect was sourced from Unity Asset Store: <https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488>
- The gitattributes template for Git LFS was sourced from: <https://gist.github.com/nemotoo/b8a1c3a0f1225bb9231979f389fd4f3f>  

## Directory Guide

- [Neuroviz-Unity](/NeuroViz-Unity/): The Unity project used to build Neuroviz. For this, we used Unity `6000.0.51f1` with the Virtual Reality template and Universal Render Pipeline.

- [Neuroviz-Blender](/NeuroViz-Blender/): This Blender project was used to adjust the 3D model to better fit our needs.

### Code

We used `ScriptableObjects` to manage data on the brain areas. For the brain area class and scriptable objects, please see [NeuroViz-Unity/Assets/Data](/NeuroViz-Unity/Assets/Data/).

The remaining code can be found in [NeuroViz-Unity/Assets/Scripts](/NeuroViz-Unity/Assets/Scripts/).

- [BrainStateManager](/NeuroViz-Unity/Assets/Scripts/BrainStateManager.cs): Manages viewing brain cross-section, internal view, and selection of area to highlight and display.

- [CameraController](/NeuroViz-Unity/Assets/Scripts/CameraController.cs): Handles camera view movement around the scene.

- [ClickableBrainArea](/NeuroViz-Unity/Assets/Scripts/ClickableBrainArea.cs): A component attached to brain areas to store data and handle clicking.

- [MNIManager](/NeuroViz-Unity/Assets/Scripts/MNIManager.cs): Handles visualizing MNI coordinates.

- [UIManager](/NeuroViz-Unity/Assets/Scripts/UIManager.cs): Handles the UI elements like brain area descriptions.
