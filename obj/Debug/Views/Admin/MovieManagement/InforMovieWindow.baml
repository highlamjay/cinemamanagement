   M S B A M L   `   `   `  ����  cinema-managementD    >cinema_management.Views.Admin.MovieManagement.InforMovieWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   -   5          �Name$
  main��5   	      MovieManagementVM � DataContext# [  5	   	     MaterialDesignBody#���  5
   	   $��Regular"�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . $��arial)�5   	   
������ $	��650��5   	   $
��1000��5   	    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      W� 	 �� 
TargetName$
	 main��6&   
 �� TargetProperty$
 Opacity�5   &    W� From$ 0X�5   &   	 W� To$ 1X�5   &    g� Duration$ 0:0:0.3D�5    &   5#      5$      5%      .��5(      � .+�5)   
   �� ���	#FFF0F3F7 �� CornerRadius$ 10��5*      
�������$��1q�5,      ._�5-      �  � RowDefinitions 5.      �� 5/      $��50 �6$   �� 50      $	��40* �6$   �� 51      $	��60* �6$   .+�54      � $��0��6   .+�55      �� $��0,0,0,1q�6   
���   �._�57      � .+�58      �� $��Chi tiết phim��6(   $��25(�59   (   $��	20,10,0,0q�5:   (   $
��Bold"�5;   (   �� 5<       �� Orientation$ 
Horizontal=�6)   $	��Top=�5=   )   $��Right=�5>   )   $��0��5?   )   .+�5A   "   �� -   5         c� OverflowMode$ AsNeeded=�5C   )   
������ 
���   �
������ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0,10,0,0��5I   )   ��5A   )   �� *	CloseCM+��5B   )   ��  �� ElementName$
 main��.��5J   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowClose=�6>   $��0q�5K   >   5L   #   5M      5N      5P      5R      � 5S      $��1��6   $��0,10,0,0q�5T       5U      �� 5V      �� 5W      .+�5Z      � $��0��6   $��0,24,0,0q�5[       � ColumnDefinitions 5\      �� 5]      $	��65* �6/   �� 5^      $	��45* �6/   .+�5b      �� $��0��6%   $��	25,0,25,0q�5c   %   .+�5d      �� .+�5e   "   �� $��	Tên phim��6(   $��20(�5f   (   $��36��5g   (   �� 5h   "   $��0q�6*     MaterialDesignFilledTextBox#��[ 5i   *   $	��Top=�5j   *    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5l   *   $��22(�5m   *   |�.  ���	#FFF0F3F7
���   �$��50��5q   *   ��5r   *   �� *	movieName+5s      5t      �� 5w      $��1��6%   $��0,0,25,0q�5x   %   .+�5y      �� $��Thể loại��6$   $��20(�5z   $   �� 5|      -   5         ��Name$ Genre��5|   &   |�.  $��25(�5~   &   $��0,0,0,1q�5   &   $��50��5�   &   $��Bottom=�5�   &   5�      5�      � 5�      $��1��6   $��0,10,0,0q�5�       5�      �� 5�      $
��292* �6/   �� 5�      $
��110* �6/   �� 5�      $	��97* �6/   .+�5�      �� $��0��6%   $��
25,10,10,0q�5�   %   .+�5�      �� $��0��6)   .+�5�   "   �� $��
Tác giả��6(   $��20(�5�   (   $��0,0,35,0q�5�   (   $��35��5�   (   �� 5�   "    . $
 Wrap=�5�   *   $��25(�5�   *   ���	#FFF0F3F7$��0q�5�   *   |�.  $��Center=�5�   *   $��40��5�   *   $��0,0,10,0q�5�   *   ��5�   *   �� *movieDirector+5�      5�      �� 5�      $��1��6%   $��	0,10,10,0q�5�   %   .+�5�      �� $��
Quốc gia��6$   $��20(�5�   $   $��35��5�   $   �� 5�      .+�5�   "   �� $��22(�6*   $��40��5�   *   |�.  $��Bottom=�5�   *   ��5�   *   �� *movieCountry+5�      5�      �� 5�      $��2��6%   $��	0,10,25,0q�5�   %   .+�5�      �� $��Thời lượng��6$   $��20(�5�   $   $��40��5�   $   �� 5�      .+�5�   "   �� $��35��6*   $��22(�5�   *   |�.  ��5�   *   �� *movieDuration+.��6I   5�   #   5�      5�      5�      5�      � 5�      $��2��6   .+�5�      �  5�      �� 5�      $	��75* �6/   �� 5�      $	��25* �6/   .+�5�      � $��0��6    5�      �� 5�   "   �� 5�   "   .+�5�      �� $
��Left=�6)   $ 
Horizontal=�5�   )   $��25,0,0,0q�5�   )   $��2��5�   )   $	��773��5�   )   .+�5�   "   �� .+�5�   &   �� $��Mô tả��6,   $��20(�5�   ,   
���   �$��0,10,0,0q�5�   ,   �� 5�   &    ! MaterialDesignOutlinedTextBox#��[ 6.   $	��Top=�5�   .    . $
 Wrap=�5�   .   " �� VerticalScrollBarVisibility$
 Auto=�5�   .   $ �� HorizontalScrollBarVisibility$ Disabled=�5�   .   |�.  $��18(�5�   .   $	��300��5�   .   $	��400��5�   .   
���   ���5�   .   �� *
movieDes+5�   #   �� 5�   "   $��
30,10,0,00q�6-   $	��346��5�   -   .+�5�   &   �� -   5         ��Name$ 
imageframe��5�   ,   $	��300��5�   ,   $	��210��5�   ,   $
��Left=�5�   ,   $��0,30,0,0q�5�   ,   ��5�   ,   �� *ImageSource+5�   #   5�      5�      � 5�      $��1��6    5�      �� 5�   "   �� 5�   "   .+�5     � $��0��6#   .+�5  "   �� $��0,0,25,0q�6-   $��Right=�5  -   .+�5  &   �� $��Năm phát hành��6,   $��20(�5  ,   $��31��5  ,   $��0,10,0,0q�5  ,   � 5	  &   .+�5
  *   �� -   5        $
 Year��5
  2   $��25(�5  2   
������ $	��Top=�5  2   $��48��5  2   $��	0,-15,0,0q�5  2   $��0q�5  2   |�.  $��Bottom=�5  2   ��5  2   �� *	movieYear+5  2   5  '   5  #   5     5     5     5     5     5     5     5     