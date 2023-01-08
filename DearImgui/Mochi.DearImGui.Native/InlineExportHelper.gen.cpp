#include "../vendor/imgui/imgui.h"
#include "../vendor/imgui/imgui_internal.h"

#pragma comment(linker, "/export:?SelectAll@ImGuiInputTextCallbackData@@QEAAXXZ")
#pragma comment(linker, "/export:?ClearSelection@ImGuiInputTextCallbackData@@QEAAXXZ")
#pragma comment(linker, "/export:?HasSelection@ImGuiInputTextCallbackData@@QEBA_NXZ")
#pragma comment(linker, "/export:?Clear@ImGuiPayload@@QEAAXXZ")
#pragma comment(linker, "/export:?IsDataType@ImGuiPayload@@QEBA_NPEBD@Z")
#pragma comment(linker, "/export:?IsPreview@ImGuiPayload@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsDelivery@ImGuiPayload@@QEBA_NXZ")
#pragma comment(linker, "/export:??BImGuiOnceUponAFrame@@QEBA_NXZ")
#pragma comment(linker, "/export:?Clear@ImGuiTextFilter@@QEAAXXZ")
#pragma comment(linker, "/export:?IsActive@ImGuiTextFilter@@QEBA_NXZ")
#pragma comment(linker, "/export:?empty@ImGuiTextRange@ImGuiTextFilter@@QEBA_NXZ")
#pragma comment(linker, "/export:??AImGuiTextBuffer@@QEBADH@Z")
#pragma comment(linker, "/export:?begin@ImGuiTextBuffer@@QEBAPEBDXZ")
#pragma comment(linker, "/export:?end@ImGuiTextBuffer@@QEBAPEBDXZ")
#pragma comment(linker, "/export:?size@ImGuiTextBuffer@@QEBAHXZ")
#pragma comment(linker, "/export:?empty@ImGuiTextBuffer@@QEBA_NXZ")
#pragma comment(linker, "/export:?clear@ImGuiTextBuffer@@QEAAXXZ")
#pragma comment(linker, "/export:?reserve@ImGuiTextBuffer@@QEAAXH@Z")
#pragma comment(linker, "/export:?c_str@ImGuiTextBuffer@@QEBAPEBDXZ")
#pragma comment(linker, "/export:?Clear@ImGuiStorage@@QEAAXXZ")
#pragma comment(linker, "/export:?GetTexID@ImDrawCmd@@QEBAPEAXXZ")
#pragma comment(linker, "/export:?Clear@ImDrawListSplitter@@QEAAXXZ")
#pragma comment(linker, "/export:?GetClipRectMin@ImDrawList@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?GetClipRectMax@ImDrawList@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?PathClear@ImDrawList@@QEAAXXZ")
#pragma comment(linker, "/export:?PathLineTo@ImDrawList@@QEAAXAEBUImVec2@@@Z")
#pragma comment(linker, "/export:?PathLineToMergeDuplicate@ImDrawList@@QEAAXAEBUImVec2@@@Z")
#pragma comment(linker, "/export:?PathFillConvex@ImDrawList@@QEAAXI@Z")
#pragma comment(linker, "/export:?PathStroke@ImDrawList@@QEAAXIHM@Z")
#pragma comment(linker, "/export:?ChannelsSplit@ImDrawList@@QEAAXH@Z")
#pragma comment(linker, "/export:?ChannelsMerge@ImDrawList@@QEAAXXZ")
#pragma comment(linker, "/export:?ChannelsSetCurrent@ImDrawList@@QEAAXH@Z")
#pragma comment(linker, "/export:?PrimWriteVtx@ImDrawList@@QEAAXAEBUImVec2@@0I@Z")
#pragma comment(linker, "/export:?PrimWriteIdx@ImDrawList@@QEAAXG@Z")
#pragma comment(linker, "/export:?PrimVtx@ImDrawList@@QEAAXAEBUImVec2@@0I@Z")
#pragma comment(linker, "/export:?Clear@ImDrawData@@QEAAXXZ")
#pragma comment(linker, "/export:?Clear@ImFontGlyphRangesBuilder@@QEAAXXZ")
#pragma comment(linker, "/export:?GetBit@ImFontGlyphRangesBuilder@@QEBA_N_K@Z")
#pragma comment(linker, "/export:?SetBit@ImFontGlyphRangesBuilder@@QEAAX_K@Z")
#pragma comment(linker, "/export:?AddChar@ImFontGlyphRangesBuilder@@QEAAXG@Z")
#pragma comment(linker, "/export:?IsPacked@ImFontAtlasCustomRect@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsBuilt@ImFontAtlas@@QEBA_NXZ")
#pragma comment(linker, "/export:?SetTexID@ImFontAtlas@@QEAAXPEAX@Z")
#pragma comment(linker, "/export:?GetCustomRectByIndex@ImFontAtlas@@QEAAPEAUImFontAtlasCustomRect@@H@Z")
#pragma comment(linker, "/export:?GetCharAdvance@ImFont@@QEBAMG@Z")
#pragma comment(linker, "/export:?IsLoaded@ImFont@@QEBA_NXZ")
#pragma comment(linker, "/export:?GetDebugName@ImFont@@QEBAPEBDXZ")
#pragma comment(linker, "/export:?GetCenter@ImGuiViewport@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?GetWorkCenter@ImGuiViewport@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?GetCenter@ImRect@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?GetSize@ImRect@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?GetWidth@ImRect@@QEBAMXZ")
#pragma comment(linker, "/export:?GetHeight@ImRect@@QEBAMXZ")
#pragma comment(linker, "/export:?GetArea@ImRect@@QEBAMXZ")
#pragma comment(linker, "/export:?GetTL@ImRect@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?GetTR@ImRect@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?GetBL@ImRect@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?GetBR@ImRect@@QEBA?AUImVec2@@XZ")
#pragma comment(linker, "/export:?Contains@ImRect@@QEBA_NAEBUImVec2@@@Z")
#pragma comment(linker, "/export:?Contains@ImRect@@QEBA_NAEBU1@@Z")
#pragma comment(linker, "/export:?Overlaps@ImRect@@QEBA_NAEBU1@@Z")
#pragma comment(linker, "/export:?Add@ImRect@@QEAAXAEBUImVec2@@@Z")
#pragma comment(linker, "/export:?Add@ImRect@@QEAAXAEBU1@@Z")
#pragma comment(linker, "/export:?Expand@ImRect@@QEAAXM@Z")
#pragma comment(linker, "/export:?Expand@ImRect@@QEAAXAEBUImVec2@@@Z")
#pragma comment(linker, "/export:?Translate@ImRect@@QEAAXAEBUImVec2@@@Z")
#pragma comment(linker, "/export:?TranslateX@ImRect@@QEAAXM@Z")
#pragma comment(linker, "/export:?TranslateY@ImRect@@QEAAXM@Z")
#pragma comment(linker, "/export:?ClipWith@ImRect@@QEAAXAEBU1@@Z")
#pragma comment(linker, "/export:?ClipWithFull@ImRect@@QEAAXAEBU1@@Z")
#pragma comment(linker, "/export:?Floor@ImRect@@QEAAXXZ")
#pragma comment(linker, "/export:?IsInverted@ImRect@@QEBA_NXZ")
#pragma comment(linker, "/export:?ToVec4@ImRect@@QEBA?AUImVec4@@XZ")
#pragma comment(linker, "/export:?Create@ImBitVector@@QEAAXH@Z")
#pragma comment(linker, "/export:?Clear@ImBitVector@@QEAAXXZ")
#pragma comment(linker, "/export:?TestBit@ImBitVector@@QEBA_NH@Z")
#pragma comment(linker, "/export:?SetBit@ImBitVector@@QEAAXH@Z")
#pragma comment(linker, "/export:?ClearBit@ImBitVector@@QEAAXH@Z")
#pragma comment(linker, "/export:?clear@ImGuiTextIndex@@QEAAXXZ")
#pragma comment(linker, "/export:?size@ImGuiTextIndex@@QEAAHXZ")
#pragma comment(linker, "/export:?get_line_begin@ImGuiTextIndex@@QEAAPEBDPEBDH@Z")
#pragma comment(linker, "/export:?get_line_end@ImGuiTextIndex@@QEAAPEBDPEBDH@Z")
#pragma comment(linker, "/export:?Clear@ImDrawDataBuilder@@QEAAXXZ")
#pragma comment(linker, "/export:?ClearFreeMemory@ImDrawDataBuilder@@QEAAXXZ")
#pragma comment(linker, "/export:?GetDrawListCount@ImDrawDataBuilder@@QEBAHXZ")
#pragma comment(linker, "/export:?ClearText@ImGuiInputTextState@@QEAAXXZ")
#pragma comment(linker, "/export:?ClearFreeMemory@ImGuiInputTextState@@QEAAXXZ")
#pragma comment(linker, "/export:?GetUndoAvailCount@ImGuiInputTextState@@QEBAHXZ")
#pragma comment(linker, "/export:?GetRedoAvailCount@ImGuiInputTextState@@QEBAHXZ")
#pragma comment(linker, "/export:?CursorAnimReset@ImGuiInputTextState@@QEAAXXZ")
#pragma comment(linker, "/export:?CursorClamp@ImGuiInputTextState@@QEAAXXZ")
#pragma comment(linker, "/export:?HasSelection@ImGuiInputTextState@@QEBA_NXZ")
#pragma comment(linker, "/export:?ClearSelection@ImGuiInputTextState@@QEAAXXZ")
#pragma comment(linker, "/export:?GetCursorPos@ImGuiInputTextState@@QEBAHXZ")
#pragma comment(linker, "/export:?GetSelectionStart@ImGuiInputTextState@@QEBAHXZ")
#pragma comment(linker, "/export:?GetSelectionEnd@ImGuiInputTextState@@QEBAHXZ")
#pragma comment(linker, "/export:?SelectAll@ImGuiInputTextState@@QEAAXXZ")
#pragma comment(linker, "/export:?ClearFlags@ImGuiNextWindowData@@QEAAXXZ")
#pragma comment(linker, "/export:?ClearFlags@ImGuiNextItemData@@QEAAXXZ")
#pragma comment(linker, "/export:?Clear@ImGuiKeyRoutingTable@@QEAAXXZ")
#pragma comment(linker, "/export:?FromIndices@ImGuiListClipperRange@@SA?AU1@HH@Z")
#pragma comment(linker, "/export:?FromPositions@ImGuiListClipperRange@@SA?AU1@MMHH@Z")
#pragma comment(linker, "/export:?Reset@ImGuiListClipperData@@QEAAXPEAUImGuiListClipper@@@Z")
#pragma comment(linker, "/export:?Clear@ImGuiNavItemData@@QEAAXXZ")
#pragma comment(linker, "/export:?IsRootNode@ImGuiDockNode@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsDockSpace@ImGuiDockNode@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsFloatingNode@ImGuiDockNode@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsCentralNode@ImGuiDockNode@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsHiddenTabBar@ImGuiDockNode@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsNoTabBar@ImGuiDockNode@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsSplitNode@ImGuiDockNode@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsLeafNode@ImGuiDockNode@@QEBA_NXZ")
#pragma comment(linker, "/export:?IsEmpty@ImGuiDockNode@@QEBA_NXZ")
#pragma comment(linker, "/export:?Rect@ImGuiDockNode@@QEBA?AUImRect@@XZ")
#pragma comment(linker, "/export:?SetLocalFlags@ImGuiDockNode@@QEAAXH@Z")
#pragma comment(linker, "/export:?UpdateMergedFlags@ImGuiDockNode@@QEAAXXZ")
#pragma comment(linker, "/export:?ClearRequestFlags@ImGuiViewportP@@QEAAXXZ")
#pragma comment(linker, "/export:?CalcWorkRectPos@ImGuiViewportP@@QEBA?AUImVec2@@AEBU2@@Z")
#pragma comment(linker, "/export:?CalcWorkRectSize@ImGuiViewportP@@QEBA?AUImVec2@@AEBU2@0@Z")
#pragma comment(linker, "/export:?UpdateWorkRect@ImGuiViewportP@@QEAAXXZ")
#pragma comment(linker, "/export:?GetMainRect@ImGuiViewportP@@QEBA?AUImRect@@XZ")
#pragma comment(linker, "/export:?GetWorkRect@ImGuiViewportP@@QEBA?AUImRect@@XZ")
#pragma comment(linker, "/export:?GetBuildWorkRect@ImGuiViewportP@@QEBA?AUImRect@@XZ")
#pragma comment(linker, "/export:?GetName@ImGuiWindowSettings@@QEAAPEADXZ")
#pragma comment(linker, "/export:?Rect@ImGuiWindow@@QEBA?AUImRect@@XZ")
#pragma comment(linker, "/export:?CalcFontSize@ImGuiWindow@@QEBAMXZ")
#pragma comment(linker, "/export:?TitleBarHeight@ImGuiWindow@@QEBAMXZ")
#pragma comment(linker, "/export:?TitleBarRect@ImGuiWindow@@QEBA?AUImRect@@XZ")
#pragma comment(linker, "/export:?MenuBarHeight@ImGuiWindow@@QEBAMXZ")
#pragma comment(linker, "/export:?MenuBarRect@ImGuiWindow@@QEBA?AUImRect@@XZ")
#pragma comment(linker, "/export:?GetTabOrder@ImGuiTabBar@@QEBAHPEBUImGuiTabItem@@@Z")
#pragma comment(linker, "/export:?GetTabName@ImGuiTabBar@@QEBAPEBDPEBUImGuiTabItem@@@Z")
#pragma comment(linker, "/export:?GetColumnSettings@ImGuiTableSettings@@QEAAPEAUImGuiTableColumnSettings@@XZ")
#pragma comment(linker, "/export:??2@YAPEAX_KUImNewWrapper@@PEAX@Z")
#pragma comment(linker, "/export:??3@YAXPEAXUImNewWrapper@@0@Z")
#pragma comment(linker, "/export:?ImTriangleArea@@YAMAEBUImVec2@@00@Z")
#pragma comment(linker, "/export:?ImBitArrayTestBit@@YA_NPEBIH@Z")
#pragma comment(linker, "/export:?ImBitArrayClearBit@@YAXPEAIH@Z")
#pragma comment(linker, "/export:?ImBitArraySetBit@@YAXPEAIH@Z")
#pragma comment(linker, "/export:?ImBitArraySetBitRange@@YAXPEAIHH@Z")
#pragma comment(linker, "/export:?GetCurrentWindowRead@ImGui@@YAPEAUImGuiWindow@@XZ")
#pragma comment(linker, "/export:?GetCurrentWindow@ImGui@@YAPEAUImGuiWindow@@XZ")
#pragma comment(linker, "/export:?WindowRectAbsToRel@ImGui@@YA?AUImRect@@PEAUImGuiWindow@@AEBU2@@Z")
#pragma comment(linker, "/export:?WindowRectRelToAbs@ImGui@@YA?AUImRect@@PEAUImGuiWindow@@AEBU2@@Z")
#pragma comment(linker, "/export:?GetDefaultFont@ImGui@@YAPEAUImFont@@XZ")
#pragma comment(linker, "/export:?GetForegroundDrawList@ImGui@@YAPEAUImDrawList@@PEAUImGuiWindow@@@Z")
#pragma comment(linker, "/export:?ScrollToBringRectIntoView@ImGui@@YAXPEAUImGuiWindow@@AEBUImRect@@@Z")
#pragma comment(linker, "/export:?GetItemID@ImGui@@YAIXZ")
#pragma comment(linker, "/export:?GetItemStatusFlags@ImGui@@YAHXZ")
#pragma comment(linker, "/export:?GetItemFlags@ImGui@@YAHXZ")
#pragma comment(linker, "/export:?GetActiveID@ImGui@@YAIXZ")
#pragma comment(linker, "/export:?GetFocusID@ImGui@@YAIXZ")
#pragma comment(linker, "/export:?ItemSize@ImGui@@YAXAEBUImRect@@M@Z")
#pragma comment(linker, "/export:?IsNamedKey@ImGui@@YA_NW4ImGuiKey@@@Z")
#pragma comment(linker, "/export:?IsNamedKeyOrModKey@ImGui@@YA_NW4ImGuiKey@@@Z")
#pragma comment(linker, "/export:?IsLegacyKey@ImGui@@YA_NW4ImGuiKey@@@Z")
#pragma comment(linker, "/export:?IsGamepadKey@ImGui@@YA_NW4ImGuiKey@@@Z")
#pragma comment(linker, "/export:?IsAliasKey@ImGui@@YA_NW4ImGuiKey@@@Z")
#pragma comment(linker, "/export:?ConvertSingleModFlagToKey@ImGui@@YA?AW4ImGuiKey@@W42@@Z")
#pragma comment(linker, "/export:?MouseButtonToKey@ImGui@@YA?AW4ImGuiKey@@H@Z")
#pragma comment(linker, "/export:?IsActiveIdUsingNavDir@ImGui@@YA_NH@Z")
#pragma comment(linker, "/export:?GetKeyOwnerData@ImGui@@YAPEAUImGuiKeyOwnerData@@W4ImGuiKey@@@Z")
#pragma comment(linker, "/export:?DockNodeGetRootNode@ImGui@@YAPEAUImGuiDockNode@@PEAU2@@Z")
#pragma comment(linker, "/export:?DockNodeIsInHierarchyOf@ImGui@@YA_NPEAUImGuiDockNode@@0@Z")
#pragma comment(linker, "/export:?DockNodeGetDepth@ImGui@@YAHPEBUImGuiDockNode@@@Z")
#pragma comment(linker, "/export:?DockNodeGetWindowMenuButtonId@ImGui@@YAIPEBUImGuiDockNode@@@Z")
#pragma comment(linker, "/export:?GetWindowDockNode@ImGui@@YAPEAUImGuiDockNode@@XZ")
#pragma comment(linker, "/export:?DockBuilderGetCentralNode@ImGui@@YAPEAUImGuiDockNode@@I@Z")
#pragma comment(linker, "/export:?GetCurrentFocusScope@ImGui@@YAIXZ")
#pragma comment(linker, "/export:?GetCurrentTable@ImGui@@YAPEAUImGuiTable@@XZ")
#pragma comment(linker, "/export:?TableGetInstanceData@ImGui@@YAPEAUImGuiTableInstanceData@@PEAUImGuiTable@@H@Z")
#pragma comment(linker, "/export:?TempInputIsActive@ImGui@@YA_NI@Z")
#pragma comment(linker, "/export:?GetInputTextState@ImGui@@YAPEAUImGuiInputTextState@@I@Z")
#pragma comment(linker, "/export:?DebugDrawItemRect@ImGui@@YAXI@Z")
#pragma comment(linker, "/export:?DebugStartItemPicker@ImGui@@YAXXZ")
#pragma comment(linker, "/export:?IsKeyPressedMap@ImGui@@YA_NW4ImGuiKey@@_N@Z")

namespace ____BiohazrdInlineExportHelpers
{
    void (ImGuiInputTextCallbackData::* unused0)() = &ImGuiInputTextCallbackData::SelectAll;
    void (ImGuiInputTextCallbackData::* unused1)() = &ImGuiInputTextCallbackData::ClearSelection;
    bool (ImGuiInputTextCallbackData::* unused2)() const = &ImGuiInputTextCallbackData::HasSelection;
    void (ImGuiPayload::* unused3)() = &ImGuiPayload::Clear;
    bool (ImGuiPayload::* unused4)(const char *) const = &ImGuiPayload::IsDataType;
    bool (ImGuiPayload::* unused5)() const = &ImGuiPayload::IsPreview;
    bool (ImGuiPayload::* unused6)() const = &ImGuiPayload::IsDelivery;
    bool (ImGuiOnceUponAFrame::* unused7)() const = &ImGuiOnceUponAFrame::operator bool;
    void (ImGuiTextFilter::* unused8)() = &ImGuiTextFilter::Clear;
    bool (ImGuiTextFilter::* unused9)() const = &ImGuiTextFilter::IsActive;
    bool (ImGuiTextFilter::ImGuiTextRange::* unused10)() const = &ImGuiTextFilter::ImGuiTextRange::empty;
    char (ImGuiTextBuffer::* unused11)(int) const = &ImGuiTextBuffer::operator[];
    const char * (ImGuiTextBuffer::* unused12)() const = &ImGuiTextBuffer::begin;
    const char * (ImGuiTextBuffer::* unused13)() const = &ImGuiTextBuffer::end;
    int (ImGuiTextBuffer::* unused14)() const = &ImGuiTextBuffer::size;
    bool (ImGuiTextBuffer::* unused15)() const = &ImGuiTextBuffer::empty;
    void (ImGuiTextBuffer::* unused16)() = &ImGuiTextBuffer::clear;
    void (ImGuiTextBuffer::* unused17)(int) = &ImGuiTextBuffer::reserve;
    const char * (ImGuiTextBuffer::* unused18)() const = &ImGuiTextBuffer::c_str;
    void (ImGuiStorage::* unused19)() = &ImGuiStorage::Clear;
    void * (ImDrawCmd::* unused20)() const = &ImDrawCmd::GetTexID;
    void (ImDrawListSplitter::* unused21)() = &ImDrawListSplitter::Clear;
    ImVec2 (ImDrawList::* unused22)() const = &ImDrawList::GetClipRectMin;
    ImVec2 (ImDrawList::* unused23)() const = &ImDrawList::GetClipRectMax;
    void (ImDrawList::* unused24)() = &ImDrawList::PathClear;
    void (ImDrawList::* unused25)(const ImVec2 &) = &ImDrawList::PathLineTo;
    void (ImDrawList::* unused26)(const ImVec2 &) = &ImDrawList::PathLineToMergeDuplicate;
    void (ImDrawList::* unused27)(unsigned int) = &ImDrawList::PathFillConvex;
    void (ImDrawList::* unused28)(unsigned int, int, float) = &ImDrawList::PathStroke;
    void (ImDrawList::* unused29)(int) = &ImDrawList::ChannelsSplit;
    void (ImDrawList::* unused30)() = &ImDrawList::ChannelsMerge;
    void (ImDrawList::* unused31)(int) = &ImDrawList::ChannelsSetCurrent;
    void (ImDrawList::* unused32)(const ImVec2 &, const ImVec2 &, unsigned int) = &ImDrawList::PrimWriteVtx;
    void (ImDrawList::* unused33)(unsigned short) = &ImDrawList::PrimWriteIdx;
    void (ImDrawList::* unused34)(const ImVec2 &, const ImVec2 &, unsigned int) = &ImDrawList::PrimVtx;
    void (ImDrawData::* unused35)() = &ImDrawData::Clear;
    void (ImFontGlyphRangesBuilder::* unused36)() = &ImFontGlyphRangesBuilder::Clear;
    bool (ImFontGlyphRangesBuilder::* unused37)(unsigned long long) const = &ImFontGlyphRangesBuilder::GetBit;
    void (ImFontGlyphRangesBuilder::* unused38)(unsigned long long) = &ImFontGlyphRangesBuilder::SetBit;
    void (ImFontGlyphRangesBuilder::* unused39)(unsigned short) = &ImFontGlyphRangesBuilder::AddChar;
    bool (ImFontAtlasCustomRect::* unused40)() const = &ImFontAtlasCustomRect::IsPacked;
    bool (ImFontAtlas::* unused41)() const = &ImFontAtlas::IsBuilt;
    void (ImFontAtlas::* unused42)(void *) = &ImFontAtlas::SetTexID;
    ImFontAtlasCustomRect * (ImFontAtlas::* unused43)(int) = &ImFontAtlas::GetCustomRectByIndex;
    float (ImFont::* unused44)(unsigned short) const = &ImFont::GetCharAdvance;
    bool (ImFont::* unused45)() const = &ImFont::IsLoaded;
    const char * (ImFont::* unused46)() const = &ImFont::GetDebugName;
    ImVec2 (ImGuiViewport::* unused47)() const = &ImGuiViewport::GetCenter;
    ImVec2 (ImGuiViewport::* unused48)() const = &ImGuiViewport::GetWorkCenter;
    ImVec2 (ImRect::* unused49)() const = &ImRect::GetCenter;
    ImVec2 (ImRect::* unused50)() const = &ImRect::GetSize;
    float (ImRect::* unused51)() const = &ImRect::GetWidth;
    float (ImRect::* unused52)() const = &ImRect::GetHeight;
    float (ImRect::* unused53)() const = &ImRect::GetArea;
    ImVec2 (ImRect::* unused54)() const = &ImRect::GetTL;
    ImVec2 (ImRect::* unused55)() const = &ImRect::GetTR;
    ImVec2 (ImRect::* unused56)() const = &ImRect::GetBL;
    ImVec2 (ImRect::* unused57)() const = &ImRect::GetBR;
    bool (ImRect::* unused58)(const ImVec2 &) const = &ImRect::Contains;
    bool (ImRect::* unused59)(const ImRect &) const = &ImRect::Contains;
    bool (ImRect::* unused60)(const ImRect &) const = &ImRect::Overlaps;
    void (ImRect::* unused61)(const ImVec2 &) = &ImRect::Add;
    void (ImRect::* unused62)(const ImRect &) = &ImRect::Add;
    void (ImRect::* unused63)(const float) = &ImRect::Expand;
    void (ImRect::* unused64)(const ImVec2 &) = &ImRect::Expand;
    void (ImRect::* unused65)(const ImVec2 &) = &ImRect::Translate;
    void (ImRect::* unused66)(float) = &ImRect::TranslateX;
    void (ImRect::* unused67)(float) = &ImRect::TranslateY;
    void (ImRect::* unused68)(const ImRect &) = &ImRect::ClipWith;
    void (ImRect::* unused69)(const ImRect &) = &ImRect::ClipWithFull;
    void (ImRect::* unused70)() = &ImRect::Floor;
    bool (ImRect::* unused71)() const = &ImRect::IsInverted;
    ImVec4 (ImRect::* unused72)() const = &ImRect::ToVec4;
    void (ImBitVector::* unused73)(int) = &ImBitVector::Create;
    void (ImBitVector::* unused74)() = &ImBitVector::Clear;
    bool (ImBitVector::* unused75)(int) const = &ImBitVector::TestBit;
    void (ImBitVector::* unused76)(int) = &ImBitVector::SetBit;
    void (ImBitVector::* unused77)(int) = &ImBitVector::ClearBit;
    void (ImGuiTextIndex::* unused78)() = &ImGuiTextIndex::clear;
    int (ImGuiTextIndex::* unused79)() = &ImGuiTextIndex::size;
    const char * (ImGuiTextIndex::* unused80)(const char *, int) = &ImGuiTextIndex::get_line_begin;
    const char * (ImGuiTextIndex::* unused81)(const char *, int) = &ImGuiTextIndex::get_line_end;
    void (ImDrawDataBuilder::* unused82)() = &ImDrawDataBuilder::Clear;
    void (ImDrawDataBuilder::* unused83)() = &ImDrawDataBuilder::ClearFreeMemory;
    int (ImDrawDataBuilder::* unused84)() const = &ImDrawDataBuilder::GetDrawListCount;
    void (ImGuiInputTextState::* unused85)() = &ImGuiInputTextState::ClearText;
    void (ImGuiInputTextState::* unused86)() = &ImGuiInputTextState::ClearFreeMemory;
    int (ImGuiInputTextState::* unused87)() const = &ImGuiInputTextState::GetUndoAvailCount;
    int (ImGuiInputTextState::* unused88)() const = &ImGuiInputTextState::GetRedoAvailCount;
    void (ImGuiInputTextState::* unused89)() = &ImGuiInputTextState::CursorAnimReset;
    void (ImGuiInputTextState::* unused90)() = &ImGuiInputTextState::CursorClamp;
    bool (ImGuiInputTextState::* unused91)() const = &ImGuiInputTextState::HasSelection;
    void (ImGuiInputTextState::* unused92)() = &ImGuiInputTextState::ClearSelection;
    int (ImGuiInputTextState::* unused93)() const = &ImGuiInputTextState::GetCursorPos;
    int (ImGuiInputTextState::* unused94)() const = &ImGuiInputTextState::GetSelectionStart;
    int (ImGuiInputTextState::* unused95)() const = &ImGuiInputTextState::GetSelectionEnd;
    void (ImGuiInputTextState::* unused96)() = &ImGuiInputTextState::SelectAll;
    void (ImGuiNextWindowData::* unused97)() = &ImGuiNextWindowData::ClearFlags;
    void (ImGuiNextItemData::* unused98)() = &ImGuiNextItemData::ClearFlags;
    void (ImGuiKeyRoutingTable::* unused99)() = &ImGuiKeyRoutingTable::Clear;
    ImGuiListClipperRange (*unused100)(int, int) = &ImGuiListClipperRange::FromIndices;
    ImGuiListClipperRange (*unused101)(float, float, int, int) = &ImGuiListClipperRange::FromPositions;
    void (ImGuiListClipperData::* unused102)(ImGuiListClipper *) = &ImGuiListClipperData::Reset;
    void (ImGuiNavItemData::* unused103)() = &ImGuiNavItemData::Clear;
    bool (ImGuiDockNode::* unused104)() const = &ImGuiDockNode::IsRootNode;
    bool (ImGuiDockNode::* unused105)() const = &ImGuiDockNode::IsDockSpace;
    bool (ImGuiDockNode::* unused106)() const = &ImGuiDockNode::IsFloatingNode;
    bool (ImGuiDockNode::* unused107)() const = &ImGuiDockNode::IsCentralNode;
    bool (ImGuiDockNode::* unused108)() const = &ImGuiDockNode::IsHiddenTabBar;
    bool (ImGuiDockNode::* unused109)() const = &ImGuiDockNode::IsNoTabBar;
    bool (ImGuiDockNode::* unused110)() const = &ImGuiDockNode::IsSplitNode;
    bool (ImGuiDockNode::* unused111)() const = &ImGuiDockNode::IsLeafNode;
    bool (ImGuiDockNode::* unused112)() const = &ImGuiDockNode::IsEmpty;
    ImRect (ImGuiDockNode::* unused113)() const = &ImGuiDockNode::Rect;
    void (ImGuiDockNode::* unused114)(int) = &ImGuiDockNode::SetLocalFlags;
    void (ImGuiDockNode::* unused115)() = &ImGuiDockNode::UpdateMergedFlags;
    void (ImGuiViewportP::* unused116)() = &ImGuiViewportP::ClearRequestFlags;
    ImVec2 (ImGuiViewportP::* unused117)(const ImVec2 &) const = &ImGuiViewportP::CalcWorkRectPos;
    ImVec2 (ImGuiViewportP::* unused118)(const ImVec2 &, const ImVec2 &) const = &ImGuiViewportP::CalcWorkRectSize;
    void (ImGuiViewportP::* unused119)() = &ImGuiViewportP::UpdateWorkRect;
    ImRect (ImGuiViewportP::* unused120)() const = &ImGuiViewportP::GetMainRect;
    ImRect (ImGuiViewportP::* unused121)() const = &ImGuiViewportP::GetWorkRect;
    ImRect (ImGuiViewportP::* unused122)() const = &ImGuiViewportP::GetBuildWorkRect;
    char * (ImGuiWindowSettings::* unused123)() = &ImGuiWindowSettings::GetName;
    ImRect (ImGuiWindow::* unused124)() const = &ImGuiWindow::Rect;
    float (ImGuiWindow::* unused125)() const = &ImGuiWindow::CalcFontSize;
    float (ImGuiWindow::* unused126)() const = &ImGuiWindow::TitleBarHeight;
    ImRect (ImGuiWindow::* unused127)() const = &ImGuiWindow::TitleBarRect;
    float (ImGuiWindow::* unused128)() const = &ImGuiWindow::MenuBarHeight;
    ImRect (ImGuiWindow::* unused129)() const = &ImGuiWindow::MenuBarRect;
    int (ImGuiTabBar::* unused130)(const ImGuiTabItem *) const = &ImGuiTabBar::GetTabOrder;
    const char * (ImGuiTabBar::* unused131)(const ImGuiTabItem *) const = &ImGuiTabBar::GetTabName;
    ImGuiTableColumnSettings * (ImGuiTableSettings::* unused132)() = &ImGuiTableSettings::GetColumnSettings;
    void * (*unused133)(unsigned long long, ImNewWrapper, void *) = &operator new;
    void (*unused134)(void *, ImNewWrapper, void *) = &operator delete;
    float (*unused135)(const ImVec2 &, const ImVec2 &, const ImVec2 &) = &ImTriangleArea;
    bool (*unused136)(const unsigned int *, int) = &ImBitArrayTestBit;
    void (*unused137)(unsigned int *, int) = &ImBitArrayClearBit;
    void (*unused138)(unsigned int *, int) = &ImBitArraySetBit;
    void (*unused139)(unsigned int *, int, int) = &ImBitArraySetBitRange;
    ImGuiWindow * (*unused140)() = &ImGui::GetCurrentWindowRead;
    ImGuiWindow * (*unused141)() = &ImGui::GetCurrentWindow;
    ImRect (*unused142)(ImGuiWindow *, const ImRect &) = &ImGui::WindowRectAbsToRel;
    ImRect (*unused143)(ImGuiWindow *, const ImRect &) = &ImGui::WindowRectRelToAbs;
    ImFont * (*unused144)() = &ImGui::GetDefaultFont;
    ImDrawList * (*unused145)(ImGuiWindow *) = &ImGui::GetForegroundDrawList;
    void (*unused146)(ImGuiWindow *, const ImRect &) = &ImGui::ScrollToBringRectIntoView;
    unsigned int (*unused147)() = &ImGui::GetItemID;
    int (*unused148)() = &ImGui::GetItemStatusFlags;
    int (*unused149)() = &ImGui::GetItemFlags;
    unsigned int (*unused150)() = &ImGui::GetActiveID;
    unsigned int (*unused151)() = &ImGui::GetFocusID;
    void (*unused152)(const ImRect &, float) = &ImGui::ItemSize;
    bool (*unused153)(ImGuiKey) = &ImGui::IsNamedKey;
    bool (*unused154)(ImGuiKey) = &ImGui::IsNamedKeyOrModKey;
    bool (*unused155)(ImGuiKey) = &ImGui::IsLegacyKey;
    bool (*unused156)(ImGuiKey) = &ImGui::IsGamepadKey;
    bool (*unused157)(ImGuiKey) = &ImGui::IsAliasKey;
    ImGuiKey (*unused158)(ImGuiKey) = &ImGui::ConvertSingleModFlagToKey;
    ImGuiKey (*unused159)(int) = &ImGui::MouseButtonToKey;
    bool (*unused160)(int) = &ImGui::IsActiveIdUsingNavDir;
    ImGuiKeyOwnerData * (*unused161)(ImGuiKey) = &ImGui::GetKeyOwnerData;
    ImGuiDockNode * (*unused162)(ImGuiDockNode *) = &ImGui::DockNodeGetRootNode;
    bool (*unused163)(ImGuiDockNode *, ImGuiDockNode *) = &ImGui::DockNodeIsInHierarchyOf;
    int (*unused164)(const ImGuiDockNode *) = &ImGui::DockNodeGetDepth;
    unsigned int (*unused165)(const ImGuiDockNode *) = &ImGui::DockNodeGetWindowMenuButtonId;
    ImGuiDockNode * (*unused166)() = &ImGui::GetWindowDockNode;
    ImGuiDockNode * (*unused167)(unsigned int) = &ImGui::DockBuilderGetCentralNode;
    unsigned int (*unused168)() = &ImGui::GetCurrentFocusScope;
    ImGuiTable * (*unused169)() = &ImGui::GetCurrentTable;
    ImGuiTableInstanceData * (*unused170)(ImGuiTable *, int) = &ImGui::TableGetInstanceData;
    bool (*unused171)(unsigned int) = &ImGui::TempInputIsActive;
    ImGuiInputTextState * (*unused172)(unsigned int) = &ImGui::GetInputTextState;
    void (*unused173)(unsigned int) = &ImGui::DebugDrawItemRect;
    void (*unused174)() = &ImGui::DebugStartItemPicker;
    bool (*unused175)(ImGuiKey, bool) = &ImGui::IsKeyPressedMap;
}

namespace ____BiohazrdInlineExportHelpers
{
    struct __BiohazrdNewHelper { };
}

inline void* operator new(size_t, ____BiohazrdInlineExportHelpers::__BiohazrdNewHelper, void* _this) { return _this; }
inline void operator delete(void*, ____BiohazrdInlineExportHelpers::__BiohazrdNewHelper, void*) { }

#pragma warning(disable: 4190) // C-linkage function returning C++ type
extern "C" namespace ____BiohazrdInlineExportHelpers
{
    __declspec(dllexport) ImGuiWindowClass* __InlineHelper0(ImGuiWindowClass* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiWindowClass(); }

    __declspec(dllexport) ImGuiPayload* __InlineHelper1(ImGuiPayload* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiPayload(); }

    __declspec(dllexport) ImGuiTableColumnSortSpecs* __InlineHelper2(ImGuiTableColumnSortSpecs* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTableColumnSortSpecs(); }

    __declspec(dllexport) ImGuiTableSortSpecs* __InlineHelper3(ImGuiTableSortSpecs* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTableSortSpecs(); }

    __declspec(dllexport) ImGuiOnceUponAFrame* __InlineHelper4(ImGuiOnceUponAFrame* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiOnceUponAFrame(); }

    __declspec(dllexport) ImGuiTextFilter::ImGuiTextRange* __InlineHelper5(ImGuiTextFilter::ImGuiTextRange* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTextFilter::ImGuiTextRange(); }

    __declspec(dllexport) ImGuiTextFilter::ImGuiTextRange* __InlineHelper6(ImGuiTextFilter::ImGuiTextRange* _this, const char *_0, const char *_1)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTextFilter::ImGuiTextRange(_0, _1); }

    __declspec(dllexport) ImGuiTextBuffer* __InlineHelper7(ImGuiTextBuffer* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTextBuffer(); }

    __declspec(dllexport) ImGuiStorage::ImGuiStoragePair* __InlineHelper8(ImGuiStorage::ImGuiStoragePair* _this, unsigned int _0, int _1)
    { return new (__BiohazrdNewHelper(), _this) ImGuiStorage::ImGuiStoragePair(_0, _1); }

    __declspec(dllexport) ImGuiStorage::ImGuiStoragePair* __InlineHelper9(ImGuiStorage::ImGuiStoragePair* _this, unsigned int _0, float _1)
    { return new (__BiohazrdNewHelper(), _this) ImGuiStorage::ImGuiStoragePair(_0, _1); }

    __declspec(dllexport) ImGuiStorage::ImGuiStoragePair* __InlineHelper10(ImGuiStorage::ImGuiStoragePair* _this, unsigned int _0, void *_1)
    { return new (__BiohazrdNewHelper(), _this) ImGuiStorage::ImGuiStoragePair(_0, _1); }

    __declspec(dllexport) ImDrawCmd* __InlineHelper11(ImDrawCmd* _this)
    { return new (__BiohazrdNewHelper(), _this) ImDrawCmd(); }

    __declspec(dllexport) ImDrawListSplitter* __InlineHelper12(ImDrawListSplitter* _this)
    { return new (__BiohazrdNewHelper(), _this) ImDrawListSplitter(); }

    __declspec(dllexport) void __InlineHelper13(ImDrawListSplitter* _this)
    { _this->~ImDrawListSplitter(); }

    __declspec(dllexport) ImDrawList* __InlineHelper14(ImDrawList* _this, ImDrawListSharedData *_0)
    { return new (__BiohazrdNewHelper(), _this) ImDrawList(_0); }

    __declspec(dllexport) void __InlineHelper15(ImDrawList* _this)
    { _this->~ImDrawList(); }

    __declspec(dllexport) ImDrawData* __InlineHelper16(ImDrawData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImDrawData(); }

    __declspec(dllexport) ImFontGlyphRangesBuilder* __InlineHelper17(ImFontGlyphRangesBuilder* _this)
    { return new (__BiohazrdNewHelper(), _this) ImFontGlyphRangesBuilder(); }

    __declspec(dllexport) ImFontAtlasCustomRect* __InlineHelper18(ImFontAtlasCustomRect* _this)
    { return new (__BiohazrdNewHelper(), _this) ImFontAtlasCustomRect(); }

    __declspec(dllexport) ImGuiViewport* __InlineHelper19(ImGuiViewport* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiViewport(); }

    __declspec(dllexport) void __InlineHelper20(ImGuiViewport* _this)
    { _this->~ImGuiViewport(); }

    __declspec(dllexport) ImGuiPlatformIO* __InlineHelper21(ImGuiPlatformIO* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiPlatformIO(); }

    __declspec(dllexport) ImGuiPlatformMonitor* __InlineHelper22(ImGuiPlatformMonitor* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiPlatformMonitor(); }

    __declspec(dllexport) ImGuiPlatformImeData* __InlineHelper23(ImGuiPlatformImeData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiPlatformImeData(); }

    __declspec(dllexport) ImRect* __InlineHelper24(ImRect* _this)
    { return new (__BiohazrdNewHelper(), _this) ImRect(); }

    __declspec(dllexport) ImRect* __InlineHelper25(ImRect* _this, const ImVec2 &_0, const ImVec2 &_1)
    { return new (__BiohazrdNewHelper(), _this) ImRect(_0, _1); }

    __declspec(dllexport) ImRect* __InlineHelper26(ImRect* _this, const ImVec4 &_0)
    { return new (__BiohazrdNewHelper(), _this) ImRect(_0); }

    __declspec(dllexport) ImRect* __InlineHelper27(ImRect* _this, float _0, float _1, float _2, float _3)
    { return new (__BiohazrdNewHelper(), _this) ImRect(_0, _1, _2, _3); }

    __declspec(dllexport) ImGuiStyleMod* __InlineHelper28(ImGuiStyleMod* _this, int _0, int _1)
    { return new (__BiohazrdNewHelper(), _this) ImGuiStyleMod(_0, _1); }

    __declspec(dllexport) ImGuiStyleMod* __InlineHelper29(ImGuiStyleMod* _this, int _0, float _1)
    { return new (__BiohazrdNewHelper(), _this) ImGuiStyleMod(_0, _1); }

    __declspec(dllexport) ImGuiStyleMod* __InlineHelper30(ImGuiStyleMod* _this, int _0, ImVec2 _1)
    { return new (__BiohazrdNewHelper(), _this) ImGuiStyleMod(_0, _1); }

    __declspec(dllexport) ImGuiComboPreviewData* __InlineHelper31(ImGuiComboPreviewData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiComboPreviewData(); }

    __declspec(dllexport) ImGuiMenuColumns* __InlineHelper32(ImGuiMenuColumns* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiMenuColumns(); }

    __declspec(dllexport) ImGuiInputTextState* __InlineHelper33(ImGuiInputTextState* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiInputTextState(); }

    __declspec(dllexport) ImGuiPopupData* __InlineHelper34(ImGuiPopupData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiPopupData(); }

    __declspec(dllexport) ImGuiNextWindowData* __InlineHelper35(ImGuiNextWindowData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiNextWindowData(); }

    __declspec(dllexport) ImGuiNextItemData* __InlineHelper36(ImGuiNextItemData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiNextItemData(); }

    __declspec(dllexport) ImGuiLastItemData* __InlineHelper37(ImGuiLastItemData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiLastItemData(); }

    __declspec(dllexport) ImGuiStackSizes* __InlineHelper38(ImGuiStackSizes* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiStackSizes(); }

    __declspec(dllexport) ImGuiPtrOrIndex* __InlineHelper39(ImGuiPtrOrIndex* _this, void *_0)
    { return new (__BiohazrdNewHelper(), _this) ImGuiPtrOrIndex(_0); }

    __declspec(dllexport) ImGuiPtrOrIndex* __InlineHelper40(ImGuiPtrOrIndex* _this, int _0)
    { return new (__BiohazrdNewHelper(), _this) ImGuiPtrOrIndex(_0); }

    __declspec(dllexport) ImGuiInputEvent* __InlineHelper41(ImGuiInputEvent* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiInputEvent(); }

    __declspec(dllexport) ImGuiKeyRoutingData* __InlineHelper42(ImGuiKeyRoutingData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiKeyRoutingData(); }

    __declspec(dllexport) ImGuiKeyRoutingTable* __InlineHelper43(ImGuiKeyRoutingTable* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiKeyRoutingTable(); }

    __declspec(dllexport) ImGuiKeyOwnerData* __InlineHelper44(ImGuiKeyOwnerData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiKeyOwnerData(); }

    __declspec(dllexport) ImGuiListClipperData* __InlineHelper45(ImGuiListClipperData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiListClipperData(); }

    __declspec(dllexport) ImGuiNavItemData* __InlineHelper46(ImGuiNavItemData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiNavItemData(); }

    __declspec(dllexport) ImGuiOldColumnData* __InlineHelper47(ImGuiOldColumnData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiOldColumnData(); }

    __declspec(dllexport) ImGuiOldColumns* __InlineHelper48(ImGuiOldColumns* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiOldColumns(); }

    __declspec(dllexport) ImGuiDockContext* __InlineHelper49(ImGuiDockContext* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiDockContext(); }

    __declspec(dllexport) ImGuiViewportP* __InlineHelper50(ImGuiViewportP* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiViewportP(); }

    __declspec(dllexport) void __InlineHelper51(ImGuiViewportP* _this)
    { _this->~ImGuiViewportP(); }

    __declspec(dllexport) ImGuiWindowSettings* __InlineHelper52(ImGuiWindowSettings* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiWindowSettings(); }

    __declspec(dllexport) ImGuiSettingsHandler* __InlineHelper53(ImGuiSettingsHandler* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiSettingsHandler(); }

    __declspec(dllexport) ImGuiMetricsConfig* __InlineHelper54(ImGuiMetricsConfig* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiMetricsConfig(); }

    __declspec(dllexport) ImGuiStackLevelInfo* __InlineHelper55(ImGuiStackLevelInfo* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiStackLevelInfo(); }

    __declspec(dllexport) ImGuiStackTool* __InlineHelper56(ImGuiStackTool* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiStackTool(); }

    __declspec(dllexport) ImGuiContextHook* __InlineHelper57(ImGuiContextHook* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiContextHook(); }

    __declspec(dllexport) ImGuiContext* __InlineHelper58(ImGuiContext* _this, ImFontAtlas *_0)
    { return new (__BiohazrdNewHelper(), _this) ImGuiContext(_0); }

    __declspec(dllexport) ImGuiTabItem* __InlineHelper59(ImGuiTabItem* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTabItem(); }

    __declspec(dllexport) ImGuiTableColumn* __InlineHelper60(ImGuiTableColumn* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTableColumn(); }

    __declspec(dllexport) ImGuiTableInstanceData* __InlineHelper61(ImGuiTableInstanceData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTableInstanceData(); }

    __declspec(dllexport) ImGuiTable* __InlineHelper62(ImGuiTable* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTable(); }

    __declspec(dllexport) void __InlineHelper63(ImGuiTable* _this)
    { _this->~ImGuiTable(); }

    __declspec(dllexport) ImGuiTableTempData* __InlineHelper64(ImGuiTableTempData* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTableTempData(); }

    __declspec(dllexport) ImGuiTableColumnSettings* __InlineHelper65(ImGuiTableColumnSettings* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTableColumnSettings(); }

    __declspec(dllexport) ImGuiTableSettings* __InlineHelper66(ImGuiTableSettings* _this)
    { return new (__BiohazrdNewHelper(), _this) ImGuiTableSettings(); }

    __declspec(dllexport) void __InlineHelper67(void *_0, unsigned long long _1, unsigned long long _2, int (*_3)(const void *, const void *))
    { ImQsort(_0, _1, _2, _3); }

    __declspec(dllexport) bool __InlineHelper68(int _0)
    { return ImIsPowerOfTwo(_0); }

    __declspec(dllexport) bool __InlineHelper69(unsigned long long _0)
    { return ImIsPowerOfTwo(_0); }

    __declspec(dllexport) int __InlineHelper70(int _0)
    { return ImUpperPowerOfTwo(_0); }

    __declspec(dllexport) char __InlineHelper71(char _0)
    { return ImToUpper(_0); }

    __declspec(dllexport) bool __InlineHelper72(char _0)
    { return ImCharIsBlankA(_0); }

    __declspec(dllexport) bool __InlineHelper73(unsigned int _0)
    { return ImCharIsBlankW(_0); }

    __declspec(dllexport) float __InlineHelper74(float _0, float _1)
    { return ImPow(_0, _1); }

    __declspec(dllexport) double __InlineHelper75(double _0, double _1)
    { return ImPow(_0, _1); }

    __declspec(dllexport) float __InlineHelper76(float _0)
    { return ImLog(_0); }

    __declspec(dllexport) double __InlineHelper77(double _0)
    { return ImLog(_0); }

    __declspec(dllexport) int __InlineHelper78(int _0)
    { return ImAbs(_0); }

    __declspec(dllexport) float __InlineHelper79(float _0)
    { return ImAbs(_0); }

    __declspec(dllexport) double __InlineHelper80(double _0)
    { return ImAbs(_0); }

    __declspec(dllexport) float __InlineHelper81(float _0)
    { return ImSign(_0); }

    __declspec(dllexport) double __InlineHelper82(double _0)
    { return ImSign(_0); }

    __declspec(dllexport) float __InlineHelper83(float _0)
    { return ImRsqrt(_0); }

    __declspec(dllexport) double __InlineHelper84(double _0)
    { return ImRsqrt(_0); }

    __declspec(dllexport) ImVec2 __InlineHelper85(const ImVec2 &_0, const ImVec2 &_1)
    { return ImMin(_0, _1); }

    __declspec(dllexport) ImVec2 __InlineHelper86(const ImVec2 &_0, const ImVec2 &_1)
    { return ImMax(_0, _1); }

    __declspec(dllexport) ImVec2 __InlineHelper87(const ImVec2 &_0, const ImVec2 &_1, ImVec2 _2)
    { return ImClamp(_0, _1, _2); }

    __declspec(dllexport) ImVec2 __InlineHelper88(const ImVec2 &_0, const ImVec2 &_1, float _2)
    { return ImLerp(_0, _1, _2); }

    __declspec(dllexport) ImVec2 __InlineHelper89(const ImVec2 &_0, const ImVec2 &_1, const ImVec2 &_2)
    { return ImLerp(_0, _1, _2); }

    __declspec(dllexport) ImVec4 __InlineHelper90(const ImVec4 &_0, const ImVec4 &_1, float _2)
    { return ImLerp(_0, _1, _2); }

    __declspec(dllexport) float __InlineHelper91(float _0)
    { return ImSaturate(_0); }

    __declspec(dllexport) float __InlineHelper92(const ImVec2 &_0)
    { return ImLengthSqr(_0); }

    __declspec(dllexport) float __InlineHelper93(const ImVec4 &_0)
    { return ImLengthSqr(_0); }

    __declspec(dllexport) float __InlineHelper94(const ImVec2 &_0, float _1)
    { return ImInvLength(_0, _1); }

    __declspec(dllexport) float __InlineHelper95(float _0)
    { return ImFloor(_0); }

    __declspec(dllexport) float __InlineHelper96(float _0)
    { return ImFloorSigned(_0); }

    __declspec(dllexport) ImVec2 __InlineHelper97(const ImVec2 &_0)
    { return ImFloor(_0); }

    __declspec(dllexport) ImVec2 __InlineHelper98(const ImVec2 &_0)
    { return ImFloorSigned(_0); }

    __declspec(dllexport) int __InlineHelper99(int _0, int _1)
    { return ImModPositive(_0, _1); }

    __declspec(dllexport) float __InlineHelper100(const ImVec2 &_0, const ImVec2 &_1)
    { return ImDot(_0, _1); }

    __declspec(dllexport) ImVec2 __InlineHelper101(const ImVec2 &_0, float _1, float _2)
    { return ImRotate(_0, _1, _2); }

    __declspec(dllexport) float __InlineHelper102(float _0, float _1, float _2)
    { return ImLinearSweep(_0, _1, _2); }

    __declspec(dllexport) ImVec2 __InlineHelper103(const ImVec2 &_0, const ImVec2 &_1)
    { return ImMul(_0, _1); }

    __declspec(dllexport) bool __InlineHelper104(float _0)
    { return ImIsFloatAboveGuaranteedIntegerPrecision(_0); }
}
