   M S B A M L   `   `   `  ����   cinema-management3    -cinema_management.Views.Admin.MainAdminWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  -   $��mainadminwindow��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=����#f2f5f9  MainAdminVM � DataContext# [  � Title$ Administrator��$	��820��$
��1440��$��arial)� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� K� ZIndex$	 999��*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger  	   	EventName$	 Loaded��*  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *FirstLoadCM+.���  � RowDefinitions �� $��20 ��� $��79.65 ��� $��720.35 �.+��� ���#132644$��0��.+���  �� Orientation$ 
Horizontal=�$	��Top=�$��Right=�.+��� -    c� OverflowMode$ AsNeeded=�$��20��$��0q�
���   �
������ ����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ����  �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 �����.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�$��15��$��20��
��������� -   $ AsNeeded=�$��20��
���   �
������ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0,10,0,0������ " ��.���  � ��
 ����  P�  �@J�IsMouseOver . . ���  � ��
 �  ��.��  $ WindowClose=�$��0q�
�������$��20��$��15��$��0,-3,0,0q�� $��1��$��2�� � ColumnDefinitions �� $
��966* ��� $	��76* ��� $
��152* ��� $
��155* ��� $	��50* ��� $	��41* �.+� � -     �Name$ 	MainFrame��$	��720��$
��1440��  � NavigationUIVisibility$ Hidden=�$ 0��$��0,80,0,0q�$��6��   $	 Loaded��.
    �� *LoadTKPageCM+   CommandParameter ��  �� ElementName$ 	MainFrame��� -    �Name$ shadow��
������� J� Opacity$	 0.3Q�$y�	Collapsed=�$��6��(  "MaterialDesignThemes.Wpf.ColorZone  -      Mode$ Inverted=�$��16q�$��80�����#132644$��6��]� $��6��.+��� $ 
Horizontal=�$��
-260,0,0,0q����� " �� ��  �� Binding �� *	IsChecked+$ SlideButton��  �� Value  True! N� EnterActions! �� .���� .��W� " �� TargetProperty$8" 2(UIElement.RenderTransform).(TranslateTransform.X)�# W� From$# 0X�	$ W� To$	$ 285X�% g� Duration$% 0:0:0.2D�& N� ExitActions& �� .���� .��W� $8" 2(UIElement.RenderTransform).(TranslateTransform.X)�$	# 285X�$$ 0X�$% 0:0:0.2D�z�T� .+�� ���#132644$	��285��$��	-25,0,0,0q�.+��� ' � 	Resources'  ! MaterialDesignFlatMidBgButton( �� BasedOn��%i   '��       7  '  +     �� " ��8(   ���  � ��
 ������� "  ���  � ��
 �����.+�� $��80��.+��� $��Center=�$ 
Horizontal=�$��60��.+��� $!��/Resources/Icon/iconApp.ico��$��60��$��	10,-5,5,0q��� $
��Wrap=�.	  (MaterialDesignThemes.Wpf.TextBlockAssist) 	  AutoToolTip) . $��Bottom=�* �� TextAlignment$* Center=�$��
VMN Cinema��$��	Helvetica)�$
��Bold"����#e3e9fa$��20(�$	��100���� $ 
Horizontal=�.+�  $ 	MovieEdit=�$��30��$��30��$��10,0,0,0q�$��Center=��� -   $��0,0,0,5q�$��Quản lý phim��$��50��$��25(�$
��Left=�
������ 
������ $	��240������ *LoadQLPPageCM+���� $ 	MainFrame���� $ 
Horizontal=�.+�  $ 	Filmstrip=�$��30��$��30��$��10,0,0,0q�$��Center=��� $��Quản lý suất chiếu��$��50��$��25(�$	��240��$
��Left=�
������ 
������ ���� *LoadSuatChieuPageCM+���� $ 	MainFrame���� $ 
Horizontal=�.+�  $
 Food=�$��30��$��30��$��10,0,0,0q�$��Center=��� $��0,0,0,5q�$��Quản lý sản phẩm��$��50��$��25(�$
��Left=�
������ 
������ $	��240������ *LoadFoodPageCM+���� $ 	MainFrame���� $ 
Horizontal=�.+�  $ AccountMultiple=�$��30��$��30��$��Center=�$��10,0,0,0q��� $��0,0,0,5q�$��Quản lý nhân sự��$��50��$��25(�$	��240��$
��Left=�
������ 
������ ���� *LoadQLNVPageCM+���� $ 	MainFrame���� $ 
Horizontal=�.+�  $ AccountGroupOutline=�$��30��$��30��$��Center=�$��10,0,0,0q��� $��0,0,0,5q�$��Quản lý khách hàng��$��50��$��25(�$	��256��$
��Left=�
������ 
������ ���� *LoadQLKHPageCM+���� $ 	MainFrame���� $ 
Horizontal=�$��10,0,0,0q�.+�  $ Finance=�$��Center=�$��30��$��30���� $��Thống kê��$��50��$��25(�$	��240��$
��Left=�
������ 
������ ���� *LoadTKPageCM+���� $ 	MainFrame���� $ 
Horizontal=�$��10,0,0,0q�.+�  $ SwapVerticalBold=�$��30��$��30��$��Center=��� $��0,0,0,5q�$��Lịch sử��$��50��$��25(�$	��240��$
��Left=�
������ 
������ ���� *
LoadLSPage+���� $ 	MainFrame���� $ 
Horizontal=�$��10,0,0,0q�.+�  $ TicketPercent=�$��30��$��30��$��Center=��� $��0,0,0,5q�$��Voucher��$��50��$��25(�$	��240��$
��Left=�
������ 
������ ���� *LoadVCPageCM+���� $ 	MainFrame���� $ 
Horizontal=�$��10,0,0,0q�.+�  $ AlertCircle=�$��30��$��30��$��Center=�� .+��� $��0,0,0,5q�$��	Sự cố��$��50��$��25(�$	��240��$
��Left=�
������ 
������ ���� *LoadErrorPage+���� $ 	MainFrame���� 
���  ��+ �� CornerRadius$	+ 100��$��30��$��30��$��
-20,-8,0,0q�._��� $��20(�$��Center=�$��Center=�
����������� *
ErrorCount+� $��40,0,0,0q�.+�d� -   , d�Name$, SlideButton�� ' #MaterialDesignHamburgerToggleButton#���  $	��Top=�$��0,20,0,0q�
��������� -	   - ��Name$- 	topnotifi��
���  ��$	+ 100��$��30��$��30��$��18,10,-11,760q�._��� -
   . ��Name$. count��$��20(�$��Center=�$��Center=�
����������� *
ErrorCount+�� $	��Top=�$��30(�$��	15,20,0,0q�
����������� *SelectedFuncName+�� $ 
Horizontal=�$��Right=�$	��Top=�$��0,20,0,0q�.+�  $ AccountCircle=�$��Center=�$��Right=�$��50��$��50��
��������� -   / ��Name$/ CurrentUserName��$�� ��$��Center=�$��25(�
�������'
  !MaterialDesignThemes.Wpf.PopupBox
  $��Right=�
�������0 
  PlacementMode$0 BottomAndAlignRightEdges=�1 
  PopupContent.1 �� $ Vertical=�.+��� $��Đổi vai trò������ *ChangeRoleCM+���� $ mainadminwindow���� $��Đăng xuất������ *	SignoutCM+���� $ mainadminwindow��