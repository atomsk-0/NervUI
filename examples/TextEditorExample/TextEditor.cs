using TextEditorExample.Layers;

namespace TextEditorExample;

public class TextEditor
{
    public string Text = "";

    public string Title = "";

    public string FilePath = "";

    public bool isSaved = false;

    private bool opened = true;

    public bool isOpened
    {
        set
        {
            opened = value;
            if (opened == false)
            {
                MainLayer.Editors.Remove(MainLayer.Editors.Find(c => c == this));
            }
        }

        get
        {
            return this.opened;
        }
    }

    public TextEditor(string title, string text = "", string filePath = "")
    {
        Title = title;
        Text = text;
        FilePath = filePath;
    }
}