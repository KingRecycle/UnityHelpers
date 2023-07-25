using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UIElements;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace CharlieMadeAThing.Editor
{
    public class ToolsMenu : EditorWindow {
        static VisualElement _root;
        static Toggle _createRootFolder;
        static TextField _rootFolderName;
        static Toggle _createScriptsFolder;
        static Toggle _createScenesFolder;
        static Toggle _createPrefabsFolder;
        static Toggle _createSpritesFolder;
        
        static Button _createButton;
        
        [MenuItem("Tools/Setup/Create Default Folders")]
        static void ShowWindow() {
            var window = GetWindow<ToolsMenu>();
            window.titleContent = new GUIContent( "Create Default Folders" );
            window.Show();
        }

        void CreateGUI() {
            _root = rootVisualElement;

            var visualTree =
                LoadAssetAtPath<VisualTreeAsset>( "Assets/Editor/UXML/create-default-folders.uxml" );
            visualTree.CloneTree( _root );
            
            _createRootFolder = _root.Q<VisualElement>( "RootToggleGroup" ).Q<Toggle>("rootToggle");
            _rootFolderName = _root.Q<VisualElement>( "RootToggleGroup" ).Q<TextField>( "rootTextField" );
            _createScriptsFolder = _root.Q<VisualElement>("ScriptsToggleGroup").Q<Toggle>( "scriptsToggle" );
            _createScenesFolder = _root.Q<VisualElement>("ScenesToggleGroup").Q<Toggle>( "scenesToggle" );
            _createPrefabsFolder = _root.Q<VisualElement>("PrefabsToggleGroup").Q<Toggle>( "prefabsToggle" );
            _createSpritesFolder = _root.Q<VisualElement>("SpritesToggleGroup").Q<Toggle>( "spritesToggle" );

            _createButton = _root.Q<Button>( "createFoldersButton" );
            _createButton.clicked += CreateFolders;
        }

        public static void CreateFolders() {
            var fullPath = "";
            if ( _createRootFolder.value ) {
                fullPath = Combine( dataPath, _rootFolderName.value );
            }
            else {
                fullPath = dataPath;
            }
            var directories = GetDirectoriesToCreate();
            
            foreach ( var directory in directories ) {
                CreateDirectory( Combine( fullPath, directory ) );
            }
            Refresh();
        }

        static IEnumerable<string> GetDirectoriesToCreate() {
            var directories = new List<string>();
            if ( _createScriptsFolder.value ) {
                directories.Add( "Scripts" );
            }
            if ( _createScenesFolder.value ) {
                directories.Add( "Scenes" );
            }
            if ( _createPrefabsFolder.value ) {
                directories.Add( "Prefabs" );
            }
            if ( _createSpritesFolder.value ) {
                directories.Add( "Sprites" );
            }
            return directories;
        }
    }
}
