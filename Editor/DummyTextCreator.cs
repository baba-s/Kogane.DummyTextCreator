using System.IO;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    internal sealed class DummyTextCreator : ScriptableWizard
    {
        [SerializeField] private uint   m_count      = 1000;
        [SerializeField] private string m_folderPath = "Assets/TextAssets/";

        [MenuItem( "Window/Dummy Text Creator" )]
        private static void Open()
        {
            DisplayWizard<DummyTextCreator>( "Dummy Text Creator" );
        }

        private void OnWizardCreate()
        {
            Directory.CreateDirectory( m_folderPath );

            for ( var i = 0; i < m_count; i++ )
            {
                var number   = i + 1;
                var filename = $"{number}.txt";
                var path     = $"{m_folderPath}/{filename}";

                File.WriteAllText( path, number.ToString() );
            }

            AssetDatabase.Refresh();
        }
    }
}