<a name='assembly'></a>
# xyLOGIX.EasyTabs

## Contents

- [ChromeTabRenderer](#T-xyLOGIX-EasyTabs-ChromeTabRenderer 'xyLOGIX.EasyTabs.ChromeTabRenderer')
  - [#ctor(parent)](#M-xyLOGIX-EasyTabs-ChromeTabRenderer-#ctor-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.ChromeTabRenderer.#ctor(xyLOGIX.EasyTabs.TitleBarTabs)')
  - [ChromeAddButtonMarginLeft](#F-xyLOGIX-EasyTabs-ChromeTabRenderer-ChromeAddButtonMarginLeft 'xyLOGIX.EasyTabs.ChromeTabRenderer.ChromeAddButtonMarginLeft')
  - [ChromeAddButtonMarginRight](#F-xyLOGIX-EasyTabs-ChromeTabRenderer-ChromeAddButtonMarginRight 'xyLOGIX.EasyTabs.ChromeTabRenderer.ChromeAddButtonMarginRight')
  - [ChromeAddButtonMarginTop](#F-xyLOGIX-EasyTabs-ChromeTabRenderer-ChromeAddButtonMarginTop 'xyLOGIX.EasyTabs.ChromeTabRenderer.ChromeAddButtonMarginTop')
  - [ChromeCloseButtonMarginLeft](#F-xyLOGIX-EasyTabs-ChromeTabRenderer-ChromeCloseButtonMarginLeft 'xyLOGIX.EasyTabs.ChromeTabRenderer.ChromeCloseButtonMarginLeft')
  - [_windowsSizingBoxes](#F-xyLOGIX-EasyTabs-ChromeTabRenderer-_windowsSizingBoxes 'xyLOGIX.EasyTabs.ChromeTabRenderer._windowsSizingBoxes')
  - [ActiveCenterImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-ActiveCenterImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.ActiveCenterImage')
  - [ActiveLeftSideImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-ActiveLeftSideImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.ActiveLeftSideImage')
  - [ActiveRightSideImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-ActiveRightSideImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.ActiveRightSideImage')
  - [AddButtonHoverImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonHoverImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.AddButtonHoverImage')
  - [AddButtonImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.AddButtonImage')
  - [AddButtonMarginLeft](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonMarginLeft 'xyLOGIX.EasyTabs.ChromeTabRenderer.AddButtonMarginLeft')
  - [AddButtonMarginRight](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonMarginRight 'xyLOGIX.EasyTabs.ChromeTabRenderer.AddButtonMarginRight')
  - [AddButtonMarginTop](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonMarginTop 'xyLOGIX.EasyTabs.ChromeTabRenderer.AddButtonMarginTop')
  - [BackgroundImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-BackgroundImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.BackgroundImage')
  - [CaptionFont](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-CaptionFont 'xyLOGIX.EasyTabs.ChromeTabRenderer.CaptionFont')
  - [CaptionMarginLeft](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-CaptionMarginLeft 'xyLOGIX.EasyTabs.ChromeTabRenderer.CaptionMarginLeft')
  - [CaptionMarginRight](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-CaptionMarginRight 'xyLOGIX.EasyTabs.ChromeTabRenderer.CaptionMarginRight')
  - [CaptionMarginTop](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-CaptionMarginTop 'xyLOGIX.EasyTabs.ChromeTabRenderer.CaptionMarginTop')
  - [CloseButtonMarginLeft](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-CloseButtonMarginLeft 'xyLOGIX.EasyTabs.ChromeTabRenderer.CloseButtonMarginLeft')
  - [CloseButtonMarginRight](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-CloseButtonMarginRight 'xyLOGIX.EasyTabs.ChromeTabRenderer.CloseButtonMarginRight')
  - [CloseButtonMarginTop](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-CloseButtonMarginTop 'xyLOGIX.EasyTabs.ChromeTabRenderer.CloseButtonMarginTop')
  - [IconMarginLeft](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-IconMarginLeft 'xyLOGIX.EasyTabs.ChromeTabRenderer.IconMarginLeft')
  - [IconMarginRight](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-IconMarginRight 'xyLOGIX.EasyTabs.ChromeTabRenderer.IconMarginRight')
  - [IconMarginTop](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-IconMarginTop 'xyLOGIX.EasyTabs.ChromeTabRenderer.IconMarginTop')
  - [InactiveRightSideImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-InactiveRightSideImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.InactiveRightSideImage')
  - [InactiveTabContentAreaImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-InactiveTabContentAreaImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.InactiveTabContentAreaImage')
  - [OverlapWidth](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-OverlapWidth 'xyLOGIX.EasyTabs.ChromeTabRenderer.OverlapWidth')
  - [RendersEntireTitleBar](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-RendersEntireTitleBar 'xyLOGIX.EasyTabs.ChromeTabRenderer.RendersEntireTitleBar')
  - [TabCloseButtonHoverImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-TabCloseButtonHoverImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.TabCloseButtonHoverImage')
  - [TabCloseButtonImage](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-TabCloseButtonImage 'xyLOGIX.EasyTabs.ChromeTabRenderer.TabCloseButtonImage')
  - [TabHeight](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-TabHeight 'xyLOGIX.EasyTabs.ChromeTabRenderer.TabHeight')
  - [TopPadding](#P-xyLOGIX-EasyTabs-ChromeTabRenderer-TopPadding 'xyLOGIX.EasyTabs.ChromeTabRenderer.TopPadding')
  - [GetMaxTabWellWidth(tabs,offset)](#M-xyLOGIX-EasyTabs-ChromeTabRenderer-GetMaxTabWellWidth-System-Collections-Generic-IList{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Point- 'xyLOGIX.EasyTabs.ChromeTabRenderer.GetMaxTabWellWidth(System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab},System.Drawing.Point)')
  - [IsOverSizingBox(mousePointerCoords)](#M-xyLOGIX-EasyTabs-ChromeTabRenderer-IsOverSizingBox-System-Drawing-Point- 'xyLOGIX.EasyTabs.ChromeTabRenderer.IsOverSizingBox(System.Drawing.Point)')
  - [NonClientHitTest(message,mousePointerCoords)](#M-xyLOGIX-EasyTabs-ChromeTabRenderer-NonClientHitTest-System-Windows-Forms-Message,System-Drawing-Point- 'xyLOGIX.EasyTabs.ChromeTabRenderer.NonClientHitTest(System.Windows.Forms.Message,System.Drawing.Point)')
  - [Render(tabs,graphicsContext,cursor,forceRedraw,offset)](#M-xyLOGIX-EasyTabs-ChromeTabRenderer-Render-System-Collections-Generic-IList{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Graphics,System-Drawing-Point,System-Drawing-Point,System-Boolean- 'xyLOGIX.EasyTabs.ChromeTabRenderer.Render(System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab},System.Drawing.Graphics,System.Drawing.Point,System.Drawing.Point,System.Boolean)')
  - [Render(graphicsContext,tab,index,area,cursor,tabLeftImage,tabCenterImage,tabRightImage)](#M-xyLOGIX-EasyTabs-ChromeTabRenderer-Render-System-Drawing-Graphics,xyLOGIX-EasyTabs-TitleBarTab,System-Int32,System-Drawing-Rectangle,System-Drawing-Point,System-Drawing-Image,System-Drawing-Image,System-Drawing-Image- 'xyLOGIX.EasyTabs.ChromeTabRenderer.Render(System.Drawing.Graphics,xyLOGIX.EasyTabs.TitleBarTab,System.Int32,System.Drawing.Rectangle,System.Drawing.Point,System.Drawing.Image,System.Drawing.Image,System.Drawing.Image)')
- [DisplayType](#T-xyLOGIX-EasyTabs-DisplayType 'xyLOGIX.EasyTabs.DisplayType')
  - [Aero](#F-xyLOGIX-EasyTabs-DisplayType-Aero 'xyLOGIX.EasyTabs.DisplayType.Aero')
  - [Basic](#F-xyLOGIX-EasyTabs-DisplayType-Basic 'xyLOGIX.EasyTabs.DisplayType.Basic')
  - [Classic](#F-xyLOGIX-EasyTabs-DisplayType-Classic 'xyLOGIX.EasyTabs.DisplayType.Classic')
- [IListWithEvents\`1](#T-xyLOGIX-EasyTabs-IListWithEvents`1 'xyLOGIX.EasyTabs.IListWithEvents`1')
  - [EventsSuppressed](#P-xyLOGIX-EasyTabs-IListWithEvents`1-EventsSuppressed 'xyLOGIX.EasyTabs.IListWithEvents`1.EventsSuppressed')
  - [AddRange()](#M-xyLOGIX-EasyTabs-IListWithEvents`1-AddRange-System-Collections-Generic-IEnumerable{`0}- 'xyLOGIX.EasyTabs.IListWithEvents`1.AddRange(System.Collections.Generic.IEnumerable{`0})')
  - [InsertRange()](#M-xyLOGIX-EasyTabs-IListWithEvents`1-InsertRange-System-Int32,System-Collections-Generic-IEnumerable{`0}- 'xyLOGIX.EasyTabs.IListWithEvents`1.InsertRange(System.Int32,System.Collections.Generic.IEnumerable{`0})')
  - [RemoveAll()](#M-xyLOGIX-EasyTabs-IListWithEvents`1-RemoveAll-System-Predicate{`0}- 'xyLOGIX.EasyTabs.IListWithEvents`1.RemoveAll(System.Predicate{`0})')
  - [RemoveRange()](#M-xyLOGIX-EasyTabs-IListWithEvents`1-RemoveRange-System-Int32,System-Int32- 'xyLOGIX.EasyTabs.IListWithEvents`1.RemoveRange(System.Int32,System.Int32)')
  - [RemoveRange(collection)](#M-xyLOGIX-EasyTabs-IListWithEvents`1-RemoveRange-System-Collections-Generic-IEnumerable{`0}- 'xyLOGIX.EasyTabs.IListWithEvents`1.RemoveRange(System.Collections.Generic.IEnumerable{`0})')
  - [ResumeEvents()](#M-xyLOGIX-EasyTabs-IListWithEvents`1-ResumeEvents 'xyLOGIX.EasyTabs.IListWithEvents`1.ResumeEvents')
  - [SuppressEvents()](#M-xyLOGIX-EasyTabs-IListWithEvents`1-SuppressEvents 'xyLOGIX.EasyTabs.IListWithEvents`1.SuppressEvents')
  - [TrimExcess()](#M-xyLOGIX-EasyTabs-IListWithEvents`1-TrimExcess 'xyLOGIX.EasyTabs.IListWithEvents`1.TrimExcess')
- [LayeredWindow](#T-xyLOGIX-EasyTabs-LayeredWindow 'xyLOGIX.EasyTabs.LayeredWindow')
  - [#ctor()](#M-xyLOGIX-EasyTabs-LayeredWindow-#ctor 'xyLOGIX.EasyTabs.LayeredWindow.#ctor')
  - [CreateParams](#P-xyLOGIX-EasyTabs-LayeredWindow-CreateParams 'xyLOGIX.EasyTabs.LayeredWindow.CreateParams')
  - [UpdateWindow(image,opacity,width,height,position)](#M-xyLOGIX-EasyTabs-LayeredWindow-UpdateWindow-System-Drawing-Bitmap,System-Byte,System-Int32,System-Int32,Win32Interop-Structs-POINT- 'xyLOGIX.EasyTabs.LayeredWindow.UpdateWindow(System.Drawing.Bitmap,System.Byte,System.Int32,System.Int32,Win32Interop.Structs.POINT)')
- [ListItemEventArgs](#T-xyLOGIX-EasyTabs-ListItemEventArgs 'xyLOGIX.EasyTabs.ListItemEventArgs')
  - [#ctor(itemIndex)](#M-xyLOGIX-EasyTabs-ListItemEventArgs-#ctor-System-Int32- 'xyLOGIX.EasyTabs.ListItemEventArgs.#ctor(System.Int32)')
  - [_itemIndex](#F-xyLOGIX-EasyTabs-ListItemEventArgs-_itemIndex 'xyLOGIX.EasyTabs.ListItemEventArgs._itemIndex')
  - [ItemIndex](#P-xyLOGIX-EasyTabs-ListItemEventArgs-ItemIndex 'xyLOGIX.EasyTabs.ListItemEventArgs.ItemIndex')
- [ListModification](#T-xyLOGIX-EasyTabs-ListModification 'xyLOGIX.EasyTabs.ListModification')
  - [Cleared](#F-xyLOGIX-EasyTabs-ListModification-Cleared 'xyLOGIX.EasyTabs.ListModification.Cleared')
  - [ItemAdded](#F-xyLOGIX-EasyTabs-ListModification-ItemAdded 'xyLOGIX.EasyTabs.ListModification.ItemAdded')
  - [ItemModified](#F-xyLOGIX-EasyTabs-ListModification-ItemModified 'xyLOGIX.EasyTabs.ListModification.ItemModified')
  - [ItemRemoved](#F-xyLOGIX-EasyTabs-ListModification-ItemRemoved 'xyLOGIX.EasyTabs.ListModification.ItemRemoved')
  - [RangeAdded](#F-xyLOGIX-EasyTabs-ListModification-RangeAdded 'xyLOGIX.EasyTabs.ListModification.RangeAdded')
  - [RangeRemoved](#F-xyLOGIX-EasyTabs-ListModification-RangeRemoved 'xyLOGIX.EasyTabs.ListModification.RangeRemoved')
- [ListModificationEventArgs](#T-xyLOGIX-EasyTabs-ListModificationEventArgs 'xyLOGIX.EasyTabs.ListModificationEventArgs')
  - [#ctor(modification,startIndex,count)](#M-xyLOGIX-EasyTabs-ListModificationEventArgs-#ctor-xyLOGIX-EasyTabs-ListModification,System-Int32,System-Int32- 'xyLOGIX.EasyTabs.ListModificationEventArgs.#ctor(xyLOGIX.EasyTabs.ListModification,System.Int32,System.Int32)')
  - [_modification](#F-xyLOGIX-EasyTabs-ListModificationEventArgs-_modification 'xyLOGIX.EasyTabs.ListModificationEventArgs._modification')
  - [Modification](#P-xyLOGIX-EasyTabs-ListModificationEventArgs-Modification 'xyLOGIX.EasyTabs.ListModificationEventArgs.Modification')
- [ListRangeEventArgs](#T-xyLOGIX-EasyTabs-ListRangeEventArgs 'xyLOGIX.EasyTabs.ListRangeEventArgs')
  - [#ctor(startIndex,count)](#M-xyLOGIX-EasyTabs-ListRangeEventArgs-#ctor-System-Int32,System-Int32- 'xyLOGIX.EasyTabs.ListRangeEventArgs.#ctor(System.Int32,System.Int32)')
  - [_count](#F-xyLOGIX-EasyTabs-ListRangeEventArgs-_count 'xyLOGIX.EasyTabs.ListRangeEventArgs._count')
  - [_startIndex](#F-xyLOGIX-EasyTabs-ListRangeEventArgs-_startIndex 'xyLOGIX.EasyTabs.ListRangeEventArgs._startIndex')
  - [Count](#P-xyLOGIX-EasyTabs-ListRangeEventArgs-Count 'xyLOGIX.EasyTabs.ListRangeEventArgs.Count')
  - [StartIndex](#P-xyLOGIX-EasyTabs-ListRangeEventArgs-StartIndex 'xyLOGIX.EasyTabs.ListRangeEventArgs.StartIndex')
- [ListWithEvents\`1](#T-xyLOGIX-EasyTabs-ListWithEvents`1 'xyLOGIX.EasyTabs.ListWithEvents`1')
  - [#ctor()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-#ctor 'xyLOGIX.EasyTabs.ListWithEvents`1.#ctor')
  - [#ctor(collection)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-#ctor-System-Collections-Generic-IEnumerable{`0}- 'xyLOGIX.EasyTabs.ListWithEvents`1.#ctor(System.Collections.Generic.IEnumerable{`0})')
  - [#ctor(capacity)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-#ctor-System-Int32- 'xyLOGIX.EasyTabs.ListWithEvents`1.#ctor(System.Int32)')
  - [SyncRoot](#F-xyLOGIX-EasyTabs-ListWithEvents`1-SyncRoot 'xyLOGIX.EasyTabs.ListWithEvents`1.SyncRoot')
  - [_suppressEvents](#F-xyLOGIX-EasyTabs-ListWithEvents`1-_suppressEvents 'xyLOGIX.EasyTabs.ListWithEvents`1._suppressEvents')
  - [EventsSuppressed](#P-xyLOGIX-EasyTabs-ListWithEvents`1-EventsSuppressed 'xyLOGIX.EasyTabs.ListWithEvents`1.EventsSuppressed')
  - [Item](#P-xyLOGIX-EasyTabs-ListWithEvents`1-Item-System-Int32- 'xyLOGIX.EasyTabs.ListWithEvents`1.Item(System.Int32)')
  - [Add()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-Add-`0- 'xyLOGIX.EasyTabs.ListWithEvents`1.Add(`0)')
  - [AddRange()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-AddRange-System-Collections-Generic-IEnumerable{`0}- 'xyLOGIX.EasyTabs.ListWithEvents`1.AddRange(System.Collections.Generic.IEnumerable{`0})')
  - [Clear()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-Clear 'xyLOGIX.EasyTabs.ListWithEvents`1.Clear')
  - [Insert()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-Insert-System-Int32,`0- 'xyLOGIX.EasyTabs.ListWithEvents`1.Insert(System.Int32,`0)')
  - [InsertRange()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-InsertRange-System-Int32,System-Collections-Generic-IEnumerable{`0}- 'xyLOGIX.EasyTabs.ListWithEvents`1.InsertRange(System.Int32,System.Collections.Generic.IEnumerable{`0})')
  - [OnCleared(e)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-OnCleared-System-EventArgs- 'xyLOGIX.EasyTabs.ListWithEvents`1.OnCleared(System.EventArgs)')
  - [OnCollectionModified(e)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-OnCollectionModified-xyLOGIX-EasyTabs-ListModificationEventArgs- 'xyLOGIX.EasyTabs.ListWithEvents`1.OnCollectionModified(xyLOGIX.EasyTabs.ListModificationEventArgs)')
  - [OnEventsSuppressedChanged()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-OnEventsSuppressedChanged 'xyLOGIX.EasyTabs.ListWithEvents`1.OnEventsSuppressedChanged')
  - [OnItemAdded(e)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-OnItemAdded-xyLOGIX-EasyTabs-ListItemEventArgs- 'xyLOGIX.EasyTabs.ListWithEvents`1.OnItemAdded(xyLOGIX.EasyTabs.ListItemEventArgs)')
  - [OnItemModified(e)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-OnItemModified-xyLOGIX-EasyTabs-ListItemEventArgs- 'xyLOGIX.EasyTabs.ListWithEvents`1.OnItemModified(xyLOGIX.EasyTabs.ListItemEventArgs)')
  - [OnItemRemoved(e)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-OnItemRemoved-System-EventArgs- 'xyLOGIX.EasyTabs.ListWithEvents`1.OnItemRemoved(System.EventArgs)')
  - [OnRangeAdded(e)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-OnRangeAdded-xyLOGIX-EasyTabs-ListRangeEventArgs- 'xyLOGIX.EasyTabs.ListWithEvents`1.OnRangeAdded(xyLOGIX.EasyTabs.ListRangeEventArgs)')
  - [OnRangeRemoved(e)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-OnRangeRemoved-System-EventArgs- 'xyLOGIX.EasyTabs.ListWithEvents`1.OnRangeRemoved(System.EventArgs)')
  - [Remove()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-Remove-`0- 'xyLOGIX.EasyTabs.ListWithEvents`1.Remove(`0)')
  - [RemoveAll()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-RemoveAll-System-Predicate{`0}- 'xyLOGIX.EasyTabs.ListWithEvents`1.RemoveAll(System.Predicate{`0})')
  - [RemoveAt()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-RemoveAt-System-Int32- 'xyLOGIX.EasyTabs.ListWithEvents`1.RemoveAt(System.Int32)')
  - [RemoveRange()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-RemoveRange-System-Int32,System-Int32- 'xyLOGIX.EasyTabs.ListWithEvents`1.RemoveRange(System.Int32,System.Int32)')
  - [RemoveRange(collection)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-RemoveRange-System-Collections-Generic-IEnumerable{`0}- 'xyLOGIX.EasyTabs.ListWithEvents`1.RemoveRange(System.Collections.Generic.IEnumerable{`0})')
  - [ResumeEvents()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-ResumeEvents 'xyLOGIX.EasyTabs.ListWithEvents`1.ResumeEvents')
  - [SetEventsSuppressed(eventsSuppressed)](#M-xyLOGIX-EasyTabs-ListWithEvents`1-SetEventsSuppressed-System-Boolean- 'xyLOGIX.EasyTabs.ListWithEvents`1.SetEventsSuppressed(System.Boolean)')
  - [SuppressEvents()](#M-xyLOGIX-EasyTabs-ListWithEvents`1-SuppressEvents 'xyLOGIX.EasyTabs.ListWithEvents`1.SuppressEvents')
- [MouseEvent](#T-xyLOGIX-EasyTabs-MouseEvent 'xyLOGIX.EasyTabs.MouseEvent')
  - [Code](#P-xyLOGIX-EasyTabs-MouseEvent-Code 'xyLOGIX.EasyTabs.MouseEvent.Code')
  - [LParam](#P-xyLOGIX-EasyTabs-MouseEvent-LParam 'xyLOGIX.EasyTabs.MouseEvent.LParam')
  - [MouseData](#P-xyLOGIX-EasyTabs-MouseEvent-MouseData 'xyLOGIX.EasyTabs.MouseEvent.MouseData')
  - [WParam](#P-xyLOGIX-EasyTabs-MouseEvent-WParam 'xyLOGIX.EasyTabs.MouseEvent.WParam')
- [OperatingSystem](#T-xyLOGIX-EasyTabs-OperatingSystem 'xyLOGIX.EasyTabs.OperatingSystem')
  - [OperatingSystemVersionKeyPath](#F-xyLOGIX-EasyTabs-OperatingSystem-OperatingSystemVersionKeyPath 'xyLOGIX.EasyTabs.OperatingSystem.OperatingSystemVersionKeyPath')
  - [ProductNameValue](#F-xyLOGIX-EasyTabs-OperatingSystem-ProductNameValue 'xyLOGIX.EasyTabs.OperatingSystem.ProductNameValue')
  - [IsWindows10](#P-xyLOGIX-EasyTabs-OperatingSystem-IsWindows10 'xyLOGIX.EasyTabs.OperatingSystem.IsWindows10')
- [Resources](#T-xyLOGIX-EasyTabs-Properties-Resources 'xyLOGIX.EasyTabs.Properties.Resources')
  - [ChromeAdd](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeAdd 'xyLOGIX.EasyTabs.Properties.Resources.ChromeAdd')
  - [ChromeAddHover](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeAddHover 'xyLOGIX.EasyTabs.Properties.Resources.ChromeAddHover')
  - [ChromeBackground](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeBackground 'xyLOGIX.EasyTabs.Properties.Resources.ChromeBackground')
  - [ChromeCenter](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeCenter 'xyLOGIX.EasyTabs.Properties.Resources.ChromeCenter')
  - [ChromeClose](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeClose 'xyLOGIX.EasyTabs.Properties.Resources.ChromeClose')
  - [ChromeCloseHover](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeCloseHover 'xyLOGIX.EasyTabs.Properties.Resources.ChromeCloseHover')
  - [ChromeInactiveCenter](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeInactiveCenter 'xyLOGIX.EasyTabs.Properties.Resources.ChromeInactiveCenter')
  - [ChromeInactiveLeft](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeInactiveLeft 'xyLOGIX.EasyTabs.Properties.Resources.ChromeInactiveLeft')
  - [ChromeInactiveRight](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeInactiveRight 'xyLOGIX.EasyTabs.Properties.Resources.ChromeInactiveRight')
  - [ChromeInactiveRightNoDivider](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeInactiveRightNoDivider 'xyLOGIX.EasyTabs.Properties.Resources.ChromeInactiveRightNoDivider')
  - [ChromeLeft](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeLeft 'xyLOGIX.EasyTabs.Properties.Resources.ChromeLeft')
  - [ChromeRight](#P-xyLOGIX-EasyTabs-Properties-Resources-ChromeRight 'xyLOGIX.EasyTabs.Properties.Resources.ChromeRight')
  - [Close](#P-xyLOGIX-EasyTabs-Properties-Resources-Close 'xyLOGIX.EasyTabs.Properties.Resources.Close')
  - [CloseHighlight](#P-xyLOGIX-EasyTabs-Properties-Resources-CloseHighlight 'xyLOGIX.EasyTabs.Properties.Resources.CloseHighlight')
  - [Culture](#P-xyLOGIX-EasyTabs-Properties-Resources-Culture 'xyLOGIX.EasyTabs.Properties.Resources.Culture')
  - [Maximize](#P-xyLOGIX-EasyTabs-Properties-Resources-Maximize 'xyLOGIX.EasyTabs.Properties.Resources.Maximize')
  - [Minimize](#P-xyLOGIX-EasyTabs-Properties-Resources-Minimize 'xyLOGIX.EasyTabs.Properties.Resources.Minimize')
  - [ResourceManager](#P-xyLOGIX-EasyTabs-Properties-Resources-ResourceManager 'xyLOGIX.EasyTabs.Properties.Resources.ResourceManager')
  - [Restore](#P-xyLOGIX-EasyTabs-Properties-Resources-Restore 'xyLOGIX.EasyTabs.Properties.Resources.Restore')
- [TabClosingEventHandler](#T-xyLOGIX-EasyTabs-TabClosingEventHandler 'xyLOGIX.EasyTabs.TabClosingEventHandler')
- [TabRendererBase](#T-xyLOGIX-EasyTabs-TabRendererBase 'xyLOGIX.EasyTabs.TabRendererBase')
  - [#ctor(parent)](#M-xyLOGIX-EasyTabs-TabRendererBase-#ctor-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.TabRendererBase.#ctor(xyLOGIX.EasyTabs.TitleBarTabs)')
  - [_addButtonShown](#F-xyLOGIX-EasyTabs-TabRendererBase-_addButtonShown 'xyLOGIX.EasyTabs.TabRendererBase._addButtonShown')
  - [_foreColor](#F-xyLOGIX-EasyTabs-TabRendererBase-_foreColor 'xyLOGIX.EasyTabs.TabRendererBase._foreColor')
  - [_isTabRepositioning](#F-xyLOGIX-EasyTabs-TabRendererBase-_isTabRepositioning 'xyLOGIX.EasyTabs.TabRendererBase._isTabRepositioning')
  - [_maxTabWellWellArea](#F-xyLOGIX-EasyTabs-TabRendererBase-_maxTabWellWellArea 'xyLOGIX.EasyTabs.TabRendererBase._maxTabWellWellArea')
  - [_previousTabCount](#F-xyLOGIX-EasyTabs-TabRendererBase-_previousTabCount 'xyLOGIX.EasyTabs.TabRendererBase._previousTabCount')
  - [_suspendRendering](#F-xyLOGIX-EasyTabs-TabRendererBase-_suspendRendering 'xyLOGIX.EasyTabs.TabRendererBase._suspendRendering')
  - [_tabBackColor](#F-xyLOGIX-EasyTabs-TabRendererBase-_tabBackColor 'xyLOGIX.EasyTabs.TabRendererBase._tabBackColor')
  - [_tabClickOffset](#F-xyLOGIX-EasyTabs-TabRendererBase-_tabClickOffset 'xyLOGIX.EasyTabs.TabRendererBase._tabClickOffset')
  - [_tabContentWidth](#F-xyLOGIX-EasyTabs-TabRendererBase-_tabContentWidth 'xyLOGIX.EasyTabs.TabRendererBase._tabContentWidth')
  - [_wasTabRepositioning](#F-xyLOGIX-EasyTabs-TabRendererBase-_wasTabRepositioning 'xyLOGIX.EasyTabs.TabRendererBase._wasTabRepositioning')
  - [ActiveCenterImage](#P-xyLOGIX-EasyTabs-TabRendererBase-ActiveCenterImage 'xyLOGIX.EasyTabs.TabRendererBase.ActiveCenterImage')
  - [ActiveLeftSideImage](#P-xyLOGIX-EasyTabs-TabRendererBase-ActiveLeftSideImage 'xyLOGIX.EasyTabs.TabRendererBase.ActiveLeftSideImage')
  - [ActiveRightSideImage](#P-xyLOGIX-EasyTabs-TabRendererBase-ActiveRightSideImage 'xyLOGIX.EasyTabs.TabRendererBase.ActiveRightSideImage')
  - [AddButtonHoverImage](#P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonHoverImage 'xyLOGIX.EasyTabs.TabRendererBase.AddButtonHoverImage')
  - [AddButtonImage](#P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonImage 'xyLOGIX.EasyTabs.TabRendererBase.AddButtonImage')
  - [AddButtonMarginLeft](#P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonMarginLeft 'xyLOGIX.EasyTabs.TabRendererBase.AddButtonMarginLeft')
  - [AddButtonMarginRight](#P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonMarginRight 'xyLOGIX.EasyTabs.TabRendererBase.AddButtonMarginRight')
  - [AddButtonMarginTop](#P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonMarginTop 'xyLOGIX.EasyTabs.TabRendererBase.AddButtonMarginTop')
  - [AddButtonRectangle](#P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonRectangle 'xyLOGIX.EasyTabs.TabRendererBase.AddButtonRectangle')
  - [BackgroundImage](#P-xyLOGIX-EasyTabs-TabRendererBase-BackgroundImage 'xyLOGIX.EasyTabs.TabRendererBase.BackgroundImage')
  - [CaptionFont](#P-xyLOGIX-EasyTabs-TabRendererBase-CaptionFont 'xyLOGIX.EasyTabs.TabRendererBase.CaptionFont')
  - [CaptionMarginLeft](#P-xyLOGIX-EasyTabs-TabRendererBase-CaptionMarginLeft 'xyLOGIX.EasyTabs.TabRendererBase.CaptionMarginLeft')
  - [CaptionMarginRight](#P-xyLOGIX-EasyTabs-TabRendererBase-CaptionMarginRight 'xyLOGIX.EasyTabs.TabRendererBase.CaptionMarginRight')
  - [CaptionMarginTop](#P-xyLOGIX-EasyTabs-TabRendererBase-CaptionMarginTop 'xyLOGIX.EasyTabs.TabRendererBase.CaptionMarginTop')
  - [CloseButtonMarginLeft](#P-xyLOGIX-EasyTabs-TabRendererBase-CloseButtonMarginLeft 'xyLOGIX.EasyTabs.TabRendererBase.CloseButtonMarginLeft')
  - [CloseButtonMarginRight](#P-xyLOGIX-EasyTabs-TabRendererBase-CloseButtonMarginRight 'xyLOGIX.EasyTabs.TabRendererBase.CloseButtonMarginRight')
  - [CloseButtonMarginTop](#P-xyLOGIX-EasyTabs-TabRendererBase-CloseButtonMarginTop 'xyLOGIX.EasyTabs.TabRendererBase.CloseButtonMarginTop')
  - [DragStart](#P-xyLOGIX-EasyTabs-TabRendererBase-DragStart 'xyLOGIX.EasyTabs.TabRendererBase.DragStart')
  - [ForeColor](#P-xyLOGIX-EasyTabs-TabRendererBase-ForeColor 'xyLOGIX.EasyTabs.TabRendererBase.ForeColor')
  - [IconMarginLeft](#P-xyLOGIX-EasyTabs-TabRendererBase-IconMarginLeft 'xyLOGIX.EasyTabs.TabRendererBase.IconMarginLeft')
  - [IconMarginRight](#P-xyLOGIX-EasyTabs-TabRendererBase-IconMarginRight 'xyLOGIX.EasyTabs.TabRendererBase.IconMarginRight')
  - [IconMarginTop](#P-xyLOGIX-EasyTabs-TabRendererBase-IconMarginTop 'xyLOGIX.EasyTabs.TabRendererBase.IconMarginTop')
  - [InactiveRightSideImage](#P-xyLOGIX-EasyTabs-TabRendererBase-InactiveRightSideImage 'xyLOGIX.EasyTabs.TabRendererBase.InactiveRightSideImage')
  - [InactiveTabContentAreaImage](#P-xyLOGIX-EasyTabs-TabRendererBase-InactiveTabContentAreaImage 'xyLOGIX.EasyTabs.TabRendererBase.InactiveTabContentAreaImage')
  - [InactiveTabLeftSideImage](#P-xyLOGIX-EasyTabs-TabRendererBase-InactiveTabLeftSideImage 'xyLOGIX.EasyTabs.TabRendererBase.InactiveTabLeftSideImage')
  - [IsTabRepositioning](#P-xyLOGIX-EasyTabs-TabRendererBase-IsTabRepositioning 'xyLOGIX.EasyTabs.TabRendererBase.IsTabRepositioning')
  - [MaxTabWellArea](#P-xyLOGIX-EasyTabs-TabRendererBase-MaxTabWellArea 'xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellArea')
  - [OverlapWidth](#P-xyLOGIX-EasyTabs-TabRendererBase-OverlapWidth 'xyLOGIX.EasyTabs.TabRendererBase.OverlapWidth')
  - [Parent](#P-xyLOGIX-EasyTabs-TabRendererBase-Parent 'xyLOGIX.EasyTabs.TabRendererBase.Parent')
  - [PreviousTabCount](#P-xyLOGIX-EasyTabs-TabRendererBase-PreviousTabCount 'xyLOGIX.EasyTabs.TabRendererBase.PreviousTabCount')
  - [RenderingSuspended](#P-xyLOGIX-EasyTabs-TabRendererBase-RenderingSuspended 'xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspended')
  - [RendersEntireTitleBar](#P-xyLOGIX-EasyTabs-TabRendererBase-RendersEntireTitleBar 'xyLOGIX.EasyTabs.TabRendererBase.RendersEntireTitleBar')
  - [ShowAddButton](#P-xyLOGIX-EasyTabs-TabRendererBase-ShowAddButton 'xyLOGIX.EasyTabs.TabRendererBase.ShowAddButton')
  - [TabBackColor](#P-xyLOGIX-EasyTabs-TabRendererBase-TabBackColor 'xyLOGIX.EasyTabs.TabRendererBase.TabBackColor')
  - [TabClickOffset](#P-xyLOGIX-EasyTabs-TabRendererBase-TabClickOffset 'xyLOGIX.EasyTabs.TabRendererBase.TabClickOffset')
  - [TabCloseButtonHoverImage](#P-xyLOGIX-EasyTabs-TabRendererBase-TabCloseButtonHoverImage 'xyLOGIX.EasyTabs.TabRendererBase.TabCloseButtonHoverImage')
  - [TabCloseButtonImage](#P-xyLOGIX-EasyTabs-TabRendererBase-TabCloseButtonImage 'xyLOGIX.EasyTabs.TabRendererBase.TabCloseButtonImage')
  - [TabContentWidth](#P-xyLOGIX-EasyTabs-TabRendererBase-TabContentWidth 'xyLOGIX.EasyTabs.TabRendererBase.TabContentWidth')
  - [TabHeight](#P-xyLOGIX-EasyTabs-TabRendererBase-TabHeight 'xyLOGIX.EasyTabs.TabRendererBase.TabHeight')
  - [TabRepositionDragDistance](#P-xyLOGIX-EasyTabs-TabRendererBase-TabRepositionDragDistance 'xyLOGIX.EasyTabs.TabRendererBase.TabRepositionDragDistance')
  - [TabTearDragDistance](#P-xyLOGIX-EasyTabs-TabRendererBase-TabTearDragDistance 'xyLOGIX.EasyTabs.TabRendererBase.TabTearDragDistance')
  - [TopPadding](#P-xyLOGIX-EasyTabs-TabRendererBase-TopPadding 'xyLOGIX.EasyTabs.TabRendererBase.TopPadding')
  - [CombineTab(tab,cursorLocation)](#M-xyLOGIX-EasyTabs-TabRendererBase-CombineTab-xyLOGIX-EasyTabs-TitleBarTab,System-Drawing-Point- 'xyLOGIX.EasyTabs.TabRendererBase.CombineTab(xyLOGIX.EasyTabs.TitleBarTab,System.Drawing.Point)')
  - [GetMaxTabWellWidth(tabs,offset)](#M-xyLOGIX-EasyTabs-TabRendererBase-GetMaxTabWellWidth-System-Collections-Generic-IList{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Point- 'xyLOGIX.EasyTabs.TabRendererBase.GetMaxTabWellWidth(System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab},System.Drawing.Point)')
  - [GetTabCenterImage(tab)](#M-xyLOGIX-EasyTabs-TabRendererBase-GetTabCenterImage-xyLOGIX-EasyTabs-TitleBarTab- 'xyLOGIX.EasyTabs.TabRendererBase.GetTabCenterImage(xyLOGIX.EasyTabs.TitleBarTab)')
  - [GetTabLeftImage(tab)](#M-xyLOGIX-EasyTabs-TabRendererBase-GetTabLeftImage-xyLOGIX-EasyTabs-TitleBarTab- 'xyLOGIX.EasyTabs.TabRendererBase.GetTabLeftImage(xyLOGIX.EasyTabs.TitleBarTab)')
  - [GetTabRightImage(tab)](#M-xyLOGIX-EasyTabs-TabRendererBase-GetTabRightImage-xyLOGIX-EasyTabs-TitleBarTab- 'xyLOGIX.EasyTabs.TabRendererBase.GetTabRightImage(xyLOGIX.EasyTabs.TitleBarTab)')
  - [InitializeTabWell(parent)](#M-xyLOGIX-EasyTabs-TabRendererBase-InitializeTabWell-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.TabRendererBase.InitializeTabWell(xyLOGIX.EasyTabs.TitleBarTabs)')
  - [IsOverAddButton(cursor)](#M-xyLOGIX-EasyTabs-TabRendererBase-IsOverAddButton-System-Drawing-Point- 'xyLOGIX.EasyTabs.TabRendererBase.IsOverAddButton(System.Drawing.Point)')
  - [IsOverCloseButton(tab,mousePointerCoords)](#M-xyLOGIX-EasyTabs-TabRendererBase-IsOverCloseButton-xyLOGIX-EasyTabs-TitleBarTab,System-Drawing-Point- 'xyLOGIX.EasyTabs.TabRendererBase.IsOverCloseButton(xyLOGIX.EasyTabs.TitleBarTab,System.Drawing.Point)')
  - [IsOverNonTransparentArea(area,image,cursor)](#M-xyLOGIX-EasyTabs-TabRendererBase-IsOverNonTransparentArea-System-Drawing-Rectangle,System-Drawing-Bitmap,System-Drawing-Point- 'xyLOGIX.EasyTabs.TabRendererBase.IsOverNonTransparentArea(System.Drawing.Rectangle,System.Drawing.Bitmap,System.Drawing.Point)')
  - [IsOverSizingBox(mousePointerCoords)](#M-xyLOGIX-EasyTabs-TabRendererBase-IsOverSizingBox-System-Drawing-Point- 'xyLOGIX.EasyTabs.TabRendererBase.IsOverSizingBox(System.Drawing.Point)')
  - [IsOverTab(tab,cursor)](#M-xyLOGIX-EasyTabs-TabRendererBase-IsOverTab-xyLOGIX-EasyTabs-TitleBarTab,System-Drawing-Point- 'xyLOGIX.EasyTabs.TabRendererBase.IsOverTab(xyLOGIX.EasyTabs.TitleBarTab,System.Drawing.Point)')
  - [NonClientHitTest(message,mousePointerCoords)](#M-xyLOGIX-EasyTabs-TabRendererBase-NonClientHitTest-System-Windows-Forms-Message,System-Drawing-Point- 'xyLOGIX.EasyTabs.TabRendererBase.NonClientHitTest(System.Windows.Forms.Message,System.Drawing.Point)')
  - [OnAddButtonShownChanged()](#M-xyLOGIX-EasyTabs-TabRendererBase-OnAddButtonShownChanged 'xyLOGIX.EasyTabs.TabRendererBase.OnAddButtonShownChanged')
  - [OnForeColorChanged()](#M-xyLOGIX-EasyTabs-TabRendererBase-OnForeColorChanged 'xyLOGIX.EasyTabs.TabRendererBase.OnForeColorChanged')
  - [OnMaxTabWellAreaChanged()](#M-xyLOGIX-EasyTabs-TabRendererBase-OnMaxTabWellAreaChanged 'xyLOGIX.EasyTabs.TabRendererBase.OnMaxTabWellAreaChanged')
  - [OnOverlayMouseDown(sender,e)](#M-xyLOGIX-EasyTabs-TabRendererBase-OnOverlayMouseDown-System-Object,System-Windows-Forms-MouseEventArgs- 'xyLOGIX.EasyTabs.TabRendererBase.OnOverlayMouseDown(System.Object,System.Windows.Forms.MouseEventArgs)')
  - [OnOverlayMouseMove(sender,e)](#M-xyLOGIX-EasyTabs-TabRendererBase-OnOverlayMouseMove-System-Object,System-Windows-Forms-MouseEventArgs- 'xyLOGIX.EasyTabs.TabRendererBase.OnOverlayMouseMove(System.Object,System.Windows.Forms.MouseEventArgs)')
  - [OnOverlayMouseUp(sender,e)](#M-xyLOGIX-EasyTabs-TabRendererBase-OnOverlayMouseUp-System-Object,System-Windows-Forms-MouseEventArgs- 'xyLOGIX.EasyTabs.TabRendererBase.OnOverlayMouseUp(System.Object,System.Windows.Forms.MouseEventArgs)')
  - [OnPreviousTabCountChanged()](#M-xyLOGIX-EasyTabs-TabRendererBase-OnPreviousTabCountChanged 'xyLOGIX.EasyTabs.TabRendererBase.OnPreviousTabCountChanged')
  - [OnRenderingSuspendedChanged()](#M-xyLOGIX-EasyTabs-TabRendererBase-OnRenderingSuspendedChanged 'xyLOGIX.EasyTabs.TabRendererBase.OnRenderingSuspendedChanged')
  - [OnTabBackColorChanged()](#M-xyLOGIX-EasyTabs-TabRendererBase-OnTabBackColorChanged 'xyLOGIX.EasyTabs.TabRendererBase.OnTabBackColorChanged')
  - [OnTabClickOffsetChanged()](#M-xyLOGIX-EasyTabs-TabRendererBase-OnTabClickOffsetChanged 'xyLOGIX.EasyTabs.TabRendererBase.OnTabClickOffsetChanged')
  - [OnTabContentWidthChanged()](#M-xyLOGIX-EasyTabs-TabRendererBase-OnTabContentWidthChanged 'xyLOGIX.EasyTabs.TabRendererBase.OnTabContentWidthChanged')
  - [OnTabRepositioningChanged()](#M-xyLOGIX-EasyTabs-TabRendererBase-OnTabRepositioningChanged 'xyLOGIX.EasyTabs.TabRendererBase.OnTabRepositioningChanged')
  - [OverTab(tabs,cursor)](#M-xyLOGIX-EasyTabs-TabRendererBase-OverTab-System-Collections-Generic-IEnumerable{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Point- 'xyLOGIX.EasyTabs.TabRendererBase.OverTab(System.Collections.Generic.IEnumerable{xyLOGIX.EasyTabs.TitleBarTab},System.Drawing.Point)')
  - [Render(tabs,graphicsContext,cursor,forceRedraw,offset)](#M-xyLOGIX-EasyTabs-TabRendererBase-Render-System-Collections-Generic-IList{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Graphics,System-Drawing-Point,System-Drawing-Point,System-Boolean- 'xyLOGIX.EasyTabs.TabRendererBase.Render(System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab},System.Drawing.Graphics,System.Drawing.Point,System.Drawing.Point,System.Boolean)')
  - [Render(graphicsContext,tab,index,area,cursor,tabLeftImage,tabCenterImage,tabRightImage)](#M-xyLOGIX-EasyTabs-TabRendererBase-Render-System-Drawing-Graphics,xyLOGIX-EasyTabs-TitleBarTab,System-Int32,System-Drawing-Rectangle,System-Drawing-Point,System-Drawing-Image,System-Drawing-Image,System-Drawing-Image- 'xyLOGIX.EasyTabs.TabRendererBase.Render(System.Drawing.Graphics,xyLOGIX.EasyTabs.TitleBarTab,System.Int32,System.Drawing.Rectangle,System.Drawing.Point,System.Drawing.Image,System.Drawing.Image,System.Drawing.Image)')
  - [Tabs_CollectionModified(sender,e)](#M-xyLOGIX-EasyTabs-TabRendererBase-Tabs_CollectionModified-System-Object,xyLOGIX-EasyTabs-ListModificationEventArgs- 'xyLOGIX.EasyTabs.TabRendererBase.Tabs_CollectionModified(System.Object,xyLOGIX.EasyTabs.ListModificationEventArgs)')
- [TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab')
  - [#ctor(parent)](#M-xyLOGIX-EasyTabs-TitleBarTab-#ctor-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.TitleBarTab.#ctor(xyLOGIX.EasyTabs.TitleBarTabs)')
  - [_active](#F-xyLOGIX-EasyTabs-TitleBarTab-_active 'xyLOGIX.EasyTabs.TitleBarTab._active')
  - [_content](#F-xyLOGIX-EasyTabs-TitleBarTab-_content 'xyLOGIX.EasyTabs.TitleBarTab._content')
  - [_parent](#F-xyLOGIX-EasyTabs-TitleBarTab-_parent 'xyLOGIX.EasyTabs.TitleBarTab._parent')
  - [Active](#P-xyLOGIX-EasyTabs-TitleBarTab-Active 'xyLOGIX.EasyTabs.TitleBarTab.Active')
  - [Area](#P-xyLOGIX-EasyTabs-TitleBarTab-Area 'xyLOGIX.EasyTabs.TitleBarTab.Area')
  - [Caption](#P-xyLOGIX-EasyTabs-TitleBarTab-Caption 'xyLOGIX.EasyTabs.TitleBarTab.Caption')
  - [CloseButtonArea](#P-xyLOGIX-EasyTabs-TitleBarTab-CloseButtonArea 'xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea')
  - [Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content')
  - [Icon](#P-xyLOGIX-EasyTabs-TitleBarTab-Icon 'xyLOGIX.EasyTabs.TitleBarTab.Icon')
  - [IsDisposed](#P-xyLOGIX-EasyTabs-TitleBarTab-IsDisposed 'xyLOGIX.EasyTabs.TitleBarTab.IsDisposed')
  - [Parent](#P-xyLOGIX-EasyTabs-TitleBarTab-Parent 'xyLOGIX.EasyTabs.TitleBarTab.Parent')
  - [ShowCloseButton](#P-xyLOGIX-EasyTabs-TitleBarTab-ShowCloseButton 'xyLOGIX.EasyTabs.TitleBarTab.ShowCloseButton')
  - [TabImage](#P-xyLOGIX-EasyTabs-TitleBarTab-TabImage 'xyLOGIX.EasyTabs.TitleBarTab.TabImage')
  - [TitleBarTabId](#P-xyLOGIX-EasyTabs-TitleBarTab-TitleBarTabId 'xyLOGIX.EasyTabs.TitleBarTab.TitleBarTabId')
  - [ClearSubscriptions()](#M-xyLOGIX-EasyTabs-TitleBarTab-ClearSubscriptions 'xyLOGIX.EasyTabs.TitleBarTab.ClearSubscriptions')
  - [Close()](#M-xyLOGIX-EasyTabs-TitleBarTab-Close 'xyLOGIX.EasyTabs.TitleBarTab.Close')
  - [Content_Closing(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTab-Content_Closing-System-Object,System-ComponentModel-CancelEventArgs- 'xyLOGIX.EasyTabs.TitleBarTab.Content_Closing(System.Object,System.ComponentModel.CancelEventArgs)')
  - [Content_TextChanged(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTab-Content_TextChanged-System-Object,System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTab.Content_TextChanged(System.Object,System.EventArgs)')
  - [GetImage()](#M-xyLOGIX-EasyTabs-TitleBarTab-GetImage 'xyLOGIX.EasyTabs.TitleBarTab.GetImage')
- [TitleBarTabCancelEventArgs](#T-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs 'xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs')
  - [Action](#P-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs-Action 'xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs.Action')
  - [Tab](#P-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs-Tab 'xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs.Tab')
  - [TabIndex](#P-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs-TabIndex 'xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs.TabIndex')
- [TitleBarTabCancelEventHandler](#T-xyLOGIX-EasyTabs-TitleBarTabCancelEventHandler 'xyLOGIX.EasyTabs.TitleBarTabCancelEventHandler')
- [TitleBarTabEventArgs](#T-xyLOGIX-EasyTabs-TitleBarTabEventArgs 'xyLOGIX.EasyTabs.TitleBarTabEventArgs')
  - [Action](#P-xyLOGIX-EasyTabs-TitleBarTabEventArgs-Action 'xyLOGIX.EasyTabs.TitleBarTabEventArgs.Action')
  - [Tab](#P-xyLOGIX-EasyTabs-TitleBarTabEventArgs-Tab 'xyLOGIX.EasyTabs.TitleBarTabEventArgs.Tab')
  - [TabIndex](#P-xyLOGIX-EasyTabs-TitleBarTabEventArgs-TabIndex 'xyLOGIX.EasyTabs.TitleBarTabEventArgs.TabIndex')
  - [WasDragging](#P-xyLOGIX-EasyTabs-TitleBarTabEventArgs-WasDragging 'xyLOGIX.EasyTabs.TitleBarTabEventArgs.WasDragging')
- [TitleBarTabEventHandler](#T-xyLOGIX-EasyTabs-TitleBarTabEventHandler 'xyLOGIX.EasyTabs.TitleBarTabEventHandler')
- [TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs')
  - [#ctor()](#M-xyLOGIX-EasyTabs-TitleBarTabs-#ctor 'xyLOGIX.EasyTabs.TitleBarTabs.#ctor')
  - [#ctor()](#M-xyLOGIX-EasyTabs-TitleBarTabs-#ctor-System-ComponentModel-IContainer- 'xyLOGIX.EasyTabs.TitleBarTabs.#ctor(System.ComponentModel.IContainer)')
  - [_aeroPeekEnabled](#F-xyLOGIX-EasyTabs-TitleBarTabs-_aeroPeekEnabled 'xyLOGIX.EasyTabs.TitleBarTabs._aeroPeekEnabled')
  - [_nonClientAreaHeight](#F-xyLOGIX-EasyTabs-TitleBarTabs-_nonClientAreaHeight 'xyLOGIX.EasyTabs.TitleBarTabs._nonClientAreaHeight')
  - [_previews](#F-xyLOGIX-EasyTabs-TitleBarTabs-_previews 'xyLOGIX.EasyTabs.TitleBarTabs._previews')
  - [_previousSelectedTab](#F-xyLOGIX-EasyTabs-TitleBarTabs-_previousSelectedTab 'xyLOGIX.EasyTabs.TitleBarTabs._previousSelectedTab')
  - [_previousWindowState](#F-xyLOGIX-EasyTabs-TitleBarTabs-_previousWindowState 'xyLOGIX.EasyTabs.TitleBarTabs._previousWindowState')
  - [_tabRenderer](#F-xyLOGIX-EasyTabs-TitleBarTabs-_tabRenderer 'xyLOGIX.EasyTabs.TitleBarTabs._tabRenderer')
  - [_tabs](#F-xyLOGIX-EasyTabs-TitleBarTabs-_tabs 'xyLOGIX.EasyTabs.TitleBarTabs._tabs')
  - [components](#F-xyLOGIX-EasyTabs-TitleBarTabs-components 'xyLOGIX.EasyTabs.TitleBarTabs.components')
  - [AeroPeekEnabled](#P-xyLOGIX-EasyTabs-TitleBarTabs-AeroPeekEnabled 'xyLOGIX.EasyTabs.TitleBarTabs.AeroPeekEnabled')
  - [ApplicationContext](#P-xyLOGIX-EasyTabs-TitleBarTabs-ApplicationContext 'xyLOGIX.EasyTabs.TitleBarTabs.ApplicationContext')
  - [CreateNewTabWhenShown](#P-xyLOGIX-EasyTabs-TitleBarTabs-CreateNewTabWhenShown 'xyLOGIX.EasyTabs.TitleBarTabs.CreateNewTabWhenShown')
  - [ExitOnLastTabClose](#P-xyLOGIX-EasyTabs-TitleBarTabs-ExitOnLastTabClose 'xyLOGIX.EasyTabs.TitleBarTabs.ExitOnLastTabClose')
  - [IsClosing](#P-xyLOGIX-EasyTabs-TitleBarTabs-IsClosing 'xyLOGIX.EasyTabs.TitleBarTabs.IsClosing')
  - [IsCompositionEnabled](#P-xyLOGIX-EasyTabs-TitleBarTabs-IsCompositionEnabled 'xyLOGIX.EasyTabs.TitleBarTabs.IsCompositionEnabled')
  - [NonClientAreaHeight](#P-xyLOGIX-EasyTabs-TitleBarTabs-NonClientAreaHeight 'xyLOGIX.EasyTabs.TitleBarTabs.NonClientAreaHeight')
  - [Overlay](#P-xyLOGIX-EasyTabs-TitleBarTabs-Overlay 'xyLOGIX.EasyTabs.TitleBarTabs.Overlay')
  - [SelectedTab](#P-xyLOGIX-EasyTabs-TitleBarTabs-SelectedTab 'xyLOGIX.EasyTabs.TitleBarTabs.SelectedTab')
  - [SelectedTabIndex](#P-xyLOGIX-EasyTabs-TitleBarTabs-SelectedTabIndex 'xyLOGIX.EasyTabs.TitleBarTabs.SelectedTabIndex')
  - [ShowTooltips](#P-xyLOGIX-EasyTabs-TitleBarTabs-ShowTooltips 'xyLOGIX.EasyTabs.TitleBarTabs.ShowTooltips')
  - [TabDropArea](#P-xyLOGIX-EasyTabs-TitleBarTabs-TabDropArea 'xyLOGIX.EasyTabs.TitleBarTabs.TabDropArea')
  - [TabRenderer](#P-xyLOGIX-EasyTabs-TitleBarTabs-TabRenderer 'xyLOGIX.EasyTabs.TitleBarTabs.TabRenderer')
  - [Tabs](#P-xyLOGIX-EasyTabs-TitleBarTabs-Tabs 'xyLOGIX.EasyTabs.TitleBarTabs.Tabs')
  - [Tooltip](#P-xyLOGIX-EasyTabs-TitleBarTabs-Tooltip 'xyLOGIX.EasyTabs.TitleBarTabs.Tooltip')
  - [AddNewTab()](#M-xyLOGIX-EasyTabs-TitleBarTabs-AddNewTab 'xyLOGIX.EasyTabs.TitleBarTabs.AddNewTab')
  - [CloseTab(closingTab)](#M-xyLOGIX-EasyTabs-TitleBarTabs-CloseTab-xyLOGIX-EasyTabs-TitleBarTab- 'xyLOGIX.EasyTabs.TitleBarTabs.CloseTab(xyLOGIX.EasyTabs.TitleBarTab)')
  - [CommonConstruct()](#M-xyLOGIX-EasyTabs-TitleBarTabs-CommonConstruct 'xyLOGIX.EasyTabs.TitleBarTabs.CommonConstruct')
  - [Content_TextChanged(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-Content_TextChanged-System-Object,System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.Content_TextChanged(System.Object,System.EventArgs)')
  - [CreateTab()](#M-xyLOGIX-EasyTabs-TitleBarTabs-CreateTab 'xyLOGIX.EasyTabs.TitleBarTabs.CreateTab')
  - [CreateThumbnailPreview(tab)](#M-xyLOGIX-EasyTabs-TitleBarTabs-CreateThumbnailPreview-xyLOGIX-EasyTabs-TitleBarTab- 'xyLOGIX.EasyTabs.TitleBarTabs.CreateThumbnailPreview(xyLOGIX.EasyTabs.TitleBarTab)')
  - [Dispose(disposing)](#M-xyLOGIX-EasyTabs-TitleBarTabs-Dispose-System-Boolean- 'xyLOGIX.EasyTabs.TitleBarTabs.Dispose(System.Boolean)')
  - [ForwardMessage(m)](#M-xyLOGIX-EasyTabs-TitleBarTabs-ForwardMessage-System-Windows-Forms-Message@- 'xyLOGIX.EasyTabs.TitleBarTabs.ForwardMessage(System.Windows.Forms.Message@)')
  - [HitTest(point,windowHandle)](#M-xyLOGIX-EasyTabs-TitleBarTabs-HitTest-System-Drawing-Point,System-IntPtr- 'xyLOGIX.EasyTabs.TitleBarTabs.HitTest(System.Drawing.Point,System.IntPtr)')
  - [InitializeComponent()](#M-xyLOGIX-EasyTabs-TitleBarTabs-InitializeComponent 'xyLOGIX.EasyTabs.TitleBarTabs.InitializeComponent')
  - [OnClientSizeChanged(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnClientSizeChanged-System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnClientSizeChanged(System.EventArgs)')
  - [OnFormClosing(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnFormClosing-System-Windows-Forms-FormClosingEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnFormClosing(System.Windows.Forms.FormClosingEventArgs)')
  - [OnLoad(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnLoad-System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnLoad(System.EventArgs)')
  - [OnPaintBackground(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnPaintBackground-System-Windows-Forms-PaintEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnPaintBackground(System.Windows.Forms.PaintEventArgs)')
  - [OnPreviewTabbedThumbnailActivated(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnPreviewTabbedThumbnailActivated-System-Object,Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnPreviewTabbedThumbnailActivated(System.Object,Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailEventArgs)')
  - [OnPreviewTabbedThumbnailBitmapRequested(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnPreviewTabbedThumbnailBitmapRequested-System-Object,Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailBitmapRequestedEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnPreviewTabbedThumbnailBitmapRequested(System.Object,Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailBitmapRequestedEventArgs)')
  - [OnPreviewTabbedThumbnailClosed(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnPreviewTabbedThumbnailClosed-System-Object,Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnPreviewTabbedThumbnailClosed(System.Object,Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailEventArgs)')
  - [OnSelectedTabIndexChanged(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnSelectedTabIndexChanged-xyLOGIX-EasyTabs-TitleBarTabEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnSelectedTabIndexChanged(xyLOGIX.EasyTabs.TitleBarTabEventArgs)')
  - [OnSelectedTabIndexChanging(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnSelectedTabIndexChanging-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnSelectedTabIndexChanging(xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs)')
  - [OnShown(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnShown-System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnShown(System.EventArgs)')
  - [OnSizeChanged(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnSizeChanged-System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnSizeChanged(System.EventArgs)')
  - [OnTabClicked(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnTabClicked-xyLOGIX-EasyTabs-TitleBarTabEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnTabClicked(xyLOGIX.EasyTabs.TitleBarTabEventArgs)')
  - [OnTabDeselected(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnTabDeselected-xyLOGIX-EasyTabs-TitleBarTabEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnTabDeselected(xyLOGIX.EasyTabs.TitleBarTabEventArgs)')
  - [OnTabDeselecting(e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnTabDeselecting-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnTabDeselecting(xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs)')
  - [OnTabsCollectionModified(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnTabsCollectionModified-System-Object,xyLOGIX-EasyTabs-ListModificationEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnTabsCollectionModified(System.Object,xyLOGIX.EasyTabs.ListModificationEventArgs)')
  - [RedrawTabs()](#M-xyLOGIX-EasyTabs-TitleBarTabs-RedrawTabs 'xyLOGIX.EasyTabs.TitleBarTabs.RedrawTabs')
  - [ResizeTabContents(tab)](#M-xyLOGIX-EasyTabs-TitleBarTabs-ResizeTabContents-xyLOGIX-EasyTabs-TitleBarTab- 'xyLOGIX.EasyTabs.TitleBarTabs.ResizeTabContents(xyLOGIX.EasyTabs.TitleBarTab)')
  - [SetFrameSize()](#M-xyLOGIX-EasyTabs-TitleBarTabs-SetFrameSize 'xyLOGIX.EasyTabs.TitleBarTabs.SetFrameSize')
  - [SetWindowThemeAttributes(attributes)](#M-xyLOGIX-EasyTabs-TitleBarTabs-SetWindowThemeAttributes-Win32Interop-Enums-WTNCA- 'xyLOGIX.EasyTabs.TitleBarTabs.SetWindowThemeAttributes(Win32Interop.Enums.WTNCA)')
  - [TitleBarTabs_Closing(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabs-TitleBarTabs_Closing-System-Object,System-ComponentModel-CancelEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.TitleBarTabs_Closing(System.Object,System.ComponentModel.CancelEventArgs)')
  - [UpdateTabThumbnail(tab)](#M-xyLOGIX-EasyTabs-TitleBarTabs-UpdateTabThumbnail-xyLOGIX-EasyTabs-TitleBarTab- 'xyLOGIX.EasyTabs.TitleBarTabs.UpdateTabThumbnail(xyLOGIX.EasyTabs.TitleBarTab)')
  - [UpdateThumbnailPreviewIcon(tab,icon)](#M-xyLOGIX-EasyTabs-TitleBarTabs-UpdateThumbnailPreviewIcon-xyLOGIX-EasyTabs-TitleBarTab,System-Drawing-Icon- 'xyLOGIX.EasyTabs.TitleBarTabs.UpdateThumbnailPreviewIcon(xyLOGIX.EasyTabs.TitleBarTab,System.Drawing.Icon)')
  - [WndProc(m)](#M-xyLOGIX-EasyTabs-TitleBarTabs-WndProc-System-Windows-Forms-Message@- 'xyLOGIX.EasyTabs.TitleBarTabs.WndProc(System.Windows.Forms.Message@)')
- [TitleBarTabsApplicationContext](#T-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext 'xyLOGIX.EasyTabs.TitleBarTabsApplicationContext')
  - [_openWindows](#F-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-_openWindows 'xyLOGIX.EasyTabs.TitleBarTabsApplicationContext._openWindows')
  - [OpenWindows](#P-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-OpenWindows 'xyLOGIX.EasyTabs.TitleBarTabsApplicationContext.OpenWindows')
  - [OnWindowFormClosed(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-OnWindowFormClosed-System-Object,System-Windows-Forms-FormClosedEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabsApplicationContext.OnWindowFormClosed(System.Object,System.Windows.Forms.FormClosedEventArgs)')
  - [OpenWindow(window)](#M-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-OpenWindow-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.TitleBarTabsApplicationContext.OpenWindow(xyLOGIX.EasyTabs.TitleBarTabs)')
  - [Start(initialFormInstance)](#M-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-Start-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.TitleBarTabsApplicationContext.Start(xyLOGIX.EasyTabs.TitleBarTabs)')
- [TitleBarTabsOverlay](#T-xyLOGIX-EasyTabs-TitleBarTabsOverlay 'xyLOGIX.EasyTabs.TitleBarTabsOverlay')
  - [#ctor()](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-#ctor 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.#ctor')
  - [#ctor(parentForm)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-#ctor-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.#ctor(xyLOGIX.EasyTabs.TitleBarTabs)')
  - [_active](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_active 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._active')
  - [_aeroEnabled](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_aeroEnabled 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._aeroEnabled')
  - [_doubleClickInterval](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_doubleClickInterval 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._doubleClickInterval')
  - [_dropAreas](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_dropAreas 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._dropAreas')
  - [_firstClick](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_firstClick 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._firstClick')
  - [_hookId](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_hookId 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._hookId')
  - [_hookProcInstalled](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_hookProcInstalled 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._hookProcInstalled')
  - [_hookproc](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_hookproc 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._hookproc')
  - [_isOverAddButton](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_isOverAddButton 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._isOverAddButton')
  - [_isOverCloseButtonForTab](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_isOverCloseButtonForTab 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._isOverCloseButtonForTab')
  - [_isOverSizingBox](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_isOverSizingBox 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._isOverSizingBox')
  - [_lastLeftButtonClickTicks](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_lastLeftButtonClickTicks 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._lastLeftButtonClickTicks')
  - [_lastTwoClickCoordinates](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_lastTwoClickCoordinates 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._lastTwoClickCoordinates')
  - [_mouseEvents](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_mouseEvents 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._mouseEvents')
  - [_mouseEventsThread](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_mouseEventsThread 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._mouseEventsThread')
  - [_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm')
  - [_parentFormClosing](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentFormClosing 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentFormClosing')
  - [_parents](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parents 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parents')
  - [_tornTab](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_tornTab 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._tornTab')
  - [_tornTabForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_tornTabForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._tornTabForm')
  - [_tornTabLock](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_tornTabLock 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._tornTabLock')
  - [_wasDragging](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_wasDragging 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._wasDragging')
  - [showTooltipTimer](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-showTooltipTimer 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.showTooltipTimer')
  - [CreateParams](#P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-CreateParams 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.CreateParams')
  - [DisplayType](#P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-DisplayType 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.DisplayType')
  - [TabDropArea](#P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-TabDropArea 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.TabDropArea')
  - [TitleBarColor](#P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-TitleBarColor 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.TitleBarColor')
  - [TitleBarGradientColor](#P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-TitleBarGradientColor 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.TitleBarGradientColor')
  - [AttachHandlers()](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-AttachHandlers 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.AttachHandlers')
  - [DrawTitleBarBackground(graphics)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-DrawTitleBarBackground-System-Drawing-Graphics- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.DrawTitleBarBackground(System.Drawing.Graphics)')
  - [GetInstance(parentForm)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-GetInstance-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.GetInstance(xyLOGIX.EasyTabs.TitleBarTabs)')
  - [GetRelativeCursorPosition(cursorPosition)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-GetRelativeCursorPosition-System-Drawing-Point- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.GetRelativeCursorPosition(System.Drawing.Point)')
  - [HideTooltip()](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-HideTooltip 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.HideTooltip')
  - [Initialize()](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-Initialize 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.Initialize')
  - [InterpretMouseEvents()](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-InterpretMouseEvents 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.InterpretMouseEvents')
  - [MouseHookCallback(nCode,wParam,lParam)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)')
  - [OnParentFormActivated(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnParentFormActivated-System-Object,System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.OnParentFormActivated(System.Object,System.EventArgs)')
  - [OnParentFormClosing(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnParentFormClosing-System-Object,System-ComponentModel-CancelEventArgs- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.OnParentFormClosing(System.Object,System.ComponentModel.CancelEventArgs)')
  - [OnParentFormDeactivate(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnParentFormDeactivate-System-Object,System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.OnParentFormDeactivate(System.Object,System.EventArgs)')
  - [OnPosition()](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnPosition 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.OnPosition')
  - [OnRefreshParentForm(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnRefreshParentForm-System-Object,System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.OnRefreshParentForm(System.Object,System.EventArgs)')
  - [OnSystemColorsChangedParentForm(sender,e)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnSystemColorsChangedParentForm-System-Object,System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.OnSystemColorsChangedParentForm(System.Object,System.EventArgs)')
  - [Render(forceRedraw)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-Render-System-Boolean- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.Render(System.Boolean)')
  - [Render(cursorPosition,forceRedraw)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-Render-System-Drawing-Point,System-Boolean- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.Render(System.Drawing.Point,System.Boolean)')
  - [WndProc(m)](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-WndProc-System-Windows-Forms-Message@- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.WndProc(System.Windows.Forms.Message@)')
- [TornTabForm](#T-xyLOGIX-EasyTabs-TornTabForm 'xyLOGIX.EasyTabs.TornTabForm')
  - [#ctor(tab,tabRenderer)](#M-xyLOGIX-EasyTabs-TornTabForm-#ctor-xyLOGIX-EasyTabs-TitleBarTab,xyLOGIX-EasyTabs-TabRendererBase- 'xyLOGIX.EasyTabs.TornTabForm.#ctor(xyLOGIX.EasyTabs.TitleBarTab,xyLOGIX.EasyTabs.TabRendererBase)')
  - [_cursorOffset](#F-xyLOGIX-EasyTabs-TornTabForm-_cursorOffset 'xyLOGIX.EasyTabs.TornTabForm._cursorOffset')
  - [_hookId](#F-xyLOGIX-EasyTabs-TornTabForm-_hookId 'xyLOGIX.EasyTabs.TornTabForm._hookId')
  - [_hookInstalled](#F-xyLOGIX-EasyTabs-TornTabForm-_hookInstalled 'xyLOGIX.EasyTabs.TornTabForm._hookInstalled')
  - [_hookproc](#F-xyLOGIX-EasyTabs-TornTabForm-_hookproc 'xyLOGIX.EasyTabs.TornTabForm._hookproc')
  - [_initialized](#F-xyLOGIX-EasyTabs-TornTabForm-_initialized 'xyLOGIX.EasyTabs.TornTabForm._initialized')
  - [_layeredWindow](#F-xyLOGIX-EasyTabs-TornTabForm-_layeredWindow 'xyLOGIX.EasyTabs.TornTabForm._layeredWindow')
  - [_tabThumbnail](#F-xyLOGIX-EasyTabs-TornTabForm-_tabThumbnail 'xyLOGIX.EasyTabs.TornTabForm._tabThumbnail')
  - [MouseHookCallback(nCode,wParam,lParam)](#M-xyLOGIX-EasyTabs-TornTabForm-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr- 'xyLOGIX.EasyTabs.TornTabForm.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)')
  - [OnClosing(e)](#M-xyLOGIX-EasyTabs-TornTabForm-OnClosing-System-ComponentModel-CancelEventArgs- 'xyLOGIX.EasyTabs.TornTabForm.OnClosing(System.ComponentModel.CancelEventArgs)')
  - [OnLoad(e)](#M-xyLOGIX-EasyTabs-TornTabForm-OnLoad-System-EventArgs- 'xyLOGIX.EasyTabs.TornTabForm.OnLoad(System.EventArgs)')
  - [SetWindowPosition(cursorPosition)](#M-xyLOGIX-EasyTabs-TornTabForm-SetWindowPosition-System-Drawing-Point- 'xyLOGIX.EasyTabs.TornTabForm.SetWindowPosition(System.Drawing.Point)')
  - [TornTabForm_Disposed(sender,e)](#M-xyLOGIX-EasyTabs-TornTabForm-TornTabForm_Disposed-System-Object,System-EventArgs- 'xyLOGIX.EasyTabs.TornTabForm.TornTabForm_Disposed(System.Object,System.EventArgs)')
  - [UpdateLayeredBackground()](#M-xyLOGIX-EasyTabs-TornTabForm-UpdateLayeredBackground 'xyLOGIX.EasyTabs.TornTabForm.UpdateLayeredBackground')
- [WindowsSizingBoxes](#T-xyLOGIX-EasyTabs-WindowsSizingBoxes 'xyLOGIX.EasyTabs.WindowsSizingBoxes')
  - [#ctor(parentWindow)](#M-xyLOGIX-EasyTabs-WindowsSizingBoxes-#ctor-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.WindowsSizingBoxes.#ctor(xyLOGIX.EasyTabs.TitleBarTabs)')
  - [_closeButtonArea](#F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_closeButtonArea 'xyLOGIX.EasyTabs.WindowsSizingBoxes._closeButtonArea')
  - [_closeButtonHighlightColor](#F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_closeButtonHighlightColor 'xyLOGIX.EasyTabs.WindowsSizingBoxes._closeButtonHighlightColor')
  - [_maximizeRestoreButtonArea](#F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_maximizeRestoreButtonArea 'xyLOGIX.EasyTabs.WindowsSizingBoxes._maximizeRestoreButtonArea')
  - [_minimizeButtonArea](#F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_minimizeButtonArea 'xyLOGIX.EasyTabs.WindowsSizingBoxes._minimizeButtonArea')
  - [_minimizeMaximizeButtonHighlightColor](#F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_minimizeMaximizeButtonHighlightColor 'xyLOGIX.EasyTabs.WindowsSizingBoxes._minimizeMaximizeButtonHighlightColor')
  - [_parentWindow](#F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_parentWindow 'xyLOGIX.EasyTabs.WindowsSizingBoxes._parentWindow')
  - [CloseButtonHighlightColor](#P-xyLOGIX-EasyTabs-WindowsSizingBoxes-CloseButtonHighlightColor 'xyLOGIX.EasyTabs.WindowsSizingBoxes.CloseButtonHighlightColor')
  - [MinimizeMaximizeButtonHighlightColor](#P-xyLOGIX-EasyTabs-WindowsSizingBoxes-MinimizeMaximizeButtonHighlightColor 'xyLOGIX.EasyTabs.WindowsSizingBoxes.MinimizeMaximizeButtonHighlightColor')
  - [Width](#P-xyLOGIX-EasyTabs-WindowsSizingBoxes-Width 'xyLOGIX.EasyTabs.WindowsSizingBoxes.Width')
  - [Contains(mousePointerCoords)](#M-xyLOGIX-EasyTabs-WindowsSizingBoxes-Contains-System-Drawing-Point- 'xyLOGIX.EasyTabs.WindowsSizingBoxes.Contains(System.Drawing.Point)')
  - [GetMaximizeOrRestoreBoxImage()](#M-xyLOGIX-EasyTabs-WindowsSizingBoxes-GetMaximizeOrRestoreBoxImage 'xyLOGIX.EasyTabs.WindowsSizingBoxes.GetMaximizeOrRestoreBoxImage')
  - [LoadSvg(svgXml,width,height)](#M-xyLOGIX-EasyTabs-WindowsSizingBoxes-LoadSvg-System-String,System-Int32,System-Int32- 'xyLOGIX.EasyTabs.WindowsSizingBoxes.LoadSvg(System.String,System.Int32,System.Int32)')
  - [NonClientHitTest(mousePointerCoords)](#M-xyLOGIX-EasyTabs-WindowsSizingBoxes-NonClientHitTest-System-Drawing-Point- 'xyLOGIX.EasyTabs.WindowsSizingBoxes.NonClientHitTest(System.Drawing.Point)')
  - [OnCloseButtonHighlightColorChanged()](#M-xyLOGIX-EasyTabs-WindowsSizingBoxes-OnCloseButtonHighlightColorChanged 'xyLOGIX.EasyTabs.WindowsSizingBoxes.OnCloseButtonHighlightColorChanged')
  - [OnMinimizeMaximizeButtonHighlightColorChanged()](#M-xyLOGIX-EasyTabs-WindowsSizingBoxes-OnMinimizeMaximizeButtonHighlightColorChanged 'xyLOGIX.EasyTabs.WindowsSizingBoxes.OnMinimizeMaximizeButtonHighlightColorChanged')
  - [Render(g,mousePointerCoords)](#M-xyLOGIX-EasyTabs-WindowsSizingBoxes-Render-System-Drawing-Graphics,System-Drawing-Point- 'xyLOGIX.EasyTabs.WindowsSizingBoxes.Render(System.Drawing.Graphics,System.Drawing.Point)')

<a name='T-xyLOGIX-EasyTabs-ChromeTabRenderer'></a>
## ChromeTabRenderer `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Renderer that produces tabs that mimic the appearance of the Chrome
browser.

<a name='M-xyLOGIX-EasyTabs-ChromeTabRenderer-#ctor-xyLOGIX-EasyTabs-TitleBarTabs-'></a>
### #ctor(parent) `constructor`

##### Summary

Constructor that initializes the various resources that we use in
rendering.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [xyLOGIX.EasyTabs.TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') | Reference to an instance of
[TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') that represents the parent
(containing the tabs) window that this renderer is responsible for drawing. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `parent`, is passed a `null`
value. |

##### Remarks

The argument of the `parent` parameter must be a
valid object reference.



Otherwise, this constructor throws
[ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException').

<a name='F-xyLOGIX-EasyTabs-ChromeTabRenderer-ChromeAddButtonMarginLeft'></a>
### ChromeAddButtonMarginLeft `constants`

##### Summary

Amount of space, in pixels, that we should put to the left of the add
tab button when rendering the content area of the tab.

<a name='F-xyLOGIX-EasyTabs-ChromeTabRenderer-ChromeAddButtonMarginRight'></a>
### ChromeAddButtonMarginRight `constants`

##### Summary

Amount of space, in pixels, that we should leave to the right of the
add tab button when rendering the content area of the tab.

<a name='F-xyLOGIX-EasyTabs-ChromeTabRenderer-ChromeAddButtonMarginTop'></a>
### ChromeAddButtonMarginTop `constants`

##### Summary

Amount of space, in pixels, that we should leave between the top of
the content area and the top of the add tab button.

<a name='F-xyLOGIX-EasyTabs-ChromeTabRenderer-ChromeCloseButtonMarginLeft'></a>
### ChromeCloseButtonMarginLeft `constants`

##### Summary

Amount of space, in pixels, that we should put to the left of the
close button when rendering the content area of the tab.

<a name='F-xyLOGIX-EasyTabs-ChromeTabRenderer-_windowsSizingBoxes'></a>
### _windowsSizingBoxes `constants`

##### Summary

Reference to an instance of
[WindowsSizingBoxes](#T-xyLOGIX-EasyTabs-WindowsSizingBoxes 'xyLOGIX.EasyTabs.WindowsSizingBoxes') that controls the
rendering of window chrome elements such as the ,
, and buttons etc.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-ActiveCenterImage'></a>
### ActiveCenterImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
used as the background of the content area for the tab when the tab is active;
its width also determines how wide the default content area for the tab is.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-ActiveLeftSideImage'></a>
### ActiveLeftSideImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
displayed the left side of an active tab.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-ActiveRightSideImage'></a>
### ActiveRightSideImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
displayed on the right side of an active tab.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonHoverImage'></a>
### AddButtonHoverImage `property`

##### Summary

Gets or sets a [Bitmap](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Bitmap 'System.Drawing.Bitmap') that is to be
displayed when the user hovers over the button.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonImage'></a>
### AddButtonImage `property`

##### Summary

Gets or sets a [Bitmap](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Bitmap 'System.Drawing.Bitmap') that is to be displayed
for the `Add` button when the user is not hovering the mouse over it.
it.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonMarginLeft'></a>
### AddButtonMarginLeft `property`

##### Summary

Gets the amount of space, in pixels, that we should put to the left of
the add tab button when rendering the content area of the tab.

##### Remarks

Child classes must override this property and specify its value.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonMarginRight'></a>
### AddButtonMarginRight `property`

##### Summary

Gets the amount of space, in pixels, that we should leave to the right
of the add tab button when rendering the content area of the tab.

##### Remarks

Child classes must override this property and specify its value.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-AddButtonMarginTop'></a>
### AddButtonMarginTop `property`

##### Summary

Gets the amount of space, in pixels, that we should leave between the
top of the content area and the top of the add tab button.

##### Remarks

Child classes must override this property and specify its value.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-BackgroundImage'></a>
### BackgroundImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
used for the background, if any, that should be displayed in the non-client
area behind the actual tabs.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-CaptionFont'></a>
### CaptionFont `property`

##### Summary

Gets the [Font](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Font 'System.Drawing.Font') that is to be used to render the
caption text of the tab(s).

##### Remarks

The default value of this property is
[CaptionFont](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.SystemFonts.CaptionFont 'System.Drawing.SystemFonts.CaptionFont').



Child classes may override this property to specify their own caption font.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-CaptionMarginLeft'></a>
### CaptionMarginLeft `property`

##### Summary

Amount of space we should put to the left of the caption when
rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-CaptionMarginRight'></a>
### CaptionMarginRight `property`

##### Summary

Amount of space that we should leave to the right of the caption when
rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-CaptionMarginTop'></a>
### CaptionMarginTop `property`

##### Summary

Amount of space that we should leave between the top of the content
area and the top of the caption text.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-CloseButtonMarginLeft'></a>
### CloseButtonMarginLeft `property`

##### Summary

Gets the amount of space, in pixels, that we should put to the left of
the close button when rendering the content area of the tab.

##### Remarks

Child classes must override this property and specify its value.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-CloseButtonMarginRight'></a>
### CloseButtonMarginRight `property`

##### Summary

Amount of space that we should leave to the right of the close button
when rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-CloseButtonMarginTop'></a>
### CloseButtonMarginTop `property`

##### Summary

Amount of space that we should leave between the top of the content
area and the top of the close button.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-IconMarginLeft'></a>
### IconMarginLeft `property`

##### Summary

Amount of space we should put to the left of the tab icon when
rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-IconMarginRight'></a>
### IconMarginRight `property`

##### Summary

Amount of space that we should leave to the right of the icon when
rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-IconMarginTop'></a>
### IconMarginTop `property`

##### Summary

Amount of space that we should leave between the top of the content
area and the top of the icon.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-InactiveRightSideImage'></a>
### InactiveRightSideImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be used to
display the right side of an inactive tab.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-InactiveTabContentAreaImage'></a>
### InactiveTabContentAreaImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
displayed to represent the background of the content area of a tab when that
tab is inactive.

##### Remarks

The width of this [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') is also used
to determine the default width of the tab content area.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-OverlapWidth'></a>
### OverlapWidth `property`

##### Summary

Since Chrome tabs overlap, we set this property to the amount that
they overlap by.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-RendersEntireTitleBar'></a>
### RendersEntireTitleBar `property`

##### Summary

Gets a value indicating whether the entire title bar is to be rendered.

##### Remarks

Child classes must implement this property to affect the rendering for
each concrete renderer type.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-TabCloseButtonHoverImage'></a>
### TabCloseButtonHoverImage `property`

##### Summary

Gets or sets the [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be displayed
each tab to close that tab when the user is hovering the mouse over the tab's
button.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-TabCloseButtonImage'></a>
### TabCloseButtonImage `property`

##### Summary

Gets or sets the [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
displayed on each tab to represent its button.

##### Remarks

Typically, the button is rendered as a `x` that the
user can click to close the tab that it is located on.



This property allows clients of this class to customize that image.

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-TabHeight'></a>
### TabHeight `property`

##### Summary

Height of the tab content area; derived from the height of
[_activeCenterImage](#F-xyLOGIX-EasyTabs-TabRendererBase-_activeCenterImage 'xyLOGIX.EasyTabs.TabRendererBase._activeCenterImage').

<a name='P-xyLOGIX-EasyTabs-ChromeTabRenderer-TopPadding'></a>
### TopPadding `property`

##### Summary

Gets a value indicating how many pixels of padding should be above the tabs.

##### Remarks

Child classes should override this property to specify their own
values.

<a name='M-xyLOGIX-EasyTabs-ChromeTabRenderer-GetMaxTabWellWidth-System-Collections-Generic-IList{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Point-'></a>
### GetMaxTabWellWidth(tabs,offset) `method`

##### Summary

Gets the maximum width to utilize for the `Tab Well`.  This area is the
entire area of the form's nonclient area that is available for displaying tabs,
minus window chrome elements, such as the , , and
boxes etc.

##### Returns

Integer specifying the maximum available width for the `Tab Well`
.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tabs | [System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab}') | (Required.) Reference to an instance of a collection of
instances of [TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') that represents the
collection of tabs currently present in the `Tab Well`. |
| offset | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | (Required.) A horizontal offset for the tabs. |

<a name='M-xyLOGIX-EasyTabs-ChromeTabRenderer-IsOverSizingBox-System-Drawing-Point-'></a>
### IsOverSizingBox(mousePointerCoords) `method`

##### Summary

Determines whether the mouse mousePointerCoords is currently hovering over
element(s) of the window chrome, such as the , ,
or boxes.

##### Returns

`true` if the user is hovering the mouse pointer over
the sizing box elements of the parent form; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mousePointerCoords | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | (Required.) A
[Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') value that gives the current coordinates
of the mouse pointer. |

<a name='M-xyLOGIX-EasyTabs-ChromeTabRenderer-NonClientHitTest-System-Windows-Forms-Message,System-Drawing-Point-'></a>
### NonClientHitTest(message,mousePointerCoords) `method`

##### Summary

Attempts to determine, on what part of the nonclient area, the
`mousePointerCoords` is located, if at all.

##### Returns

One of the [HT](#T-Win32Interop-Enums-HT 'Win32Interop.Enums.HT') enumeration values.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.Windows.Forms.Message](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Message 'System.Windows.Forms.Message') | (Required.) One of the [Message](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Message 'System.Windows.Forms.Message') values
that identifies the Windows message that is being handled. |
| mousePointerCoords | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | (Required.) A [Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') value
that gives the current mouse pointer location. |

<a name='M-xyLOGIX-EasyTabs-ChromeTabRenderer-Render-System-Collections-Generic-IList{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Graphics,System-Drawing-Point,System-Drawing-Point,System-Boolean-'></a>
### Render(tabs,graphicsContext,cursor,forceRedraw,offset) `method`

##### Summary

Renders the list of `tabs` to the screen using the
given `graphicsContext`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tabs | [System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab}') | List of tabs that we are to render. |
| graphicsContext | [System.Drawing.Graphics](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Graphics 'System.Drawing.Graphics') | Graphics context that we should use while
rendering. |
| cursor | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current location of the cursor on the screen. |
| forceRedraw | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Flag indicating whether the redraw should be
forced. |
| offset | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Offset within `graphicsContext` that the
tabs should be rendered. |

<a name='M-xyLOGIX-EasyTabs-ChromeTabRenderer-Render-System-Drawing-Graphics,xyLOGIX-EasyTabs-TitleBarTab,System-Int32,System-Drawing-Rectangle,System-Drawing-Point,System-Drawing-Image,System-Drawing-Image,System-Drawing-Image-'></a>
### Render(graphicsContext,tab,index,area,cursor,tabLeftImage,tabCenterImage,tabRightImage) `method`

##### Summary

Internal method for rendering an individual `tab` to
the screen.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| graphicsContext | [System.Drawing.Graphics](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Graphics 'System.Drawing.Graphics') | Graphics context to use when rendering the tab. |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Individual tab that we are to render. |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index of the current `tab` in the
collection of currently open tabs. |
| area | [System.Drawing.Rectangle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Rectangle 'System.Drawing.Rectangle') | Area of the screen that the tab should be rendered to. |
| cursor | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current position of the cursor. |
| tabLeftImage | [System.Drawing.Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') | Image to use for the left side of the tab. |
| tabCenterImage | [System.Drawing.Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') | Image to use for the center of the tab. |
| tabRightImage | [System.Drawing.Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') | Image to use for the right side of the tab. |

<a name='T-xyLOGIX-EasyTabs-DisplayType'></a>
## DisplayType `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

The type of theme being used to render the desktop.

<a name='F-xyLOGIX-EasyTabs-DisplayType-Aero'></a>
### Aero `constants`

##### Summary

Full compositing enabled in the theme.

<a name='F-xyLOGIX-EasyTabs-DisplayType-Basic'></a>
### Basic `constants`

##### Summary

Contemporary theme, but without Aero enabled.

<a name='F-xyLOGIX-EasyTabs-DisplayType-Classic'></a>
### Classic `constants`

##### Summary

Windows 2000-esque theme.

<a name='T-xyLOGIX-EasyTabs-IListWithEvents`1'></a>
## IListWithEvents\`1 `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Defines the publicly-exposed events, methods and properties of an object that
stores a `List` of `T` but with events.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | (Required.) Data type of each of the element(s) of the
collection. |

<a name='P-xyLOGIX-EasyTabs-IListWithEvents`1-EventsSuppressed'></a>
### EventsSuppressed `property`

##### Summary

Gets whether the events are currently being suppressed.

<a name='M-xyLOGIX-EasyTabs-IListWithEvents`1-AddRange-System-Collections-Generic-IEnumerable{`0}-'></a>
### AddRange() `method`

##### Summary

Overloads
[AddRange](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.AddRange 'System.Collections.Generic.List`1.AddRange(System.Collections.Generic.IEnumerable{`0})')
.

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-IListWithEvents`1-InsertRange-System-Int32,System-Collections-Generic-IEnumerable{`0}-'></a>
### InsertRange() `method`

##### Summary

Overloads
[InsertRange](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.InsertRange 'System.Collections.Generic.List`1.InsertRange(System.Int32,System.Collections.Generic.IEnumerable{`0})')
.

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-IListWithEvents`1-RemoveAll-System-Predicate{`0}-'></a>
### RemoveAll() `method`

##### Summary

Overloads
[RemoveAll](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.RemoveAll 'System.Collections.Generic.List`1.RemoveAll(System.Predicate{`0})')
.

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-IListWithEvents`1-RemoveRange-System-Int32,System-Int32-'></a>
### RemoveRange() `method`

##### Summary

Overloads
[RemoveRange](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.RemoveRange 'System.Collections.Generic.List`1.RemoveRange(System.Int32,System.Int32)')
.

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-IListWithEvents`1-RemoveRange-System-Collections-Generic-IEnumerable{`0}-'></a>
### RemoveRange(collection) `method`

##### Summary

Removes the specified list of entries from the collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | Collection to be removed from the list. |

##### Remarks

This operation employs
[Remove](#M-xyLOGIX-EasyTabs-ListWithEvents`1-Remove-`0- 'xyLOGIX.EasyTabs.ListWithEvents`1.Remove(`0)')
method for removing each individual item which is thread-safe.  However,
overall
operation isn't atomic, and hence does not guarantee thread-safety.

<a name='M-xyLOGIX-EasyTabs-IListWithEvents`1-ResumeEvents'></a>
### ResumeEvents() `method`

##### Summary

Resumes raising events after
[SuppressEvents](#M-xyLOGIX-EasyTabs-ListWithEvents`1-SuppressEvents 'xyLOGIX.EasyTabs.ListWithEvents`1.SuppressEvents') call.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-IListWithEvents`1-SuppressEvents'></a>
### SuppressEvents() `method`

##### Summary

Stops raising events until
[ResumeEvents](#M-xyLOGIX-EasyTabs-ListWithEvents`1-ResumeEvents 'xyLOGIX.EasyTabs.ListWithEvents`1.ResumeEvents') is called.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-IListWithEvents`1-TrimExcess'></a>
### TrimExcess() `method`

##### Summary

Removes the extra capacity of the collection after, e.g., items have been
removed or added.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-EasyTabs-LayeredWindow'></a>
## LayeredWindow `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Form that actually displays the thumbnail content for
[TornTabForm](#T-xyLOGIX-EasyTabs-TornTabForm 'xyLOGIX.EasyTabs.TornTabForm').

<a name='M-xyLOGIX-EasyTabs-LayeredWindow-#ctor'></a>
### #ctor() `constructor`

##### Summary

Default constructor.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-EasyTabs-LayeredWindow-CreateParams'></a>
### CreateParams `property`

##### Summary

Makes sure that the window is created with an
[WS_EX_LAYERED](#F-Win32Interop-Enums-WS_EX-WS_EX_LAYERED 'Win32Interop.Enums.WS_EX.WS_EX_LAYERED') flag set so that it can
be alpha-blended properly with the desktop
contents underneath it.

<a name='M-xyLOGIX-EasyTabs-LayeredWindow-UpdateWindow-System-Drawing-Bitmap,System-Byte,System-Int32,System-Int32,Win32Interop-Structs-POINT-'></a>
### UpdateWindow(image,opacity,width,height,position) `method`

##### Summary

Renders the tab thumbnail (`image`) using the given
dimensions and coordinates and blends it properly with the underlying desktop
elements.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| image | [System.Drawing.Bitmap](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Bitmap 'System.Drawing.Bitmap') | Thumbnail to display. |
| opacity | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | Opacity that `image` should be
displayed with. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Width of `image`. |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Height of `image`. |
| position | [Win32Interop.Structs.POINT](#T-Win32Interop-Structs-POINT 'Win32Interop.Structs.POINT') | Screen position that `image` should be
displayed at. |

<a name='T-xyLOGIX-EasyTabs-ListItemEventArgs'></a>
## ListItemEventArgs `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Provides data for the
[](#E-xyLOGIX-EasyTabs-ListWithEvents`1-ItemAdded 'xyLOGIX.EasyTabs.ListWithEvents`1.ItemAdded') events.

<a name='M-xyLOGIX-EasyTabs-ListItemEventArgs-#ctor-System-Int32-'></a>
### #ctor(itemIndex) `constructor`

##### Summary

Initializes a new instance of the
[ListItemEventArgs](#T-xyLOGIX-EasyTabs-ListItemEventArgs 'xyLOGIX.EasyTabs.ListItemEventArgs') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| itemIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index of the item being changed. |

<a name='F-xyLOGIX-EasyTabs-ListItemEventArgs-_itemIndex'></a>
### _itemIndex `constants`

##### Summary

Index of the item being changed.

<a name='P-xyLOGIX-EasyTabs-ListItemEventArgs-ItemIndex'></a>
### ItemIndex `property`

##### Summary

Gets the index of the item changed.

<a name='T-xyLOGIX-EasyTabs-ListModification'></a>
## ListModification `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

List of possible [ListWithEvents\`1](#T-xyLOGIX-EasyTabs-ListWithEvents`1 'xyLOGIX.EasyTabs.ListWithEvents`1')
modifications.

<a name='F-xyLOGIX-EasyTabs-ListModification-Cleared'></a>
### Cleared `constants`

##### Summary

The list has been cleared.

<a name='F-xyLOGIX-EasyTabs-ListModification-ItemAdded'></a>
### ItemAdded `constants`

##### Summary

A new item has been added.

<a name='F-xyLOGIX-EasyTabs-ListModification-ItemModified'></a>
### ItemModified `constants`

##### Summary

An item has been modified.

<a name='F-xyLOGIX-EasyTabs-ListModification-ItemRemoved'></a>
### ItemRemoved `constants`

##### Summary

An item has been removed.

<a name='F-xyLOGIX-EasyTabs-ListModification-RangeAdded'></a>
### RangeAdded `constants`

##### Summary

A range of items has been added.

<a name='F-xyLOGIX-EasyTabs-ListModification-RangeRemoved'></a>
### RangeRemoved `constants`

##### Summary

A range of items has been removed.

<a name='T-xyLOGIX-EasyTabs-ListModificationEventArgs'></a>
## ListModificationEventArgs `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Provides data for the
[](#E-xyLOGIX-EasyTabs-ListWithEvents`1-CollectionModified 'xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified') events.

<a name='M-xyLOGIX-EasyTabs-ListModificationEventArgs-#ctor-xyLOGIX-EasyTabs-ListModification,System-Int32,System-Int32-'></a>
### #ctor(modification,startIndex,count) `constructor`

##### Summary

Initializes a new instance of the
[ListModificationEventArgs](#T-xyLOGIX-EasyTabs-ListModificationEventArgs 'xyLOGIX.EasyTabs.ListModificationEventArgs') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| modification | [xyLOGIX.EasyTabs.ListModification](#T-xyLOGIX-EasyTabs-ListModification 'xyLOGIX.EasyTabs.ListModification') | Modification being made to the list. |
| startIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index from which the modifications start. |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of modifications being made. |

<a name='F-xyLOGIX-EasyTabs-ListModificationEventArgs-_modification'></a>
### _modification `constants`

##### Summary

Modification being made to the list.

<a name='P-xyLOGIX-EasyTabs-ListModificationEventArgs-Modification'></a>
### Modification `property`

##### Summary

Gets the type of list modification.

<a name='T-xyLOGIX-EasyTabs-ListRangeEventArgs'></a>
## ListRangeEventArgs `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Provides data for the
[](#E-xyLOGIX-EasyTabs-ListWithEvents`1-RangeAdded 'xyLOGIX.EasyTabs.ListWithEvents`1.RangeAdded') events.

<a name='M-xyLOGIX-EasyTabs-ListRangeEventArgs-#ctor-System-Int32,System-Int32-'></a>
### #ctor(startIndex,count) `constructor`

##### Summary

Initializes a new instance of the
[ListRangeEventArgs](#T-xyLOGIX-EasyTabs-ListRangeEventArgs 'xyLOGIX.EasyTabs.ListRangeEventArgs') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| startIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index of the first item in the range. |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of items in the range. |

<a name='F-xyLOGIX-EasyTabs-ListRangeEventArgs-_count'></a>
### _count `constants`

##### Summary

Number of items in the range.

<a name='F-xyLOGIX-EasyTabs-ListRangeEventArgs-_startIndex'></a>
### _startIndex `constants`

##### Summary

Index of the first item in the range.

<a name='P-xyLOGIX-EasyTabs-ListRangeEventArgs-Count'></a>
### Count `property`

##### Summary

Gets the number of items in the range.

<a name='P-xyLOGIX-EasyTabs-ListRangeEventArgs-StartIndex'></a>
### StartIndex `property`

##### Summary

Gets the index of the first item in the range.

<a name='T-xyLOGIX-EasyTabs-ListWithEvents`1'></a>
## ListWithEvents\`1 `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Represents a strongly typed list of objects with events.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of elements in the list. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the
[ListWithEvents\`1](#T-xyLOGIX-EasyTabs-ListWithEvents`1 'xyLOGIX.EasyTabs.ListWithEvents`1') class that is empty and has
the
default initial capacity.

##### Parameters

This constructor has no parameters.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-#ctor-System-Collections-Generic-IEnumerable{`0}-'></a>
### #ctor(collection) `constructor`

##### Summary

Initializes a new instance of the
[ListWithEvents\`1](#T-xyLOGIX-EasyTabs-ListWithEvents`1 'xyLOGIX.EasyTabs.ListWithEvents`1')
class that contains elements copied from the specified collection and has
sufficient capacity to accommodate the number of elements copied.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | The collection whose elements are copied to the new
list. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | The collection is null. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-#ctor-System-Int32-'></a>
### #ctor(capacity) `constructor`

##### Summary

Initializes a new instance of the
[ListWithEvents\`1](#T-xyLOGIX-EasyTabs-ListWithEvents`1 'xyLOGIX.EasyTabs.ListWithEvents`1') class that is empty and has
the
specified initial capacity.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| capacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of elements that the new list can initially
store. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | The capacity is less
than 0. |

<a name='F-xyLOGIX-EasyTabs-ListWithEvents`1-SyncRoot'></a>
### SyncRoot `constants`

##### Summary

Synchronization root for thread safety.

<a name='F-xyLOGIX-EasyTabs-ListWithEvents`1-_suppressEvents'></a>
### _suppressEvents `constants`

##### Summary

Flag indicating whether events are being suppressed during an
operation.

<a name='P-xyLOGIX-EasyTabs-ListWithEvents`1-EventsSuppressed'></a>
### EventsSuppressed `property`

##### Summary

Gets whether the events are currently being suppressed.

<a name='P-xyLOGIX-EasyTabs-ListWithEvents`1-Item-System-Int32-'></a>
### Item `property`

##### Summary

Overloads
[Item](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.Item 'System.Collections.Generic.List`1.Item(System.Int32)').

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-Add-`0-'></a>
### Add() `method`

##### Summary

Overloads [Add](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.Add 'System.Collections.Generic.List`1.Add(`0)').

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-AddRange-System-Collections-Generic-IEnumerable{`0}-'></a>
### AddRange() `method`

##### Summary

Overloads
[AddRange](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.AddRange 'System.Collections.Generic.List`1.AddRange(System.Collections.Generic.IEnumerable{`0})')
.

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-Clear'></a>
### Clear() `method`

##### Summary

Overloads [Clear](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.Clear 'System.Collections.Generic.List`1.Clear').

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-Insert-System-Int32,`0-'></a>
### Insert() `method`

##### Summary

Overloads
[Insert](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.Insert 'System.Collections.Generic.List`1.Insert(System.Int32,`0)').

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-InsertRange-System-Int32,System-Collections-Generic-IEnumerable{`0}-'></a>
### InsertRange() `method`

##### Summary

Overloads
[InsertRange](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.InsertRange 'System.Collections.Generic.List`1.InsertRange(System.Int32,System.Collections.Generic.IEnumerable{`0})')
.

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-OnCleared-System-EventArgs-'></a>
### OnCleared(e) `method`

##### Summary

Raises [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-CollectionModified 'xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified')
and [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-Cleared 'xyLOGIX.EasyTabs.ListWithEvents`1.Cleared') events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | An [EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') that contains the event
data. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-OnCollectionModified-xyLOGIX-EasyTabs-ListModificationEventArgs-'></a>
### OnCollectionModified(e) `method`

##### Summary

Raises [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-CollectionModified 'xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified')
events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.EasyTabs.ListModificationEventArgs](#T-xyLOGIX-EasyTabs-ListModificationEventArgs 'xyLOGIX.EasyTabs.ListModificationEventArgs') | An [ListModificationEventArgs](#T-xyLOGIX-EasyTabs-ListModificationEventArgs 'xyLOGIX.EasyTabs.ListModificationEventArgs') that
contains the event data. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-OnEventsSuppressedChanged'></a>
### OnEventsSuppressedChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-ListWithEvents`1-EventsSuppressedChanged 'xyLOGIX.EasyTabs.ListWithEvents`1.EventsSuppressedChanged')
event.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-OnItemAdded-xyLOGIX-EasyTabs-ListItemEventArgs-'></a>
### OnItemAdded(e) `method`

##### Summary

Raises [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-CollectionModified 'xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified')
and [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-ItemAdded 'xyLOGIX.EasyTabs.ListWithEvents`1.ItemAdded') events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.EasyTabs.ListItemEventArgs](#T-xyLOGIX-EasyTabs-ListItemEventArgs 'xyLOGIX.EasyTabs.ListItemEventArgs') | An [ListItemEventArgs](#T-xyLOGIX-EasyTabs-ListItemEventArgs 'xyLOGIX.EasyTabs.ListItemEventArgs') that contains
the event data. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-OnItemModified-xyLOGIX-EasyTabs-ListItemEventArgs-'></a>
### OnItemModified(e) `method`

##### Summary

Raises [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-CollectionModified 'xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified')
and [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-ItemModified 'xyLOGIX.EasyTabs.ListWithEvents`1.ItemModified') events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.EasyTabs.ListItemEventArgs](#T-xyLOGIX-EasyTabs-ListItemEventArgs 'xyLOGIX.EasyTabs.ListItemEventArgs') | An [ListItemEventArgs](#T-xyLOGIX-EasyTabs-ListItemEventArgs 'xyLOGIX.EasyTabs.ListItemEventArgs') that contains
the event data. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-OnItemRemoved-System-EventArgs-'></a>
### OnItemRemoved(e) `method`

##### Summary

Raises [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-CollectionModified 'xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified')
and [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-ItemRemoved 'xyLOGIX.EasyTabs.ListWithEvents`1.ItemRemoved') events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | An [EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') that contains the event
data. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-OnRangeAdded-xyLOGIX-EasyTabs-ListRangeEventArgs-'></a>
### OnRangeAdded(e) `method`

##### Summary

Raises [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-CollectionModified 'xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified')
and [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-RangeAdded 'xyLOGIX.EasyTabs.ListWithEvents`1.RangeAdded') events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.EasyTabs.ListRangeEventArgs](#T-xyLOGIX-EasyTabs-ListRangeEventArgs 'xyLOGIX.EasyTabs.ListRangeEventArgs') | An [ListRangeEventArgs](#T-xyLOGIX-EasyTabs-ListRangeEventArgs 'xyLOGIX.EasyTabs.ListRangeEventArgs') that contains
the event data. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-OnRangeRemoved-System-EventArgs-'></a>
### OnRangeRemoved(e) `method`

##### Summary

Raises [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-CollectionModified 'xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified')
and [](#E-xyLOGIX-EasyTabs-ListWithEvents`1-RangeRemoved 'xyLOGIX.EasyTabs.ListWithEvents`1.RangeRemoved') events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | An [EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') that contains the event
data. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-Remove-`0-'></a>
### Remove() `method`

##### Summary

Overloads
[Remove](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.Remove 'System.Collections.Generic.List`1.Remove(`0)').

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-RemoveAll-System-Predicate{`0}-'></a>
### RemoveAll() `method`

##### Summary

Overloads
[RemoveAll](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.RemoveAll 'System.Collections.Generic.List`1.RemoveAll(System.Predicate{`0})')
.

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-RemoveAt-System-Int32-'></a>
### RemoveAt() `method`

##### Summary

Overloads
[RemoveAt](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.RemoveAt 'System.Collections.Generic.List`1.RemoveAt(System.Int32)').

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-RemoveRange-System-Int32,System-Int32-'></a>
### RemoveRange() `method`

##### Summary

Overloads
[RemoveRange](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1.RemoveRange 'System.Collections.Generic.List`1.RemoveRange(System.Int32,System.Int32)')
.

##### Parameters

This method has no parameters.

##### Remarks

This operation is thread-safe.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-RemoveRange-System-Collections-Generic-IEnumerable{`0}-'></a>
### RemoveRange(collection) `method`

##### Summary

Removes the specified list of entries from the collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | Collection to be removed from the list. |

##### Remarks

This operation employs
[Remove](#M-xyLOGIX-EasyTabs-ListWithEvents`1-Remove-`0- 'xyLOGIX.EasyTabs.ListWithEvents`1.Remove(`0)')
method for removing each individual item which is thread-safe.  However,
overall
operation isn't atomic, and hence does not guarantee thread-safety.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-ResumeEvents'></a>
### ResumeEvents() `method`

##### Summary

Resumes raising events after
[SuppressEvents](#M-xyLOGIX-EasyTabs-ListWithEvents`1-SuppressEvents 'xyLOGIX.EasyTabs.ListWithEvents`1.SuppressEvents') call.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-SetEventsSuppressed-System-Boolean-'></a>
### SetEventsSuppressed(eventsSuppressed) `method`

##### Summary

Updates the value of the
[EventsSuppressed](#P-xyLOGIX-EasyTabs-ListWithEvents`1-EventsSuppressed 'xyLOGIX.EasyTabs.ListWithEvents`1.EventsSuppressed') property to
match
the specified `eventsSuppressed` setting.s

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eventsSuppressed | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Optional.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean')
value that is to be the new setting of the
[EventsSuppressed](#P-xyLOGIX-EasyTabs-ListWithEvents`1-EventsSuppressed 'xyLOGIX.EasyTabs.ListWithEvents`1.EventsSuppressed') property.



The default value of this parameter is `true`. |

<a name='M-xyLOGIX-EasyTabs-ListWithEvents`1-SuppressEvents'></a>
### SuppressEvents() `method`

##### Summary

Stops raising events until
[ResumeEvents](#M-xyLOGIX-EasyTabs-ListWithEvents`1-ResumeEvents 'xyLOGIX.EasyTabs.ListWithEvents`1.ResumeEvents') is called.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-EasyTabs-MouseEvent'></a>
## MouseEvent `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Contains information on mouse events captured by
[MouseHookCallback](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-MouseHookCallback 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback') and
processed by
[InterpretMouseEvents](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-InterpretMouseEvents 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.InterpretMouseEvents').

<a name='P-xyLOGIX-EasyTabs-MouseEvent-Code'></a>
### Code `property`

##### Summary

Code for the event.

<a name='P-xyLOGIX-EasyTabs-MouseEvent-LParam'></a>
### LParam `property`

##### Summary

LParam value associated with the event.

<a name='P-xyLOGIX-EasyTabs-MouseEvent-MouseData'></a>
### MouseData `property`

##### Summary

Data associated with the mouse event.

<a name='P-xyLOGIX-EasyTabs-MouseEvent-WParam'></a>
### WParam `property`

##### Summary

WParam value associated with the event.

<a name='T-xyLOGIX-EasyTabs-OperatingSystem'></a>
## OperatingSystem `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Exposes static methods to interrogate the operating system.

<a name='F-xyLOGIX-EasyTabs-OperatingSystem-OperatingSystemVersionKeyPath'></a>
### OperatingSystemVersionKeyPath `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the subkey path of the
`HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion` subkey.

<a name='F-xyLOGIX-EasyTabs-OperatingSystem-ProductNameValue'></a>
### ProductNameValue `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the name of the
`ProductName` registry value.

<a name='P-xyLOGIX-EasyTabs-OperatingSystem-IsWindows10'></a>
### IsWindows10 `property`

##### Summary

Gets a value indicating whether the user is running the client application on
the Windows 10 operating system.

<a name='T-xyLOGIX-EasyTabs-Properties-Resources'></a>
## Resources `type`

##### Namespace

xyLOGIX.EasyTabs.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeAdd'></a>
### ChromeAdd `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeAddHover'></a>
### ChromeAddHover `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeBackground'></a>
### ChromeBackground `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeCenter'></a>
### ChromeCenter `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeClose'></a>
### ChromeClose `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeCloseHover'></a>
### ChromeCloseHover `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeInactiveCenter'></a>
### ChromeInactiveCenter `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeInactiveLeft'></a>
### ChromeInactiveLeft `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeInactiveRight'></a>
### ChromeInactiveRight `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeInactiveRightNoDivider'></a>
### ChromeInactiveRightNoDivider `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeLeft'></a>
### ChromeLeft `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ChromeRight'></a>
### ChromeRight `property`

##### Summary

Looks up a localized resource of type System.Drawing.Bitmap.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-Close'></a>
### Close `property`

##### Summary

Looks up a localized resource of type System.Byte[].

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-CloseHighlight'></a>
### CloseHighlight `property`

##### Summary

Looks up a localized resource of type System.Byte[].

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-Maximize'></a>
### Maximize `property`

##### Summary

Looks up a localized resource of type System.Byte[].

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-Minimize'></a>
### Minimize `property`

##### Summary

Looks up a localized resource of type System.Byte[].

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='P-xyLOGIX-EasyTabs-Properties-Resources-Restore'></a>
### Restore `property`

##### Summary

Looks up a localized resource of type System.Byte[].

<a name='T-xyLOGIX-EasyTabs-TabClosingEventHandler'></a>
## TabClosingEventHandler `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Represents a handler for a `TabClosing` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:xyLOGIX.EasyTabs.TabClosingEventHandler](#T-T-xyLOGIX-EasyTabs-TabClosingEventHandler 'T:xyLOGIX.EasyTabs.TabClosingEventHandler') | Reference to an instance of [TitleBarTab\`1](#T-xyLOGIX-EasyTabs-TitleBarTab`1 'xyLOGIX.EasyTabs.TitleBarTab`1')
that is about to be closed. |

##### Remarks

This delegate merely specifies the signature of all methods that handle the
`TabClosing` event.

<a name='T-xyLOGIX-EasyTabs-TabRendererBase'></a>
## TabRendererBase `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Provides the base functionality for any `TabRenderer`, taking
care of actually rendering and detecting whether the cursor is over a tab.  Any
custom tab renderer needs to inherit from this class, just as
[ChromeTabRenderer](#T-xyLOGIX-EasyTabs-ChromeTabRenderer 'xyLOGIX.EasyTabs.ChromeTabRenderer') does.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-#ctor-xyLOGIX-EasyTabs-TitleBarTabs-'></a>
### #ctor(parent) `constructor`

##### Summary

Constructs a new instance of [TabRendererBase](#T-xyLOGIX-EasyTabs-TabRendererBase 'xyLOGIX.EasyTabs.TabRendererBase')
and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [xyLOGIX.EasyTabs.TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') | Reference to an instance of
[TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') that represents the parent
(containing the tabs) window that this renderer is responsible for drawing. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `parent`, is passed a `null`
value. |

##### Remarks

The argument of the `parent` parameter must be a
valid object reference.



Otherwise, this constructor throws
[ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException').

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_addButtonShown'></a>
### _addButtonShown `constants`

##### Summary

Flag indicating whether the button is to be shown.

##### Remarks

The default value of this flag is `true`.

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_foreColor'></a>
### _foreColor `constants`

##### Summary

A [Color](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color 'System.Drawing.Color') value that is to be used for the text
of the tabs.

##### Remarks

The default value of this field is
[White](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color.White 'System.Drawing.Color.White').

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_isTabRepositioning'></a>
### _isTabRepositioning `constants`

##### Summary

Flag indicating whether a tab is being repositioned.

##### Remarks

This flag is used by the
[IsTabRepositioning](#P-xyLOGIX-EasyTabs-TabRendererBase-IsTabRepositioning 'xyLOGIX.EasyTabs.TabRendererBase.IsTabRepositioning') property
to detect whether its value has been updated.

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_maxTabWellWellArea'></a>
### _maxTabWellWellArea `constants`

##### Summary

A [Rectangle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Rectangle 'System.Drawing.Rectangle') value that demarcates the maximum
area on the screen that a given tabs, as a set, may occupy, excluding the
button.

##### Remarks

This flag is used by the
[MaxTabWellArea](#P-xyLOGIX-EasyTabs-TabRendererBase-MaxTabWellArea 'xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellArea') property to
tell when the value of the property has been updated.

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_previousTabCount'></a>
### _previousTabCount `constants`

##### Summary

Count of tabs that were present when we last rendered.

##### Remarks

Used to determine whether we need to redraw the tabs.



This field is used by the
[PreviousTabCount](#P-xyLOGIX-EasyTabs-TabRendererBase-PreviousTabCount 'xyLOGIX.EasyTabs.TabRendererBase.PreviousTabCount') property to
determine when its value has been altered.

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_suspendRendering'></a>
### _suspendRendering `constants`

##### Summary

Flag indicating whether rendering has been suspended while we perform some
operation.

##### Remarks

The field is used by the
[RenderingSuspended](#P-xyLOGIX-EasyTabs-TabRendererBase-RenderingSuspended 'xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspended') property
in order to determine whether its value has been altered.

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_tabBackColor'></a>
### _tabBackColor `constants`

##### Summary

A [Color](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color 'System.Drawing.Color') value that is to be used for the
background color of each of the tabs.

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_tabClickOffset'></a>
### _tabClickOffset `constants`

##### Summary

Value indicating the horizontal offset within the tab where the user clicked to
start a `Drag` operation.

##### Remarks

The default value of this field is `-1`, for
`not applicable`.



This field is used by the
[TabClickOffset](#P-xyLOGIX-EasyTabs-TabRendererBase-TabClickOffset 'xyLOGIX.EasyTabs.TabRendererBase.TabClickOffset') property to
determine whether its value has been altered.

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_tabContentWidth'></a>
### _tabContentWidth `constants`

##### Summary

The width, in pixels, of the `Content Area` that we should use
for each tab.

<a name='F-xyLOGIX-EasyTabs-TabRendererBase-_wasTabRepositioning'></a>
### _wasTabRepositioning `constants`

##### Summary

Flag indicating whether a tab was being repositioned.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-ActiveCenterImage'></a>
### ActiveCenterImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
used as the background of the content area for the tab when the tab is active;
its width also determines how wide the default content area for the tab is.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-ActiveLeftSideImage'></a>
### ActiveLeftSideImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
displayed the left side of an active tab.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-ActiveRightSideImage'></a>
### ActiveRightSideImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
displayed on the right side of an active tab.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonHoverImage'></a>
### AddButtonHoverImage `property`

##### Summary

Gets or sets a [Bitmap](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Bitmap 'System.Drawing.Bitmap') that is to be
displayed when the user hovers over the button.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonImage'></a>
### AddButtonImage `property`

##### Summary

Gets or sets a [Bitmap](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Bitmap 'System.Drawing.Bitmap') that is to be displayed
for the `Add` button when the user is not hovering the mouse over it.
it.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonMarginLeft'></a>
### AddButtonMarginLeft `property`

##### Summary

Gets the amount of space, in pixels, that we should put to the left of
the add tab button when rendering the content area of the tab.

##### Remarks

Child classes must override this property and specify its value.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonMarginRight'></a>
### AddButtonMarginRight `property`

##### Summary

Gets the amount of space, in pixels, that we should leave to the right
of the add tab button when rendering the content area of the tab.

##### Remarks

Child classes must override this property and specify its value.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonMarginTop'></a>
### AddButtonMarginTop `property`

##### Summary

Gets the amount of space, in pixels, that we should leave between the
top of the content area and the top of the add tab button.

##### Remarks

Child classes must override this property and specify its value.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-AddButtonRectangle'></a>
### AddButtonRectangle `property`

##### Summary

Gets or sets a [Rectangle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Rectangle 'System.Drawing.Rectangle') value that
demarcates the area on the screen where the , or button is
located.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-BackgroundImage'></a>
### BackgroundImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
used for the background, if any, that should be displayed in the non-client
area behind the actual tabs.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-CaptionFont'></a>
### CaptionFont `property`

##### Summary

Gets the [Font](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Font 'System.Drawing.Font') that is to be used to render the
caption text of the tab(s).

##### Remarks

The default value of this property is
[CaptionFont](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.SystemFonts.CaptionFont 'System.Drawing.SystemFonts.CaptionFont').



Child classes may override this property to specify their own caption font.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-CaptionMarginLeft'></a>
### CaptionMarginLeft `property`

##### Summary

Amount of space we should put to the left of the caption when
rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-CaptionMarginRight'></a>
### CaptionMarginRight `property`

##### Summary

Amount of space that we should leave to the right of the caption when
rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-CaptionMarginTop'></a>
### CaptionMarginTop `property`

##### Summary

Amount of space that we should leave between the top of the content
area and the top of the caption text.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-CloseButtonMarginLeft'></a>
### CloseButtonMarginLeft `property`

##### Summary

Gets the amount of space, in pixels, that we should put to the left of
the close button when rendering the content area of the tab.

##### Remarks

Child classes must override this property and specify its value.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-CloseButtonMarginRight'></a>
### CloseButtonMarginRight `property`

##### Summary

Amount of space that we should leave to the right of the close button
when rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-CloseButtonMarginTop'></a>
### CloseButtonMarginTop `property`

##### Summary

Amount of space that we should leave between the top of the content
area and the top of the close button.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-DragStart'></a>
### DragStart `property`

##### Summary

Gets a [Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') that represents the mouse
coordinates where the user first clicked and held the mouse in order to begin
the operation of dragging a `Tab`.

##### Remarks

The default value of this property is
[Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point.Empty 'System.Drawing.Point.Empty').

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-ForeColor'></a>
### ForeColor `property`

##### Summary

Gets or sets a [Color](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color 'System.Drawing.Color') value that is to be used
for the text of the tabs.

##### Remarks

The default value of this property is
[White](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color.White 'System.Drawing.Color.White') for the `Dark Theme`.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-IconMarginLeft'></a>
### IconMarginLeft `property`

##### Summary

Amount of space we should put to the left of the tab icon when
rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-IconMarginRight'></a>
### IconMarginRight `property`

##### Summary

Amount of space that we should leave to the right of the icon when
rendering the content area of the tab.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-IconMarginTop'></a>
### IconMarginTop `property`

##### Summary

Amount of space that we should leave between the top of the content
area and the top of the icon.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-InactiveRightSideImage'></a>
### InactiveRightSideImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be used to
display the right side of an inactive tab.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-InactiveTabContentAreaImage'></a>
### InactiveTabContentAreaImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
displayed to represent the background of the content area of a tab when that
tab is inactive.

##### Remarks

The width of this [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') is also used
to determine the default width of the tab content area.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-InactiveTabLeftSideImage'></a>
### InactiveTabLeftSideImage `property`

##### Summary

Gets or sets a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be used to
display the left side of an inactive tab.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-IsTabRepositioning'></a>
### IsTabRepositioning `property`

##### Summary

Gets a value that indicates whether a tab is being repositioned.

##### Remarks

If the value of this property is updated, then the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-TabRepositioningChanged 'xyLOGIX.EasyTabs.TabRendererBase.TabRepositioningChanged') event
is raised.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-MaxTabWellArea'></a>
### MaxTabWellArea `property`

##### Summary

Gets the [Rectangle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Rectangle 'System.Drawing.Rectangle') value that demarcates the
maximum area on the screen that a given tabs, as a set, may occupy, excluding
the button.

##### Remarks

If the value of this property is updated, then the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-MaxTabWellAreaChanged 'xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellAreaChanged') event
is raised.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-OverlapWidth'></a>
### OverlapWidth `property`

##### Summary

If the renderer overlaps the tabs (like Chrome), this is the width that the
tabs should overlap by.  For renderers that do not overlap tabs (like
Firefox), this should be left at 0.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-Parent'></a>
### Parent `property`

##### Summary

Gets a reference to an instance of
[TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') that represents the parent
container that this renderer instance is associated with.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-PreviousTabCount'></a>
### PreviousTabCount `property`

##### Summary

Gets the count of tabs that were present when we last rendered.

##### Remarks

Used to determine whether we need to redraw the tabs.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-RenderingSuspended'></a>
### RenderingSuspended `property`

##### Summary

Gets a value indicating whether rendering has been suspended while we perform
some operation.

##### Remarks

If the value of this property is updated, then the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-RenderingSuspendedChanged 'xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspendedChanged')
event is raised.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-RendersEntireTitleBar'></a>
### RendersEntireTitleBar `property`

##### Summary

Gets a value indicating whether the entire title bar is to be rendered.

##### Remarks

Child classes must implement this property to affect the rendering for
each concrete renderer type.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-ShowAddButton'></a>
### ShowAddButton `property`

##### Summary

Gets or sets a value indicating whether the button is to be
shown.

##### Remarks

The default value of this property is `true`.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-TabBackColor'></a>
### TabBackColor `property`

##### Summary

Gets or sets the [Color](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color 'System.Drawing.Color') value that is to be used
to paint the background of the tabs and tab well.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-TabClickOffset'></a>
### TabClickOffset `property`

##### Summary

Gets a value that indicates the horizontal offset within the tab where the user
clicked to start a `Drag` operation.

##### Remarks

The default value of this property is `-1`, which means
`not applicable`.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-TabCloseButtonHoverImage'></a>
### TabCloseButtonHoverImage `property`

##### Summary

Gets or sets the [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be displayed
each tab to close that tab when the user is hovering the mouse over the tab's
button.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-TabCloseButtonImage'></a>
### TabCloseButtonImage `property`

##### Summary

Gets or sets the [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to be
displayed on each tab to represent its button.

##### Remarks

Typically, the button is rendered as a `x` that the
user can click to close the tab that it is located on.



This property allows clients of this class to customize that image.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-TabContentWidth'></a>
### TabContentWidth `property`

##### Summary

Gets the width, in pixels, of the content area of the tabs.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-TabHeight'></a>
### TabHeight `property`

##### Summary

Height of the tab content area; derived from the height of
[_activeCenterImage](#F-xyLOGIX-EasyTabs-TabRendererBase-_activeCenterImage 'xyLOGIX.EasyTabs.TabRendererBase._activeCenterImage').

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-TabRepositionDragDistance'></a>
### TabRepositionDragDistance `property`

##### Summary

Horizontal distance that a tab must be dragged before it starts to be
repositioned.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-TabTearDragDistance'></a>
### TabTearDragDistance `property`

##### Summary

Distance that a user must drag a tab outside the tab area before it
shows up as "torn" from its parent window.

<a name='P-xyLOGIX-EasyTabs-TabRendererBase-TopPadding'></a>
### TopPadding `property`

##### Summary

Gets a value indicating how many pixels of padding should be above the tabs.

##### Remarks

Child classes should override this property to specify their own
values.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-CombineTab-xyLOGIX-EasyTabs-TitleBarTab,System-Drawing-Point-'></a>
### CombineTab(tab,cursorLocation) `method`

##### Summary

Called when a torn tab is dragged into the
[TabDropArea](#P-xyLOGIX-EasyTabs-TitleBarTabs-TabDropArea 'xyLOGIX.EasyTabs.TitleBarTabs.TabDropArea') of
[_parentWindow](#F-xyLOGIX-EasyTabs-TabRendererBase-_parentWindow 'xyLOGIX.EasyTabs.TabRendererBase._parentWindow').  Places the
tab in the
list and
sets [IsTabRepositioning](#P-xyLOGIX-EasyTabs-TabRendererBase-IsTabRepositioning 'xyLOGIX.EasyTabs.TabRendererBase.IsTabRepositioning') to
true to
simulate the user continuing to drag the tab around in the window.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab that was dragged into this window. |
| cursorLocation | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Location of the user's cursor. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-GetMaxTabWellWidth-System-Collections-Generic-IList{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Point-'></a>
### GetMaxTabWellWidth(tabs,offset) `method`

##### Summary

Gets the maximum width to utilize for the `Tab Well`.  This area is the
entire area of the form's nonclient area that is available for displaying tabs,
minus window chrome elements, such as the , , and
boxes etc.

##### Returns

Integer specifying the maximum available width for the `Tab Well`
.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tabs | [System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab}') | (Required.) Reference to an instance of a collection of
instances of [TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') that represents the
collection of tabs currently present in the `Tab Well`. |
| offset | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | (Required.) A horizontal offset for the tabs. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-GetTabCenterImage-xyLOGIX-EasyTabs-TitleBarTab-'></a>
### GetTabCenterImage(tab) `method`

##### Summary

Gets the image to use for the center of the `tab`.

##### Returns

The image for the center of `tab`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab that we are retrieving the image for. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-GetTabLeftImage-xyLOGIX-EasyTabs-TitleBarTab-'></a>
### GetTabLeftImage(tab) `method`

##### Summary

Gets the image to use for the left side of the `tab`.

##### Returns

The image for the left side of `tab`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab that we are retrieving the image for. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-GetTabRightImage-xyLOGIX-EasyTabs-TitleBarTab-'></a>
### GetTabRightImage(tab) `method`

##### Summary

Gets the image to use for the right side of the `tab`.

##### Returns

The image for the right side of `tab`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab that we are retrieving the image for. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-InitializeTabWell-xyLOGIX-EasyTabs-TitleBarTabs-'></a>
### InitializeTabWell(parent) `method`

##### Summary



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [xyLOGIX.EasyTabs.TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') |  |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-IsOverAddButton-System-Drawing-Point-'></a>
### IsOverAddButton(cursor) `method`

##### Summary

Tests whether the `cursor` is hovering over the add
tab button.

##### Returns

True if the `cursor` is within
[_addButtonArea](#F-xyLOGIX-EasyTabs-TabRendererBase-_addButtonArea 'xyLOGIX.EasyTabs.TabRendererBase._addButtonArea') and is over a
non-transparent pixel of
[_addButtonHoverImage](#F-xyLOGIX-EasyTabs-TabRendererBase-_addButtonHoverImage 'xyLOGIX.EasyTabs.TabRendererBase._addButtonHoverImage'), false
otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cursor | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current location of the cursor. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-IsOverCloseButton-xyLOGIX-EasyTabs-TitleBarTab,System-Drawing-Point-'></a>
### IsOverCloseButton(tab,mousePointerCoords) `method`

##### Summary

Checks to see if the `mousePointerCoords` is over the
[CloseButtonArea](#P-xyLOGIX-EasyTabs-TitleBarTab-CloseButtonArea 'xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea') of the given
`tab`.

##### Returns

True if the `tab`'s
[CloseButtonArea](#P-xyLOGIX-EasyTabs-TitleBarTab-CloseButtonArea 'xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea') contains
`mousePointerCoords`, false otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | The tab whose
[CloseButtonArea](#P-xyLOGIX-EasyTabs-TitleBarTab-CloseButtonArea 'xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea') we are to check
to see if
it contains `mousePointerCoords`. |
| mousePointerCoords | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current position of the mousePointerCoords. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-IsOverNonTransparentArea-System-Drawing-Rectangle,System-Drawing-Bitmap,System-Drawing-Point-'></a>
### IsOverNonTransparentArea(area,image,cursor) `method`

##### Summary

Helper method to detect whether the `cursor` is within the
given `area` and, if it is, whether it is over a
non-transparent pixel in the given `image`.

##### Returns

True if the `cursor` is within the given
`area` and is over a non-transparent pixel in the
`image`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| area | [System.Drawing.Rectangle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Rectangle 'System.Drawing.Rectangle') | Screen area that we should check to see if the
`cursor` is within. |
| image | [System.Drawing.Bitmap](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Bitmap 'System.Drawing.Bitmap') | Image contained within `area` that we should check to see if
the `cursor` is over a non-transparent
pixel. |
| cursor | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current location of the cursor. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-IsOverSizingBox-System-Drawing-Point-'></a>
### IsOverSizingBox(mousePointerCoords) `method`

##### Summary

Determines whether the mouse mousePointerCoords is currently hovering over
element(s) of the window chrome, such as the , ,
or boxes.

##### Returns

`true` if the user is hovering the mouse pointer over
the sizing box elements of the parent form; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mousePointerCoords | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | (Required.) A
[Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') value that gives the current coordinates
of the mouse pointer. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-IsOverTab-xyLOGIX-EasyTabs-TitleBarTab,System-Drawing-Point-'></a>
### IsOverTab(tab,cursor) `method`

##### Summary

Tests whether the `cursor` is hovering over the
given `tab`.

##### Returns

True if the `cursor` is within the
[Area](#P-xyLOGIX-EasyTabs-TitleBarTab-Area 'xyLOGIX.EasyTabs.TitleBarTab.Area') of the
`tab` and
is over a non-transparent
pixel of [TabImage](#P-xyLOGIX-EasyTabs-TitleBarTab-TabImage 'xyLOGIX.EasyTabs.TitleBarTab.TabImage'), false
otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab that we are to see if the cursor is hovering over. |
| cursor | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current location of the cursor. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-NonClientHitTest-System-Windows-Forms-Message,System-Drawing-Point-'></a>
### NonClientHitTest(message,mousePointerCoords) `method`

##### Summary

Attempts to determine whether the user has clicked the left mouse button in the
nonclient area of the form.

##### Returns

If successful, one of the [HT](#T-Win32Interop-Enums-HT 'Win32Interop.Enums.HT')
enumeration values that indicates where the user has clicked the left mouse
button; otherwise, the [HTCAPTION](#F-HTCAPTION 'HTCAPTION') value is returned by default.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.Windows.Forms.Message](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Message 'System.Windows.Forms.Message') | (Required.) A
[Message](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Message 'System.Windows.Forms.Message') value that indicates which
`Windows Message` is currently being processed by the window procedure. |
| mousePointerCoords | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | (Required.) A
[Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') value that gives the current coordinates
of the mouse pointer. |

##### Remarks

Children of this class must provide an implementation for this method.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnAddButtonShownChanged'></a>
### OnAddButtonShownChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-AddButtonShownChanged 'xyLOGIX.EasyTabs.TabRendererBase.AddButtonShownChanged') event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[ShowAddButton](#P-xyLOGIX-EasyTabs-TabRendererBase-ShowAddButton 'xyLOGIX.EasyTabs.TabRendererBase.ShowAddButton') property is
updated.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnForeColorChanged'></a>
### OnForeColorChanged() `method`

##### Summary

Raises the [](#E-xyLOGIX-EasyTabs-TabRendererBase-ForeColorChanged 'xyLOGIX.EasyTabs.TabRendererBase.ForeColorChanged')
event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[ForeColor](#P-xyLOGIX-EasyTabs-TabRendererBase-ForeColor 'xyLOGIX.EasyTabs.TabRendererBase.ForeColor') property is
updated.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnMaxTabWellAreaChanged'></a>
### OnMaxTabWellAreaChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-MaxTabWellAreaChanged 'xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellAreaChanged') event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[MaxTabWellArea](#P-xyLOGIX-EasyTabs-TabRendererBase-MaxTabWellArea 'xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellArea') property is
updated.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnOverlayMouseDown-System-Object,System-Windows-Forms-MouseEventArgs-'></a>
### OnOverlayMouseDown(sender,e) `method`

##### Summary

Initialize the [DragStart](#P-xyLOGIX-EasyTabs-TabRendererBase-DragStart 'xyLOGIX.EasyTabs.TabRendererBase.DragStart')
and [_tabClickOffset](#F-xyLOGIX-EasyTabs-TabRendererBase-_tabClickOffset 'xyLOGIX.EasyTabs.TabRendererBase._tabClickOffset') fields in
case
the user starts dragging a tab.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [System.Windows.Forms.MouseEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.MouseEventArgs 'System.Windows.Forms.MouseEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnOverlayMouseMove-System-Object,System-Windows-Forms-MouseEventArgs-'></a>
### OnOverlayMouseMove(sender,e) `method`

##### Summary

If the user is dragging the mouse, see if they have passed the
[TabRepositionDragDistance](#P-xyLOGIX-EasyTabs-TabRendererBase-TabRepositionDragDistance 'xyLOGIX.EasyTabs.TabRendererBase.TabRepositionDragDistance')
threshold; and, if so, officially begin the tab drag operation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [System.Windows.Forms.MouseEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.MouseEventArgs 'System.Windows.Forms.MouseEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnOverlayMouseUp-System-Object,System-Windows-Forms-MouseEventArgs-'></a>
### OnOverlayMouseUp(sender,e) `method`

##### Summary

End the drag operation by resetting the
[DragStart](#P-xyLOGIX-EasyTabs-TabRendererBase-DragStart 'xyLOGIX.EasyTabs.TabRendererBase.DragStart') and
[_tabClickOffset](#F-xyLOGIX-EasyTabs-TabRendererBase-_tabClickOffset 'xyLOGIX.EasyTabs.TabRendererBase._tabClickOffset') fields and
setting
[IsTabRepositioning](#P-xyLOGIX-EasyTabs-TabRendererBase-IsTabRepositioning 'xyLOGIX.EasyTabs.TabRendererBase.IsTabRepositioning') to false.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [System.Windows.Forms.MouseEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.MouseEventArgs 'System.Windows.Forms.MouseEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnPreviousTabCountChanged'></a>
### OnPreviousTabCountChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-PreviousTabCountChanged 'xyLOGIX.EasyTabs.TabRendererBase.PreviousTabCountChanged')
event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[PreviousTabCount](#P-xyLOGIX-EasyTabs-TabRendererBase-PreviousTabCount 'xyLOGIX.EasyTabs.TabRendererBase.PreviousTabCount') property is
updated.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnRenderingSuspendedChanged'></a>
### OnRenderingSuspendedChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-RenderingSuspendedChanged 'xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspendedChanged')
event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[RenderingSuspended](#P-xyLOGIX-EasyTabs-TabRendererBase-RenderingSuspended 'xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspended') property
is updated.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnTabBackColorChanged'></a>
### OnTabBackColorChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-TabBackColorChanged 'xyLOGIX.EasyTabs.TabRendererBase.TabBackColorChanged')
event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[TabBackColor](#P-xyLOGIX-EasyTabs-TabRendererBase-TabBackColor 'xyLOGIX.EasyTabs.TabRendererBase.TabBackColor') property is
updated.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnTabClickOffsetChanged'></a>
### OnTabClickOffsetChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-TabClickOffsetChanged 'xyLOGIX.EasyTabs.TabRendererBase.TabClickOffsetChanged') event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[TabClickOffset](#P-xyLOGIX-EasyTabs-TabRendererBase-TabClickOffset 'xyLOGIX.EasyTabs.TabRendererBase.TabClickOffset') property is
updated.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnTabContentWidthChanged'></a>
### OnTabContentWidthChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-TabContentWidthChanged 'xyLOGIX.EasyTabs.TabRendererBase.TabContentWidthChanged') event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[TabContentWidth](#P-xyLOGIX-EasyTabs-TabRendererBase-TabContentWidth 'xyLOGIX.EasyTabs.TabRendererBase.TabContentWidth') property has
been updated.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OnTabRepositioningChanged'></a>
### OnTabRepositioningChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-TabRendererBase-TabRepositioningChanged 'xyLOGIX.EasyTabs.TabRendererBase.TabRepositioningChanged')
event.

##### Parameters

This method has no parameters.

##### Remarks

Child classes that override this method must call the base class
before beginning their own logic.

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-OverTab-System-Collections-Generic-IEnumerable{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Point-'></a>
### OverTab(tabs,cursor) `method`

##### Summary

Called from the [_parentWindow](#F-xyLOGIX-EasyTabs-TabRendererBase-_parentWindow 'xyLOGIX.EasyTabs.TabRendererBase._parentWindow')
to
determine which, if any, of the `tabs` the
`cursor` is
over.

##### Returns

The tab within `tabs` that the
`cursor` is over; if none, then null is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tabs | [System.Collections.Generic.IEnumerable{xyLOGIX.EasyTabs.TitleBarTab}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{xyLOGIX.EasyTabs.TitleBarTab}') | The list of tabs that we should check. |
| cursor | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | The relative position of the cursor within the window. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-Render-System-Collections-Generic-IList{xyLOGIX-EasyTabs-TitleBarTab},System-Drawing-Graphics,System-Drawing-Point,System-Drawing-Point,System-Boolean-'></a>
### Render(tabs,graphicsContext,cursor,forceRedraw,offset) `method`

##### Summary

Renders the list of `tabs` to the screen using the
given `graphicsContext`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tabs | [System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{xyLOGIX.EasyTabs.TitleBarTab}') | List of tabs that we are to render. |
| graphicsContext | [System.Drawing.Graphics](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Graphics 'System.Drawing.Graphics') | Graphics context that we should use while
rendering. |
| cursor | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current location of the cursor on the screen. |
| forceRedraw | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Flag indicating whether the redraw should be
forced. |
| offset | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Offset within `graphicsContext` that the
tabs should be rendered. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-Render-System-Drawing-Graphics,xyLOGIX-EasyTabs-TitleBarTab,System-Int32,System-Drawing-Rectangle,System-Drawing-Point,System-Drawing-Image,System-Drawing-Image,System-Drawing-Image-'></a>
### Render(graphicsContext,tab,index,area,cursor,tabLeftImage,tabCenterImage,tabRightImage) `method`

##### Summary

Internal method for rendering an individual `tab` to
the screen.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| graphicsContext | [System.Drawing.Graphics](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Graphics 'System.Drawing.Graphics') | Graphics context to use when rendering the tab. |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Individual tab that we are to render. |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index of the current `tab` in the
collection of currently open tabs. |
| area | [System.Drawing.Rectangle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Rectangle 'System.Drawing.Rectangle') | Area of the screen that the tab should be rendered to. |
| cursor | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current position of the cursor. |
| tabLeftImage | [System.Drawing.Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') | Image to use for the left side of the tab. |
| tabCenterImage | [System.Drawing.Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') | Image to use for the center of the tab. |
| tabRightImage | [System.Drawing.Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') | Image to use for the right side of the tab. |

<a name='M-xyLOGIX-EasyTabs-TabRendererBase-Tabs_CollectionModified-System-Object,xyLOGIX-EasyTabs-ListModificationEventArgs-'></a>
### Tabs_CollectionModified(sender,e) `method`

##### Summary

When items are added to the tabs collection, we need to ensure that the
[_parentWindow](#F-xyLOGIX-EasyTabs-TabRendererBase-_parentWindow 'xyLOGIX.EasyTabs.TabRendererBase._parentWindow')'s minimum width
is set
so that we can display at
least each tab and its close buttons.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | List of tabs in the
[_parentWindow](#F-xyLOGIX-EasyTabs-TabRendererBase-_parentWindow 'xyLOGIX.EasyTabs.TabRendererBase._parentWindow'). |
| e | [xyLOGIX.EasyTabs.ListModificationEventArgs](#T-xyLOGIX-EasyTabs-ListModificationEventArgs 'xyLOGIX.EasyTabs.ListModificationEventArgs') | Arguments associated with the event. |

<a name='T-xyLOGIX-EasyTabs-TitleBarTab'></a>
## TitleBarTab `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Wraps a [Form](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Form 'System.Windows.Forms.Form') instance (
[_content](#F-xyLOGIX-EasyTabs-TitleBarTab-_content 'xyLOGIX.EasyTabs.TitleBarTab._content')), that represents the
content
that should be displayed within a `Tab` instance.

<a name='M-xyLOGIX-EasyTabs-TitleBarTab-#ctor-xyLOGIX-EasyTabs-TitleBarTabs-'></a>
### #ctor(parent) `constructor`

##### Summary

Default constructor that initializes the various properties.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [xyLOGIX.EasyTabs.TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') | Parent window that contains this `Tab`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `parent`, is passed a `null`
value. |

<a name='F-xyLOGIX-EasyTabs-TitleBarTab-_active'></a>
### _active `constants`

##### Summary

Flag indicating whether this `Tab` is active.

<a name='F-xyLOGIX-EasyTabs-TitleBarTab-_content'></a>
### _content `constants`

##### Summary

Content that should be displayed within the `Tab`.

<a name='F-xyLOGIX-EasyTabs-TitleBarTab-_parent'></a>
### _parent `constants`

##### Summary

Parent window that contains this `Tab`.

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-Active'></a>
### Active `property`

##### Summary

Flag indicating whether this `Tab` is active.

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-Area'></a>
### Area `property`

##### Summary

The area in which the `Tab` is rendered in the client window.

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-Caption'></a>
### Caption `property`

##### Summary

The caption that's displayed in the `Tab`'s title (simply uses the
[Text](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Form.Text 'System.Windows.Forms.Form.Text') of
[Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content')).

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-CloseButtonArea'></a>
### CloseButtonArea `property`

##### Summary

The area of the close button for this `Tab` in the client window.

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-Content'></a>
### Content `property`

##### Summary

The content that should be displayed for this `Tab`.

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-Icon'></a>
### Icon `property`

##### Summary

The icon that's displayed in the `Tab`'s title (simply uses the
[Icon](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Form.Icon 'System.Windows.Forms.Form.Icon') of
[Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content')).

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-IsDisposed'></a>
### IsDisposed `property`

##### Summary

Gets a value indicating whether the content of the `Tab` has been
disposed.

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-Parent'></a>
### Parent `property`

##### Summary

Parent window that contains this `Tab`.

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-ShowCloseButton'></a>
### ShowCloseButton `property`

##### Summary

Flag indicating whether we should display the close button for
this `Tab`.

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-TabImage'></a>
### TabImage `property`

##### Summary

Pre-rendered image of the `Tab`'s background.

<a name='P-xyLOGIX-EasyTabs-TitleBarTab-TitleBarTabId'></a>
### TitleBarTabId `property`

##### Summary

Gets a unique identifier that refers to this
[TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') instance.

<a name='M-xyLOGIX-EasyTabs-TitleBarTab-ClearSubscriptions'></a>
### ClearSubscriptions() `method`

##### Summary

Unsubscribes the `Tab` from any event handlers that may have been
attached to its [](#E-xyLOGIX-EasyTabs-TitleBarTab-Closing 'xyLOGIX.EasyTabs.TitleBarTab.Closing') or
[](#E-xyLOGIX-EasyTabs-TitleBarTab-TextChanged 'xyLOGIX.EasyTabs.TitleBarTab.TextChanged') events.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTab-Close'></a>
### Close() `method`

##### Summary

Closes this [TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') by telling its
[Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content') to close.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTab-Content_Closing-System-Object,System-ComponentModel-CancelEventArgs-'></a>
### Content_Closing(sender,e) `method`

##### Summary

Event handler that is invoked when
[Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content')'s
[](#E-System-Windows-Forms-Form-Closing 'System.Windows.Forms.Form.Closing') event is fired, which in
turn fires this class'
[](#E-xyLOGIX-EasyTabs-TitleBarTab-Closing 'xyLOGIX.EasyTabs.TitleBarTab.Closing') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated (
[Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content') in this case). |
| e | [System.ComponentModel.CancelEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.CancelEventArgs 'System.ComponentModel.CancelEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTab-Content_TextChanged-System-Object,System-EventArgs-'></a>
### Content_TextChanged(sender,e) `method`

##### Summary

Event handler that is invoked when
[Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content')'s
[](#E-System-Windows-Forms-Control-TextChanged 'System.Windows.Forms.Control.TextChanged') event is fired, which
in turn fires this class'
[](#E-xyLOGIX-EasyTabs-TitleBarTab-TextChanged 'xyLOGIX.EasyTabs.TitleBarTab.TextChanged') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated (
[Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content') in this case). |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTab-GetImage'></a>
### GetImage() `method`

##### Summary

Called from [TornTabForm](#T-xyLOGIX-EasyTabs-TornTabForm 'xyLOGIX.EasyTabs.TornTabForm') when we need to
generate a
thumbnail for a `Tab` when it is torn out of its parent window.  We simply
call
[CopyFromScreen](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Graphics.CopyFromScreen 'System.Drawing.Graphics.CopyFromScreen(System.Drawing.Point,System.Drawing.Point,System.Drawing.Size)')
to copy the screen contents to a
[Bitmap](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Bitmap 'System.Drawing.Bitmap').

##### Returns

An image of the `Tab`'s contents.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs'></a>
## TitleBarTabCancelEventArgs `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Event arguments class for a cancelable event that occurs on a
collection of [TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab')s.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs-Action'></a>
### Action `property`

##### Summary

Action that is being performed.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs-Tab'></a>
### Tab `property`

##### Summary

The tab that the
[Action](#P-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs-Action 'xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs.Action') is being
performed
on.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs-TabIndex'></a>
### TabIndex `property`

##### Summary

Index of the tab within the collection.

<a name='T-xyLOGIX-EasyTabs-TitleBarTabCancelEventHandler'></a>
## TitleBarTabCancelEventHandler `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Event delegate for
[](#E-xyLOGIX-EasyTabs-TitleBarTabs-TabDeselecting 'xyLOGIX.EasyTabs.TitleBarTabs.TabDeselecting') and
[](#E-xyLOGIX-EasyTabs-TitleBarTabs-SelectedTabIndexChanging 'xyLOGIX.EasyTabs.TitleBarTabs.SelectedTabIndexChanging') that allows
subscribers to
cancel the
event and keep it from proceeding.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:xyLOGIX.EasyTabs.TitleBarTabCancelEventHandler](#T-T-xyLOGIX-EasyTabs-TitleBarTabCancelEventHandler 'T:xyLOGIX.EasyTabs.TitleBarTabCancelEventHandler') | Object for which this event was raised. |

<a name='T-xyLOGIX-EasyTabs-TitleBarTabEventArgs'></a>
## TitleBarTabEventArgs `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Event arguments class for an event that occurs on a collection of
[TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab')s.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabEventArgs-Action'></a>
### Action `property`

##### Summary

Action that is being performed.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabEventArgs-Tab'></a>
### Tab `property`

##### Summary

The tab that the [Action](#P-xyLOGIX-EasyTabs-TitleBarTabEventArgs-Action 'xyLOGIX.EasyTabs.TitleBarTabEventArgs.Action')
is being performed on.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabEventArgs-TabIndex'></a>
### TabIndex `property`

##### Summary

Index of the tab within the collection.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabEventArgs-WasDragging'></a>
### WasDragging `property`

##### Summary

Flag indicating if the user was dragging the tab when the event
occurred.

<a name='T-xyLOGIX-EasyTabs-TitleBarTabEventHandler'></a>
## TitleBarTabEventHandler `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Event delegate for [](#E-xyLOGIX-EasyTabs-TitleBarTabs-SelectedTabIndexChanged 'xyLOGIX.EasyTabs.TitleBarTabs.SelectedTabIndexChanged')
and [](#E-xyLOGIX-EasyTabs-TitleBarTabs-TabDeselected 'xyLOGIX.EasyTabs.TitleBarTabs.TabDeselected').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:xyLOGIX.EasyTabs.TitleBarTabEventHandler](#T-T-xyLOGIX-EasyTabs-TitleBarTabEventHandler 'T:xyLOGIX.EasyTabs.TitleBarTabEventHandler') | Object for which this event was raised. |

<a name='T-xyLOGIX-EasyTabs-TitleBarTabs'></a>
## TitleBarTabs `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Base class that contains the functionality to render tabs within a WinForms
application's title bar area. This  is done through a borderless overlay
window ([_overlay](#F-xyLOGIX-EasyTabs-TitleBarTabs-_overlay 'xyLOGIX.EasyTabs.TitleBarTabs._overlay')) rendered on
top of the
non-client area at the top of this window.  All an implementing class will need
to do is set
the [TabRenderer](#P-xyLOGIX-EasyTabs-TitleBarTabs-TabRenderer 'xyLOGIX.EasyTabs.TitleBarTabs.TabRenderer') property and
begin
adding tabs to [Tabs](#P-xyLOGIX-EasyTabs-TitleBarTabs-Tabs 'xyLOGIX.EasyTabs.TitleBarTabs.Tabs').

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') and
returns a reference to it.

##### Parameters

This constructor has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-#ctor-System-ComponentModel-IContainer-'></a>
### #ctor() `constructor`

##### Summary

Default constructor.

##### Parameters

This constructor has no parameters.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabs-_aeroPeekEnabled'></a>
### _aeroPeekEnabled `constants`

##### Summary

Flag indicating whether each tab has an Aero Peek entry
allowing the user to switch between tabs from the taskbar.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabs-_nonClientAreaHeight'></a>
### _nonClientAreaHeight `constants`

##### Summary

Height of the non-client area at the top of the window.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabs-_previews'></a>
### _previews `constants`

##### Summary

The preview images for each tab used to display each tab when Aero
Peek is activated.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabs-_previousSelectedTab'></a>
### _previousSelectedTab `constants`

##### Summary

When switching between tabs, this keeps track of the tab that was previously
active so that, when it is switched away from, we can generate a fresh
Aero Peek preview image for it.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabs-_previousWindowState'></a>
### _previousWindowState `constants`

##### Summary

Maintains the previous window state so that we can respond properly to
maximize/restore events in
[OnSizeChanged](#M-xyLOGIX-EasyTabs-TitleBarTabs-OnSizeChanged-System-EventArgs- 'xyLOGIX.EasyTabs.TitleBarTabs.OnSizeChanged(System.EventArgs)').

<a name='F-xyLOGIX-EasyTabs-TitleBarTabs-_tabRenderer'></a>
### _tabRenderer `constants`

##### Summary

Class responsible for actually rendering the tabs in
[_overlay](#F-xyLOGIX-EasyTabs-TitleBarTabs-_overlay 'xyLOGIX.EasyTabs.TitleBarTabs._overlay').

<a name='F-xyLOGIX-EasyTabs-TitleBarTabs-_tabs'></a>
### _tabs `constants`

##### Summary

List of tabs to display for this window.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabs-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-AeroPeekEnabled'></a>
### AeroPeekEnabled `property`

##### Summary

Flag indicating whether each tab has an Aero Peek entry
allowing the user to switch between tabs from the taskbar.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-ApplicationContext'></a>
### ApplicationContext `property`

##### Summary

Application context under which this particular window runs.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-CreateNewTabWhenShown'></a>
### CreateNewTabWhenShown `property`

##### Summary

Gets or sets a value that indicates whether a new tab is created when this form
is first shown, by default.

##### Remarks

The default value of this property is `true`.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-ExitOnLastTabClose'></a>
### ExitOnLastTabClose `property`

##### Summary

Flag indicating whether the application itself should exit when the
last tab is closed.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-IsClosing'></a>
### IsClosing `property`

##### Summary

Flag indicating whether we are in the process of closing the window.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-IsCompositionEnabled'></a>
### IsCompositionEnabled `property`

##### Summary

Flag indicating whether composition is enabled on the desktop.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-NonClientAreaHeight'></a>
### NonClientAreaHeight `property`

##### Summary

Height of the "glassed" area of the window's non-client area.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-Overlay'></a>
### Overlay `property`

##### Summary

Borderless window that is rendered over top of the non-client area of
this window.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-SelectedTab'></a>
### SelectedTab `property`

##### Summary

The tab that is currently selected by the user.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-SelectedTabIndex'></a>
### SelectedTabIndex `property`

##### Summary

Gets or sets the index of the tab that is currently selected by the
user.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-ShowTooltips'></a>
### ShowTooltips `property`

##### Summary

Flag indicating whether a tooltip should be shown when hovering over a
tab.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-TabDropArea'></a>
### TabDropArea `property`

##### Summary

Area of the screen in which tabs can be dropped for this window.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-TabRenderer'></a>
### TabRenderer `property`

##### Summary

The renderer to use when drawing the tabs.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-Tabs'></a>
### Tabs `property`

##### Summary

Gets the collection of tabs to display for this window.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabs-Tooltip'></a>
### Tooltip `property`

##### Summary

Tooltip UI element to show when hovering over a tab.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-AddNewTab'></a>
### AddNewTab() `method`

##### Summary

Calls [CreateTab](#M-xyLOGIX-EasyTabs-TitleBarTabs-CreateTab 'xyLOGIX.EasyTabs.TitleBarTabs.CreateTab'), adds the
resulting tab to the [Tabs](#P-xyLOGIX-EasyTabs-TitleBarTabs-Tabs 'xyLOGIX.EasyTabs.TitleBarTabs.Tabs')
collection,
and activates it.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-CloseTab-xyLOGIX-EasyTabs-TitleBarTab-'></a>
### CloseTab(closingTab) `method`

##### Summary

Removes `closingTab` from
[Tabs](#P-xyLOGIX-EasyTabs-TitleBarTabs-Tabs 'xyLOGIX.EasyTabs.TitleBarTabs.Tabs') and selects the next
applicable tab
in the list.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| closingTab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab that is being closed. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-CommonConstruct'></a>
### CommonConstruct() `method`

##### Summary

Called to implement logic that is common to all the constructor(s) of this
object.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-Content_TextChanged-System-Object,System-EventArgs-'></a>
### Content_TextChanged(sender,e) `method`

##### Summary

Event handler that is called when a tab's
[Text](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Form.Text 'System.Windows.Forms.Form.Text') property is changed, which
re-renders the tab text and updates the title of the
Aero Peek preview.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated (the
[Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content') object in this case). |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-CreateTab'></a>
### CreateTab() `method`

##### Summary

Callback that should be implemented by the inheriting class that will create a
new [TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') object when the add button is
clicked.

##### Returns

A newly created tab.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-CreateThumbnailPreview-xyLOGIX-EasyTabs-TitleBarTab-'></a>
### CreateThumbnailPreview(tab) `method`

##### Summary

Creates a new thumbnail for `tab` when the application is
initially enabled for AeroPeek or when it is turned on sometime during
execution.

##### Returns

Thumbnail created for `tab`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab that we are to create the thumbnail for. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed;
otherwise, false. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-ForwardMessage-System-Windows-Forms-Message@-'></a>
### ForwardMessage(m) `method`

##### Summary

Forwards a message received by
[TitleBarTabsOverlay](#T-xyLOGIX-EasyTabs-TitleBarTabsOverlay 'xyLOGIX.EasyTabs.TitleBarTabsOverlay') to the underlying window.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| m | [System.Windows.Forms.Message@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Message@ 'System.Windows.Forms.Message@') | Message received by the overlay. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-HitTest-System-Drawing-Point,System-IntPtr-'></a>
### HitTest(point,windowHandle) `method`

##### Summary

Called when a [WM_NCHITTEST](#F-Win32Interop-Enums-WM-WM_NCHITTEST 'Win32Interop.Enums.WM.WM_NCHITTEST')
message is received to see where in the non-client area the user clicked.

##### Returns

One of the [HT](#T-Win32Interop-Enums-HT 'Win32Interop.Enums.HT') values, depending on
where the user clicked.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| point | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Screen location that we are to test. |
| windowHandle | [System.IntPtr](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IntPtr 'System.IntPtr') | Handle to the window for which we are performing the
test. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnClientSizeChanged-System-EventArgs-'></a>
### OnClientSizeChanged(e) `method`

##### Summary

Callback for the
[](#E-System-Windows-Forms-Control-ClientSizeChanged 'System.Windows.Forms.Control.ClientSizeChanged') event that
resizes the [Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content') form of the
currently
selected
tab when the size of the client area for this window changes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnFormClosing-System-Windows-Forms-FormClosingEventArgs-'></a>
### OnFormClosing(e) `method`

##### Summary

Raises the [](#E-System-Windows-Forms-Form-FormClosing 'System.Windows.Forms.Form.FormClosing')
event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Windows.Forms.FormClosingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.FormClosingEventArgs 'System.Windows.Forms.FormClosingEventArgs') | A [FormClosingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.FormClosingEventArgs 'System.Windows.Forms.FormClosingEventArgs')
that contains the event data. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnLoad-System-EventArgs-'></a>
### OnLoad(e) `method`

##### Summary

Event handler that is invoked when the
[](#E-System-Windows-Forms-Form-Load 'System.Windows.Forms.Form.Load') event is fired.  Instantiates
[_overlay](#F-xyLOGIX-EasyTabs-TitleBarTabs-_overlay 'xyLOGIX.EasyTabs.TitleBarTabs._overlay') and clears out the
window's
caption.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnPaintBackground-System-Windows-Forms-PaintEventArgs-'></a>
### OnPaintBackground(e) `method`

##### Summary

Override of the handler for the paint background event that is left
blank so that code is never executed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Windows.Forms.PaintEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.PaintEventArgs 'System.Windows.Forms.PaintEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnPreviewTabbedThumbnailActivated-System-Object,Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailEventArgs-'></a>
### OnPreviewTabbedThumbnailActivated(sender,e) `method`

##### Summary

Handler method that's called when the user clicks on an Aero Peek preview
thumbnail.  Finds the tab associated with the thumbnail and
focuses on it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailEventArgs](#T-Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailEventArgs 'Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailEventArgs') | Arguments associated with this event. |

##### Remarks

If this method is overriden, implementers must call the base class
before any of their own logic.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnPreviewTabbedThumbnailBitmapRequested-System-Object,Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailBitmapRequestedEventArgs-'></a>
### OnPreviewTabbedThumbnailBitmapRequested(sender,e) `method`

##### Summary

Handler method that's called when Aero Peek needs to display a thumbnail for a
[TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab'); finds the preview bitmap
generated in
[](#E-xyLOGIX-EasyTabs-TitleBarTabs-TabDeselecting 'xyLOGIX.EasyTabs.TitleBarTabs.TabDeselecting') and returns that.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailBitmapRequestedEventArgs](#T-Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailBitmapRequestedEventArgs 'Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailBitmapRequestedEventArgs') | Arguments associated with this event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnPreviewTabbedThumbnailClosed-System-Object,Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailEventArgs-'></a>
### OnPreviewTabbedThumbnailClosed(sender,e) `method`

##### Summary

Handler method that's called when the user clicks the close button in an Aero
Peek preview thumbnail.  Finds the window associated with the thumbnail
and calls [Close](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Form.Close 'System.Windows.Forms.Form.Close') on it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailEventArgs](#T-Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailEventArgs 'Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailEventArgs') | Arguments associated with this event. |

##### Remarks

If this method is overriden, then overriders must call the base class
prior to running their own logic.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnSelectedTabIndexChanged-xyLOGIX-EasyTabs-TitleBarTabEventArgs-'></a>
### OnSelectedTabIndexChanged(e) `method`

##### Summary

Callback for the
[](#E-xyLOGIX-EasyTabs-TitleBarTabs-SelectedTabIndexChanged 'xyLOGIX.EasyTabs.TitleBarTabs.SelectedTabIndexChanged')
event.
Called when a [TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') gains focus.  Sets
the
active window in Aero Peek via a
call to
[SetActiveTab](#M-Microsoft-WindowsAPICodePack-Taskbar-TabbedThumbnailManager-SetActiveTab-System-Windows-Forms-Control- 'Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailManager.SetActiveTab(System.Windows.Forms.Control)')
.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.EasyTabs.TitleBarTabEventArgs](#T-xyLOGIX-EasyTabs-TitleBarTabEventArgs 'xyLOGIX.EasyTabs.TitleBarTabEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnSelectedTabIndexChanging-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs-'></a>
### OnSelectedTabIndexChanging(e) `method`

##### Summary

Callback for the
[](#E-xyLOGIX-EasyTabs-TitleBarTabs-SelectedTabIndexChanging 'xyLOGIX.EasyTabs.TitleBarTabs.SelectedTabIndexChanging')
event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs](#T-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs 'xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnShown-System-EventArgs-'></a>
### OnShown(e) `method`

##### Summary

Raises the [](#E-System-Windows-Forms-Form-Shown 'System.Windows.Forms.Form.Shown') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | A [EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') that contains the event data. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnSizeChanged-System-EventArgs-'></a>
### OnSizeChanged(e) `method`

##### Summary

Overrides the [](#E-System-Windows-Forms-Control-SizeChanged 'System.Windows.Forms.Control.SizeChanged') handler
so that we can detect when the user has maximized or restored the window and
adjust the size
of the non-client area accordingly.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnTabClicked-xyLOGIX-EasyTabs-TitleBarTabEventArgs-'></a>
### OnTabClicked(e) `method`

##### Summary

Callback for the [](#E-xyLOGIX-EasyTabs-TitleBarTabs-TabClicked 'xyLOGIX.EasyTabs.TitleBarTabs.TabClicked')
event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.EasyTabs.TitleBarTabEventArgs](#T-xyLOGIX-EasyTabs-TitleBarTabEventArgs 'xyLOGIX.EasyTabs.TitleBarTabEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnTabDeselected-xyLOGIX-EasyTabs-TitleBarTabEventArgs-'></a>
### OnTabDeselected(e) `method`

##### Summary

Callback for the [](#E-xyLOGIX-EasyTabs-TitleBarTabs-TabDeselected 'xyLOGIX.EasyTabs.TitleBarTabs.TabDeselected')
event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.EasyTabs.TitleBarTabEventArgs](#T-xyLOGIX-EasyTabs-TitleBarTabEventArgs 'xyLOGIX.EasyTabs.TitleBarTabEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnTabDeselecting-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs-'></a>
### OnTabDeselecting(e) `method`

##### Summary

Callback for the [](#E-xyLOGIX-EasyTabs-TitleBarTabs-TabDeselecting 'xyLOGIX.EasyTabs.TitleBarTabs.TabDeselecting')
event.
Called when a [TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') is in the process
of losing
focus.  Grabs an image of
the tab's content to be used when Aero Peek is activated.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs](#T-xyLOGIX-EasyTabs-TitleBarTabCancelEventArgs 'xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-OnTabsCollectionModified-System-Object,xyLOGIX-EasyTabs-ListModificationEventArgs-'></a>
### OnTabsCollectionModified(sender,e) `method`

##### Summary

Callback that is invoked whenever anything is added or removed from
[Tabs](#P-xyLOGIX-EasyTabs-TitleBarTabs-Tabs 'xyLOGIX.EasyTabs.TitleBarTabs.Tabs') so that we can trigger a
redraw of
the tabs.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object for which this event was raised. |
| e | [xyLOGIX.EasyTabs.ListModificationEventArgs](#T-xyLOGIX-EasyTabs-ListModificationEventArgs 'xyLOGIX.EasyTabs.ListModificationEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-RedrawTabs'></a>
### RedrawTabs() `method`

##### Summary

Calls
[Render](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-Render-System-Boolean- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.Render(System.Boolean)') on
[_overlay](#F-xyLOGIX-EasyTabs-TitleBarTabs-_overlay 'xyLOGIX.EasyTabs.TitleBarTabs._overlay') to force a redrawing of
the
tabs.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-ResizeTabContents-xyLOGIX-EasyTabs-TitleBarTab-'></a>
### ResizeTabContents(tab) `method`

##### Summary

Resizes the [Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content') form of the
`tab` to match the size of the client area for this window.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab whose [Content](#P-xyLOGIX-EasyTabs-TitleBarTab-Content 'xyLOGIX.EasyTabs.TitleBarTab.Content') form we should
resize;
if not specified, we default to
[SelectedTab](#P-xyLOGIX-EasyTabs-TitleBarTabs-SelectedTab 'xyLOGIX.EasyTabs.TitleBarTabs.SelectedTab'). |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-SetFrameSize'></a>
### SetFrameSize() `method`

##### Summary

When the window's state (maximized, minimized, or restored) changes, this sets
the size of the non-client area at the top of the window properly so
that the tabs can be displayed.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-SetWindowThemeAttributes-Win32Interop-Enums-WTNCA-'></a>
### SetWindowThemeAttributes(attributes) `method`

##### Summary

Calls
[SetWindowThemeAttribute](#M-Win32Interop-Methods-Uxtheme-SetWindowThemeAttribute-System-IntPtr,Win32Interop-Enums-WINDOWTHEMEATTRIBUTETYPE,Win32Interop-Structs-WTA_OPTIONS@,System-UInt32- 'Win32Interop.Methods.Uxtheme.SetWindowThemeAttribute(System.IntPtr,Win32Interop.Enums.WINDOWTHEMEATTRIBUTETYPE,Win32Interop.Structs.WTA_OPTIONS@,System.UInt32)')
to set various attributes on the window.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| attributes | [Win32Interop.Enums.WTNCA](#T-Win32Interop-Enums-WTNCA 'Win32Interop.Enums.WTNCA') | Attributes to set on the window. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-TitleBarTabs_Closing-System-Object,System-ComponentModel-CancelEventArgs-'></a>
### TitleBarTabs_Closing(sender,e) `method`

##### Summary

Event handler that is called when a tab's
[](#E-xyLOGIX-EasyTabs-TitleBarTab-Closing 'xyLOGIX.EasyTabs.TitleBarTab.Closing') event is fired, which
removes the
tab from [Tabs](#P-xyLOGIX-EasyTabs-TitleBarTabs-Tabs 'xyLOGIX.EasyTabs.TitleBarTabs.Tabs') and
re-renders [_overlay](#F-xyLOGIX-EasyTabs-TitleBarTabs-_overlay 'xyLOGIX.EasyTabs.TitleBarTabs._overlay').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated (the
[TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') in this case). |
| e | [System.ComponentModel.CancelEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.CancelEventArgs 'System.ComponentModel.CancelEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-UpdateTabThumbnail-xyLOGIX-EasyTabs-TitleBarTab-'></a>
### UpdateTabThumbnail(tab) `method`

##### Summary

Generate a new thumbnail image for `tab`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab that we need to generate a thumbnail for. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-UpdateThumbnailPreviewIcon-xyLOGIX-EasyTabs-TitleBarTab,System-Drawing-Icon-'></a>
### UpdateThumbnailPreviewIcon(tab,icon) `method`

##### Summary

When a child tab updates its [Icon](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Form.Icon 'System.Windows.Forms.Form.Icon')
property, it should call this method to update the icon in the AeroPeek
preview.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab whose icon was updated. |
| icon | [System.Drawing.Icon](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Icon 'System.Drawing.Icon') | The new icon to use.  If this is left as null, we use
[Icon](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Form.Icon 'System.Windows.Forms.Form.Icon') on `tab`. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabs-WndProc-System-Windows-Forms-Message@-'></a>
### WndProc(m) `method`

##### Summary

Overrides the message processor for the window so that we can respond
to windows events to render and manipulate the tabs properly.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| m | [System.Windows.Forms.Message@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Message@ 'System.Windows.Forms.Message@') | Message received by the pump. |

<a name='T-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext'></a>
## TitleBarTabsApplicationContext `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Application context to use when starting a
[TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') application via
[Run](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Application.Run 'System.Windows.Forms.Application.Run(System.Windows.Forms.ApplicationContext)')
.  Used to
track open windows so that the entire application doesn't quit when the
first-opened window is closed.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-_openWindows'></a>
### _openWindows `constants`

##### Summary

List of all opened windows.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-OpenWindows'></a>
### OpenWindows `property`

##### Summary

List of all opened windows.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-OnWindowFormClosed-System-Object,System-Windows-Forms-FormClosedEventArgs-'></a>
### OnWindowFormClosed(sender,e) `method`

##### Summary

Handler method that's called when an item in
[_openWindows](#F-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-_openWindows 'xyLOGIX.EasyTabs.TitleBarTabsApplicationContext._openWindows') has its
[](#E-System-Windows-Forms-Form-FormClosed 'System.Windows.Forms.Form.FormClosed') event invoked.  Removes
the window
from [_openWindows](#F-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-_openWindows 'xyLOGIX.EasyTabs.TitleBarTabsApplicationContext._openWindows') and,
if there are no more windows open, calls
[ExitThread](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.ApplicationContext.ExitThread 'System.Windows.Forms.ApplicationContext.ExitThread').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [System.Windows.Forms.FormClosedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.FormClosedEventArgs 'System.Windows.Forms.FormClosedEventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-OpenWindow-xyLOGIX-EasyTabs-TitleBarTabs-'></a>
### OpenWindow(window) `method`

##### Summary

Adds `window` to
[_openWindows](#F-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-_openWindows 'xyLOGIX.EasyTabs.TitleBarTabsApplicationContext._openWindows') and
attaches event handlers to its
[](#E-System-Windows-Forms-Form-FormClosed 'System.Windows.Forms.Form.FormClosed') event to keep track
of it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| window | [xyLOGIX.EasyTabs.TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') | Window that we're opening. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsApplicationContext-Start-xyLOGIX-EasyTabs-TitleBarTabs-'></a>
### Start(initialFormInstance) `method`

##### Summary

Constructor; takes the initial window to display and, if it's not
closing, opens it and shows it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| initialFormInstance | [xyLOGIX.EasyTabs.TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') | Initial window to display. |

<a name='T-xyLOGIX-EasyTabs-TitleBarTabsOverlay'></a>
## TitleBarTabsOverlay `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Borderless overlay window that is moved with and rendered on top of the
non-client area of a  [TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') instance that's responsible
for rendering the actual tab content and responding to click events for those
tabs.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of
[TitleBarTabsOverlay](#T-xyLOGIX-EasyTabs-TitleBarTabsOverlay 'xyLOGIX.EasyTabs.TitleBarTabsOverlay') and returns a reference
to it.

##### Parameters

This constructor has no parameters.

##### Remarks

Blank default constructor to ensure that the overlays are only
initialized through [GetInstance](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-GetInstance-xyLOGIX-EasyTabs-TitleBarTabs- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.GetInstance(xyLOGIX.EasyTabs.TitleBarTabs)').

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-#ctor-xyLOGIX-EasyTabs-TitleBarTabs-'></a>
### #ctor(parentForm) `constructor`

##### Summary

Creates the overlay window and attaches it to
`parentForm`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parentForm | [xyLOGIX.EasyTabs.TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') | Parent form that the overlay should be rendered on top
of. |

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_active'></a>
### _active `constants`

##### Summary

Flag indicating whether the underlying window is active.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_aeroEnabled'></a>
### _aeroEnabled `constants`

##### Summary

Flag indicating whether we should draw the titlebar background (i.e.
we are in a non-Aero environment).

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_doubleClickInterval'></a>
### _doubleClickInterval `constants`

##### Summary

Represents the time interval, in milliseconds, that is considered a
double-click time for the mouse.

##### Remarks

This field is initialized using the [GetDoubleClickTime](#M-Win32Interop-Methods-User32-GetDoubleClickTime 'Win32Interop.Methods.User32.GetDoubleClickTime')
method from the `Win32Interop` package.



The double-click time is the maximum number of milliseconds that can elapse
between a first click and a second click for them to be considered a
double-click.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_dropAreas'></a>
### _dropAreas `constants`

##### Summary

When a tab is torn from the window, this is where we store the areas on all
open windows where tabs can be dropped to combine the tab with that
window.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_firstClick'></a>
### _firstClick `constants`

##### Summary

Value indicating whether this is the first left-mouse button click in a series
of subsequent clicks at the same or similar coordinates.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_hookId'></a>
### _hookId `constants`

##### Summary

Pointer to the low-level mouse hook callback (
[MouseHookCallback](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)')).

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_hookProcInstalled'></a>
### _hookProcInstalled `constants`

##### Summary

Flag indicating whether [_hookproc](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_hookproc 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._hookproc') has been
installed as a hook.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_hookproc'></a>
### _hookproc `constants`

##### Summary

Delegate of [MouseHookCallback](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)'); declared as a member
variable to keep it from being garbage collected.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_isOverAddButton'></a>
### _isOverAddButton `constants`

##### Summary

Value indicating whether the mouse is currently hovering over the 
button.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_isOverCloseButtonForTab'></a>
### _isOverCloseButtonForTab `constants`

##### Summary

Index of the tab, if any, whose close button is being hovered over.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_isOverSizingBox'></a>
### _isOverSizingBox `constants`

##### Summary

Value indicating whether the mouse is currently hovering over the sizing box,
i.e., the area that provides the form's ,
, and buttons.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_lastLeftButtonClickTicks'></a>
### _lastLeftButtonClickTicks `constants`

##### Summary

Measures the UNIX ticks since the last click of the left mouse-button at the
same or similar coordinates.  This determines whether the appropriate Windows
message is to be sent.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_lastTwoClickCoordinates'></a>
### _lastTwoClickCoordinates `constants`

##### Summary

Array of [Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') values that contains the
coordinates of the most recent two clicks of the left mouse button.

##### Remarks

This field is used to determine whether a double-click has indeed
occurred.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_mouseEvents'></a>
### _mouseEvents `constants`

##### Summary

Queue of mouse events reported by [_hookproc](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_hookproc 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._hookproc') that need
to be processed.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_mouseEventsThread'></a>
### _mouseEventsThread `constants`

##### Summary

Consumer thread for processing events in [_mouseEvents](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_mouseEvents 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._mouseEvents').

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm'></a>
### _parentForm `constants`

##### Summary

Parent form for the overlay.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentFormClosing'></a>
### _parentFormClosing `constants`

##### Summary

Value indicating whether the parent [Form](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Form 'System.Windows.Forms.Form')
is in the process of closing.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parents'></a>
### _parents `constants`

##### Summary

All the parent forms and their overlays so that we don't create
duplicate overlays across the application domain.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_tornTab'></a>
### _tornTab `constants`

##### Summary

Tab that has been torn off from this window and is being dragged.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_tornTabForm'></a>
### _tornTabForm `constants`

##### Summary

Thumbnail representation of [_tornTab](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_tornTab 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._tornTab') used when
dragging.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_tornTabLock'></a>
### _tornTabLock `constants`

##### Summary

Semaphore to control access to [_tornTab](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_tornTab 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._tornTab').

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_wasDragging'></a>
### _wasDragging `constants`

##### Summary

Flag used in [WndProc](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-WndProc-System-Windows-Forms-Message@- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.WndProc(System.Windows.Forms.Message@)') and [MouseHookCallback](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)') to
track whether the user was click/dragging when a particular event
occurred.

<a name='F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-showTooltipTimer'></a>
### showTooltipTimer `constants`

##### Summary

A [Timer](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Timers.Timer 'System.Timers.Timer') that measures the time interval within
which, if the  mouse has been hovering over a tab, a
[ToolTip](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.ToolTip 'System.Windows.Forms.ToolTip') is to be shown.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-CreateParams'></a>
### CreateParams `property`

##### Summary

Makes sure that the window is created with an
[WS_EX_LAYERED](#F-Win32Interop-Enums-WS_EX-WS_EX_LAYERED 'Win32Interop.Enums.WS_EX.WS_EX_LAYERED') flag set so that it can be alpha-blended
properly with the content (
[_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm')) underneath the overlay.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-DisplayType'></a>
### DisplayType `property`

##### Summary

Type of theme being used by the OS to render the desktop.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-TabDropArea'></a>
### TabDropArea `property`

##### Summary

Screen area in which tabs can be dragged to and dropped for this
window.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-TitleBarColor'></a>
### TitleBarColor `property`

##### Summary

Primary color for the titlebar background.

<a name='P-xyLOGIX-EasyTabs-TitleBarTabsOverlay-TitleBarGradientColor'></a>
### TitleBarGradientColor `property`

##### Summary

Gradient color for the titlebar background.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-AttachHandlers'></a>
### AttachHandlers() `method`

##### Summary

Attaches the various event handlers to [_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm') so that the
overlay is moved in synchronization to
[_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm').

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-DrawTitleBarBackground-System-Drawing-Graphics-'></a>
### DrawTitleBarBackground(graphics) `method`

##### Summary

Draws the titlebar background behind the tabs if Aero glass is not
enabled.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| graphics | [System.Drawing.Graphics](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Graphics 'System.Drawing.Graphics') | Graphics context with which to draw the background. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-GetInstance-xyLOGIX-EasyTabs-TitleBarTabs-'></a>
### GetInstance(parentForm) `method`

##### Summary

Retrieves or creates the overlay for `parentForm`.

##### Returns

Newly-created or previously existing overlay for
`parentForm`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parentForm | [xyLOGIX.EasyTabs.TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') | Parent form that we are to create the overlay for. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-GetRelativeCursorPosition-System-Drawing-Point-'></a>
### GetRelativeCursorPosition(cursorPosition) `method`

##### Summary

Gets the relative location of the cursor within the overlay.

##### Returns

The relative location of the cursor within the overlay.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cursorPosition | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Cursor position that represents the absolute
position of the cursor on the screen. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-HideTooltip'></a>
### HideTooltip() `method`

##### Summary

Prevents the [ToolTip](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.ToolTip 'System.Windows.Forms.ToolTip') from being shown, or
hides if it is currently showing.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-Initialize'></a>
### Initialize() `method`

##### Summary

Called to run initialization logic for this overlay form.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-InterpretMouseEvents'></a>
### InterpretMouseEvents() `method`

##### Summary

Consumer method that processes mouse events in
[_mouseEvents](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_mouseEvents 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._mouseEvents') that are recorded by
[MouseHookCallback](#M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr- 'xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)').

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr-'></a>
### MouseHookCallback(nCode,wParam,lParam) `method`

##### Summary

Hook callback to process [WM_MOUSEMOVE](#F-Win32Interop-Enums-WM-WM_MOUSEMOVE 'Win32Interop.Enums.WM.WM_MOUSEMOVE') messages to
highlight/un-highlight the close button on each tab.

##### Returns

A zero value if the procedure processes the message; a nonzero value
if the procedure ignores the message.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nCode | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The message being received. |
| wParam | [System.IntPtr](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IntPtr 'System.IntPtr') | Additional information about the message. |
| lParam | [System.IntPtr](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IntPtr 'System.IntPtr') | Additional information about the message. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnParentFormActivated-System-Object,System-EventArgs-'></a>
### OnParentFormActivated(sender,e) `method`

##### Summary

Event handler that is called when [_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm')'s
[](#E-System-Windows-Forms-Form-Activated 'System.Windows.Forms.Form.Activated') event is fired.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnParentFormClosing-System-Object,System-ComponentModel-CancelEventArgs-'></a>
### OnParentFormClosing(sender,e) `method`

##### Summary

Event handler that is called when [_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm') is in the process
of closing.  This uninstalls [_hookproc](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_hookproc 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._hookproc') from the low-level hooks
list and stops the consumer thread that processes those events.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated,
[_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm') in this case. |
| e | [System.ComponentModel.CancelEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.CancelEventArgs 'System.ComponentModel.CancelEventArgs') | Arguments associated with this event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnParentFormDeactivate-System-Object,System-EventArgs-'></a>
### OnParentFormDeactivate(sender,e) `method`

##### Summary

Event handler that is called when [_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm')'s
[](#E-System-Windows-Forms-Form-Deactivate 'System.Windows.Forms.Form.Deactivate') event is fired.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnPosition'></a>
### OnPosition() `method`

##### Summary

Sets the position of the overlay window to match that of
[_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm') so that it moves in tandem with it.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnRefreshParentForm-System-Object,System-EventArgs-'></a>
### OnRefreshParentForm(sender,e) `method`

##### Summary

Event handler that is called when [_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm')'s
[](#E-System-Windows-Forms-Control-SizeChanged 'System.Windows.Forms.Control.SizeChanged'), [](#E-System-Windows-Forms-Control-VisibleChanged 'System.Windows.Forms.Control.VisibleChanged'), or
[](#E-System-Windows-Forms-Control-Move 'System.Windows.Forms.Control.Move') events are fired which re-renders the tabs.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which the event originated. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-OnSystemColorsChangedParentForm-System-Object,System-EventArgs-'></a>
### OnSystemColorsChangedParentForm(sender,e) `method`

##### Summary

Event handler that is called when [_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm')'s
[](#E-System-Windows-Forms-Control-SystemColorsChanged 'System.Windows.Forms.Control.SystemColorsChanged') event is fired which re-renders
the tabs.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which the event originated. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with the event. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-Render-System-Boolean-'></a>
### Render(forceRedraw) `method`

##### Summary

Renders the tabs and then calls [UpdateLayeredWindow](#M-Win32Interop-Methods-User32-UpdateLayeredWindow-System-IntPtr,System-IntPtr,Win32Interop-Structs-POINT@,Win32Interop-Structs-SIZE@,System-IntPtr,Win32Interop-Structs-POINT@,System-UInt32,Win32Interop-Structs-BLENDFUNCTION@,Win32Interop-Enums-ULW- 'Win32Interop.Methods.User32.UpdateLayeredWindow(System.IntPtr,System.IntPtr,Win32Interop.Structs.POINT@,Win32Interop.Structs.SIZE@,System.IntPtr,Win32Interop.Structs.POINT@,System.UInt32,Win32Interop.Structs.BLENDFUNCTION@,Win32Interop.Enums.ULW)') to
blend the tab content with the underlying window (
[_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm')).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| forceRedraw | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Flag indicating whether a full render should be
forced. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-Render-System-Drawing-Point,System-Boolean-'></a>
### Render(cursorPosition,forceRedraw) `method`

##### Summary

Renders the tabs and then calls [UpdateLayeredWindow](#M-Win32Interop-Methods-User32-UpdateLayeredWindow-System-IntPtr,System-IntPtr,Win32Interop-Structs-POINT@,Win32Interop-Structs-SIZE@,System-IntPtr,Win32Interop-Structs-POINT@,System-UInt32,Win32Interop-Structs-BLENDFUNCTION@,Win32Interop-Enums-ULW- 'Win32Interop.Methods.User32.UpdateLayeredWindow(System.IntPtr,System.IntPtr,Win32Interop.Structs.POINT@,Win32Interop.Structs.SIZE@,System.IntPtr,Win32Interop.Structs.POINT@,System.UInt32,Win32Interop.Structs.BLENDFUNCTION@,Win32Interop.Enums.ULW)') to
blend the tab content with the underlying window (
[_parentForm](#F-xyLOGIX-EasyTabs-TitleBarTabsOverlay-_parentForm 'xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm')).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cursorPosition | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current position of the cursor. |
| forceRedraw | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Flag indicating whether a full render should be
forced. |

<a name='M-xyLOGIX-EasyTabs-TitleBarTabsOverlay-WndProc-System-Windows-Forms-Message@-'></a>
### WndProc(m) `method`

##### Summary

Overrides the message pump for the window so that we can respond to
click events on the tabs themselves.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| m | [System.Windows.Forms.Message@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Message@ 'System.Windows.Forms.Message@') | Message received by the pump. |

<a name='T-xyLOGIX-EasyTabs-TornTabForm'></a>
## TornTabForm `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Contains a semi-transparent window with a thumbnail of a tab that has been torn
away from its parent window.  This thumbnail will follow the cursor
around as it's dragged around the screen.

<a name='M-xyLOGIX-EasyTabs-TornTabForm-#ctor-xyLOGIX-EasyTabs-TitleBarTab,xyLOGIX-EasyTabs-TabRendererBase-'></a>
### #ctor(tab,tabRenderer) `constructor`

##### Summary

Constructor; initializes the window and constructs the tab thumbnail
image to use when dragging.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tab | [xyLOGIX.EasyTabs.TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') | Tab that was torn out of its parent window. |
| tabRenderer | [xyLOGIX.EasyTabs.TabRendererBase](#T-xyLOGIX-EasyTabs-TabRendererBase 'xyLOGIX.EasyTabs.TabRendererBase') | Renderer instance to use when drawing the actual tab. |

<a name='F-xyLOGIX-EasyTabs-TornTabForm-_cursorOffset'></a>
### _cursorOffset `constants`

##### Summary

Offset of the cursor within the torn tab representation while
dragging.

<a name='F-xyLOGIX-EasyTabs-TornTabForm-_hookId'></a>
### _hookId `constants`

##### Summary

Pointer to the low-level mouse hook callback (
[MouseHookCallback](#M-xyLOGIX-EasyTabs-TornTabForm-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr- 'xyLOGIX.EasyTabs.TornTabForm.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)')
).

<a name='F-xyLOGIX-EasyTabs-TornTabForm-_hookInstalled'></a>
### _hookInstalled `constants`

##### Summary

Flag indicating whether
[_hookproc](#F-xyLOGIX-EasyTabs-TornTabForm-_hookproc 'xyLOGIX.EasyTabs.TornTabForm._hookproc') is installed.

<a name='F-xyLOGIX-EasyTabs-TornTabForm-_hookproc'></a>
### _hookproc `constants`

##### Summary

Delegate of
[MouseHookCallback](#M-xyLOGIX-EasyTabs-TornTabForm-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr- 'xyLOGIX.EasyTabs.TornTabForm.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)')
; declared as a member variable to keep it from being garbage collected.

<a name='F-xyLOGIX-EasyTabs-TornTabForm-_initialized'></a>
### _initialized `constants`

##### Summary

Flag indicating whether the constructor has finished running.

<a name='F-xyLOGIX-EasyTabs-TornTabForm-_layeredWindow'></a>
### _layeredWindow `constants`

##### Summary

Window that contains the actual thumbnail image data.

<a name='F-xyLOGIX-EasyTabs-TornTabForm-_tabThumbnail'></a>
### _tabThumbnail `constants`

##### Summary

Thumbnail of the tab we are dragging.

<a name='M-xyLOGIX-EasyTabs-TornTabForm-MouseHookCallback-System-Int32,System-IntPtr,System-IntPtr-'></a>
### MouseHookCallback(nCode,wParam,lParam) `method`

##### Summary

Hook callback to process
[WM_MOUSEMOVE](#F-Win32Interop-Enums-WM-WM_MOUSEMOVE 'Win32Interop.Enums.WM.WM_MOUSEMOVE') messages to move the
thumbnail along with the cursor.

##### Returns

A zero value if the procedure processes the message; a nonzero value
if the procedure ignores the message.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nCode | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The message being received. |
| wParam | [System.IntPtr](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IntPtr 'System.IntPtr') | Additional information about the message. |
| lParam | [System.IntPtr](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IntPtr 'System.IntPtr') | Additional information about the message. |

<a name='M-xyLOGIX-EasyTabs-TornTabForm-OnClosing-System-ComponentModel-CancelEventArgs-'></a>
### OnClosing(e) `method`

##### Summary

Event handler that is called when the window is closing; closes
[_layeredWindow](#F-xyLOGIX-EasyTabs-TornTabForm-_layeredWindow 'xyLOGIX.EasyTabs.TornTabForm._layeredWindow') as well.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.ComponentModel.CancelEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.CancelEventArgs 'System.ComponentModel.CancelEventArgs') | Arguments associated with this event. |

<a name='M-xyLOGIX-EasyTabs-TornTabForm-OnLoad-System-EventArgs-'></a>
### OnLoad(e) `method`

##### Summary

Event handler that's called when the window is loaded; shows
[_layeredWindow](#F-xyLOGIX-EasyTabs-TornTabForm-_layeredWindow 'xyLOGIX.EasyTabs.TornTabForm._layeredWindow') and installs the mouse
hook via
[SetWindowsHookEx](#M-Win32Interop-Methods-User32-SetWindowsHookEx-Win32Interop-Enums-WH,Win32Interop-Methods-HOOKPROC,System-IntPtr,System-UInt32- 'Win32Interop.Methods.User32.SetWindowsHookEx(Win32Interop.Enums.WH,Win32Interop.Methods.HOOKPROC,System.IntPtr,System.UInt32)')
.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with this event. |

<a name='M-xyLOGIX-EasyTabs-TornTabForm-SetWindowPosition-System-Drawing-Point-'></a>
### SetWindowPosition(cursorPosition) `method`

##### Summary

Updates the window position to keep up with the cursor's movement.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cursorPosition | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | Current position of the cursor. |

<a name='M-xyLOGIX-EasyTabs-TornTabForm-TornTabForm_Disposed-System-Object,System-EventArgs-'></a>
### TornTabForm_Disposed(sender,e) `method`

##### Summary

Event handler that's called from [Dispose](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IDisposable.Dispose 'System.IDisposable.Dispose');
calls
[UnhookWindowsHookEx](#M-Win32Interop-Methods-User32-UnhookWindowsHookEx-System-IntPtr- 'Win32Interop.Methods.User32.UnhookWindowsHookEx(System.IntPtr)')
to unsubscribe from the mouse
hook.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object from which this event originated. |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | Arguments associated with this event. |

<a name='M-xyLOGIX-EasyTabs-TornTabForm-UpdateLayeredBackground'></a>
### UpdateLayeredBackground() `method`

##### Summary

Calls
[UpdateWindow](#M-xyLOGIX-EasyTabs-LayeredWindow-UpdateWindow-System-Drawing-Bitmap,System-Byte,System-Int32,System-Int32,Win32Interop-Structs-POINT- 'xyLOGIX.EasyTabs.LayeredWindow.UpdateWindow(System.Drawing.Bitmap,System.Byte,System.Int32,System.Int32,Win32Interop.Structs.POINT)')
to update the position of the thumbnail and blend it properly with the
underlying desktop
elements.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-EasyTabs-WindowsSizingBoxes'></a>
## WindowsSizingBoxes `type`

##### Namespace

xyLOGIX.EasyTabs

##### Summary

Controls the rendering of the window chrome elements, such as the
, , and button(s).

<a name='M-xyLOGIX-EasyTabs-WindowsSizingBoxes-#ctor-xyLOGIX-EasyTabs-TitleBarTabs-'></a>
### #ctor(parentWindow) `constructor`

##### Summary

Constructs a new instance of
[WindowsSizingBoxes](#T-xyLOGIX-EasyTabs-WindowsSizingBoxes 'xyLOGIX.EasyTabs.WindowsSizingBoxes') and returns a reference to
it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parentWindow | [xyLOGIX.EasyTabs.TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') | (Required.) Reference to an instance of
[TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') that refers to the parent window
of the overlay form. |

<a name='F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_closeButtonArea'></a>
### _closeButtonArea `constants`

##### Summary

A [Rectangle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Rectangle 'System.Drawing.Rectangle') value that demarcates the area
within which the box is to be rendered.

<a name='F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_closeButtonHighlightColor'></a>
### _closeButtonHighlightColor `constants`

##### Summary

A [Color](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color 'System.Drawing.Color') that is to be used for the highlight
color of the button.

##### Remarks

The highlight color is painted when the use hovers the mouse pointer
over the box or clicks the button.

<a name='F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_maximizeRestoreButtonArea'></a>
### _maximizeRestoreButtonArea `constants`

##### Summary

A [Rectangle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Rectangle 'System.Drawing.Rectangle') value specifying the bounds of the
button.

<a name='F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_minimizeButtonArea'></a>
### _minimizeButtonArea `constants`

##### Summary

A [Rectangle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Rectangle 'System.Drawing.Rectangle') value specifying the bounds of the
button.

<a name='F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_minimizeMaximizeButtonHighlightColor'></a>
### _minimizeMaximizeButtonHighlightColor `constants`

##### Summary

A [Color](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color 'System.Drawing.Color') value that describes the color to be
used when the mouse pointer hovers over, or clicks, the or
button.

<a name='F-xyLOGIX-EasyTabs-WindowsSizingBoxes-_parentWindow'></a>
### _parentWindow `constants`

##### Summary

Reference to an instance of [TitleBarTabs](#T-xyLOGIX-EasyTabs-TitleBarTabs 'xyLOGIX.EasyTabs.TitleBarTabs') that
refers to the parent window of the overlay form.

<a name='P-xyLOGIX-EasyTabs-WindowsSizingBoxes-CloseButtonHighlightColor'></a>
### CloseButtonHighlightColor `property`

##### Summary

Gets or sets the [Color](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color 'System.Drawing.Color') value that is to be used
for the highlight color of the box.

##### Remarks

The highlight color is painted when the use hovers the mouse pointer over the
box or clicks the box.



This property raises the
[](#E-xyLOGIX-EasyTabs-WindowsSizingBoxes-CloseButtonHighlightColorChanged 'xyLOGIX.EasyTabs.WindowsSizingBoxes.CloseButtonHighlightColorChanged')
event when its value is updated.

<a name='P-xyLOGIX-EasyTabs-WindowsSizingBoxes-MinimizeMaximizeButtonHighlightColor'></a>
### MinimizeMaximizeButtonHighlightColor `property`

##### Summary

Gets or sets a [Color](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color 'System.Drawing.Color') value that describes the
color to be used when the mouse pointer hovers over, or clicks, the
or button.

##### Remarks

This property raises the
[](#E-xyLOGIX-EasyTabs-WindowsSizingBoxes-MinimizeMaximizeButtonHighlightColorChanged 'xyLOGIX.EasyTabs.WindowsSizingBoxes.MinimizeMaximizeButtonHighlightColorChanged')
event when its value is updated.

<a name='P-xyLOGIX-EasyTabs-WindowsSizingBoxes-Width'></a>
### Width `property`

##### Summary

Gets the total width, in pixels, of the area containing the ,
, and button(s).

<a name='M-xyLOGIX-EasyTabs-WindowsSizingBoxes-Contains-System-Drawing-Point-'></a>
### Contains(mousePointerCoords) `method`

##### Summary

Determines whether the area of the , , and
button(s) contains the specified
`mousePointerCoords`.

##### Returns

`true` if the area of the ,
, and button(s) contains the specified
`mousePointerCoords`; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mousePointerCoords | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | (Required.) A [Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') that contains the current
mouse pointer coordinates. |

<a name='M-xyLOGIX-EasyTabs-WindowsSizingBoxes-GetMaximizeOrRestoreBoxImage'></a>
### GetMaximizeOrRestoreBoxImage() `method`

##### Summary

Attempts to obtain a suitable [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that is to
be used for rendering either the or the box,
depending on whether the parent window is in the
[Maximized](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.FormWindowState.Maximized 'System.Windows.Forms.FormWindowState.Maximized').

##### Returns

If successful, a reference to an instance of
[Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that can be used for rendering;
otherwise, a `null` reference is returned.

##### Parameters

This method has no parameters.

##### Remarks

If the parent window is set to a `null` reference or
is currently disposed, then this method returns a `null`
reference.

<a name='M-xyLOGIX-EasyTabs-WindowsSizingBoxes-LoadSvg-System-String,System-Int32,System-Int32-'></a>
### LoadSvg(svgXml,width,height) `method`

##### Summary

Attempts to parse the provided `svgXml`, and, if successful,
returns a [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') that has been loaded from it.

##### Returns

If successful, a reference to an instance of
[Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image') describing the loaded image; otherwise, a
`null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| svgXml | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains
fully-formed XML from which an SVG image can be loaded. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) A positive integer specifying the width of the
resulting [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image'). |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) A positive integer specifying the height of
the resulting [Image](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Image 'System.Drawing.Image'). |

<a name='M-xyLOGIX-EasyTabs-WindowsSizingBoxes-NonClientHitTest-System-Drawing-Point-'></a>
### NonClientHitTest(mousePointerCoords) `method`

##### Summary

Determines whether the specified `mousePointerCoords` are
within the bounds of the , , or
button(s) and returns the corresponding hit-test code(s), if
applicable.

##### Returns

One of the [HT](#T-Win32Interop-Enums-HT 'Win32Interop.Enums.HT') enumeration value(s)
that describes which key region of the nonclient area of the parent from
contains the specified `mousePointerCoords`, or the
[HTNOWHERE](#F-Win32Interop-Enums-HT-HTNOWHERE 'Win32Interop.Enums.HT.HTNOWHERE') value if this cannot be
determined.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mousePointerCoords | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | (Required.) A [Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') that contains the current
mouse pointer coordinates. |

<a name='M-xyLOGIX-EasyTabs-WindowsSizingBoxes-OnCloseButtonHighlightColorChanged'></a>
### OnCloseButtonHighlightColorChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-WindowsSizingBoxes-CloseButtonHighlightColorChanged 'xyLOGIX.EasyTabs.WindowsSizingBoxes.CloseButtonHighlightColorChanged')
event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[CloseButtonHighlightColor](#P-xyLOGIX-EasyTabs-WindowsSizingBoxes-CloseButtonHighlightColor 'xyLOGIX.EasyTabs.WindowsSizingBoxes.CloseButtonHighlightColor')
property is updated.

<a name='M-xyLOGIX-EasyTabs-WindowsSizingBoxes-OnMinimizeMaximizeButtonHighlightColorChanged'></a>
### OnMinimizeMaximizeButtonHighlightColorChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-EasyTabs-WindowsSizingBoxes-MinimizeMaximizeButtonHighlightColorChanged 'xyLOGIX.EasyTabs.WindowsSizingBoxes.MinimizeMaximizeButtonHighlightColorChanged')
event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[MinimizeMaximizeButtonHighlightColor](#P-xyLOGIX-EasyTabs-WindowsSizingBoxes-MinimizeMaximizeButtonHighlightColor 'xyLOGIX.EasyTabs.WindowsSizingBoxes.MinimizeMaximizeButtonHighlightColor')
property is updated.

<a name='M-xyLOGIX-EasyTabs-WindowsSizingBoxes-Render-System-Drawing-Graphics,System-Drawing-Point-'></a>
### Render(g,mousePointerCoords) `method`

##### Summary

Call this method to render the , , and
button(s) on the parent form.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| g | [System.Drawing.Graphics](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Graphics 'System.Drawing.Graphics') | (Required.) Reference to an instance of
[Graphics](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Graphics 'System.Drawing.Graphics') that describes the drawing surface. |
| mousePointerCoords | [System.Drawing.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') | (Required.) A [Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point 'System.Drawing.Point') that contains the current
mouse pointer coordinates. |

##### Remarks

This method takes no action if the `g` parameter is
set to a `null` reference, if the
`mousePointerCoords` is set to
[Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Point.Empty 'System.Drawing.Point.Empty'), or if the parent window is in the
process of being closed or disposed.
