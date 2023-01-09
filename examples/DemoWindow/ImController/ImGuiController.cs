using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Mochi.DearImGui;
using Mochi.DearImGui.Internal;
using Silk.NET.Input;
using Silk.NET.Input.Extensions;
using Silk.NET.Maths;
using Silk.NET.OpenGL;

namespace Arqan.ImController;

public unsafe class ImGuiController : IDisposable
{
    private GL _gl;
    private Window _window;
    private IInputContext _input;
    private bool _frameBegun;
    private readonly List<char> _pressedChars = new List<char>();
    private IKeyboard _keyboard;

    private int _attribLocationTex;
    private int _attribLocationProjMtx;
    private int _attribLocationVtxPos;
    private int _attribLocationVtxUV;
    private int _attribLocationVtxColor;
    private uint _vboHandle;
    private uint _elementsHandle;
    private uint _vertexArrayObject;

    private Texture _fontTexture;
    private Shader _shader;

    private int _windowWidth;
    private int _windowHeight;

    public IntPtr Context;
    
    /// <summary>
    /// Constructs a new ImGuiController.
    /// </summary>
    public ImGuiController(GL gl, Window view, IInputContext input) : this(gl, view, input, null, null)
    {
    }

    /// <summary>
    /// Constructs a new ImGuiController with font configuration.
    /// </summary>
    public ImGuiController(GL gl, Window view, IInputContext input, ImGuiFontConfig imGuiFontConfig) : this(gl, view, input, imGuiFontConfig, null)
    {
    }

    /// <summary>
    /// Constructs a new ImGuiController with an onConfigureIO Action.
    /// </summary>
    public ImGuiController(GL gl, Window view, IInputContext input, Action onConfigureIO) : this(gl, view, input, null, onConfigureIO)
    {
    }

    /// <summary>
    /// Constructs a new ImGuiController with font configuration and onConfigure Action.
    /// </summary>
    public ImGuiController(GL gl, Window view, IInputContext input, ImGuiFontConfig? imGuiFontConfig = null, Action onConfigureIO = null)
    {
        Init(gl, view, input);

        var io = ImGui.GetIO();
        if (imGuiFontConfig is not null)
        {
            io->Fonts->AddFontFromFileTTF(imGuiFontConfig.Value.FontPath, imGuiFontConfig.Value.FontSize);
        }

        onConfigureIO?.Invoke();

        io->BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset;

        CreateDeviceResources();
        SetKeyMappings();

        SetPerFrameImGuiData(1f / 60f);

        BeginFrame();
    }
    
    private void Init(GL gl, Window view, IInputContext input)
    {
        _gl = gl;
        _window = view;
        _input = input;
        _windowWidth = (int)view.Size.X;
        _windowHeight = (int)view.Size.Y;

        Context = (nint)ImGui.CreateContext();
        ImGui.SetCurrentContext((ImGuiContext*)Context);
        ImGui.StyleColorsDark();
    }

    public void MakeCurrent()
    {
       ImGui.SetCurrentContext((ImGuiContext*)this.Context);
    }
    
    private void BeginFrame()
    {
         ImGui.NewFrame();
        _frameBegun = true;
        _keyboard = _input.Keyboards[0];
        _view.Resize += WindowResized;
        _keyboard.KeyChar += OnKeyChar;
    }

    private void OnKeyChar(IKeyboard arg1, char arg2)
    {
        _pressedChars.Add(arg2);
    }

    private void WindowResized(Vector2D<int> size)
    {
        _windowWidth = size.X;
        _windowHeight = size.Y;
    }
    
    public void Dispose()
    {
        
    }
}