
# RhinoRaven 🦅

A simple plugin for Rhino
> RhinoRaven name is a tribute to the creator of RhinoCommons, then RavenDB.

- [RhinoRaven 🦅](#rhinoraven-)
  - [Requirements](#requirements)
  - [🚀 Installation](#-installation)
  - [🗑️ Uninstallation](#️-uninstallation)
  - [🚨 Known Issues](#-known-issues)
      - [plugin toolbar doesn't appear automatically](#plugin-toolbar-doesnt-appear-automatically)
      - [selection json file's destination folder is static](#selection-json-files-destination-folder-is-static)
  - [📝 Usage](#-usage)


## Requirements

To use RhinoRaven, you need the following:

- macOS
- Rhino 8
- .NET 7.0

In case of installation script files permission issues remember to make it executable
```bash
# from the repo root
chmod +x install.sh
chmod +x uninstall.sh
```

## 🚀 Installation

To install RhinoRaven, follow these steps:

1. Ensure you meet the requirements listed above.
2. Download or clone the RhinoRaven repository.
3. Navigate to the repository folder.
4. Run the `install.sh` script:
    ```bash
    ./install.sh
    ```
5. The script will install RhinoRaven into Rhino 8.

## 🗑️ Uninstallation

To uninstall RhinoRaven, follow these steps:

1. Navigate to the repository folder.
2. Run the `uninstall.sh` script:
    ```bash
    ./uninstall.sh
    ```
3. The script will remove RhinoRaven from Rhino 8.

## 🚨 Known Issues

- [ ] plugin toolbar doesn't appear automatically
- [ ] selection json file's destination folder is static

#### plugin toolbar doesn't appear automatically

The plugin creates a toolbar using a `.rui` file, but even after the plugin is installed and loadexd it is still needed to manually make the toolbar visible 

#### selection json file's destination folder is static

At the mmoment the plugin doesn't have the possibility to specify a custom path to save 
JSON files

## 📝 Usage

To use the RhinoRaven plugin, follow these steps:

1. **Enable the RhinoRaven Toolbar Panel:**
   - Make sure to enable the RhinoRaven toolbar panel in Rhino. You can usually find this in the toolbar customization settings of Rhino.

2. **Open a 3dm File**
   
3. **Select an Object:**
   - Once the 3dm file is loaded, select an object.

4. **Click the Button "Save To Raven":**
   - In the RhinoRaven toolbar panel, click on the "Save To Raven" button.

5. **Review the Selection Snapshot:**
   - After clicking the button, RhinoRaven will save a Selection Snapshot JSON file.
   - The Selection Snapshot will be saved in a subfolder named `selections` at the plugin installation path.
     - Within that folder, a sub folder is created and named using the slug of the file name
     - The folder is generally available at `/Users/{username}/Library/Application Support/McNeel/Rhinoceros/packages/8.0/RhinoRaven/1.0.0/selections`

