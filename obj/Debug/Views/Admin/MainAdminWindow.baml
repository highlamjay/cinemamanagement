   M S B A M L   `   `   `  ����  cinema-management3    -cinema_management.Views.Admin.MainAdminWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   -   5        $��mainadminwindow��5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   ���#f2f5f9  MainAdminVM � DataContext# [ 5   	    � Title$ Administrator��5   	   $	��820��5   	   $
��1440��5   	   $��arial)�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    K� ZIndex$	 999��5   	   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
   	   	EventName$	 Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *FirstLoadCM+5      .��5!      �  � RowDefinitions 5"   
   �� 5#      $��20 �6   �� 5$      $��79.65 �6   �� 5%      $��720.35 �6   .+�5)   
   �� ���#132644$��0��5*      .+�5+      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�5,      $��Right=�5-      .+�5/      �� -   5         c� OverflowMode$ AsNeeded=�5/      $��20��50      $��0q�51      
���   �
������ ��55      �� 56       �� 
TargetType" ��6    .�57      ��  �� Property � �� �� Value
 ���� 58   %    �� Triggers 59      P� 5:   "    P� Property �@J�IsMouseOver P� Value . . �5<   &   ��  � ��
 �����5=   -   5>   #   5@      .��5B      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6.   $��15��5C   .   $��20��5D   .   
�������5E   .   5F      �� 5H      -   5        $ AsNeeded=�5H      $��20��5I      
���   �
������ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0,10,0,0��5L      ��5N      �� 5O      " ��6    .�5P      ��  � ��
 ���� 5Q   %    5R      P� 5S   "    �@J�IsMouseOver . . �5U   &   ��  � ��
 �  ��5V   -   5W   #   5Y      .��5[        $ WindowClose=�6.   $��0q�5\   .   
�������$��20��5^   .   $��15��5_   .   $��0,-3,0,0q�5`   .   5a      5b      5c      � 5e   
   $��1��6   $��2��6    � ColumnDefinitions 5f      �� 5g      $
��966* �6#   �� 5h      $	��76* �6#   �� 5i      $
��152* �6#   �� 5j      $
��155* �6#   �� 5k      $	��50* �6#   �� 5l      $	��41* �6#   .+�5p       � -   5          �Name$ 	MainFrame��5p      $	��720��5q      $
��1440��5r        � NavigationUIVisibility$ Hidden=�5s      $ 0��5t      $��0,80,0,0q�5u      $��6��6&    5w        5x      $	 Loaded��6%   .
 5y         60   �� *LoadTKPageCM+   CommandParameter 5z   0   ��  �� ElementName$ 	MainFrame��5{      5}      � 5~      -   5         �Name$ shadow��5�      
������� J� Opacity$	 0.3Q�5�      $y�	Collapsed=�5�      $��6��5�   3   (  "MaterialDesignThemes.Wpf.ColorZone  5�      -   5           Mode$ Inverted=�5�   '   $��16q�5�   '   $��80��5�   '   ���#132644$��6��5�   a   ]� 5�      $��6��6   .+�5�      �� $ 
Horizontal=�6   $��
-260,0,0,0q�5�      ��5�      �� 5�      " ��6     5�      �� 5�   "    �� Binding 6.   �� *	IsChecked+$ SlideButton��  �� Value  True5�   .   ! N� EnterActions! 5�   &   �� 5�   *   .��5�   .   �� .��5�   2   W� " �� TargetProperty$8" 2(UIElement.RenderTransform).(TranslateTransform.X)�6B   # W� From$# 0X�5�   B   	$ W� To$	$ 285X�5�   B   % g� Duration$% 0:0:0.2D�5�   B   5�   /   5�   +   & N� ExitActions& 5�   &   �� 5�   *   .��5�   .   �� .��5�   2   W� $8" 2(UIElement.RenderTransform).(TranslateTransform.X)�6B   $	# 285X�5�   B   $$ 0X�5�   B   $% 0:0:0.2D�5�   B   5�   /   5�   +   5�   #   5�      z�5�      T� 5�      .+�5�      � ���#132644$	��285��5�      $��	-25,0,0,0q�5�      .+�5�      �� ' � 	Resources' 5�       ! MaterialDesignFlatMidBgButton( �� BasedOn��%�   '��       7  '  ]     �� 5�   "   " ��6(   8(   �5�   &   �� 5�   *    � ��
 �����5�   1   5�   #   �� 5�   "   "  6(   �5�   &   �� 5�   *    � ��
 �����5�   1   5�   #   5�      .+�5�      � $��80��6#   .+�5�   "   �� $��Center=�6-   $ 
Horizontal=�5�   -   $��60��5�   -   .+�5�   &   �� $!��/Resources/Icon/iconApp.ico��6,   $��60��5�   ,   $��	10,-5,5,0q�5�   ,   �� 5�   &   $
��Wrap=�60   .	  (MaterialDesignThemes.Wpf.TextBlockAssist) 	  AutoToolTip) . $��Bottom=�5�   0   * �� TextAlignment$* Center=�5�   0   $��
VMN Cinema��5�   0   $��	Helvetica)�5�   0   $
��Bold"�5�   0   ���#e3e9fa$��20(�5�   0   $	��100��5�   0   5�   #   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "     $ 	MovieEdit=�6:   $��30��5�   :   $��30��5�   :   $��10,0,0,0q�5�   :   $��Center=�5�   :   �� 5�   "   -   5        $��0,0,0,5q�5�   )   $��Quản lý phim��5�   )   $��50��5�   )   $��25(�5�   )   $
��Left=�5�   )   
������ 
������ $	��240��5�   )   ��5�   )   �� *LoadQLPPageCM+��5�   )   �� $ 	MainFrame��6\   5�      �� 5�      $ 
Horizontal=�6*   .+�5�   "     $ 	Filmstrip=�6:   $��30��5�   :   $��30��5�   :   $��10,0,0,0q�5�   :   $��Center=�5�   :   �� 5�   "   $��Quản lý suất chiếu��6)   $��50��5�   )   $��25(�5�   )   $	��240��5�   )   $
��Left=�5�   )   
������ 
������ ��5�   )   �� *LoadSuatChieuPageCM+��5�   )   �� $ 	MainFrame��5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "     $
 Food=�6:   $��30��5�   :   $��30��5�   :   $��10,0,0,0q�5�   :   $��Center=�5   :   �� 5  "   $��0,0,0,5q�6)   $��Quản lý sản phẩm��5  )   $��50��5  )   $��25(�5  )   $
��Left=�5  )   
������ 
������ $	��240��5  )   ��5	  )   �� *LoadFoodPageCM+��5
  )   �� $ 	MainFrame��5     �� 5     $ 
Horizontal=�6)   .+�5  "     $ AccountMultiple=�6:   $��30��5  :   $��30��5  :   $��Center=�5  :   $��10,0,0,0q�5  :   �� 5  "   $��0,0,0,5q�6)   $��Quản lý nhân sự��5  )   $��50��5  )   $��25(�5  )   $	��240��5  )   $
��Left=�5  )   
������ 
������ ��5  )   �� *LoadQLNVPageCM+��5  )   �� $ 	MainFrame��5     �� 5     $ 
Horizontal=�6)   .+�5   "     $ AccountGroupOutline=�6:   $��30��5!  :   $��30��5"  :   $��Center=�5#  :   $��10,0,0,0q�5$  :   �� 5%  "   $��0,0,0,5q�6)   $��Quản lý khách hàng��5&  )   $��50��5'  )   $��25(�5(  )   $	��256��5)  )   $
��Left=�5*  )   
������ 
������ ��5-  )   �� *LoadQLKHPageCM+��5.  )   �� $ 	MainFrame��5/     �� 51     $ 
Horizontal=�6)   $��10,0,0,0q�52  )   .+�53  "     $ Finance=�6:   $��Center=�54  :   $��30��55  :   $��30��56  :   �� 57  "   $��Thống kê��6)   $��50��58  )   $��25(�59  )   $	��240��5:  )   $
��Left=�5;  )   
������ 
������ ��5>  )   �� *LoadTKPageCM+��5?  )   �� $ 	MainFrame��5@     �� 5B     $ 
Horizontal=�6)   $��10,0,0,0q�5C  )   .+�5D  "     $ SwapVerticalBold=�6:   $��30��5E  :   $��30��5F  :   $��Center=�5G  :   �� 5H  "   $��0,0,0,5q�6)   $��Lịch sử��5I  )   $��50��5J  )   $��25(�5K  )   $	��240��5L  )   $
��Left=�5M  )   
������ 
������ ��5P  )   �� *
LoadLSPage+��5Q  )   �� $ 	MainFrame��5R     �� 5T     $ 
Horizontal=�6)   $��10,0,0,0q�5U  )   .+�5V  "     $ TicketPercent=�6:   $��30��5W  :   $��30��5X  :   $��Center=�5Y  :   �� 5Z  "   $��0,0,0,5q�6)   $��Voucher��5[  )   $��50��5\  )   $��25(�5]  )   $	��240��5^  )   $
��Left=�5_  )   
������ 
������ ��5b  )   �� *LoadVCPageCM+��5c  )   �� $ 	MainFrame��5d     �� 5f     $ 
Horizontal=�6)   $��10,0,0,0q�5g  )   .+�5h  "     $ AlertCircle=�6:   $��30��5i  :   $��30��5j  :   $��Center=�5k  :   � 5l  "   .+�5m  &   �� $��0,0,0,5q�6-   $��	Sự cố��5n  -   $��50��5o  -   $��25(�5p  -   $	��240��5q  -   $
��Left=�5r  -   
������ 
������ ��5u  -   �� *LoadErrorPage+��5v  -   �� $ 	MainFrame���� 5w  &   
���  ��+ �� CornerRadius$	+ 100��5x  -   $��30��5y  -   $��30��5z  -   $��
-20,-8,0,0q�5{  -   ._�5|  *   �� $��20(�5}  4   $��Center=�5~  4   $��Center=�5  4   
���������5|  4   �� *
ErrorCount+5�  4   5�  '   5�  #   5�     5�     5�     � 5�     $��40,0,0,0q�6   .+�5�     d� -   5        , d�Name$, SlideButton��5�  '    ' #MaterialDesignHamburgerToggleButton#���  5�  '   $	��Top=�5�  '   $��0,20,0,0q�5�  '   
�������5�  '   �� 5�     -	   5        - ��Name$- 	topnotifi��5�  !   
���  ��$	+ 100��5�  !   $��30��5�  !   $��30��5�  !   $��18,10,-11,760q�5�  !   ._�5�     �� -
   5        . ��Name$. count��5�  (   $��20(�5�  (   $��Center=�5�  (   $��Center=�5�  (   
���������5�  (   �� *
ErrorCount+5�  (   5�     5�     �� 5�     $	��Top=�6    $��30(�5�      $��	15,20,0,0q�5�      
���������5�      �� *SelectedFuncName+5�     5�     �� 5�     $ 
Horizontal=�6   $��Right=�5�     $	��Top=�5�     $��0,20,0,0q�5�     .+�5�       $ AccountCircle=�6.   $��Center=�5�  .   $��Right=�5�  .   $��50��5�  .   $��50��5�  .   
�������5�  .   �� 5�     -   5        / ��Name$/ CurrentUserName��5�     $�� ��5�     $��Center=�5�     $��25(�5�     
�������5�     '
  !MaterialDesignThemes.Wpf.PopupBox
  5�     $��Right=�6.   
�������0 
  PlacementMode$0 BottomAndAlignRightEdges=�5�  .   1 
  PopupContent.1 5�     �� $ Vertical=�6%   .+�5�     �� $��Đổi vai trò��6%   ��5�  %   �� *ChangeRoleCM+��5�  %   �� $ mainadminwindow���� 5�     $��Đăng xuất��6%   ��5�  %   �� *	SignoutCM+��5�  %   �� $ mainadminwindow��5�     5�     5�     5�     5�     5�     5�     