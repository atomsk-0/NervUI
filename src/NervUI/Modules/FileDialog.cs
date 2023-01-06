using System.Numerics;
using Mochi.DearImGui;

namespace NervUI.Modules;

public enum FileDialogType
{
    OpenFile,
    SelectFolder
}

public enum FileDialogSortOrder
{
    Up,
    Down,
    None
}

public unsafe class FileDialog
{
    public bool FileDialogOpen = false;
    public FileDialogType FileDialogType = FileDialogType.OpenFile;
    public string path = "C:\\";

    public string selectedPath = "";

    private bool _pathInitialized = false;

    private string _currentPath = "";

    private string _selectedFile = "";
    private string _selectedFolder = "";

    private int _folderSelectedIndex = 0;
    private int _fileSelectedIndex = 0;
    
    private float initial_spacing_column_0 = 230.0f;
    private float initial_spacing_column_1 = 80.0f;
    private float initial_spacing_column_2 = 80.0f;
    
    private FileDialogSortOrder file_name_sort_order = FileDialogSortOrder.None;
    private FileDialogSortOrder size_sort_order = FileDialogSortOrder.None;
    private FileDialogSortOrder date_sort_order = FileDialogSortOrder.None;
    private FileDialogSortOrder type_sort_order = FileDialogSortOrder.None;

    private string newFolderName = "";

    public void RenderFileDialog()
    {
        if (FileDialogOpen)
        {
            if (!_pathInitialized)
            {
                _currentPath = path;
                _pathInitialized = true;
            }
            
            bool* na = null;

            string window_title = (FileDialogType == FileDialogType.OpenFile ? "Select a file" : "Select a folder");
            
            string[] files = Directory.GetFiles(_currentPath);
            string[] folders = Directory.GetDirectories(_currentPath);
            
            ImGui.SetNextWindowSize(new Vector2(740, 420));
            ImGui.Begin(window_title, na, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoDocking);
            {
                ImGui.Text(_currentPath);
            
                ImGui.BeginChild("Directories##1", new Vector2(200, 300), true, ImGuiWindowFlags.HorizontalScrollbar);
                {
                    if (ImGuiManaged.Selectable("..", false, ImGuiSelectableFlags.AllowDoubleClick,
                            new OpenTK.Mathematics.Vector2(ImGui.GetContentRegionAvail().X, 0)))
                    {
                        if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        {
                            _currentPath = Directory.GetParent(_currentPath).FullName;
                        }
                    }
                    
                    for (int i = 0; i < folders.Length; i++)
                    {
                        if (ImGuiManaged.Selectable(folders[i].Split(@"\").Last(), i == _folderSelectedIndex,
                                ImGuiSelectableFlags.AllowDoubleClick,
                                new OpenTK.Mathematics.Vector2(ImGui.GetContentRegionAvail().X, 0)))
                        {
                            if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                            {
                                _currentPath = folders[i];
                                _folderSelectedIndex = 0;
                                _fileSelectedIndex = 0;
                                _selectedFolder = "";
                                ImGui.SetScrollHereY(0);
                            }
                            else
                            {
                                _folderSelectedIndex = i;
                                _selectedFolder = folders[i];
                            }
                        }
                    }
                }
                ImGui.EndChild();
                
                ImGui.SameLine();

                ImGui.BeginChild("Files##1", new Vector2(516, 300), true, ImGuiWindowFlags.HorizontalScrollbar);
                {
                    ImGui.Columns(4);
                    if (initial_spacing_column_0 > 0)
                    {
                        if (initial_spacing_column_0 > 0) {
                            ImGui.SetColumnWidth(0, initial_spacing_column_0);
                            //initial_spacing_column_0 = 0.0f;
                        }
                        if (initial_spacing_column_1 > 0) {
                            ImGui.SetColumnWidth(1, initial_spacing_column_1);
                            //initial_spacing_column_1 = 0.0f;
                        }
                        if (initial_spacing_column_2 > 0) {
                            ImGui.SetColumnWidth(2, initial_spacing_column_2);
                            //initial_spacing_column_2 = 0.0f;
                        }
                        if (ImGuiManaged.Selectable("File")) {
                            size_sort_order = FileDialogSortOrder.None;
                            date_sort_order = FileDialogSortOrder.None;
                            type_sort_order = FileDialogSortOrder.None;
                            file_name_sort_order = (file_name_sort_order == FileDialogSortOrder.Down ? FileDialogSortOrder.Up : FileDialogSortOrder.Down);
                        }
                        ImGui.NextColumn();
                        if (ImGuiManaged.Selectable("Size")) {
                            file_name_sort_order = FileDialogSortOrder.None;
                            date_sort_order = FileDialogSortOrder.None;
                            type_sort_order = FileDialogSortOrder.None;
                            size_sort_order = (size_sort_order == FileDialogSortOrder.Down ? FileDialogSortOrder.Up : FileDialogSortOrder.Down);
                        }
                        ImGui.NextColumn();
                        if (ImGuiManaged.Selectable("Type")) {
                            file_name_sort_order = FileDialogSortOrder.None;
                            date_sort_order = FileDialogSortOrder.None;
                            size_sort_order = FileDialogSortOrder.None;
                            type_sort_order = (type_sort_order == FileDialogSortOrder.Down ? FileDialogSortOrder.Up : FileDialogSortOrder.Down);
                        }
                        ImGui.NextColumn();
                        if (ImGuiManaged.Selectable("Date")) {
                            file_name_sort_order = FileDialogSortOrder.None;
                            size_sort_order = FileDialogSortOrder.None;
                            type_sort_order = FileDialogSortOrder.None;
                            date_sort_order = (date_sort_order == FileDialogSortOrder.Down ? FileDialogSortOrder.Up : FileDialogSortOrder.Down);
                        }
                        ImGui.NextColumn();
                        ImGui.Separator();
                        
                        //TODO SORT  FILES

                        for (int i = 0; i < files.Length; ++i) {
                            if (ImGuiManaged.Selectable(files[i].Split(@"\").Last(), i == _fileSelectedIndex, ImGuiSelectableFlags.AllowDoubleClick, new OpenTK.Mathematics.Vector2(ImGui.GetContentRegionAvail().X, 0)))
                            {
                                _fileSelectedIndex = i;
                                _selectedFile = files[i];
                                _selectedFolder = "";
                            }
                            ImGui.NextColumn();
                            var fi = new FileInfo(files[i]);
                            ImGui.Text(fi.Length.ToString());
                            ImGui.NextColumn();
                            ImGui.Text(fi.Extension);
                            ImGui.NextColumn();
                            ImGui.Text(fi.LastWriteTime.ToShortTimeString() + " " + fi.LastWriteTime.ToShortDateString());
                            ImGui.NextColumn();
                        }
                    }
                }
                ImGui.EndChild();
                
                ImGui.PushItemWidth(724);
                string ok = (_selectedFolder.Length > 0 ? _selectedFolder : _selectedFile);
                //string ok = (file_dialog_current_folder.size() > 0 ? file_dialog_current_folder : file_dialog_current_file);
                ImGuiManaged.InputText("##text", ref ok, 999, ImGuiInputTextFlags.ReadOnly);
                
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 6);
                if (ImGui.Button("New folder", new Vector2()))
                {
                    ImGui.OpenPopup("NewFolderPopup");
                }
                ImGui.SameLine();
                if (ImGui.Button("Delete", new Vector2()))
                {
                    if (File.Exists(ok))
                    {
                        _selectedFile = "";
                        File.Delete(ok);
                    }
                    if (Directory.Exists(ok))
                    {
                        _selectedFolder = "";
                        Directory.Delete(ok);
                    }
                }
                ImGui.SameLine();
                ImGui.SetCursorPosX(ImGui.GetWindowWidth() - 120);
                if (ImGui.Button("Cancel", new Vector2()))
                {
                    _fileSelectedIndex = 0;
                    _selectedFolder = "";
                    _selectedFile = "";
                    _folderSelectedIndex = 0;
                    _pathInitialized = false;
                    path = "";
                    _currentPath = "";
                    FileDialogOpen = false;
                }
                ImGui.SameLine();
                if (ImGui.Button("Select", new Vector2()))
                {
                    selectedPath = ok;
                    _pathInitialized = false;
                    _fileSelectedIndex = 0;
                    _selectedFolder = "";
                    _selectedFile = "";
                    _folderSelectedIndex = 0;
                    path = "";
                    _currentPath = "";
                    FileDialogOpen = false;
                }
                
                
                var center = new Vector2(ImGui.GetWindowPos().X + ImGui.GetWindowSize().X * 0.5f, ImGui.GetWindowPos().Y + ImGui.GetWindowSize().Y * 0.5f);
                ImGui.SetNextWindowPos(center, ImGuiCond.Appearing, new Vector2(0.5f, 0.5f));
                if (ImGui.BeginPopup("NewFolderPopup", ImGuiWindowFlags.Modal)) {
                    ImGui.Text("Enter a name for the new folder");
                    ImGuiManaged.InputText("##newfolder", ref newFolderName, 500);
                    if (ImGui.Button("Create##1", new Vector2())) 
                    {
                        if (newFolderName.Length > 0)
                        {
                            Directory.CreateDirectory(Path.Combine(_currentPath, newFolderName));
                            newFolderName = "";
                            ImGui.CloseCurrentPopup();
                        }
                    }
                    ImGui.SameLine();
                    if (ImGui.Button("Cancel##1", new Vector2())) {
                        newFolderName = "";
                        ImGui.CloseCurrentPopup();
                    }
                    ImGui.EndPopup();
                }
                ImGui.End();
            }
            

            

        }
    }
}