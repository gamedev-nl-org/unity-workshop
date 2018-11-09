# Workshop 3: Input (Mouse, Keyboard, and Controllers)

The assets used in this workshop are from [here](https://kenney.nl/assets/topdown-shooter). They're covered under the [creative commons license](https://creativecommons.org/publicdomain/zero/1.0/). Meaning you can use them in your personal or commercial projects royalty free. If you enjoy this tutorial please consider [donating](https://kenney.itch.io/kenney-donation) to the artists.

# Overview
* GetAxis("")
* XBox One Pad
  * Sensitivity/Gravity
  * Dead
  * Joy Num
* Limitations of the native input manager (build project, remapping in game) these limitations are patched in a development version https://forum.unity.com/threads/input-system-update.508660/page-2#post-3329735
  * Building Standalone Games
* Touch Controls
  * Input.touchCount
  * Input.touches

* Absolute Positioning
  * Logging
    * Collapse
    * Stack Traces
    * File Location
      * macOS	~/Library/Logs/Unity/Editor.log
      * Windows	C:\Users\username\AppData\Local\Unity\Editor\Editor.log
    * tailing the log `tail -f`

 * Mouse Input
  * Debug.DrawLine & Debug.DrawRay